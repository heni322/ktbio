import { useState, useMemo, useEffect } from 'react';
import { useNavigate, useLocation } from 'react-router-dom';
import * as XLSX from 'xlsx';
import { ArrowLeft, FileSpreadsheet, Minus, Plus } from 'lucide-react';
import { inventoryApi } from '@/services/api';
import { toast } from 'sonner';
import { Button } from '@/components/ui/button';
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from '@/components/ui/select';
import type { InventoryGroupView, Depot, Etat, SousFamille } from '@/types';

interface InventoryTableProps {
  inventory: InventoryGroupView[];
  depots: Depot[];
  allSousFamilles: SousFamille[];
}

type ViewMode = 'Date' | 'Quantité' | 'Lot';

// ── Warning triangle icon ─────────────────────────────────────────────────────
function WarningIcon({ size = 16 }: { size?: number }) {
  return (
    <svg viewBox="0 0 100 88" width={size} height={size} xmlns="http://www.w3.org/2000/svg" className="drop-shadow-sm flex-shrink-0">
      <defs>
        <linearGradient id="invTriGrad" x1="50%" y1="0%" x2="50%" y2="100%">
          <stop offset="0%"   stopColor="#FDE047" />
          <stop offset="100%" stopColor="#F59E0B" />
        </linearGradient>
      </defs>
      <polygon points="50,5 97,83 3,83" fill="url(#invTriGrad)" stroke="#92400E" strokeWidth="3" strokeLinejoin="round" />
      <text x="50" y="74" textAnchor="middle" fontSize="54" fontWeight="900" fill="#1C1917" fontFamily="Arial, sans-serif">!</text>
    </svg>
  );
}

export function InventoryTable({ inventory: initialInventory, depots, allSousFamilles }: InventoryTableProps) {
  const navigate    = useNavigate();
  const location    = useLocation();
  const filterEtat  = location.state?.filterEtat as Etat | undefined;

  // ── Data state ───────────────────────────────────────────────────────────
  const [inventory, setInventory] = useState(initialInventory);

  // ── UI filters ───────────────────────────────────────────────────────────
  const [anneeFilter, setAnneeFilter]             = useState<string>('tout');
  const [sousFamilleFilter, setSousFamilleFilter] = useState<string>('tout');
  const [viewMode, setViewMode]                   = useState<ViewMode>('Date');

  // Sync when parent re-fetches (e.g. etat filter changes)
  useEffect(() => { setInventory(initialInventory); }, [initialInventory]);

  // ── Derived ───────────────────────────────────────────────────────────────
  const sousFamillesNames = useMemo(() => allSousFamilles.map(sf => sf.nom), [allSousFamilles]);

  const displayedDepots = useMemo(() => {
    if (!filterEtat || filterEtat.depots.length === 0) return depots;
    return depots.filter(d => filterEtat.depots.includes(d.deNo));
  }, [depots, filterEtat]);

  const annees = useMemo(() => {
    const years = new Set<number>();
    inventory.forEach(item => {
      item.depots.forEach(depot => {
        depot.items.forEach(detail => {
          if (detail.dateExpiration) years.add(new Date(detail.dateExpiration).getFullYear());
        });
      });
    });
    return Array.from(years).sort();
  }, [inventory]);

  // Client-side filters: année + sousFamille
  const filteredInventory = useMemo(() => {
    return inventory
      .map(item => {
        const filteredItemDepots = item.depots.filter(d =>
          displayedDepots.some(dd => dd.deNo === d.depotId)
        );
        const updatedDepots = filteredItemDepots.map(d => ({
          ...d,
          items: d.items.filter(detail => {
            const matchesSousFamille =
              sousFamilleFilter === 'tout' || detail.sousFamille === sousFamilleFilter;
            const matchesAnnee =
              anneeFilter === 'tout' ||
              (detail.dateExpiration &&
                new Date(detail.dateExpiration).getFullYear().toString() === anneeFilter);
            return matchesSousFamille && matchesAnnee;
          }),
        }));
        const total = updatedDepots.reduce(
          (sum, d) => sum + d.items.reduce((iSum, i) => iSum + i.quantite, 0), 0
        );
        return { ...item, depots: updatedDepots, total };
      })
      .filter(item => item.total > 0);
  }, [inventory, anneeFilter, sousFamilleFilter, displayedDepots]);

  // ── Helpers ───────────────────────────────────────────────────────────────
  const updateLocalQuantity = (id: number, delta: number) => {
    setInventory(prev =>
      prev.map(group => ({
        ...group,
        depots: group.depots.map(depot => ({
          ...depot,
          items: depot.items.map(item =>
            item.id === id ? { ...item, quantite: Math.max(0, item.quantite + delta) } : item
          ),
        })),
      }))
    );
  };

  const getCriticalClass = (months: number): string => {
    if (months <= 0) return 'bg-red-500 text-white';
    if (months <= 2) return 'bg-red-500 text-white';
    if (months <= 5) return 'bg-orange-500 text-white';
    if (months <= 8) return 'bg-yellow-500 text-gray-900';
    return 'bg-blue-400 text-white';
  };

  const handleExportExcel = () => {
    const headers = ['Longueur', 'Diamètre', ...displayedDepots.map(d => d.deIntitule), 'Total'];
    const data = filteredInventory.map(item => {
      const row: Record<string, unknown> = { Longueur: item.longueur, Diamètre: item.diametre };
      displayedDepots.forEach(depot => {
        const depotData = item.depots.find(d => d.depotId === depot.deNo);
        if (depotData && depotData.items.length > 0) {
          row[depot.deIntitule] = depotData.items.map(detail => {
            if (viewMode === 'Quantité') return detail.quantite;
            if (viewMode === 'Lot') return detail.lot || '-';
            const dateStr = detail.dateExpiration
              ? new Date(detail.dateExpiration).toLocaleDateString('fr-FR', { year: 'numeric', month: '2-digit' })
              : '-';
            return `${detail.sousFamille}: ${dateStr} (${detail.quantite})`;
          }).join(' | ');
        } else {
          row[depot.deIntitule] = '-';
        }
      });
      row['Total'] = item.total;
      return row;
    });
    const worksheet = XLSX.utils.json_to_sheet(data, { header: headers });
    const workbook  = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, 'Inventaire');
    const date = new Date().toISOString().split('T')[0];
    XLSX.writeFile(workbook, `Inventaire_${filterEtat ? filterEtat.nom + '_' : ''}${date}.xlsx`);
  };

  // ── Render ────────────────────────────────────────────────────────────────
  return (
    <div className="h-full flex flex-col bg-white">

      {/* ── Top bar ── */}
      <div className="p-4 border-b border-gray-200">
        <div className="flex flex-wrap items-center justify-between gap-4">

          {/* Left: back + active filter badge */}
          <div className="flex items-center gap-2">
            <Button variant="outline" size="sm" className="text-[#3CBAAE]" onClick={() => navigate(-1)}>
              <ArrowLeft className="h-4 w-4 mr-1" />
              Retour
            </Button>
            {filterEtat && (
              <span className="bg-[#3CBAAE]/10 text-[#3CBAAE] px-3 py-1 rounded-full text-sm font-medium border border-[#3CBAAE]/20">
                Filtre: {filterEtat.nom}
              </span>
            )}
          </div>

          {/* Right: controls */}
          <div className="flex flex-wrap items-center gap-3">

            {/* Année */}
            <div className="flex items-center gap-2">
              <span className="text-sm font-medium text-gray-700">Année:</span>
              <Select value={anneeFilter} onValueChange={setAnneeFilter}>
                <SelectTrigger className="w-[120px]"><SelectValue placeholder="Toutes" /></SelectTrigger>
                <SelectContent>
                  <SelectItem value="tout">Toutes</SelectItem>
                  {annees.map(year => <SelectItem key={year} value={year.toString()}>{year}</SelectItem>)}
                </SelectContent>
              </Select>
            </div>

            {/* Sous Famille */}
            <div className="flex items-center gap-2">
              <span className="text-sm font-medium text-gray-700">Sous Famille:</span>
              <Select value={sousFamilleFilter} onValueChange={setSousFamilleFilter}>
                <SelectTrigger className="w-[180px]"><SelectValue placeholder="Toutes" /></SelectTrigger>
                <SelectContent>
                  <SelectItem value="tout">Toutes</SelectItem>
                  {sousFamillesNames.map(sf => <SelectItem key={sf} value={sf}>{sf}</SelectItem>)}
                </SelectContent>
              </Select>
            </div>

            {/* Affichage */}
            <div className="flex items-center gap-2">
              <span className="text-sm font-medium text-gray-700">Affichage:</span>
              <Select value={viewMode} onValueChange={v => setViewMode(v as ViewMode)}>
                <SelectTrigger className="w-[120px]"><SelectValue /></SelectTrigger>
                <SelectContent>
                  <SelectItem value="Date">Date</SelectItem>
                  <SelectItem value="Quantité">Quantité</SelectItem>
                  <SelectItem value="Lot">Lot</SelectItem>
                </SelectContent>
              </Select>
            </div>
          </div>
        </div>
      </div>

      {/* ── Legend (Date mode) ── */}
      {viewMode === 'Date' && (
        <div className="px-4 py-2 bg-white border-b flex flex-wrap items-center gap-2">
          <span className="text-xs font-medium px-2 py-1 bg-red-500 text-white rounded">Date échéance atteinte</span>
          <span className="text-xs font-medium px-2 py-1 bg-red-500 text-white rounded">Période critique entre 1 et 2 mois</span>
          <span className="text-xs font-medium px-2 py-1 bg-orange-500 text-white rounded">Période critique entre 3 et 5 mois</span>
          <span className="text-xs font-medium px-2 py-1 bg-yellow-500 text-black rounded">Période critique entre 6 et 8 mois</span>
          <span className="text-xs font-medium px-2 py-1 bg-blue-400 text-white rounded">Période critique 9 mois plus</span>
        </div>
      )}

      {/* ── Legend (Quantité mode) ── */}
      {viewMode === 'Quantité' && (
        <div className="px-4 py-2 bg-white border-b flex flex-wrap items-center gap-3">
          <span className="text-xs font-semibold text-gray-400 uppercase tracking-wide">Légende :</span>
          <span className="inline-flex items-center gap-1.5 text-xs font-semibold px-2 py-0.5 rounded-full bg-[#3CBAAE] text-white">
            Quantité normale
          </span>
          <span className="inline-flex items-center gap-1.5 text-xs font-semibold px-2 py-0.5 rounded-full bg-amber-400 text-gray-900">
            <WarningIcon size={13} />
            Stock = 1 (critique)
          </span>
        </div>
      )}

      {/* ── Excel button ── */}
      <div className="px-4 py-2 bg-white border-b border-gray-100">
        <Button className="bg-[#3CBAAE] hover:bg-[#35a89d]" onClick={handleExportExcel}>
          <FileSpreadsheet className="h-4 w-4 mr-2" />
          Excel
        </Button>
      </div>

      {/* ── Table ── */}
      <div className="flex-1 overflow-auto relative">

        {filteredInventory.length === 0 ? (
          <div className="flex flex-col items-center justify-center h-full text-gray-400 gap-2 py-24">
            <svg className="h-12 w-12 opacity-30" fill="none" viewBox="0 0 24 24" stroke="currentColor">
              <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={1.5}
                d="M9 17v-2a4 4 0 014-4h0a4 4 0 014 4v2M3 21h18M12 3a4 4 0 100 8 4 4 0 000-8z" />
            </svg>
            <p className="text-sm font-medium">Aucun article trouvé pour ces filtres.</p>
            {filterEtat && (
              <p className="text-xs text-gray-400">Filtre actif : <strong>{filterEtat.nom}</strong></p>
            )}
          </div>
        ) : (
          <table className="w-full border-collapse">
            <thead>
              <tr className="bg-[#3CBAAE] text-white sticky top-0 z-30 shadow-sm">
                <th className="px-3 py-2 text-left font-semibold text-xs whitespace-nowrap bg-[#3CBAAE] sticky left-0 z-40 w-24 border-r border-white/30 uppercase tracking-tight">
                  Longueur
                </th>
                <th className="px-3 py-2 text-left font-semibold text-xs whitespace-nowrap bg-[#3CBAAE] sticky left-24 z-40 w-28 border-r border-white/10 uppercase tracking-tight">
                  Diamètre
                </th>
                {displayedDepots.map(depot => (
                  <th key={depot.deNo}
                    className="px-2 py-2 text-center font-semibold text-[11px] leading-tight break-words min-w-[100px] bg-[#3CBAAE] border-r border-white/10 uppercase tracking-tight">
                    {depot.deIntitule}
                  </th>
                ))}
                <th className="px-3 py-2 text-center font-semibold text-xs whitespace-nowrap bg-[#3CBAAE] uppercase tracking-tight">
                  Total
                </th>
              </tr>
            </thead>
            <tbody>
              {filteredInventory.map((item, idx) => {
                const isNewLength = idx === 0 || item.longueur !== filteredInventory[idx - 1].longueur;
                return (
                  <tr
                    key={`${item.longueur}-${item.diametre}-${idx}`}
                    className={`${idx % 2 === 0 ? 'bg-white' : 'bg-gray-50/50'} border-b border-gray-100 ${
                      isNewLength && idx > 0 ? 'border-t-2 border-t-[#3CBAAE]/30' : ''
                    }`}
                  >
                    {/* Longueur – rowspan */}
                    {isNewLength && (
                      <td
                        className="px-3 py-1.5 font-bold text-[#3CBAAE] bg-[#f0fdfc] align-middle border-r border-[#3CBAAE]/30 sticky left-0 z-20 w-24 text-sm"
                        rowSpan={
                          filteredInventory.slice(idx).findIndex(n => n.longueur !== item.longueur) === -1
                            ? filteredInventory.length - idx
                            : filteredInventory.slice(idx).findIndex(n => n.longueur !== item.longueur)
                        }
                      >
                        {item.longueur > 0 ? item.longueur : '-'}
                      </td>
                    )}

                    {/* Diamètre */}
                    <td className="px-3 py-1.5 font-bold text-[#3CBAAE] bg-[#f0fdfc] sticky left-24 z-20 w-28 border-r border-[#3CBAAE]/10 text-sm relative">
                      {idx > 0 && item.longueur === filteredInventory[idx - 1].longueur && (
                        <div className="absolute top-0 left-2 right-2 h-[1px] bg-gray-200/60" />
                      )}
                      {item.diametre > 0 ? item.diametre.toFixed(2) : '-'}
                    </td>

                    {/* Per-depot cells */}
                    {displayedDepots.map(displayDepot => {
                      const depotData = item.depots.find(d => d.depotId === displayDepot.deNo);

                      if (viewMode === 'Quantité') {
                        const totalQty = depotData
                          ? depotData.items.reduce((sum, i) => sum + i.quantite, 0)
                          : 0;
                        return (
                          <td key={displayDepot.deNo} className="px-2 py-1.5 border-r border-gray-100 min-w-[100px] text-center">
                            {totalQty > 0 ? (
                              <div className="inline-flex flex-col items-center gap-1">
                                <span className={`inline-flex items-center justify-center h-7 min-w-[2rem] px-2 rounded-lg text-sm font-bold shadow-sm transition-colors
                                  ${totalQty === 1 ? 'bg-amber-400 text-gray-900 shadow-amber-200' : 'bg-[#3CBAAE] text-white shadow-teal-200'}`}>
                                  {totalQty}
                                </span>
                                {totalQty === 1 && (
                                  <div className="flex items-center gap-0.5" title="Dernière unité en stock — réapprovisionner">
                                    <WarningIcon size={15} />
                                  </div>
                                )}
                              </div>
                            ) : (
                              <span className="text-gray-300">-</span>
                            )}
                          </td>
                        );
                      }

                      return (
                        <td key={displayDepot.deNo} className="px-2 py-1.5 border-r border-gray-50 min-w-[100px]">
                          <div className="space-y-1">
                            {depotData && depotData.items.length > 0 ? (
                              depotData.items.map((detail, dIdx) => (
                                <div key={dIdx}>
                                  {viewMode === 'Lot' ? (
                                    <div className="text-center">
                                      <span className="text-gray-900 font-medium text-sm">
                                        {detail.lot || '-'}
                                      </span>
                                    </div>
                                  ) : (
                                    <div className={`px-2 py-1 rounded text-center text-[11px] font-bold ${getCriticalClass(detail.criticalPeriodMonths)}`}>
                                      {detail.sousFamille}:{' '}
                                      {detail.dateExpiration
                                        ? new Date(detail.dateExpiration).toLocaleDateString('fr-FR', { year: 'numeric', month: '2-digit' })
                                        : '-'}
                                      ({detail.quantite})
                                    </div>
                                  )}

                                  {viewMode === 'Date' && (
                                    <div className="flex items-center justify-center gap-2 mt-1 py-1 px-2 bg-white rounded border border-gray-200 shadow-sm h-7">
                                      <button className="text-red-500 hover:bg-red-50 p-1 rounded-full transition-all active:scale-90"
                                        onClick={async e => {
                                          e.preventDefault(); e.stopPropagation();
                                          if (detail.quantite > 0) {
                                            try {
                                              updateLocalQuantity(detail.id, -1);
                                              await inventoryApi.adjustQuantity(detail.id, -1);
                                              toast.success('Mis à jour');
                                            } catch (err: unknown) {
                                              updateLocalQuantity(detail.id, 1);
                                              toast.error(`Erreur: ${(err as any)?.response?.data || (err as Error)?.message || 'Erreur'}`);
                                            }
                                          }
                                        }}>
                                        <Minus className="h-3.5 w-3.5 stroke-[3px]" />
                                      </button>
                                      <span className="text-xs font-bold text-gray-900 w-6 text-center tabular-nums">{detail.quantite}</span>
                                      <button className="text-green-500 hover:bg-green-50 p-1 rounded-full transition-all active:scale-90"
                                        onClick={async e => {
                                          e.preventDefault(); e.stopPropagation();
                                          try {
                                            updateLocalQuantity(detail.id, 1);
                                            await inventoryApi.adjustQuantity(detail.id, 1);
                                            toast.success('Mis à jour');
                                          } catch (err: unknown) {
                                            updateLocalQuantity(detail.id, -1);
                                            toast.error(`Erreur: ${(err as any)?.response?.data || (err as Error)?.message || 'Erreur'}`);
                                          }
                                        }}>
                                        <Plus className="h-3.5 w-3.5 stroke-[3px]" />
                                      </button>
                                    </div>
                                  )}
                                </div>
                              ))
                            ) : (
                              <div className="flex justify-center">
                                <span className="text-gray-300">-</span>
                              </div>
                            )}
                          </div>
                        </td>
                      );
                    })}

                    {/* Total */}
                    <td className="px-3 py-1.5 text-center font-bold text-[#3CBAAE] bg-[#f0fdfc] border-l border-[#3CBAAE]/10 text-sm">
                      {item.total}
                    </td>
                  </tr>
                );
              })}
            </tbody>
          </table>
        )}
      </div>
    </div>
  );
}
