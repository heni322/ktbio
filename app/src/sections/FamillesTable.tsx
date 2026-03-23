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
import type { Famille } from '@/types';

interface FamillesTableProps {
    familles: Famille[];
    onAdd?: (famille: Omit<Famille, 'cbMarq'>) => void;
    onUpdate?: (id: number, famille: Omit<Famille, 'cbMarq'>) => void;
    onDelete?: (code: string) => void;
}

export function FamillesTable({ familles, onAdd, onUpdate, onDelete }: FamillesTableProps) {
    const [searchTerm, setSearchTerm] = useState('');
    const [entriesPerPage, setEntriesPerPage] = useState(10);
    const [isAddDialogOpen, setIsAddDialogOpen] = useState(false);
    const [isEditDialogOpen, setIsEditDialogOpen] = useState(false);
    const [currentFamille, setCurrentFamille] = useState<Famille | null>(null);
    const [newFamille, setNewFamille] = useState({ faCodeFamille: '', faIntitule: '' });

    const filteredFamilles = familles.filter(f =>
        f.faIntitule.toLowerCase().includes(searchTerm.toLowerCase()) ||
        f.faCodeFamille.toLowerCase().includes(searchTerm.toLowerCase())
    );

    const displayedFamilies = filteredFamilles.slice(0, entriesPerPage);

    const handleAdd = () => {
        if (onAdd && newFamille.faCodeFamille && newFamille.faIntitule) {
            onAdd(newFamille);
            setNewFamille({ faCodeFamille: '', faIntitule: '' });
            setIsAddDialogOpen(false);
        }
    };

    const handleEdit = (famille: Famille) => {
        setCurrentFamille(famille);
        setNewFamille({ faCodeFamille: famille.faCodeFamille, faIntitule: famille.faIntitule });
        setIsEditDialogOpen(true);
    };

    const handleUpdate = () => {
        if (onUpdate && currentFamille && newFamille.faIntitule) {
            onUpdate(currentFamille.cbMarq, newFamille);
            setIsEditDialogOpen(false);
            setCurrentFamille(null);
        }
    };

    const handleDelete = (code: string) => {
        if (onDelete && window.confirm('Êtes-vous sûr de vouloir supprimer cette famille ?')) {
            onDelete(code);
        }
    };

    return (
        <div className="bg-white rounded-lg shadow">
            <div className="p-6 border-b border-gray-200">
                <h2 className="text-xl font-semibold text-gray-800">Liste des familles</h2>
                <p className="text-sm text-gray-500 mt-1">Accueil / familles</p>
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
                                    Nouvelle Famille
                                </Button>
                            </DialogTrigger>
                            <DialogContent>
                                <DialogHeader>
                                    <DialogTitle>Nouvelle Famille</DialogTitle>
                                </DialogHeader>
                                <div className="space-y-4 py-4">
                                    <div className="space-y-2">
                                        <Label>Code Famille</Label>
                                        <Input
                                            placeholder="Code de la famille"
                                            value={newFamille.faCodeFamille}
                                            onChange={(e) => setNewFamille(prev => ({ ...prev, faCodeFamille: e.target.value }))}
                                        />
                                    </div>
                                    <div className="space-y-2">
                                        <Label>Intitulé</Label>
                                        <Input
                                            placeholder="Intitulé de la famille"
                                            value={newFamille.faIntitule}
                                            onChange={(e) => setNewFamille(prev => ({ ...prev, faIntitule: e.target.value }))}
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
                                    <DialogTitle>Modifier Famille</DialogTitle>
                                </DialogHeader>
                                <div className="space-y-4 py-4">
                                    <div className="space-y-2">
                                        <Label>Code Famille (Non modifiable)</Label>
                                        <Input
                                            value={newFamille.faCodeFamille}
                                            disabled
                                        />
                                    </div>
                                    <div className="space-y-2">
                                        <Label>Intitulé</Label>
                                        <Input
                                            placeholder="Intitulé de la famille"
                                            value={newFamille.faIntitule}
                                            onChange={(e) => setNewFamille(prev => ({ ...prev, faIntitule: e.target.value }))}
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
                                <TableHead className="text-white">Code Famille</TableHead>
                                <TableHead className="text-white">Intitulé</TableHead>
                                <TableHead className="text-white text-right">Action</TableHead>
                            </TableRow>
                        </TableHeader>
                        <TableBody>
                            {displayedFamilies.map((f) => (
                                <TableRow key={f.cbMarq} className="hover:bg-gray-50">
                                    <TableCell className="font-medium">{f.faCodeFamille}</TableCell>
                                    <TableCell>{f.faIntitule}</TableCell>
                                    <TableCell className="text-right">
                                        <div className="flex items-center justify-end gap-2">
                                            <Button
                                                variant="ghost"
                                                size="icon"
                                                className="h-8 w-8 text-emerald-500"
                                                onClick={() => handleEdit(f)}
                                            >
                                                <Edit className="h-4 w-4" />
                                            </Button>
                                            <Button
                                                variant="ghost"
                                                size="icon"
                                                className="h-8 w-8 text-red-500"
                                                onClick={() => handleDelete(f.faCodeFamille)}
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
