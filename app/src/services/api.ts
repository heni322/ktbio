import axios from 'axios';
import { toast } from 'sonner';
import type {
  Depot, Famille, SousFamille, Utilisateur, Etat,
  InventoryItem, InventoryGroupView, LoginRequest, LoginResponse,
  RefreshResponse, AddUtilisateurRequest, PagedResult
} from '@/types';

const API_BASE_URL = import.meta.env.VITE_API_URL || 'https://localhost:51430/api';

const api = axios.create({
  baseURL: API_BASE_URL,
  headers: {
    'Content-Type': 'application/json',
  },
});

// ─── Request interceptor: attach JWT ────────────────────────────────────────
api.interceptors.request.use((config) => {
  const token = localStorage.getItem('token');
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

export function parseApiError(error: unknown): string {
  if (!axios.isAxiosError(error)) return 'Une erreur inattendue est survenue';

  const data = error.response?.data;
  if (!data) return error.message || 'Erreur réseau';

  if (data.errors && typeof data.errors === 'object') {
    const messages = Object.values(data.errors as Record<string, string[]>)
      .flat()
      .filter(Boolean);
    if (messages.length) return messages.join('\n');
  }

  if (typeof data.message === 'string' && data.message) return data.message;
  if (typeof data.title === 'string' && data.title) return data.title;

  return `Erreur ${error.response?.status ?? ''}`;
}

// ─── Response interceptor ────────────────────────────────────────────────────
api.interceptors.response.use(
  (response) => response,
  async (error) => {
    const originalRequest = error.config;

    if (
      axios.isAxiosError(error) &&
      error.response?.status === 401 &&
      !originalRequest._retry &&
      !originalRequest.url?.includes('/Account/Login') &&
      !originalRequest.url?.includes('/Account/Refresh')
    ) {
      originalRequest._retry = true;
      const refreshToken = localStorage.getItem('refreshToken');
      if (refreshToken) {
        try {
          const res = await api.post<RefreshResponse>('/Account/Refresh', { refreshToken });
          const { token, refreshToken: newRefresh } = res.data;
          localStorage.setItem('token', token);
          localStorage.setItem('refreshToken', newRefresh);
          originalRequest.headers['Authorization'] = `Bearer ${token}`;
          return api(originalRequest);
        } catch {
          localStorage.removeItem('token');
          localStorage.removeItem('refreshToken');
          localStorage.removeItem('user');
          window.location.href = '/login';
          return Promise.reject(error);
        }
      } else {
        localStorage.removeItem('token');
        localStorage.removeItem('user');
        window.location.href = '/login';
        return Promise.reject(error);
      }
    }

    if (axios.isAxiosError(error) && error.response?.status === 401) {
      return Promise.reject(error);
    }

    const message = parseApiError(error);
    message.split('\n').forEach((line) => {
      if (line.trim()) toast.error(line.trim());
    });

    return Promise.reject(error);
  }
);

export const depotApi = {
  getAll: () => api.get<Depot[]>('/Depot'),
  getById: (id: number) => api.get<Depot>(`/Depot/${id}`),
  create: (depot: Depot) => api.post<Depot>('/Depot', depot),
  update: (id: number, depot: Depot) => api.put(`/Depot/${id}`, depot),
  delete: (id: number) => api.delete(`/Depot/${id}`),
};

export const familleApi = {
  getPaged: (page: number, pageSize: number, search?: string) =>
    api.get<PagedResult<Famille>>('/Famille', { params: { page, pageSize, search: search || undefined } }),
  getAll: () =>
    api.get<PagedResult<Famille>>('/Famille', { params: { page: 1, pageSize: 100 } })
      .then(r => ({ ...r, data: r.data.items })),
  getByCode: (code: string) => api.get<Famille>(`/Famille/${code}`),
  create: (famille: Omit<Famille, 'cbMarq'>) => api.post<Famille>('/Famille', famille),
  update: (code: string, famille: Famille) => api.put(`/Famille/${code}`, famille),
  delete: (code: string) => api.delete(`/Famille/${code}`),
};

export const sousFamilleApi = {
  getPaged: (page: number, pageSize: number, search?: string, familleCode?: string) =>
    api.get<PagedResult<SousFamille>>('/SousFamille', {
      params: { page, pageSize, search: search || undefined, familleCode: familleCode || undefined }
    }),
  getAll: (familleCode?: string) =>
    api.get<PagedResult<SousFamille>>('/SousFamille', {
      params: { page: 1, pageSize: 200, familleCode: familleCode || undefined }
    }).then(r => ({ ...r, data: r.data.items })),
  getById: (id: number) => api.get<SousFamille>(`/SousFamille/${id}`),
  create: (sf: SousFamille) => api.post<SousFamille>('/SousFamille', sf),
  update: (id: number, sf: SousFamille) => api.put(`/SousFamille/${id}`, sf),
  delete: (id: number) => api.delete(`/SousFamille/${id}`),
};

export const accountApi = {
  login:               (credentials: LoginRequest)          => api.post<LoginResponse>('/Account/Login', credentials),
  refresh:             (refreshToken: string)               => api.post<RefreshResponse>('/Account/Refresh', { refreshToken }),
  getUsers:            ()                                   => api.get<Utilisateur[]>('/Account/ListeUtilisateurs'),
  getUser:             (id: number)                         => api.get<Utilisateur>(`/Account/user/${id}`),
  register:            (req: AddUtilisateurRequest)          => api.post('/Account/Register', req),
  addUtilisateur:      (req: AddUtilisateurRequest)          => api.post('/Account/AddUtilisateur', req),
  deleteUtilisateur:   (id: number)                         => api.delete(`/Account/DeleteUtilisateur/${id}`),
  // ── New endpoints ──────────────────────────────────────────────────────────
  updateUtilisateur:   (id: number, data: { fullName: string; email: string; role: string }) =>
    api.put(`/Account/UpdateUtilisateur/${id}`, data),
  resetPasswordAdmin:  (id: number, newPassword: string)    =>
    api.post(`/Account/ResetPasswordAdmin/${id}`, { newPassword }),
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
    codeSousFamille?: string;
    familles?: string[];
    depots?: number[];
    modeAffichage?: string;
  }) => api.post<InventoryGroupView[]>('/Inventory/filter', filters),
  getSousFamilles: () => api.get<string[]>('/Inventory/sousfamilles'),
  getAnnees: () => api.get<number[]>('/Inventory/annees'),
  updateQuantity: (id: number, quantity: number) =>
    api.put(`/Inventory/${id}/quantity/${quantity}`),
  adjustQuantity: (id: number, delta: number) =>
    api.put(`/Inventory/${id}/adjust/${delta}`),
};

export default api;
