import * as signalR from '@microsoft/signalr';

const HUB_URL = import.meta.env.VITE_HUB_URL || 'http://localhost:5000/hubs/chat';

class SignalRService {
  private connection: signalR.HubConnection | null = null;
  private messageHandlers: Array<(user: string, message: string) => void> = [];
  private notificationHandlers: Array<(notification: { title: string; message: string; type: string }) => void> = [];
  private inventoryUpdateHandlers: Array<(data: { depotId: number; productRef: string; newQuantity: number }) => void> = [];

  async connect(userName: string = 'Anonymous') {
    if (this.connection) return;

    this.connection = new signalR.HubConnectionBuilder()
      .withUrl(`${HUB_URL}?userName=${encodeURIComponent(userName)}`)
      .withAutomaticReconnect()
      .build();

    this.connection.on('ReceiveMessage', (user: string, message: string) => {
      this.messageHandlers.forEach(handler => handler(user, message));
    });

    this.connection.on('ReceiveNotification', (notification: { title: string; message: string; type: string }) => {
      this.notificationHandlers.forEach(handler => handler(notification));
    });

    this.connection.on('InventoryUpdated', (data: { depotId: number; productRef: string; newQuantity: number }) => {
      this.inventoryUpdateHandlers.forEach(handler => handler(data));
    });

    this.connection.on('UserConnected', (user: string) => {
      console.log(`User connected: ${user}`);
    });

    this.connection.on('UserDisconnected', (user: string) => {
      console.log(`User disconnected: ${user}`);
    });

    try {
      await this.connection.start();
      console.log('SignalR Connected');
    } catch (err) {
      console.error('SignalR Connection Error:', err);
    }
  }

  async disconnect() {
    if (this.connection) {
      await this.connection.stop();
      this.connection = null;
    }
  }

  async sendMessage(user: string, message: string) {
    if (this.connection) {
      await this.connection.invoke('SendMessage', user, message);
    }
  }

  async sendNotification(title: string, message: string, type: string = 'info') {
    if (this.connection) {
      await this.connection.invoke('SendNotification', title, message, type);
    }
  }

  async notifyInventoryUpdate(depotId: number, productRef: string, newQuantity: number) {
    if (this.connection) {
      await this.connection.invoke('NotifyInventoryUpdate', depotId, productRef, newQuantity);
    }
  }

  onMessage(handler: (user: string, message: string) => void) {
    this.messageHandlers.push(handler);
    return () => {
      this.messageHandlers = this.messageHandlers.filter(h => h !== handler);
    };
  }

  onNotification(handler: (notification: { title: string; message: string; type: string }) => void) {
    this.notificationHandlers.push(handler);
    return () => {
      this.notificationHandlers = this.notificationHandlers.filter(h => h !== handler);
    };
  }

  onInventoryUpdate(handler: (data: { depotId: number; productRef: string; newQuantity: number }) => void) {
    this.inventoryUpdateHandlers.push(handler);
    return () => {
      this.inventoryUpdateHandlers = this.inventoryUpdateHandlers.filter(h => h !== handler);
    };
  }

  getConnectionState() {
    return this.connection?.state;
  }
}

export const signalRService = new SignalRService();
export default signalRService;
