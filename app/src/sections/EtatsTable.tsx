import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { Search, Edit, Trash2, Plus, Package } from 'lucide-react';
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
import type { Etat } from '@/types';
import { EtatForm } from './EtatForm';

interface EtatsTableProps {
  etats: Etat[];
  familles: { cbMarq: number; faCodeFamille: string; faIntitule: string }[];
  utilisateurs: { id: number; fullName: string }[];
  depots: { deNo: number; deIntitule: string }[];
  onAdd: (etat: Omit<Etat, 'id'>) => void;
  onUpdate: (id: number, etat: Omit<Etat, 'id'>) => void;
  onDelete: (id: number) => void;
}

export function EtatsTable({
  etats,
  familles,
  utilisateurs,
  depots,
  onAdd,
  onUpdate,
  onDelete
}: EtatsTableProps) {
  const navigate = useNavigate();
  const [searchTerm, setSearchTerm] = useState('');
  const [entriesPerPage, setEntriesPerPage] = useState(10);
  const [editingEtat, setEditingEtat] = useState<Etat | null>(null);
  const [isAddDialogOpen, setIsAddDialogOpen] = useState(false);
  const [isEditDialogOpen, setIsEditDialogOpen] = useState(false);

  const filteredEtats = etats.filter(etat =>
    etat.nom.toLowerCase().includes(searchTerm.toLowerCase()) ||
    etat.familles.some(f => f.toLowerCase().includes(searchTerm.toLowerCase()))
  );

  const displayedEtats = filteredEtats.slice(0, entriesPerPage);

  const handleEdit = (etat: Etat) => {
    setEditingEtat(etat);
    setIsEditDialogOpen(true);
  };

  const handleUpdate = (data: Omit<Etat, 'id'>) => {
    if (editingEtat) {
      onUpdate(editingEtat.id, data);
      setIsEditDialogOpen(false);
      setEditingEtat(null);
    }
  };

  return (
    <div className="bg-white rounded-lg shadow">
      <div className="p-4 border-b border-gray-200 flex items-center justify-between">
        <h2 className="text-lg font-semibold text-gray-800">Liste des états</h2>
        <Dialog open={isAddDialogOpen} onOpenChange={setIsAddDialogOpen}>
          <DialogTrigger asChild>
            <Button className="bg-[#3CBAAE] hover:bg-[#35a89d]">
              <Plus className="h-4 w-4 mr-2" />
              Nouvel état
            </Button>
          </DialogTrigger>
          <DialogContent className="max-w-2xl max-h-[90vh] overflow-y-auto">
            <DialogHeader>
              <DialogTitle>Nouvel état</DialogTitle>
            </DialogHeader>
            <EtatForm
              familles={familles}
              utilisateurs={utilisateurs}
              depots={depots}
              onSubmit={(data) => {
                onAdd(data);
                setIsAddDialogOpen(false);
              }}
              onCancel={() => setIsAddDialogOpen(false)}
            />
          </DialogContent>
        </Dialog>
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
          <div className="relative">
            <Search className="absolute left-3 top-1/2 -translate-y-1/2 h-4 w-4 text-gray-400" />
            <Input
              placeholder="Search..."
              value={searchTerm}
              onChange={(e) => setSearchTerm(e.target.value)}
              className="pl-10 w-64"
            />
          </div>
        </div>

        <div className="overflow-x-auto">
          <Table>
            <TableHeader>
              <TableRow className="bg-[#3CBAAE]">
                <TableHead className="text-white">Etat</TableHead>
                <TableHead className="text-white">Liste des familles</TableHead>
                <TableHead className="text-white">Liste des utilisateurs</TableHead>
                <TableHead className="text-white text-right">Action</TableHead>
              </TableRow>
            </TableHeader>
            <TableBody>
              {displayedEtats.map((etat) => (
                <TableRow key={etat.id} className="hover:bg-gray-50">
                  <TableCell className="font-medium">{etat.nom}</TableCell>
                  <TableCell>{etat.familles.join(', ')}</TableCell>
                  <TableCell className="max-w-xs truncate">
                    {etat.utilisateurs.join('-')}
                  </TableCell>
                  <TableCell className="text-right">
                    <div className="flex items-center justify-end gap-2">
                      <Button
                        size="sm"
                        className="bg-[#3CBAAE] hover:bg-[#35a89d] text-white gap-2"
                        onClick={() => navigate('/inventory', { state: { filterEtat: etat } })}
                      >
                        <Package className="h-4 w-4" />
                        Consulter
                      </Button>
                      <Button
                        variant="ghost"
                        size="icon"
                        className="h-8 w-8 text-emerald-500"
                        onClick={() => handleEdit(etat)}
                      >
                        <Edit className="h-4 w-4" />
                      </Button>
                      <Button
                        variant="ghost"
                        size="icon"
                        className="h-8 w-8 text-red-500"
                        onClick={() => onDelete(etat.id)}
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

      <Dialog open={isEditDialogOpen} onOpenChange={setIsEditDialogOpen}>
        <DialogContent className="max-w-2xl max-h-[90vh] overflow-y-auto">
          <DialogHeader>
            <DialogTitle>Modification d'état</DialogTitle>
          </DialogHeader>
          {editingEtat && (
            <EtatForm
              initialData={editingEtat}
              familles={familles}
              utilisateurs={utilisateurs}
              depots={depots}
              onSubmit={handleUpdate}
              onCancel={() => {
                setIsEditDialogOpen(false);
                setEditingEtat(null);
              }}
            />
          )}
        </DialogContent>
      </Dialog>
    </div>
  );
}
