import { useState } from 'react';
import { X, Search, ChevronDown, Check } from 'lucide-react';
import { Button } from '@/components/ui/button';
import { Input } from '@/components/ui/input';
import { Label } from '@/components/ui/label';
import type { Etat } from '@/types';

interface EtatFormProps {
  initialData?: Etat;
  familles: { cbMarq: number; faCodeFamille: string; faIntitule: string }[];
  utilisateurs: { id: number; fullName: string }[];
  depots: { deNo: number; deIntitule: string }[];
  onSubmit: (data: Omit<Etat, 'id'>) => void;
  onCancel: () => void;
}

export function EtatForm({
  initialData,
  familles,
  utilisateurs,
  depots,
  onSubmit,
  onCancel
}: EtatFormProps) {
  const [nom, setNom] = useState(initialData?.nom || '');
  const [selectedFamilles, setSelectedFamilles] = useState<string[]>(initialData?.familles || []);
  const [selectedUtilisateurs, setSelectedUtilisateurs] = useState<string[]>(initialData?.utilisateurs || []);
  const [selectedDepots, setSelectedDepots] = useState<number[]>(initialData?.depots || []);
  const [showFamilleDropdown, setShowFamilleDropdown] = useState(false);
  const [showUserDropdown, setShowUserDropdown] = useState(false);
  const [depotSearch, setDepotSearch] = useState('');

  const filteredDepots = depots.filter(d =>
    d.deIntitule.toLowerCase().includes(depotSearch.toLowerCase())
  );

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    onSubmit({
      nom,
      familles: selectedFamilles,
      utilisateurs: selectedUtilisateurs,
      depots: selectedDepots
    });
  };

  const toggleFamille = (code: string) => {
    setSelectedFamilles(prev =>
      prev.includes(code) ? prev.filter(f => f !== code) : [...prev, code]
    );
  };

  const toggleUtilisateur = (fullName: string) => {
    setSelectedUtilisateurs(prev =>
      prev.includes(fullName) ? prev.filter(u => u !== fullName) : [...prev, fullName]
    );
  };

  const toggleDepot = (id: number) => {
    setSelectedDepots(prev =>
      prev.includes(id) ? prev.filter(d => d !== id) : [...prev, id]
    );
  };

  const removeFamille = (code: string) => {
    setSelectedFamilles(prev => prev.filter(f => f !== code));
  };

  const removeUtilisateur = (name: string) => {
    setSelectedUtilisateurs(prev => prev.filter(u => u !== name));
  };

  return (
    <form onSubmit={handleSubmit} className="space-y-6">
      <div className="space-y-2">
        <Label htmlFor="nom" className="text-gray-700 font-bold">État :</Label>
        <Input
          id="nom"
          value={nom}
          onChange={(e) => setNom(e.target.value)}
          placeholder="Ex: ÉTAT CARDIOLOGIE"
          className="h-11 shadow-sm border-gray-300 focus:border-[#3CBAAE] focus:ring-[#3CBAAE]"
          required
        />
      </div>

      {/* ── Familles ── */}
      <div className="space-y-2">
        <Label className="text-gray-700 font-bold">Code Famille(s) :</Label>
        <div className="relative">
          <div
            className="border border-gray-300 rounded-lg p-2 min-h-[46px] flex flex-wrap gap-2 cursor-pointer bg-white shadow-sm hover:border-[#3CBAAE] transition-colors"
            onClick={() => setShowFamilleDropdown(!showFamilleDropdown)}
          >
            {selectedFamilles.length === 0 ? (
              <span className="text-gray-400 text-sm py-1">Sélectionner des familles...</span>
            ) : (
              selectedFamilles.map(code => (
                <span key={code} className="bg-[#3CBAAE]/10 text-[#3CBAAE] border border-[#3CBAAE]/20 px-2.5 py-1 rounded-full text-xs font-bold flex items-center gap-1.5 animate-in zoom-in-95">
                  {code}
                  <button
                    type="button"
                    onClick={(e) => {
                      e.stopPropagation();
                      removeFamille(code);
                    }}
                    className="hover:text-red-500 transition-colors"
                  >
                    <X className="h-3 w-3" />
                  </button>
                </span>
              ))
            )}
            <ChevronDown className={`h-4 w-4 ml-auto text-gray-400 transition-transform ${showFamilleDropdown ? 'rotate-180' : ''}`} />
          </div>

          {showFamilleDropdown && (
            <>
              <div className="fixed inset-0 z-10" onClick={() => setShowFamilleDropdown(false)} />
              <div className="absolute z-20 w-full mt-1 bg-white border border-gray-200 rounded-lg shadow-xl max-h-64 overflow-auto animate-in slide-in-from-top-2">
                <div className="p-1">
                  {familles.map(f => (
                    <div
                      key={f.cbMarq}
                      className={`px-3 py-2.5 hover:bg-gray-50 cursor-pointer rounded-md flex items-center justify-between transition-colors ${selectedFamilles.includes(f.faCodeFamille) ? 'bg-emerald-50 text-[#3CBAAE]' : 'text-gray-700'}`}
                      onClick={() => toggleFamille(f.faCodeFamille)}
                    >
                      <div className="flex items-center gap-3">
                        <div className={`w-5 h-5 rounded border flex items-center justify-center transition-colors ${selectedFamilles.includes(f.faCodeFamille) ? 'bg-[#3CBAAE] border-[#3CBAAE]' : 'border-gray-300 bg-white'}`}>
                          {selectedFamilles.includes(f.faCodeFamille) && <Check className="h-3 w-3 text-white" />}
                        </div>
                        <span className="text-sm font-medium">{f.faCodeFamille} - {f.faIntitule}</span>
                      </div>
                    </div>
                  ))}
                </div>
              </div>
            </>
          )}
        </div>
      </div>

      {/* ── Utilisateurs ── */}
      <div className="space-y-2">
        <Label className="text-gray-700 font-bold">Utilisateur(s) :</Label>
        <div className="relative">
          <div
            className="border border-gray-300 rounded-lg p-2 min-h-[46px] flex flex-wrap gap-2 cursor-pointer bg-white shadow-sm hover:border-[#3CBAAE] transition-colors"
            onClick={() => setShowUserDropdown(!showUserDropdown)}
          >
            {selectedUtilisateurs.length === 0 ? (
              <span className="text-gray-400 text-sm py-1">Sélectionner des utilisateurs...</span>
            ) : (
              selectedUtilisateurs.map(name => (
                <span key={name} className="bg-[#3CBAAE]/10 text-[#3CBAAE] border border-[#3CBAAE]/20 px-2.5 py-1 rounded-full text-xs font-bold flex items-center gap-1.5 animate-in zoom-in-95">
                  {name}
                  <button
                    type="button"
                    onClick={(e) => {
                      e.stopPropagation();
                      removeUtilisateur(name);
                    }}
                    className="hover:text-red-500 transition-colors"
                  >
                    <X className="h-3 w-3" />
                  </button>
                </span>
              ))
            )}
            <ChevronDown className={`h-4 w-4 ml-auto text-gray-400 transition-transform ${showUserDropdown ? 'rotate-180' : ''}`} />
          </div>

          {showUserDropdown && (
            <>
              <div className="fixed inset-0 z-10" onClick={() => setShowUserDropdown(false)} />
              <div className="absolute z-20 w-full mt-1 bg-white border border-gray-200 rounded-lg shadow-xl max-h-64 overflow-auto animate-in slide-in-from-top-2">
                <div className="p-1">
                  {utilisateurs.map(u => {
                    const isSelected = selectedUtilisateurs.includes(u.fullName);
                    return (
                      <div
                        key={u.id}
                        className={`px-3 py-2.5 hover:bg-gray-50 cursor-pointer rounded-md flex items-center gap-3 transition-colors ${isSelected ? 'bg-emerald-50 text-[#3CBAAE]' : 'text-gray-700'}`}
                        onClick={() => toggleUtilisateur(u.fullName)}
                      >
                        <div className={`w-5 h-5 rounded border flex items-center justify-center transition-colors flex-shrink-0 ${isSelected ? 'bg-[#3CBAAE] border-[#3CBAAE]' : 'border-gray-300 bg-white'}`}>
                          {isSelected && <Check className="h-3 w-3 text-white" />}
                        </div>
                        <span className="text-sm font-medium">{u.fullName}</span>
                      </div>
                    );
                  })}
                  {utilisateurs.length === 0 && (
                    <p className="px-3 py-4 text-sm text-gray-400 text-center">Aucun utilisateur disponible</p>
                  )}
                </div>
              </div>
            </>
          )}
        </div>
      </div>

      {/* ── Dépôts ── */}
      <div className="space-y-4">
        <Label className="text-gray-700 font-bold">Choisir liste de(s) Dépôt(s) :</Label>
        <div className="relative">
          <Search className="absolute left-3 top-1/2 -translate-y-1/2 h-4 w-4 text-gray-400" />
          <Input
            placeholder="Rechercher un dépôt..."
            value={depotSearch}
            onChange={(e) => setDepotSearch(e.target.value)}
            className="pl-10 h-11 shadow-sm focus:border-[#3CBAAE] focus:ring-[#3CBAAE]"
          />
        </div>

        <div className="border border-gray-200 rounded-lg overflow-hidden bg-white shadow-sm">
          <div className="max-h-[300px] overflow-y-auto">
            <table className="w-full border-collapse">
              <thead className="bg-[#3CBAAE]/10 sticky top-0 z-10 backdrop-blur-sm">
                <tr>
                  <th className="px-4 py-2.5 text-left text-xs font-bold text-[#3CBAAE] uppercase tracking-wider w-12"></th>
                  <th className="px-4 py-2.5 text-left text-xs font-bold text-[#3CBAAE] uppercase tracking-wider">Dépôt</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-gray-100">
                {filteredDepots.map(d => (
                  <tr
                    key={d.deNo}
                    className={`hover:bg-gray-50 transition-colors cursor-pointer ${selectedDepots.includes(d.deNo) ? 'bg-emerald-50/50 text-[#3CBAAE]' : 'text-gray-700'}`}
                    onClick={() => toggleDepot(d.deNo)}
                  >
                    <td className="px-4 py-3">
                      <div className={`w-5 h-5 rounded border flex items-center justify-center transition-colors ${selectedDepots.includes(d.deNo) ? 'bg-[#3CBAAE] border-[#3CBAAE]' : 'border-gray-300 bg-white'}`}>
                        {selectedDepots.includes(d.deNo) && <Check className="h-3 w-3 text-white" />}
                      </div>
                    </td>
                    <td className="px-4 py-3 text-sm font-medium">
                      {d.deIntitule}
                      <span className={`ml-2 text-xs font-normal ${selectedDepots.includes(d.deNo) ? 'text-[#3CBAAE]/70' : 'text-gray-400'}`}>#{d.deNo}</span>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
            {filteredDepots.length === 0 && (
              <div className="p-8 text-center text-gray-500 italic">
                Aucun dépôt trouvé
              </div>
            )}
          </div>
        </div>
        <div className="flex justify-between items-center px-1">
          <p className="text-xs text-gray-500 font-medium">
            Affichage de {filteredDepots.length} dépôts
            {selectedDepots.length > 0 && (
              <span className="text-[#3CBAAE] ml-1">({selectedDepots.length} sélectionnés)</span>
            )}
          </p>
          {selectedDepots.length > 0 && (
            <button
              type="button"
              onClick={() => setSelectedDepots([])}
              className="text-xs text-red-500 hover:text-red-700 font-medium"
            >
              Tout désélectionner
            </button>
          )}
        </div>
      </div>

      <div className="flex justify-end gap-3 pt-6 border-t border-gray-100 mt-2">
        <Button
          type="button"
          variant="ghost"
          onClick={onCancel}
          className="text-gray-500 hover:bg-gray-100"
        >
          Annuler
        </Button>
        <Button
          type="submit"
          className="bg-[#3CBAAE] hover:bg-[#35a89d] text-white px-8 shadow-sm transition-all hover:shadow-md active:scale-95"
          disabled={!nom || selectedFamilles.length === 0 || selectedDepots.length === 0}
        >
          Enregistrer
        </Button>
      </div>
    </form>
  );
}
