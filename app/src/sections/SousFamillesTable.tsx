import { useState } from 'react';
import { Search, Edit, Trash2, Plus } from 'lucide-react';
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
import type { SousFamille, Famille } from '@/types';

interface SousFamillesTableProps {
  sousFamilles: SousFamille[];
  familles: Famille[];
  onAdd?: (sousFamille: Omit<SousFamille, 'cbMarq'>) => void;
  onUpdate?: (id: number, sousFamille: Omit<SousFamille, 'cbMarq'>) => void;
  onDelete?: (id: number) => void;
}

export function SousFamillesTable({ sousFamilles, familles, onAdd, onUpdate, onDelete }: SousFamillesTableProps) {
  const [searchTerm, setSearchTerm] = useState('');
  const [entriesPerPage, setEntriesPerPage] = useState(10);
  const [isAddDialogOpen, setIsAddDialogOpen] = useState(false);
  const [isEditDialogOpen, setIsEditDialogOpen] = useState(false);
  const [currentSousFamille, setCurrentSousFamille] = useState<SousFamille | null>(null);
  const [formData, setFormData] = useState({ nom: '', code: '', fCodeFFamille: '' });

  const filteredSousFamilles = sousFamilles.filter(sf =>
    sf.nom.toLowerCase().includes(searchTerm.toLowerCase()) ||
    sf.code.toLowerCase().includes(searchTerm.toLowerCase()) ||
    sf.fCodeFFamille.toLowerCase().includes(searchTerm.toLowerCase())
  );

  const displayedSousFamilies = filteredSousFamilles.slice(0, entriesPerPage);

  const getFamilleName = (codeOrId: string) => {
    return familles.find(f => f.faCodeFamille === codeOrId || f.cbMarq.toString() === codeOrId)?.faIntitule || codeOrId;
  };

  const handleAdd = () => {
    if (onAdd && formData.nom && formData.code && formData.fCodeFFamille) {
      onAdd(formData);
      setFormData({ nom: '', code: '', fCodeFFamille: '' });
      setIsAddDialogOpen(false);
    }
  };

  const handleEdit = (sf: SousFamille) => {
    setCurrentSousFamille(sf);
    setFormData({ nom: sf.nom, code: sf.code, fCodeFFamille: sf.fCodeFFamille });
    setIsEditDialogOpen(true);
  };

  const handleUpdate = () => {
    if (onUpdate && currentSousFamille && formData.nom) {
      onUpdate(currentSousFamille.cbMarq, formData);
      setIsEditDialogOpen(false);
      setCurrentSousFamille(null);
    }
  };

  const handleDelete = (id: number) => {
    if (onDelete && window.confirm('Êtes-vous sûr de vouloir supprimer cette sous-famille ?')) {
      onDelete(id);
    }
  };

  return (
    <div className="bg-white rounded-lg shadow">
      <div className="p-6 border-b border-gray-200">
        <h2 className="text-xl font-semibold text-gray-800">Liste des sous familles</h2>
        <p className="text-sm text-gray-500 mt-1">Accueil / sous familles</p>
      </div>

      <div className="p-4">
        <div className="flex items-center justify-between mb-4">
          <div className="flex items-center gap-2">
            <span className="text-sm text-gray-600">Show</span>
            <select
              className="border border-gray-300 rounded px-2 py-1 text-sm bg-white"
              value={entriesPerPage}
              onChange={(e) => setEntriesPerPage(Number(e.target.value))}
            >
              <option value={10}>10</option>
              <option value={25}>25</option>
              <option value={50}>50</option>
              <option value={100}>100</option>
            </select>
            <span className="text-sm text-gray-600">entries</span>
          </div>
          <div className="flex items-center gap-4">
            <div className="relative">
              <Search className="absolute left-3 top-1/2 -translate-y-1/2 h-4 w-4 text-gray-400" />
              <Input
                placeholder="Search..."
                value={searchTerm}
                onChange={(e) => setSearchTerm(e.target.value)}
                className="pl-10 w-64"
              />
            </div>
            <Dialog open={isAddDialogOpen} onOpenChange={setIsAddDialogOpen}>
              <DialogTrigger asChild>
                <Button className="bg-[#3CBAAE] hover:bg-[#35a89d]">
                  <Plus className="h-4 w-4 mr-2" />
                  Nouvelle sous Famille
                </Button>
              </DialogTrigger>
              <DialogContent>
                <DialogHeader>
                  <DialogTitle>Nouvelle Sous-Famille</DialogTitle>
                </DialogHeader>
                <div className="space-y-4 py-4">
                  <div className="space-y-2">
                    <Label>Famille</Label>
                    <select
                      className="w-full border border-gray-300 rounded-lg px-3 py-2"
                      value={formData.fCodeFFamille}
                      onChange={(e) => setFormData(prev => ({ ...prev, fCodeFFamille: e.target.value }))}
                    >
                      <option value="">Sélectionner une famille</option>
                      {familles.map(f => (
                        <option key={f.cbMarq} value={f.faCodeFamille}>
                          {f.faCodeFamille} - {f.faIntitule}
                        </option>
                      ))}
                    </select>
                  </div>
                  <div className="space-y-2">
                    <Label>Nom</Label>
                    <Input
                      placeholder="Nom de la sous-famille"
                      value={formData.nom}
                      onChange={(e) => setFormData(prev => ({ ...prev, nom: e.target.value }))}
                    />
                  </div>
                  <div className="space-y-2">
                    <Label>Code</Label>
                    <Input
                      placeholder="Code"
                      value={formData.code}
                      onChange={(e) => setFormData(prev => ({ ...prev, code: e.target.value }))}
                    />
                  </div>
                  <div className="flex justify-end gap-3 pt-4">
                    <Button variant="outline" onClick={() => setIsAddDialogOpen(false)}>
                      Annuler
                    </Button>
                    <Button
                      className="bg-[#3CBAAE] hover:bg-[#35a89d]"
                      onClick={handleAdd}
                    >
                      Enregistrer
                    </Button>
                  </div>
                </div>
              </DialogContent>
            </Dialog>

            <Dialog open={isEditDialogOpen} onOpenChange={setIsEditDialogOpen}>
              <DialogContent>
                <DialogHeader>
                  <DialogTitle>Modifier Sous-Famille</DialogTitle>
                </DialogHeader>
                <div className="space-y-4 py-4">
                  <div className="space-y-2">
                    <Label>Famille</Label>
                    <select
                      className="w-full border border-gray-300 rounded-lg px-3 py-2"
                      value={formData.fCodeFFamille}
                      onChange={(e) => setFormData(prev => ({ ...prev, fCodeFFamille: e.target.value }))}
                    >
                      <option value="">Sélectionner une famille</option>
                      {familles.map(f => (
                        <option key={f.cbMarq} value={f.faCodeFamille}>
                          {f.faCodeFamille} - {f.faIntitule}
                        </option>
                      ))}
                    </select>
                  </div>
                  <div className="space-y-2">
                    <Label>Nom</Label>
                    <Input
                      placeholder="Nom de la sous-famille"
                      value={formData.nom}
                      onChange={(e) => setFormData(prev => ({ ...prev, nom: e.target.value }))}
                    />
                  </div>
                  <div className="space-y-2">
                    <Label>Code</Label>
                    <Input
                      placeholder="Code"
                      value={formData.code}
                      onChange={(e) => setFormData(prev => ({ ...prev, code: e.target.value }))}
                    />
                  </div>
                  <div className="flex justify-end gap-3 pt-4">
                    <Button variant="outline" onClick={() => setIsEditDialogOpen(false)}>
                      Annuler
                    </Button>
                    <Button
                      className="bg-[#3CBAAE] hover:bg-[#35a89d]"
                      onClick={handleUpdate}
                    >
                      Mettre à jour
                    </Button>
                  </div>
                </div>
              </DialogContent>
            </Dialog>
          </div>
        </div>

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
              {displayedSousFamilies.map((sf) => (
                <TableRow key={sf.cbMarq} className="hover:bg-gray-50">
                  <TableCell>{getFamilleName(sf.fCodeFFamille)}</TableCell>
                  <TableCell>{sf.nom}</TableCell>
                  <TableCell>{sf.code}</TableCell>
                  <TableCell className="text-right">
                    <div className="flex items-center justify-end gap-2">
                      <Button
                        variant="ghost"
                        size="icon"
                        className="h-8 w-8 text-emerald-500"
                        onClick={() => handleEdit(sf)}
                      >
                        <Edit className="h-4 w-4" />
                      </Button>
                      <Button
                        variant="ghost"
                        size="icon"
                        className="h-8 w-8 text-red-500"
                        onClick={() => handleDelete(sf.cbMarq)}
                      >
                        <Trash2 className="h-4 w-4" />
                      </Button>
                    </div>
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </div>
      </div>
    </div>
  );
}
