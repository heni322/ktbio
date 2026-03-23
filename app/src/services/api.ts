import axios from 'axios';
import type {
  Depot, Famille, SousFamille, Utilisateur, Etat,
  InventoryItem, InventoryGroupView, LoginRequest, LoginResponse
} from '@/types';

const API_BASE_URL = import.meta.env.VITE_API_URL || 'https://localhost:51430/api';

const api = axios.create({
  baseURL: API_BASE_URL,
  headers: {
    'Content-Type': 'application/json',
  },
});

api.interceptors.request.use((config) => {
  const token = localStorage.getItem('token');
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

export const depotApi = {
  getAll: () => api.get<Depot[]>('/Depot'),
  getById: (id: number) => api.get<Depot>(`/Depot/${id}`),
  create: (depot: Depot) => api.post<Depot>('/Depot', depot),
  update: (id: number, depot: Depot) => api.put(`/Depot/${id}`, depot),
  delete: (id: number) => api.delete(`/Depot/${id}`),
};

export const familleApi = {
  getAll: () => api.get<Famille[]>('/Famille'),
  getByCode: (code: string) => api.get<Famille>(`/Famille/${code}`),
  create: (famille: Omit<Famille, 'cbMarq'>) => api.post<Famille>('/Famille', famille),
  update: (code: string, famille: Famille) => api.put(`/Famille/${code}`, famille),
  delete: (code: string) => api.delete(`/Famille/${code}`),
};

export const sousFamilleApi = {
  getAll: (familleCode?: string) => api.get<SousFamille[]>('/SousFamille', { params: { familleCode } }),
  getById: (id: number) => api.get<SousFamille>(`/SousFamille/${id}`),
  create: (sf: SousFamille) => api.post<SousFamille>('/SousFamille', sf),
  update: (id: number, sf: SousFamille) => api.put(`/SousFamille/${id}`, sf),
  delete: (id: number) => api.delete(`/SousFamille/${id}`),
};

export const accountApi = {
  login: (credentials: LoginRequest) => api.post<LoginResponse>('/Account/Login', credentials),
  getUsers: () => api.get<Utilisateur[]>('/Account/ListeUtilisateurs'),
  getUser: (id: number) => api.get<Utilisateur>(`/Account/user/${id}`),
  register: (user: Utilisateur) => api.post<Utilisateur>('/Account/Register', user),
};

export const etatApi = {
  getAll: () => api.get<Etat[]>('/Etat'),
  getById: (id: number) => api.get<Etat>(`/Etat/${id}`),
  create: (etat: Omit<Etat, 'id'>) => api.post<Etat>('/Etat', etat),
  update: (id: number, etat: Omit<Etat, 'id'>) => api.put(`/Etat/${id}`, etat),
  delete: (id: number) => api.delete(`/Etat/${id}`),
};

export const inventoryApi = {
  getAll: (params?: { depotId?: number; sousFamille?: string; annee?: string }) =>
    api.get<InventoryItem[]>('/Inventory', { params }),
  filter: (filters: {
    annee?: string;
    sousFamille?: string;
    familles?: string[];
    depots?: number[];
    modeAffichage?: string
  }) => api.post<InventoryGroupView[]>('/Inventory/filter', filters),
  getSousFamilles: () => api.get<string[]>('/Inventory/sousfamilles'),
  getAnnees: () => api.get<number[]>('/Inventory/annees'),
  updateQuantity: (id: number, quantity: number) =>
    api.put(`/Inventory/${id}/quantity/${quantity}`),
  adjustQuantity: (id: number, delta: number) =>
    api.put(`/Inventory/${id}/adjust/${delta}`),
};

export default api;
