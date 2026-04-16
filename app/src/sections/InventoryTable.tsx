import { useState, useMemo, useEffect, useRef } from 'react';
import { useNavigate, useLocation } from 'react-router-dom';
import * as XLSX from 'xlsx';
import { ArrowLeft, FileSpreadsheet } from 'lucide-react';
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
  activeSousFamilleCode?: string;
  onSousFamilleChange?: (code: string) => void;
}

type ViewMode = 'Date' | 'Quantité' | 'Lot';

export function InventoryTable({ inventory: initialInventory, depots, allSousFamilles, activeSousFamilleCode = '', onSousFamilleChange }: InventoryTableProps) {
  const navigate   = useNavigate();
  const location   = useLocation();
  const filterEtat = location.state?.filterEtat as Etat | undefined;

  const [inventory, setInventory] = useState(initialInventory);
  const [anneeFilter, setAnneeFilter] = useState<string>('tout');
  const [viewMode, setViewMode]       = useState<ViewMode>('Date');

  const sousFamilleFilter = useMemo(() => {
    if (!activeSousFamilleCode) return 'tout';
    const sf = allSousFamilles.find(s => s.code === activeSousFamilleCode);
    return sf?.nom ?? 'tout';
  }, [activeSousFamilleCode, allSousFamilles]);

  useEffect(() => { setInventory(initialInventory); }, [initialInventory]);

  const filterEtatId = filterEtat?.id ?? null;
  const prevEtatIdRef = useRef<number | null | undefined>(undefined);
  useEffect(() => {
    if (prevEtatIdRef.current === undefined) { prevEtatIdRef.current = filterEtatId; return; }
    if (prevEtatIdRef.current !== filterEtatId) {
      prevEtatIdRef.current = filterEtatId;
      setAnneeFilter('tout');
      onSousFamilleChange?.('');
    }
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [filterEtatId]);

  // FIX 2 : si aucune sous-famille ne correspond aux familles de l'etat,
  // on retourne TOUTES les sous-familles pour ne pas laisser le dropdown vide.
  const relevantSousFamilles = useMemo(() => {
    if (!filterEtat || filterEtat.familles.length === 0) return allSousFamilles;
    const filtered = allSousFamilles.filter(sf => filterEtat.familles.includes(sf.fCodeFFamille));
    return filtered.length > 0 ? filtered : allSousFamilles;
  }, [allSousFamilles, filterEtat]);

  const sousFamillesNames = useMemo(() => relevantSousFamilles.map(sf => sf.nom), [relevantSousFamilles]);

  const displayedDepots = useMemo(() => {
    if (!filterEtat || filterEtat.depots.length === 0) return depots;
    return depots.filter(d => filterEtat.depots.includes(d.deNo));
  }, [depots, filterEtat]);

  const annees = useMemo(() => {
    const years = new Set<number>();
    inventory.forEach(item =>
      item.depots.forEach(depot =>
        depot.items.forEach(detail => {
          if (detail.dateExpiration) years.add(new Date(detail.dateExpiration).getFullYear());
        })
      )
    );
    return Array.from(years).sort();
  }, [inventory]);

  const filteredInventory = useMemo(() => {
    return inventory
      .map(item => {
        const filteredDepots = item.depots
          .filter(d => displayedDepots.some(dd => dd.deNo === d.depotId))
          .map(d => ({
            ...d,
            items: d.items.filter(detail => {
              return anneeFilter === 'tout' ||
                (detail.dateExpiration &&
                  new Date(detail.dateExpiration).getFullYear().toString() === anneeFilter);
            }),
          }));
        const total = filteredDepots.reduce((sum, d) => sum + d.items.reduce((s, i) => s + i.quantite, 0), 0);
        return { ...item, depots: filteredDepots, total };
      })
      .filter(item => item.total > 0);
  }, [inventory, anneeFilter, displayedDepots]);

  // ── Column sums ───────────────────────────────────────────────────────────
  const columnSums = useMemo(() => {
    const sums: Record<number, number> = {};
    displayedDepots.forEach(depot => {
      sums[depot.deNo] = filteredInventory.reduce((acc, item) => {
        const depotData = item.depots.find(d => d.depotId === depot.deNo);
        if (!depotData) return acc;
        return acc + depotData.items.reduce((s, i) => s + i.quantite, 0);
      }, 0);
    });
    return sums;
  }, [filteredInventory, displayedDepots]);

  const totalSum = useMemo(() => filteredInventory.reduce((acc, item) => acc + item.total, 0), [filteredInventory]);

  // ── Compute rowspans for Longueur and Diamètre columns ───────────────────
  const rowMeta = useMemo(() => {
    return filteredInventory.map((item, idx) => {
      let longueurSpan = 0;
      if (idx === 0 || item.longueur !== filteredInventory[idx - 1].longueur) {
        for (let j = idx; j < filteredInventory.length; j++) {
          if (filteredInventory[j].longueur === item.longueur) longueurSpan++;
          else break;
        }
      }

      let diametreSpan = 0;
      const sameLongueur = idx === 0 || item.longueur !== filteredInventory[idx - 1].longueur;
      const sameLongueurAndDiametre =
        idx > 0 &&
        item.longueur === filteredInventory[idx - 1].longueur &&
        item.diametre === filteredInventory[idx - 1].diametre;

      if (sameLongueur || !sameLongueurAndDiametre) {
        for (let j = idx; j < filteredInventory.length; j++) {
          if (
            filteredInventory[j].longueur === item.longueur &&
            filteredInventory[j].diametre === item.diametre
          ) diametreSpan++;
          else break;
        }
      }

      return { longueurSpan, diametreSpan };
    });
  }, [filteredInventory]);

  // ── Bug Fix 3: couleurs distinctes pour date dépassée vs critique ─────────
  const getCriticalClass = (months: number): string => {
    if (months < 0)   return 'bg-gray-900 text-white';        // Date DÉPASSÉE  → noir/gris foncé
    if (months === 0) return 'bg-purple-700 text-white';      // Expire ce mois → violet foncé
    if (months <= 2)  return 'bg-red-500 text-white';         // 1-2 mois       → rouge
    if (months <= 5)  return 'bg-orange-500 text-white';      // 3-5 mois       → orange
    if (months <= 8)  return 'bg-yellow-500 text-gray-900';   // 6-8 mois       → jaune
    return 'bg-blue-400 text-white';                           // 9+ mois        → bleu
  };

  // ── Bug Fix 2: Excel avec fusion Longueur + ligne TOTAL ──────────────────
  const handleExportExcel = () => {
    const headers = ['Longueur', 'Diamètre', ...displayedDepots.map(d => d.deIntitule), 'Total'];

    // Données lignes
    const data = filteredInventory.map(item => {
      const row: Record<string, unknown> = {
        'Longueur': item.longueur ?? '—',
        'Diamètre': item.diametre != null ? item.diametre : '—',
      };
      displayedDepots.forEach(depot => {
        const depotData = item.depots.find(d => d.depotId === depot.deNo);
        if (depotData && depotData.items.length > 0) {
          if (viewMode === 'Quantité') {
            row[depot.deIntitule] = depotData.items.reduce((s, i) => s + i.quantite, 0);
          } else if (viewMode === 'Lot') {
            row[depot.deIntitule] = depotData.items.map(i => i.lot || '-').join(' | ');
          } else {
            row[depot.deIntitule] = depotData.items.map(detail => {
              const dateStr = detail.dateExpiration
                ? new Date(detail.dateExpiration).toLocaleDateString('fr-FR', { year: 'numeric', month: '2-digit' })
                : '-';
              return `${detail.sousFamille}: ${dateStr} (${detail.quantite})`;
            }).join(' | ');
          }
        } else {
          row[depot.deIntitule] = '-';
        }
      });
      row['Total'] = item.total;
      return row;
    });

    // Ligne TOTAL en bas
    const totalRow: Record<string, unknown> = { 'Longueur': 'TOTAL', 'Diamètre': '' };
    displayedDepots.forEach(d => { totalRow[d.deIntitule] = columnSums[d.deNo] ?? 0; });
    totalRow['Total'] = totalSum;
    data.push(totalRow);

    const worksheet = XLSX.utils.json_to_sheet(data, { header: headers });

    // ── Fusion des cellules Longueur (colonne A, index 0) ─────────────────
    const merges: XLSX.Range[] = [];
    let groupStart = 1; // ligne 0 = en-tête
    for (let i = 1; i <= filteredInventory.length; i++) {
      const currLon = filteredInventory[i]?.longueur;
      const prevLon = filteredInventory[i - 1]?.longueur;
      if (currLon !== prevLon || i === filteredInventory.length) {
        if (i - groupStart > 0) {
          // fusion de groupStart à i (inclus), colonne 0 = Longueur
          merges.push({ s: { r: groupStart, c: 0 }, e: { r: i, c: 0 } });
        }
        groupStart = i + 1;
      }
    }
    if (merges.length) worksheet['!merges'] = merges;

    // ── Largeurs colonnes ─────────────────────────────────────────────────
    worksheet['!cols'] = [
      { wch: 12 },
      { wch: 10 },
      ...displayedDepots.map(() => ({ wch: 22 })),
      { wch: 10 },
    ];

    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, 'Inventaire');
    const date = new Date().toISOString().split('T')[0];
    XLSX.writeFile(workbook, `Inventaire_${filterEtat ? filterEtat.nom + '_' : ''}${date}.xlsx`);
  };

  return (
    <div className="h-screen flex flex-col bg-white overflow-hidden">

      {/* ── Top bar ── */}
      <div className="flex-shrink-0 p-4 border-b border-gray-200 bg-white z-10">
        <div className="flex flex-wrap items-center justify-between gap-4">
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
              <Select
                value={sousFamilleFilter}
                onValueChange={(nom) => {
                  if (nom === 'tout') {
                    onSousFamilleChange?.('');
                  } else {
                    const sf = allSousFamilles.find(s => s.nom === nom);
                    onSousFamilleChange?.(sf?.code ?? nom);
                  }
                }}
              >
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

            {/* Export Excel */}
            <Button className="bg-[#3CBAAE] hover:bg-[#35a89d]" onClick={handleExportExcel}>
              <FileSpreadsheet className="h-4 w-4 mr-2" />
              Excel
            </Button>
          </div>
        </div>
      </div>

      {/* ── Legend (Date mode) ── */}
      {viewMode === 'Date' && (
        <div className="flex-shrink-0 px-4 py-2 bg-white border-b flex flex-wrap items-center gap-2">
          <span className="text-xs font-medium px-2 py-1 bg-gray-900 text-white rounded">Date dépassée</span>
          <span className="text-xs font-medium px-2 py-1 bg-purple-700 text-white rounded">Expire ce mois</span>
          <span className="text-xs font-medium px-2 py-1 bg-red-500 text-white rounded">1-2 mois</span>
          <span className="text-xs font-medium px-2 py-1 bg-orange-500 text-white rounded">3-5 mois</span>
          <span className="text-xs font-medium px-2 py-1 bg-yellow-500 text-black rounded">6-8 mois</span>
          <span className="text-xs font-medium px-2 py-1 bg-blue-400 text-white rounded">9 mois+</span>
        </div>
      )}

      {/* ── Table wrapper — scrollable in BOTH directions ── */}
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
          <table className="border-collapse" style={{ minWidth: '100%' }}>
            <thead>
              <tr className="bg-[#3CBAAE] text-white" style={{ position: 'sticky', top: 0, zIndex: 30 }}>
                <th className="px-3 py-2 text-left font-semibold text-xs whitespace-nowrap uppercase tracking-tight border-r border-white/30 w-24"
                  style={{ position: 'sticky', left: 0, zIndex: 40, background: '#3CBAAE' }}>
                  Longueur
                </th>
                <th className="px-3 py-2 text-left font-semibold text-xs whitespace-nowrap uppercase tracking-tight border-r border-white/10 w-28"
                  style={{ position: 'sticky', left: '6rem', zIndex: 40, background: '#3CBAAE' }}>
                  Diamètre
                </th>
                {displayedDepots.map(depot => (
                  <th key={depot.deNo}
                    className="px-2 py-2 text-center font-semibold text-[11px] leading-tight break-words min-w-[100px] border-r border-white/10 uppercase tracking-tight"
                    style={{ background: '#3CBAAE' }}>
                    {depot.deIntitule}
                  </th>
                ))}
                <th className="px-3 py-2 text-center font-semibold text-xs whitespace-nowrap uppercase tracking-tight"
                  style={{ background: '#3CBAAE' }}>
                  Total
                </th>
              </tr>
            </thead>
            <tbody>
              {filteredInventory.map((item, idx) => {
                const { longueurSpan, diametreSpan } = rowMeta[idx];
                const rowBg = idx % 2 === 0 ? '#ffffff' : '#f9fafb';

                return (
                  <tr
                    key={`${item.longueur}-${item.diametre}-${idx}`}
                    className={`border-b border-gray-100 ${
                      longueurSpan > 0 && idx > 0 ? 'border-t-2 border-t-[#3CBAAE]/30' : ''
                    }`}
                    style={{ background: rowBg }}
                  >
                    {/* ── Longueur ── */}
                    {longueurSpan > 0 && (
                      <td
                        rowSpan={longueurSpan}
                        className="px-3 py-1.5 font-bold text-[#3CBAAE] align-middle border-r border-[#3CBAAE]/30 w-24 text-sm"
                        style={{ position: 'sticky', left: 0, zIndex: 20, background: '#f0fdfc' }}
                      >
                        {item.longueur > 0 ? item.longueur : '-'}
                      </td>
                    )}

                    {/* ── Diamètre ── */}
                    {diametreSpan > 0 && (
                      <td
                        rowSpan={diametreSpan}
                        className="px-3 py-1.5 font-bold text-[#3CBAAE] align-middle w-28 border-r border-[#3CBAAE]/10 text-sm"
                        style={{ position: 'sticky', left: '6rem', zIndex: 20, background: '#f0fdfc' }}
                      >
                        {item.diametre > 0 ? item.diametre.toFixed(2) : '-'}
                      </td>
                    )}

                    {/* ── Per-depot cells ── */}
                    {displayedDepots.map(displayDepot => {
                      const depotData = item.depots.find(d => d.depotId === displayDepot.deNo);

                      if (viewMode === 'Quantité') {
                        const totalQty = depotData
                          ? depotData.items.reduce((sum, i) => sum + i.quantite, 0)
                          : 0;
                        return (
                          <td key={displayDepot.deNo} className="px-2 py-1.5 border-r border-gray-100 min-w-[100px] text-center">
                            {totalQty > 0 ? (
                              <span className={`inline-flex items-center justify-center h-7 min-w-[2rem] px-2 rounded-lg text-sm font-bold shadow-sm
                                ${totalQty === 1 ? 'bg-amber-400 text-gray-900 shadow-amber-200' : 'bg-[#3CBAAE] text-white shadow-teal-200'}`}>
                                {totalQty}
                              </span>
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
                                <div
                                  key={dIdx}
                                  className={`px-2 py-1 rounded text-center text-[11px] font-bold cursor-default ${
                                    viewMode === 'Date'
                                      ? getCriticalClass(detail.criticalPeriodMonths)
                                      : 'bg-blue-400 text-white'
                                  }`}
                                >
                                  {detail.sousFamille}:{' '}
                                  {viewMode === 'Lot'
                                    ? (detail.lot || '-')
                                    : detail.dateExpiration
                                        ? new Date(detail.dateExpiration).toLocaleDateString('fr-FR', { year: 'numeric', month: '2-digit' })
                                        : '-'}
                                  {' '}({detail.quantite})
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

                    {/* ── Total ── */}
                    <td className="px-3 py-1.5 text-center font-bold text-[#3CBAAE] border-l border-[#3CBAAE]/10 text-sm"
                      style={{ background: '#f0fdfc' }}>
                      {item.total}
                    </td>
                  </tr>
                );
              })}
            </tbody>

            {/* ── Totals / sums footer row ── */}
            <tfoot>
              <tr style={{ position: 'sticky', bottom: 0, zIndex: 30, background: '#0f766e' }}>
                <td
                  colSpan={2}
                  className="px-3 py-2 font-bold text-white text-xs uppercase tracking-tight border-r border-white/20"
                  style={{ position: 'sticky', left: 0, zIndex: 40, background: '#0f766e' }}
                >
                  TOTAL
                </td>
                {displayedDepots.map(depot => (
                  <td key={depot.deNo} className="px-2 py-2 text-center border-r border-white/10">
                    {columnSums[depot.deNo] > 0 ? (
                      <span className="inline-flex items-center justify-center h-6 min-w-[2rem] px-2 rounded-md text-xs font-bold bg-white/20 text-white">
                        {columnSums[depot.deNo]}
                      </span>
                    ) : (
                      <span className="text-white/40 text-xs">-</span>
                    )}
                  </td>
                ))}
                <td className="px-3 py-2 text-center font-bold text-white text-sm">
                  {totalSum}
                </td>
              </tr>
            </tfoot>
          </table>
        )}
      </div>
    </div>
  );
}
