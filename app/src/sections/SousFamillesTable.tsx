import { useState, useEffect, useCallback } from 'react';
import { Search, Edit, Trash2, Plus, ChevronLeft, ChevronRight } from 'lucide-react';
import { Button } from '@/components/ui/button';
import { Input } from '@/components/ui/input';
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from '@/components/ui/table';
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from '@/components/ui/dialog';
import { Label } from '@/components/ui/label';
import { sousFamilleApi } from '@/services/api';
import type { SousFamille, Famille, PagedResult } from '@/types';

interface SousFamillesTableProps {
  familles: Famille[];
  onAdd?: (sousFamille: Omit<SousFamille, 'cbMarq'>) => Promise<void>;
  onUpdate?: (id: number, sousFamille: Omit<SousFamille, 'cbMarq'>) => Promise<void>;
  onDelete?: (id: number) => Promise<void>;
}

export function SousFamillesTable({ familles, onAdd, onUpdate, onDelete }: SousFamillesTableProps) {
  const [result, setResult]             = useState<PagedResult<SousFamille> | null>(null);
  const [page, setPage]                 = useState(1);
  const [pageSize, setPageSize]         = useState(10);
  const [search, setSearch]             = useState('');
  const [searchInput, setSearchInput]   = useState('');
  const [loading, setLoading]           = useState(false);

  const [isAddDialogOpen, setIsAddDialogOpen]   = useState(false);
  const [isEditDialogOpen, setIsEditDialogOpen] = useState(false);
  const [currentSF, setCurrentSF]               = useState<SousFamille | null>(null);
  const [formData, setFormData]                 = useState({ nom: '', code: '', fCodeFFamille: '' });

  const load = useCallback(async (p: number, ps: number, s: string) => {
    setLoading(true);
    try {
      const res = await sousFamilleApi.getPaged(p, ps, s);
      setResult(res.data);
    } finally {
      setLoading(false);
    }
  }, []);

  useEffect(() => { load(page, pageSize, search); }, [page, pageSize, search, load]);

  // Debounce search input
  useEffect(() => {
    const t = setTimeout(() => { setSearch(searchInput); setPage(1); }, 400);
    return () => clearTimeout(t);
  }, [searchInput]);

  const handlePageSizeChange = (ps: number) => { setPageSize(ps); setPage(1); };

  const getFamilleName = (code: string) =>
    familles.find(f => f.faCodeFamille === code)?.faIntitule || code;

  const handleAdd = async () => {
    if (onAdd && formData.nom && formData.code && formData.fCodeFFamille) {
      await onAdd(formData);
      setFormData({ nom: '', code: '', fCodeFFamille: '' });
      setIsAddDialogOpen(false);
      load(page, pageSize, search);
    }
  };

  const handleEdit = (sf: SousFamille) => {
    setCurrentSF(sf);
    setFormData({ nom: sf.nom, code: sf.code, fCodeFFamille: sf.fCodeFFamille });
    setIsEditDialogOpen(true);
  };

  const handleUpdate = async () => {
    if (onUpdate && currentSF && formData.nom) {
      await onUpdate(currentSF.cbMarq, formData);
      setIsEditDialogOpen(false);
      setCurrentSF(null);
      load(page, pageSize, search);
    }
  };

  const handleDelete = async (id: number) => {
    if (onDelete && window.confirm('Êtes-vous sûr de vouloir supprimer cette sous-famille ?')) {
      await onDelete(id);
      if (result && result.items.length === 1 && page > 1) setPage(p => p - 1);
      else load(page, pageSize, search);
    }
  };

  const totalPages = result?.totalPages ?? 1;
  const totalCount = result?.totalCount ?? 0;
  const items      = result?.items ?? [];
  const from       = totalCount === 0 ? 0 : (page - 1) * pageSize + 1;
  const to         = Math.min(page * pageSize, totalCount);

  return (
    <div className="bg-white rounded-lg shadow">
      <div className="p-6 border-b border-gray-200">
        <h2 className="text-xl font-semibold text-gray-800">Liste des sous familles</h2>
        <p className="text-sm text-gray-500 mt-1">Accueil / sous familles</p>
      </div>

      <div className="p-4">
        {/* Top bar */}
        <div className="flex items-center justify-between mb-4 flex-wrap gap-3">
          <div className="flex items-center gap-2">
            <span className="text-sm text-gray-600">Show</span>
            <select
              className="border border-gray-300 rounded px-2 py-1 text-sm bg-white"
              value={pageSize}
              onChange={(e) => handlePageSizeChange(Number(e.target.value))}
            >
              {[10, 25, 50, 100].map(n => <option key={n} value={n}>{n}</option>)}
            </select>
            <span className="text-sm text-gray-600">entries</span>
          </div>

          <div className="flex items-center gap-4">
            <div className="relative">
              <Search className="absolute left-3 top-1/2 -translate-y-1/2 h-4 w-4 text-gray-400" />
              <Input
                placeholder="Search..."
                value={searchInput}
                onChange={(e) => setSearchInput(e.target.value)}
                className="pl-10 w-64"
              />
            </div>

            {/* Add dialog */}
            <Dialog open={isAddDialogOpen} onOpenChange={setIsAddDialogOpen}>
              <DialogTrigger asChild>
                <Button className="bg-[#3CBAAE] hover:bg-[#35a89d]">
                  <Plus className="h-4 w-4 mr-2" />
                  Nouvelle sous Famille
                </Button>
              </DialogTrigger>
              <DialogContent>
                <DialogHeader><DialogTitle>Nouvelle Sous-Famille</DialogTitle></DialogHeader>
                <div className="space-y-4 py-4">
                  <div className="space-y-2">
                    <Label>Famille</Label>
                    <select className="w-full border border-gray-300 rounded-lg px-3 py-2"
                      value={formData.fCodeFFamille}
                      onChange={(e) => setFormData(p => ({ ...p, fCodeFFamille: e.target.value }))}>
                      <option value="">Sélectionner une famille</option>
                      {familles.map(f => (
                        <option key={f.cbMarq} value={f.faCodeFamille}>{f.faCodeFamille} - {f.faIntitule}</option>
                      ))}
                    </select>
                  </div>
                  <div className="space-y-2">
                    <Label>Nom</Label>
                    <Input placeholder="Nom de la sous-famille" value={formData.nom}
                      onChange={(e) => setFormData(p => ({ ...p, nom: e.target.value }))} />
                  </div>
                  <div className="space-y-2">
                    <Label>Code</Label>
                    <Input placeholder="Code" value={formData.code}
                      onChange={(e) => setFormData(p => ({ ...p, code: e.target.value }))} />
                  </div>
                  <div className="flex justify-end gap-3 pt-4">
                    <Button variant="outline" onClick={() => setIsAddDialogOpen(false)}>Annuler</Button>
                    <Button className="bg-[#3CBAAE] hover:bg-[#35a89d]" onClick={handleAdd}>Enregistrer</Button>
                  </div>
                </div>
              </DialogContent>
            </Dialog>

            {/* Edit dialog */}
            <Dialog open={isEditDialogOpen} onOpenChange={setIsEditDialogOpen}>
              <DialogContent>
                <DialogHeader><DialogTitle>Modifier Sous-Famille</DialogTitle></DialogHeader>
                <div className="space-y-4 py-4">
                  <div className="space-y-2">
                    <Label>Famille</Label>
                    <select className="w-full border border-gray-300 rounded-lg px-3 py-2"
                      value={formData.fCodeFFamille}
                      onChange={(e) => setFormData(p => ({ ...p, fCodeFFamille: e.target.value }))}>
                      <option value="">Sélectionner une famille</option>
                      {familles.map(f => (
                        <option key={f.cbMarq} value={f.faCodeFamille}>{f.faCodeFamille} - {f.faIntitule}</option>
                      ))}
                    </select>
                  </div>
                  <div className="space-y-2">
                    <Label>Nom</Label>
                    <Input placeholder="Nom de la sous-famille" value={formData.nom}
                      onChange={(e) => setFormData(p => ({ ...p, nom: e.target.value }))} />
                  </div>
                  <div className="space-y-2">
                    <Label>Code</Label>
                    <Input placeholder="Code" value={formData.code}
                      onChange={(e) => setFormData(p => ({ ...p, code: e.target.value }))} />
                  </div>
                  <div className="flex justify-end gap-3 pt-4">
                    <Button variant="outline" onClick={() => setIsEditDialogOpen(false)}>Annuler</Button>
                    <Button className="bg-[#3CBAAE] hover:bg-[#35a89d]" onClick={handleUpdate}>Mettre à jour</Button>
                  </div>
                </div>
              </DialogContent>
            </Dialog>
          </div>
        </div>

        {/* Table */}
        <div className="overflow-x-auto">
          <Table>
            <TableHeader>
              <TableRow className="bg-[#3CBAAE]">
                <TableHead className="text-white">Famille</TableHead>
                <TableHead className="text-white">Sous Famille</TableHead>
                <TableHead className="text-white">Code</TableHead>
                <TableHead className="text-white text-right">Action</TableHead>
              </TableRow>
            </TableHeader>
            <TableBody>
              {loading ? (
                <TableRow><TableCell colSpan={4} className="text-center py-8 text-gray-400">Chargement…</TableCell></TableRow>
              ) : items.length === 0 ? (
                <TableRow><TableCell colSpan={4} className="text-center py-8 text-gray-400">Aucune sous-famille trouvée</TableCell></TableRow>
              ) : items.map((sf) => (
                <TableRow key={sf.cbMarq} className="hover:bg-gray-50">
                  <TableCell>{getFamilleName(sf.fCodeFFamille)}</TableCell>
                  <TableCell>{sf.nom}</TableCell>
                  <TableCell>{sf.code}</TableCell>
                  <TableCell className="text-right">
                    <div className="flex items-center justify-end gap-2">
                      <Button variant="ghost" size="icon" className="h-8 w-8 text-emerald-500" onClick={() => handleEdit(sf)}>
                        <Edit className="h-4 w-4" />
                      </Button>
                      <Button variant="ghost" size="icon" className="h-8 w-8 text-red-500" onClick={() => handleDelete(sf.cbMarq)}>
                        <Trash2 className="h-4 w-4" />
                      </Button>
                    </div>
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </div>

        {/* Pagination footer */}
        <div className="flex items-center justify-between mt-4 flex-wrap gap-2">
          <p className="text-sm text-gray-600">
            {totalCount === 0 ? 'Aucun résultat' : `Affichage de ${from} à ${to} sur ${totalCount} entrées`}
          </p>
          <div className="flex items-center gap-1">
            <Button variant="outline" size="icon" className="h-8 w-8" disabled={page <= 1} onClick={() => setPage(1)}>
              <ChevronLeft className="h-3 w-3" /><ChevronLeft className="h-3 w-3 -ml-2" />
            </Button>
            <Button variant="outline" size="icon" className="h-8 w-8" disabled={page <= 1} onClick={() => setPage(p => p - 1)}>
              <ChevronLeft className="h-4 w-4" />
            </Button>
            {Array.from({ length: Math.min(5, totalPages) }, (_, i) => {
              const start = Math.max(1, Math.min(page - 2, totalPages - 4));
              const p = start + i;
              if (p > totalPages) return null;
              return (
                <Button key={p} variant={p === page ? 'default' : 'outline'} size="icon"
                  className={`h-8 w-8 ${p === page ? 'bg-[#3CBAAE] hover:bg-[#35a89d]' : ''}`}
                  onClick={() => setPage(p)}>
                  {p}
                </Button>
              );
            })}
            <Button variant="outline" size="icon" className="h-8 w-8" disabled={page >= totalPages} onClick={() => setPage(p => p + 1)}>
              <ChevronRight className="h-4 w-4" />
            </Button>
            <Button variant="outline" size="icon" className="h-8 w-8" disabled={page >= totalPages} onClick={() => setPage(totalPages)}>
              <ChevronRight className="h-3 w-3" /><ChevronRight className="h-3 w-3 -ml-2" />
            </Button>
          </div>
        </div>
      </div>
    </div>
  );
}
