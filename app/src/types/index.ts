export interface Depot {
  deNo: number;
  deIntitule: string;
}

export interface Famille {
  cbMarq: number;
  faCodeFamille: string;
  faIntitule: string;
}

export interface SousFamille {
  cbMarq: number;
  code: string;
  nom: string;
  fCodeFFamille: string;
  dateCreation?: string;
}

export interface Utilisateur {
  id: number;
  username: string;
  fullName: string;
  email: string;
  role: string;
}

export interface Etat {
  id: number;
  nom: string;
  familles: string[];
  utilisateurs: string[];
  depots: number[];
}

export interface InventoryItem {
  id: number;
  codeFamille: string;
  referenceArticle: string;
  designation: string;
  sousFamille: string;
  longueur: number;
  diametre: number;
  depotId: number;
  depotName: string;
  quantite: number;
  dateExpiration: string | null;
  lot: string | null;
  criticalPeriodMonths: number;
}

export interface InventoryDetail {
  id: number;
  sousFamille: string;
  quantite: number;
  dateExpiration: string | null;
  lot: string | null;
  criticalPeriodMonths: number;
}

export interface DepotInventory {
  depotId: number;
  depotName: string;
  items: InventoryDetail[];
}

export interface InventoryGroupView {
  longueur: number;
  diametre: number;
  depots: DepotInventory[];
  total: number;
}

export interface LoginRequest {
  username: string;
  password: string;
}

export interface LoginResponse {
  success: boolean;
  token: string;
  message: string;
  user: Utilisateur | null;
}

export interface DashboardStats {
  demandeDispatching: number;
  bonDispatching: number;
  demandeRetour: number;
  bonRetour: number;
  utilisateurs: number;
  sousFamilles: number;
}
