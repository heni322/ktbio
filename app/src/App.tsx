import { useState, useEffect } from 'react';
import { BrowserRouter, Routes, Route, Navigate, useLocation } from 'react-router-dom';
import { Header } from './sections/Header';
import { Sidebar } from './sections/Sidebar';
import { DashboardStats } from './sections/DashboardStats';
import { EtatsTable } from './sections/EtatsTable';
import { FamillesTable } from './sections/FamillesTable';
import { SousFamillesTable } from './sections/SousFamillesTable';
import { InventoryTable } from './sections/InventoryTable';
import { ArticleStockTable } from './sections/ArticleStockTable';
import { LoginForm } from './sections/LoginForm';
import { AuthProvider, useAuth } from './hooks/useAuth';
import { inventoryApi, depotApi, familleApi, sousFamilleApi, accountApi, etatApi } from './services/api';
import { signalRService } from './services/signalr';
import { Toaster } from '@/components/ui/sonner';
import { toast } from 'sonner';
import { Bell, User, Settings } from 'lucide-react';
import { Button } from '@/components/ui/button';
import { Switch } from '@/components/ui/switch';
import type { Depot, Famille, SousFamille, Utilisateur, Etat, InventoryGroupView } from '@/types';

interface LayoutProps {
  children: React.ReactNode;
  fullWidth?: boolean;
}

function Layout({ children, fullWidth = false }: LayoutProps) {
  const [sidebarCollapsed, setSidebarCollapsed] = useState(false);

  return (
    <div className="min-h-screen bg-gray-100">
      <Header notificationCount={0} />
      <div className="flex">
        <Sidebar
          isCollapsed={sidebarCollapsed}
          onToggle={() => setSidebarCollapsed(!sidebarCollapsed)}
        />
        <main className={`flex-1 ${fullWidth ? 'p-0 overflow-hidden' : 'p-6 overflow-auto'}`}>
          {children}
        </main>
      </div>
    </div>
  );
}

function Dashboard() {
  const [stats, setStats] = useState({
    demandeDispatching: 0,
    bonDispatching: 0,
    demandeRetour: 0,
    bonRetour: 0,
    utilisateurs: 0,
    sousFamilles: 0
  });
  const [etats, setEtats] = useState<Etat[]>([]);
  const [familles, setFamilles] = useState<Famille[]>([]);
  const [utilisateurs, setUtilisateurs] = useState<Utilisateur[]>([]);
  const [depots, setDepots] = useState<Depot[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    async function fetchData() {
      try {
        const [etatsRes, usersRes, sfRes, famRes, depRes] = await Promise.all([
          etatApi.getAll(),
          accountApi.getUsers(),
          sousFamilleApi.getAll(),
          familleApi.getAll(),
          depotApi.getAll()
        ]);
        setEtats(etatsRes.data);
        setFamilles(famRes.data);
        setUtilisateurs(usersRes.data);
        setDepots(depRes.data);
        setStats({
          demandeDispatching: 0,
          bonDispatching: 0,
          demandeRetour: 0,
          bonRetour: 0,
          utilisateurs: usersRes.data.length,
          sousFamilles: sfRes.data.length
        });
      } catch (error) {
        toast.error('Erreur lors du chargement des statistiques');
      } finally {
        setLoading(false);
      }
    }
    fetchData();
  }, []);

  const handleAddEtat = async (etat: Omit<Etat, 'id'>) => {
    try {
      await etatApi.create(etat);
      toast.success('État ajouté avec succès');
      const res = await etatApi.getAll();
      setEtats(res.data);
    } catch (error) {
      toast.error("Erreur lors de l'ajout");
    }
  };

  const handleUpdateEtat = async (id: number, etat: Omit<Etat, 'id'>) => {
    try {
      await etatApi.update(id, etat);
      toast.success('État mis à jour');
      const res = await etatApi.getAll();
      setEtats(res.data);
    } catch (error) {
      toast.error('Erreur lors de la mise à jour');
    }
  };

  const handleDeleteEtat = async (id: number) => {
    try {
      await etatApi.delete(id);
      toast.success('État supprimé');
      const res = await etatApi.getAll();
      setEtats(res.data);
    } catch (error) {
      toast.error('Erreur lors de la suppression');
    }
  };

  if (loading) {
    return (
      <Layout>
        <div className="flex items-center justify-center h-64">
          <div className="animate-spin rounded-full h-8 w-8 border-b-2 border-[#3CBAAE]"></div>
        </div>
      </Layout>
    );
  }

  return (
    <Layout>
      <div className="space-y-6">
        <DashboardStats stats={stats} />
        <EtatsTable
          etats={etats}
          familles={familles}
          utilisateurs={utilisateurs.map(u => ({ id: u.id, fullName: u.fullName }))}
          depots={depots}
          onAdd={handleAddEtat}
          onUpdate={handleUpdateEtat}
          onDelete={handleDeleteEtat}
        />
      </div>
    </Layout>
  );
}

function EtatsPage() {
  const [etats, setEtats] = useState<Etat[]>([]);
  const [familles, setFamilles] = useState<Famille[]>([]);
  const [utilisateurs, setUtilisateurs] = useState<Utilisateur[]>([]);
  const [depots, setDepots] = useState<Depot[]>([]);
  const [loading, setLoading] = useState(true);

  const fetchData = async () => {
    try {
      const [etatsRes, famRes, usersRes, depRes] = await Promise.all([
        etatApi.getAll(),
        familleApi.getAll(),
        accountApi.getUsers(),
        depotApi.getAll()
      ]);
      setEtats(etatsRes.data);
      setFamilles(famRes.data);
      setUtilisateurs(usersRes.data);
      setDepots(depRes.data);
    } catch (error) {
      toast.error('Erreur lors du chargement des données');
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchData();
  }, []);

  const handleAdd = async (etat: Omit<Etat, 'id'>) => {
    try {
      await etatApi.create(etat);
      toast.success('État ajouté avec succès');
      fetchData();
    } catch (error) {
      toast.error("Erreur lors de l'ajout");
    }
  };

  const handleUpdate = async (id: number, etat: Omit<Etat, 'id'>) => {
    try {
      await etatApi.update(id, etat);
      toast.success('État mis à jour');
      fetchData();
    } catch (error) {
      toast.error('Erreur lors de la mise à jour');
    }
  };

  const handleDelete = async (id: number) => {
    try {
      await etatApi.delete(id);
      toast.success('État supprimé');
      fetchData();
    } catch (error) {
      toast.error('Erreur lors de la suppression');
    }
  };

  if (loading) {
    return (
      <Layout>
        <div className="flex items-center justify-center h-64">
          <div className="animate-spin rounded-full h-8 w-8 border-b-2 border-[#3CBAAE]"></div>
        </div>
      </Layout>
    );
  }

  return (
    <Layout>
      <EtatsTable
        etats={etats}
        familles={familles}
        utilisateurs={utilisateurs.map(u => ({ id: u.id, fullName: u.fullName }))}
        depots={depots}
        onAdd={handleAdd}
        onUpdate={handleUpdate}
        onDelete={handleDelete}
      />
    </Layout>
  );
}

function FamillesPage() {
  const handleAdd = async (famille: Omit<Famille, 'cbMarq'>) => {
    try {
      await familleApi.create(famille as Famille);
      toast.success('Famille ajoutée');
    } catch {
      // Error already toasted by the global API interceptor
    }
  };

  const handleUpdate = async (_id: number, famille: Omit<Famille, 'cbMarq'>) => {
    try {
      await familleApi.update(famille.faCodeFamille, famille as Famille);
      toast.success('Famille mise à jour');
    } catch {
      // Error already toasted by the global API interceptor
    }
  };

  const handleDelete = async (code: string) => {
    try {
      await familleApi.delete(code);
      toast.success('Famille supprimée');
    } catch {
      // Error already toasted by the global API interceptor
    }
  };

  return (
    <Layout>
      <FamillesTable
        onAdd={handleAdd}
        onUpdate={handleUpdate}
        onDelete={handleDelete}
      />
    </Layout>
  );
}

function SousFamillesPage() {
  const [familles, setFamilles] = useState<Famille[]>([]);

  useEffect(() => {
    familleApi.getAll()
      .then(r => setFamilles(r.data))
      .catch(() => {});
  }, []);

  const handleAdd = async (sf: Omit<SousFamille, 'cbMarq'>) => {
    try {
      await sousFamilleApi.create(sf as SousFamille);
      toast.success('Sous-famille ajoutée');
    } catch {
      // Error already toasted by the global API interceptor
    }
  };

  const handleUpdate = async (id: number, sf: Omit<SousFamille, 'cbMarq'>) => {
    try {
      await sousFamilleApi.update(id, sf as SousFamille);
      toast.success('Sous-famille mise à jour');
    } catch {
      // Error already toasted by the global API interceptor
    }
  };

  const handleDelete = async (id: number) => {
    try {
      await sousFamilleApi.delete(id);
      toast.success('Sous-famille supprimée');
    } catch {
      // Error already toasted by the global API interceptor
    }
  };

  return (
    <Layout>
      <SousFamillesTable
        familles={familles}
        onAdd={handleAdd}
        onUpdate={handleUpdate}
        onDelete={handleDelete}
      />
    </Layout>
  );
}

function InventoryPage() {
  const location = useLocation();
  const [inventory, setInventory] = useState<InventoryGroupView[]>([]);
  const [depots, setDepots] = useState<Depot[]>([]);
  const [sousFamilles, setSousFamilles] = useState<SousFamille[]>([]);
  const [loading, setLoading] = useState(true);

  const [sousFamilleCode, setSousFamilleCode] = useState('');

  const filterEtat = (location.state as any)?.filterEtat as Etat | undefined;

  const filterKey = JSON.stringify({
    etat: filterEtat
      ? { id: filterEtat.id, familles: filterEtat.familles, depots: filterEtat.depots }
      : null,
    sf: sousFamilleCode,
  });

  useEffect(() => {
    let cancelled = false;

    async function fetchData() {
      setLoading(true);
      try {
        const filter: {
          familles?: string[];
          depots?: number[];
          codeSousFamille?: string;
        } = {};

        if (filterEtat) {
          filter.familles = filterEtat.familles;
          filter.depots   = filterEtat.depots;
        }
        if (sousFamilleCode) {
          filter.codeSousFamille = sousFamilleCode;
        }

        const [invRes, depRes, sfRes] = await Promise.all([
          inventoryApi.filter(filter),
          depotApi.getAll(),
          sousFamilleApi.getAll(),
        ]);

        if (!cancelled) {
          setInventory(invRes.data);
          setDepots(depRes.data);
          setSousFamilles(sfRes.data);
        }
      } catch {
        if (!cancelled) toast.error("Erreur lors du chargement de l'inventaire");
      } finally {
        if (!cancelled) setLoading(false);
      }
    }

    fetchData();
    return () => { cancelled = true; };
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [filterKey]);

  if (loading) {
    return (
      <Layout fullWidth>
        <div className="flex items-center justify-center h-full">
          <div className="animate-spin rounded-full h-12 w-12 border-b-2 border-[#3CBAAE]"></div>
        </div>
      </Layout>
    );
  }

  return (
    <Layout fullWidth>
      <InventoryTable
        inventory={inventory}
        depots={depots}
        allSousFamilles={sousFamilles}
        activeSousFamilleCode={sousFamilleCode}
        onSousFamilleChange={(code) => setSousFamilleCode(code)}
      />
    </Layout>
  );
}

function ArticleStockPage() {
  return (
    <Layout fullWidth>
      <ArticleStockTable />
    </Layout>
  );
}

function DepotsPage() {
  const [depots, setDepots] = useState<Depot[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    async function fetchData() {
      try {
        const res = await depotApi.getAll();
        setDepots(res.data);
      } catch (error) {
        toast.error('Erreur lors du chargement des dépôts');
      } finally {
        setLoading(false);
      }
    }
    fetchData();
  }, []);

  if (loading) {
    return (
      <Layout>
        <div className="flex items-center justify-center h-64">
          <div className="animate-spin rounded-full h-8 w-8 border-b-2 border-[#3CBAAE]"></div>
        </div>
      </Layout>
    );
  }

  return (
    <Layout>
      <div className="bg-white rounded-lg shadow p-6">
        <h2 className="text-xl font-semibold mb-4">Liste des Dépôts</h2>
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
          {depots.map(depot => (
            <div key={depot.deNo} className="border border-gray-200 rounded-lg p-4 hover:shadow-md transition-shadow">
              <h3 className="font-medium text-[#3CBAAE]">{depot.deIntitule}</h3>
              <p className="text-sm text-gray-500">Code: {depot.deNo}</p>
            </div>
          ))}
        </div>
      </div>
    </Layout>
  );
}

// ── Utilisateurs Page ─────────────────────────────────────────────────────────
function UtilisateursPage() {
  const { user: currentUser } = useAuth();
  const [utilisateurs, setUtilisateurs] = useState<Utilisateur[]>([]);
  const [loading, setLoading]           = useState(true);
  const [showForm, setShowForm]         = useState(false);
  const [formLoading, setFormLoading]   = useState(false);
  const [formData, setFormData]         = useState({
    username: '', fullName: '', email: '', password: '', role: 'User'
  });
  const [formError, setFormError] = useState('');

  // ── Edit state ────────────────────────────────────────────────────────────
  const [editingUser, setEditingUser]   = useState<Utilisateur | null>(null);
  const [editFormData, setEditFormData] = useState({ fullName: '', email: '', role: 'User' });
  const [editError, setEditError]       = useState('');
  const [editLoading, setEditLoading]   = useState(false);

  // ── Change-password state ─────────────────────────────────────────────────
  const [changePwdUser, setChangePwdUser] = useState<Utilisateur | null>(null);
  const [pwdData, setPwdData]             = useState({ newPassword: '', confirmPassword: '' });
  const [pwdError, setPwdError]           = useState('');
  const [pwdLoading, setPwdLoading]       = useState(false);

  const isAdmin = currentUser?.role === 'Admin';

  const fetchData = async () => {
    try {
      const res = await accountApi.getUsers();
      setUtilisateurs(res.data);
    } catch {
      toast.error('Erreur lors du chargement des utilisateurs');
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => { fetchData(); }, []);

  const handleAdd = async (e: React.FormEvent) => {
    e.preventDefault();
    setFormError('');
    if (!formData.username || !formData.fullName || !formData.email || !formData.password) {
      setFormError('Tous les champs sont obligatoires.');
      return;
    }
    setFormLoading(true);
    try {
      await accountApi.addUtilisateur(formData);
      toast.success('Utilisateur créé avec succès');
      setShowForm(false);
      setFormData({ username: '', fullName: '', email: '', password: '', role: 'User' });
      fetchData();
    } catch (err: any) {
      const msg = err?.response?.data?.error || 'Erreur lors de la création';
      setFormError(msg);
    } finally {
      setFormLoading(false);
    }
  };

  const handleDelete = async (id: number) => {
    if (!window.confirm('Supprimer cet utilisateur ?')) return;
    try {
      await accountApi.deleteUtilisateur(id);
      toast.success('Utilisateur supprimé');
      fetchData();
    } catch {
      toast.error('Erreur lors de la suppression');
    }
  };

  const openEdit = (u: Utilisateur) => {
    setEditingUser(u);
    setEditFormData({ fullName: u.fullName, email: u.email, role: u.role });
    setEditError('');
  };

  const handleEdit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!editingUser) return;
    setEditError('');
    setEditLoading(true);
    try {
      await accountApi.updateUtilisateur(editingUser.id, editFormData);
      toast.success('Utilisateur modifié avec succès');
      setEditingUser(null);
      fetchData();
    } catch (err: any) {
      const msg = err?.response?.data?.error || 'Erreur lors de la modification';
      setEditError(msg);
    } finally {
      setEditLoading(false);
    }
  };

  const openChangePwd = (u: Utilisateur) => {
    setChangePwdUser(u);
    setPwdData({ newPassword: '', confirmPassword: '' });
    setPwdError('');
  };

  const handleChangePwd = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!changePwdUser) return;
    setPwdError('');
    if (pwdData.newPassword.length < 6) {
      setPwdError('Le mot de passe doit contenir au moins 6 caractères.');
      return;
    }
    if (pwdData.newPassword !== pwdData.confirmPassword) {
      setPwdError('Les mots de passe ne correspondent pas.');
      return;
    }
    setPwdLoading(true);
    try {
      await accountApi.resetPasswordAdmin(changePwdUser.id, pwdData.newPassword);
      toast.success('Mot de passe modifié avec succès');
      setChangePwdUser(null);
    } catch (err: any) {
      const msg = err?.response?.data?.error || 'Erreur lors du changement de mot de passe';
      setPwdError(msg);
    } finally {
      setPwdLoading(false);
    }
  };

  if (loading) {
    return (
      <Layout>
        <div className="flex items-center justify-center h-64">
          <div className="animate-spin rounded-full h-8 w-8 border-b-2 border-[#3CBAAE]"></div>
        </div>
      </Layout>
    );
  }

  return (
    <Layout>
      <div className="space-y-6">
        {/* Header */}
        <div className="flex items-center justify-between">
          <h2 className="text-xl font-semibold text-gray-800">Gestion des Utilisateurs</h2>
          {isAdmin && (
            <Button className="bg-[#3CBAAE] hover:bg-[#35a89d] text-white"
              onClick={() => { setShowForm(!showForm); setFormError(''); }}>
              {showForm ? 'Annuler' : '+ Ajouter un utilisateur'}
            </Button>
          )}
        </div>

        {/* Add form */}
        {showForm && isAdmin && (
          <div className="bg-white rounded-xl shadow border border-gray-100 p-6">
            <h3 className="text-lg font-semibold mb-4 text-gray-700">Nouvel utilisateur</h3>
            {formError && <div className="mb-4 bg-red-50 text-red-600 px-4 py-2 rounded text-sm">{formError}</div>}
            <form onSubmit={handleAdd} className="grid grid-cols-1 sm:grid-cols-2 gap-4">
              <div>
                <label className="block text-sm font-medium text-gray-700 mb-1">Nom d'utilisateur *</label>
                <input type="text" required value={formData.username}
                  onChange={e => setFormData(p => ({ ...p, username: e.target.value }))}
                  className="w-full border border-gray-300 rounded-lg px-3 py-2 text-sm focus:outline-none focus:ring-2 focus:ring-[#3CBAAE]" />
              </div>
              <div>
                <label className="block text-sm font-medium text-gray-700 mb-1">Nom complet *</label>
                <input type="text" required value={formData.fullName}
                  onChange={e => setFormData(p => ({ ...p, fullName: e.target.value }))}
                  className="w-full border border-gray-300 rounded-lg px-3 py-2 text-sm focus:outline-none focus:ring-2 focus:ring-[#3CBAAE]" />
              </div>
              <div>
                <label className="block text-sm font-medium text-gray-700 mb-1">Email *</label>
                <input type="email" required value={formData.email}
                  onChange={e => setFormData(p => ({ ...p, email: e.target.value }))}
                  className="w-full border border-gray-300 rounded-lg px-3 py-2 text-sm focus:outline-none focus:ring-2 focus:ring-[#3CBAAE]" />
              </div>
              <div>
                <label className="block text-sm font-medium text-gray-700 mb-1">Mot de passe *</label>
                <input type="password" required minLength={6} value={formData.password}
                  onChange={e => setFormData(p => ({ ...p, password: e.target.value }))}
                  className="w-full border border-gray-300 rounded-lg px-3 py-2 text-sm focus:outline-none focus:ring-2 focus:ring-[#3CBAAE]" />
              </div>
              <div>
                <label className="block text-sm font-medium text-gray-700 mb-1">Rôle</label>
                <select value={formData.role} onChange={e => setFormData(p => ({ ...p, role: e.target.value }))}
                  className="w-full border border-gray-300 rounded-lg px-3 py-2 text-sm focus:outline-none focus:ring-2 focus:ring-[#3CBAAE]">
                  <option value="User">Utilisateur</option>
                  <option value="Admin">Administrateur</option>
                </select>
              </div>
              <div className="sm:col-span-2 flex justify-end gap-3 pt-2">
                <Button type="button" variant="outline" onClick={() => setShowForm(false)}>Annuler</Button>
                <Button type="submit" className="bg-[#3CBAAE] hover:bg-[#35a89d] text-white" disabled={formLoading}>
                  {formLoading ? 'Création...' : "Créer l'utilisateur"}
                </Button>
              </div>
            </form>
          </div>
        )}

        {/* Edit modal */}
        {editingUser && (
          <div className="fixed inset-0 z-50 flex items-center justify-center bg-black/40">
            <div className="bg-white rounded-xl shadow-xl border border-gray-100 p-6 w-full max-w-md mx-4">
              <h3 className="text-lg font-semibold mb-4 text-gray-700">
                Modifier — <span className="text-[#3CBAAE]">{editingUser.username}</span>
              </h3>
              {editError && <div className="mb-4 bg-red-50 text-red-600 px-4 py-2 rounded text-sm">{editError}</div>}
              <form onSubmit={handleEdit} className="space-y-4">
                <div>
                  <label className="block text-sm font-medium text-gray-700 mb-1">Nom complet *</label>
                  <input type="text" required value={editFormData.fullName}
                    onChange={e => setEditFormData(p => ({ ...p, fullName: e.target.value }))}
                    className="w-full border border-gray-300 rounded-lg px-3 py-2 text-sm focus:outline-none focus:ring-2 focus:ring-[#3CBAAE]" />
                </div>
                <div>
                  <label className="block text-sm font-medium text-gray-700 mb-1">Email *</label>
                  <input type="email" required value={editFormData.email}
                    onChange={e => setEditFormData(p => ({ ...p, email: e.target.value }))}
                    className="w-full border border-gray-300 rounded-lg px-3 py-2 text-sm focus:outline-none focus:ring-2 focus:ring-[#3CBAAE]" />
                </div>
                <div>
                  <label className="block text-sm font-medium text-gray-700 mb-1">Rôle</label>
                  <select value={editFormData.role}
                    onChange={e => setEditFormData(p => ({ ...p, role: e.target.value }))}
                    className="w-full border border-gray-300 rounded-lg px-3 py-2 text-sm focus:outline-none focus:ring-2 focus:ring-[#3CBAAE]">
                    <option value="User">Utilisateur</option>
                    <option value="Admin">Administrateur</option>
                  </select>
                </div>
                <div className="flex justify-end gap-3 pt-2">
                  <Button type="button" variant="outline" onClick={() => setEditingUser(null)}>Annuler</Button>
                  <Button type="submit" className="bg-[#3CBAAE] hover:bg-[#35a89d] text-white" disabled={editLoading}>
                    {editLoading ? 'Enregistrement...' : 'Enregistrer'}
                  </Button>
                </div>
              </form>
            </div>
          </div>
        )}

        {/* Change password modal */}
        {changePwdUser && (
          <div className="fixed inset-0 z-50 flex items-center justify-center bg-black/40">
            <div className="bg-white rounded-xl shadow-xl border border-gray-100 p-6 w-full max-w-md mx-4">
              <h3 className="text-lg font-semibold mb-4 text-gray-700">
                Mot de passe — <span className="text-[#3CBAAE]">{changePwdUser.username}</span>
              </h3>
              {pwdError && <div className="mb-4 bg-red-50 text-red-600 px-4 py-2 rounded text-sm">{pwdError}</div>}
              <form onSubmit={handleChangePwd} className="space-y-4">
                <div>
                  <label className="block text-sm font-medium text-gray-700 mb-1">Nouveau mot de passe *</label>
                  <input type="password" required minLength={6} value={pwdData.newPassword}
                    onChange={e => setPwdData(p => ({ ...p, newPassword: e.target.value }))}
                    className="w-full border border-gray-300 rounded-lg px-3 py-2 text-sm focus:outline-none focus:ring-2 focus:ring-[#3CBAAE]" />
                </div>
                <div>
                  <label className="block text-sm font-medium text-gray-700 mb-1">Confirmer *</label>
                  <input type="password" required value={pwdData.confirmPassword}
                    onChange={e => setPwdData(p => ({ ...p, confirmPassword: e.target.value }))}
                    className="w-full border border-gray-300 rounded-lg px-3 py-2 text-sm focus:outline-none focus:ring-2 focus:ring-[#3CBAAE]" />
                </div>
                <div className="flex justify-end gap-3 pt-2">
                  <Button type="button" variant="outline" onClick={() => setChangePwdUser(null)}>Annuler</Button>
                  <Button type="submit" className="bg-orange-500 hover:bg-orange-600 text-white" disabled={pwdLoading}>
                    {pwdLoading ? 'Modification...' : 'Changer'}
                  </Button>
                </div>
              </form>
            </div>
          </div>
        )}

        {/* Table */}
        <div className="bg-white rounded-lg shadow p-6">
          <div className="overflow-x-auto">
            <table className="w-full">
              <thead className="bg-[#3CBAAE] text-white">
                <tr>
                  <th className="px-4 py-3 text-left text-sm">Nom complet</th>
                  <th className="px-4 py-3 text-left text-sm">Identifiant</th>
                  <th className="px-4 py-3 text-left text-sm">Email</th>
                  <th className="px-4 py-3 text-left text-sm">Rôle</th>
                  {isAdmin && <th className="px-4 py-3 text-left text-sm">Actions</th>}
                </tr>
              </thead>
              <tbody>
                {utilisateurs.map((u, idx) => (
                  <tr key={u.id} className={idx % 2 === 0 ? 'bg-white' : 'bg-gray-50'}>
                    <td className="px-4 py-3 text-sm">{u.fullName}</td>
                    <td className="px-4 py-3 text-sm font-mono text-gray-600">@{u.username}</td>
                    <td className="px-4 py-3 text-sm">{u.email}</td>
                    <td className="px-4 py-3">
                      <span className={`px-2 py-1 rounded text-xs font-medium ${
                        u.role === 'Admin' ? 'bg-purple-100 text-purple-700' : 'bg-blue-100 text-blue-700'
                      }`}>
                        {u.role === 'Admin' ? 'Administrateur' : 'Utilisateur'}
                      </span>
                    </td>
                    {isAdmin && (
                      <td className="px-4 py-3">
                        <div className="flex items-center gap-2 flex-wrap">
                          <button onClick={() => openEdit(u)}
                            className="text-[#3CBAAE] hover:text-[#35a89d] text-xs font-medium border border-[#3CBAAE]/30 px-2 py-1 rounded hover:bg-[#3CBAAE]/5 transition-colors">
                            Modifier
                          </button>
                          <button onClick={() => openChangePwd(u)}
                            className="text-orange-500 hover:text-orange-700 text-xs font-medium border border-orange-200 px-2 py-1 rounded hover:bg-orange-50 transition-colors">
                            Mot de passe
                          </button>
                          {u.id !== currentUser?.id && (
                            <button onClick={() => handleDelete(u.id)}
                              className="text-red-500 hover:text-red-700 text-xs font-medium border border-red-200 px-2 py-1 rounded hover:bg-red-50 transition-colors">
                              Supprimer
                            </button>
                          )}
                        </div>
                      </td>
                    )}
                  </tr>
                ))}
              </tbody>
            </table>
            {utilisateurs.length === 0 && (
              <p className="text-center text-gray-400 py-8">Aucun utilisateur trouvé.</p>
            )}
          </div>
        </div>
      </div>
    </Layout>
  );
}

function ProfilePage() {
  const { user } = useAuth();
  return (
    <Layout>
      <div className="max-w-4xl mx-auto space-y-6">
        <div className="bg-white rounded-2xl shadow-xl overflow-hidden border border-gray-100 flex flex-col md:flex-row">
          <div className="md:w-1/3 bg-gradient-to-br from-[#3CBAAE] to-[#2d8d84] p-8 flex flex-col items-center justify-center text-white">
            <div className="w-32 h-32 bg-white/20 backdrop-blur-md rounded-full flex items-center justify-center mb-4 border-4 border-white/30 shadow-2xl">
              <User className="h-16 w-16 text-white" />
            </div>
            <h2 className="text-2xl font-bold text-center">{user?.fullName}</h2>
            <p className="text-[#e2f5f3] text-sm font-medium mt-1 px-3 py-1 bg-white/10 rounded-full backdrop-blur-sm">{user?.role}</p>
          </div>
          <div className="md:w-2/3 p-8">
            <div className="flex justify-between items-start mb-6">
              <h3 className="text-xl font-bold text-gray-800">Détails du compte</h3>
              <Button size="sm" variant="outline" className="border-[#3CBAAE] text-[#3CBAAE] hover:bg-[#3CBAAE]/5">
                Modifier le profil
              </Button>
            </div>
            <div className="grid grid-cols-1 sm:grid-cols-2 gap-6">
              <div className="space-y-1">
                <p className="text-xs font-bold text-gray-400 uppercase tracking-wider">Nom complet</p>
                <p className="text-gray-700 font-medium">{user?.fullName}</p>
              </div>
              <div className="space-y-1">
                <p className="text-xs font-bold text-gray-400 uppercase tracking-wider">Identifiant</p>
                <p className="text-gray-700 font-medium">@{user?.username}</p>
              </div>
              <div className="space-y-1">
                <p className="text-xs font-bold text-gray-400 uppercase tracking-wider">Adresse email</p>
                <p className="text-gray-700 font-medium">{user?.email}</p>
              </div>
              <div className="space-y-1">
                <p className="text-xs font-bold text-gray-400 uppercase tracking-wider">Rôle système</p>
                <span className="inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium bg-[#3CBAAE]/10 text-[#3CBAAE]">{user?.role}</span>
              </div>
            </div>
            <div className="mt-8 pt-8 border-t border-gray-100">
              <h4 className="text-sm font-bold text-gray-800 mb-4">Statistiques d'activité</h4>
              <div className="grid grid-cols-3 gap-4 text-center">
                <div className="p-3 bg-gray-50 rounded-xl">
                  <p className="text-lg font-bold text-[#3CBAAE]">14</p>
                  <p className="text-[10px] text-gray-500 uppercase">Actions</p>
                </div>
                <div className="p-3 bg-gray-50 rounded-xl">
                  <p className="text-lg font-bold text-[#3CBAAE]">2</p>
                  <p className="text-[10px] text-gray-500 uppercase">Rapports</p>
                </div>
                <div className="p-3 bg-gray-50 rounded-xl">
                  <p className="text-lg font-bold text-[#3CBAAE]">Active</p>
                  <p className="text-[10px] text-gray-500 uppercase">Session</p>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </Layout>
  );
}

function ParametresPage() {
  const [darkMode, setDarkMode] = useState(false);
  const [notifications, setNotifications] = useState(true);

  const handleResetPassword = () => {
    toast.success("Lien de réinitialisation envoyé", {
      description: "Un email a été envoyé à votre adresse pour changer votre mot de passe."
    });
  };

  return (
    <Layout>
      <div className="max-w-4xl mx-auto space-y-6">
        <h2 className="text-2xl font-bold text-gray-800">Paramètres</h2>
        <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
          <div className="md:col-span-1 space-y-4">
            <div className="bg-white rounded-xl shadow-sm border border-gray-100 overflow-hidden">
              <button className="w-full px-4 py-3 text-left flex items-center gap-3 bg-[#3CBAAE]/5 text-[#3CBAAE] border-l-4 border-[#3CBAAE]">
                <User className="h-4 w-4" /><span className="font-medium text-sm">Général</span>
              </button>
              <button className="w-full px-4 py-3 text-left flex items-center gap-3 text-gray-600 hover:bg-gray-50 transition-colors">
                <Bell className="h-4 w-4" /><span className="font-medium text-sm">Notifications</span>
              </button>
              <button className="w-full px-4 py-3 text-left flex items-center gap-3 text-gray-600 hover:bg-gray-50 transition-colors">
                <Settings className="h-4 w-4" /><span className="font-medium text-sm">Système</span>
              </button>
            </div>
          </div>
          <div className="md:col-span-2 space-y-6">
            <div className="bg-white rounded-xl shadow-sm border border-gray-100 p-6 space-y-6">
              <div>
                <h3 className="text-lg font-bold text-gray-800 mb-4">Informations Système</h3>
                <div className="space-y-4">
                  <div className="flex items-center justify-between py-3 border-b border-gray-50">
                    <div>
                      <p className="font-medium text-sm text-gray-700">Mode Sombre</p>
                      <p className="text-xs text-gray-400">Activer l'interface sombre (Bientôt)</p>
                    </div>
                    <Switch checked={darkMode} onCheckedChange={setDarkMode} />
                  </div>
                  <div className="flex items-center justify-between py-3 border-b border-gray-50">
                    <div>
                      <p className="font-medium text-sm text-gray-700">Langue du système</p>
                      <p className="text-xs text-gray-400">Français par défaut</p>
                    </div>
                    <span className="text-sm font-medium text-[#3CBAAE]">Français</span>
                  </div>
                  <div className="flex items-center justify-between py-3">
                    <div>
                      <p className="font-medium text-sm text-gray-700">Notifications Push</p>
                      <p className="text-xs text-gray-400">Alerte de stock en temps réel</p>
                    </div>
                    <Switch checked={notifications} onCheckedChange={setNotifications} />
                  </div>
                </div>
              </div>
              <div className="pt-4">
                <h3 className="text-lg font-bold mb-4 text-red-600">Sécurité</h3>
                <Button variant="outline" className="text-red-600 border-red-200 hover:bg-red-50 hover:text-red-700" onClick={handleResetPassword}>
                  Réinitialiser le mot de passe
                </Button>
              </div>
            </div>
            <div className="bg-gradient-to-r from-[#3CBAAE] to-[#2d8d84] rounded-xl p-6 text-white shadow-lg">
              <h4 className="font-bold mb-1">Version Pro active</h4>
              <p className="text-xs opacity-90 mb-4">Votre licence est valide jusqu'au 31 Décembre 2025.</p>
              <div className="h-1.5 bg-white/20 rounded-full overflow-hidden">
                <div className="h-full bg-white w-3/4 rounded-full"></div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </Layout>
  );
}

function ProtectedRoute({ children }: { children: React.ReactNode }) {
  const { isAuthenticated, isLoading } = useAuth();
  if (isLoading) {
    return (
      <div className="min-h-screen flex items-center justify-center">
        <div className="animate-spin rounded-full h-12 w-12 border-b-2 border-[#3CBAAE]"></div>
      </div>
    );
  }
  if (!isAuthenticated) return <Navigate to="/login" replace />;
  return <>{children}</>;
}

function AppRoutes() {
  const { isAuthenticated, user } = useAuth();

  useEffect(() => {
    if (isAuthenticated && user) {
      signalRService.connect(user.fullName || 'Anonymous')
        .then(() => toast.success('Connecté au serveur en temps réel'))
        .catch(() => toast.error('Impossible de se connecter au serveur en temps réel'));

      signalRService.onNotification((notification) => {
        toast[notification.type as 'success' | 'error' | 'info' | 'warning'](notification.title, {
          description: notification.message,
        });
      });

      return () => { signalRService.disconnect(); };
    }
  }, [isAuthenticated, user]);

  return (
    <Routes>
      <Route path="/login" element={isAuthenticated ? <Navigate to="/" replace /> : <LoginForm />} />
      <Route path="/" element={<ProtectedRoute><Dashboard /></ProtectedRoute>} />
      <Route path="/familles" element={<ProtectedRoute><FamillesPage /></ProtectedRoute>} />
      <Route path="/inventory" element={<ProtectedRoute><InventoryPage /></ProtectedRoute>} />
      <Route path="/article-stock" element={<ProtectedRoute><ArticleStockPage /></ProtectedRoute>} />
      <Route path="/sous-familles" element={<ProtectedRoute><SousFamillesPage /></ProtectedRoute>} />
      <Route path="/etats" element={<ProtectedRoute><EtatsPage /></ProtectedRoute>} />
      <Route path="/depots" element={<ProtectedRoute><DepotsPage /></ProtectedRoute>} />
      <Route path="/utilisateurs" element={<ProtectedRoute><UtilisateursPage /></ProtectedRoute>} />
      <Route path="/parametres" element={<ProtectedRoute><ParametresPage /></ProtectedRoute>} />
      <Route path="/profil" element={<ProtectedRoute><ProfilePage /></ProtectedRoute>} />
    </Routes>
  );
}

function App() {
  return (
    <AuthProvider>
      <BrowserRouter>
        <AppRoutes />
        <Toaster position="top-right" />
      </BrowserRouter>
    </AuthProvider>
  );
}

export default App;
