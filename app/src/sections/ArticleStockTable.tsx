import { useState, useMemo, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import * as XLSX from 'xlsx';
import { ArrowLeft, FileSpreadsheet, Minus, Plus, Search } from 'lucide-react';
import { toast } from 'sonner';
import { Button } from '@/components/ui/button';
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from '@/components/ui/select';
import api from '@/services/api';

// ── Types ────────────────────────────────────────────────────────────────────

interface DepotInfo {
  deNo: number;
  deIntitule: string;
}

interface ArticleLotDetail {
  id: number;
  lot: string;
  quantite: number;
  dateExpiration: string | null;
  criticalPeriodMonths: number;
}

interface ArticleDepotDetail {
  depotId: number;
  depotName: string;
  totalQte: number;
  lots: ArticleLotDetail[];
}

interface ArticleStockRow {
  arRef: string;
  arDesign: string;
  faCodeFamille: string;
  total: number;
  depots: ArticleDepotDetail[];
}

interface ArticleStockResponse {
  articles: ArticleStockRow[];
  depots: DepotInfo[];
}

// ── Helpers ──────────────────────────────────────────────────────────────────

function getCriticalClass(months: number): string {
  if (months < 0) return 'bg-red-500 text-white';
  if (months <= 2) return 'bg-red-500 text-white';
  if (months <= 5) return 'bg-orange-500 text-white';
  if (months <= 8) return 'bg-yellow-400 text-gray-900';
  return 'bg-[#4ec9c0] text-white';
}

function formatDate(d: string | null): string {
  if (!d) return '-';
  const dt = new Date(d);
  const mm = String(dt.getMonth() + 1).padStart(2, '0');
  const yyyy = dt.getFullYear();
  return `${mm}/${yyyy}`;
}

// ── API call ─────────────────────────────────────────────────────────────────

async function fetchArticleStock(
  familles?: string[],
  depots?: number[]
): Promise<ArticleStockResponse> {
  const res = await api.post<ArticleStockResponse>('/ArticleStock/filter', {
    familles: familles ?? [],
    depots: depots ?? [],
  });
  return res.data;
}

async function adjustQty(id: number, delta: number) {
  await api.put(`/ArticleStock/${id}/adjust/${delta}`);
}

// ── Component ─────────────────────────────────────────────────────────────────

export function ArticleStockTable() {
  const navigate = useNavigate();

  const [data, setData] = useState<ArticleStockResponse>({ articles: [], depots: [] });
  const [loading, setLoading] = useState(true);
  const [viewMode, setViewMode] = useState<'Date' | 'Quantité' | 'Lot'>('Date');
  const [search, setSearch] = useState('');
  const [familleFilter, setFamilleFilter] = useState<string>('tout');

  // load on mount – no famille filter yet (load all CARD families)
  useEffect(() => {
    load();
  }, []);

  async function load(familles?: string[], depots?: number[]) {
    setLoading(true);
    try {
      const res = await fetchArticleStock(familles, depots);
      setData(res);
    } catch {
      toast.error("Erreur lors du chargement du stock articles");
    } finally {
      setLoading(false);
    }
  }

  // Derived list of unique famille codes
  const familleCodes = useMemo(() => {
    const codes = new Set(data.articles.map(a => a.faCodeFamille));
    return Array.from(codes).sort();
  }, [data.articles]);

  // Update local quantity optimistically
  const updateLocal = (articleRef: string, id: number, delta: number) => {
    setData(prev => ({
      ...prev,
      articles: prev.articles.map(art =>
        art.arRef !== articleRef
          ? art
          : {
              ...art,
              total: art.total + delta,
              depots: art.depots.map(dep => ({
                ...dep,
                totalQte: dep.lots.some(l => l.id === id) ? dep.totalQte + delta : dep.totalQte,
                lots: dep.lots.map(l =>
                  l.id === id ? { ...l, quantite: Math.max(0, l.quantite + delta) } : l
                ),
              })),
            }
      ),
    }));
  };

  const filtered = useMemo(() => {
    let rows = data.articles;
    if (familleFilter !== 'tout') rows = rows.filter(r => r.faCodeFamille === familleFilter);
    if (search.trim()) {
      const q = search.trim().toLowerCase();
      rows = rows.filter(r => r.arDesign.toLowerCase().includes(q) || r.arRef.toLowerCase().includes(q));
    }
    return rows;
  }, [data.articles, familleFilter, search]);

  // Totals per depot (for footer)
  const depotTotals = useMemo(() => {
    const map: Record<number, number> = {};
    filtered.forEach(art => {
      art.depots.forEach(dep => {
        map[dep.depotId] = (map[dep.depotId] ?? 0) + dep.totalQte;
      });
    });
    return map;
  }, [filtered]);

  const grandTotal = useMemo(() => filtered.reduce((s, a) => s + a.total, 0), [filtered]);

  function handleExcelExport() {
    const headers = ['Référence', 'Désignation', 'Famille', ...data.depots.map(d => d.deIntitule), 'Total'];
    const rows = filtered.map(art => {
      const row: Record<string, string | number> = {
        'Référence': art.arRef,
        'Désignation': art.arDesign,
        'Famille': art.faCodeFamille,
      };
      data.depots.forEach(dep => {
        const d = art.depots.find(x => x.depotId === dep.deNo);
        row[dep.deIntitule] = d ? d.totalQte : 0;
      });
      row['Total'] = art.total;
      return row;
    });
    const ws = XLSX.utils.json_to_sheet(rows, { header: headers });
    const wb = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Stock Articles');
    XLSX.writeFile(wb, `StockArticles_${new Date().toISOString().split('T')[0]}.xlsx`);
  }

  if (loading) {
    return (
      <div className="flex items-center justify-center h-64">
        <div className="animate-spin rounded-full h-10 w-10 border-b-2 border-[#3CBAAE]" />
      </div>
    );
  }

  return (
    <div className="h-full flex flex-col bg-white">
      {/* ── Toolbar ── */}
      <div className="p-4 border-b border-gray-200 space-y-3">
        {/* Row 1 */}
        <div className="flex flex-wrap items-center justify-between gap-3">
          <Button variant="outline" size="sm" className="text-[#3CBAAE]" onClick={() => navigate(-1)}>
            <ArrowLeft className="h-4 w-4 mr-1" />
            Retour
          </Button>

          <div className="flex flex-wrap items-center gap-3">
            {/* Search */}
            <div className="relative">
              <Search className="h-3.5 w-3.5 absolute left-2.5 top-1/2 -translate-y-1/2 text-gray-400" />
              <input
                type="text"
                value={search}
                onChange={e => setSearch(e.target.value)}
                placeholder="Rechercher article..."
                className="pl-8 pr-3 py-1.5 text-sm border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-[#3CBAAE] w-48"
              />
            </div>

            {/* Famille filter */}
            <div className="flex items-center gap-2">
              <span className="text-sm font-medium text-gray-700 whitespace-nowrap">Famille :</span>
              <Select value={familleFilter} onValueChange={setFamilleFilter}>
                <SelectTrigger className="w-[130px]">
                  <SelectValue placeholder="Toutes" />
                </SelectTrigger>
                <SelectContent>
                  <SelectItem value="tout">Toutes</SelectItem>
                  {familleCodes.map(c => (
                    <SelectItem key={c} value={c}>{c}</SelectItem>
                  ))}
                </SelectContent>
              </Select>
            </div>

            {/* View mode */}
            <div className="flex items-center gap-2">
              <span className="text-sm font-medium text-gray-700 whitespace-nowrap">Affichage :</span>
              <Select value={viewMode} onValueChange={v => setViewMode(v as typeof viewMode)}>
                <SelectTrigger className="w-[120px]">
                  <SelectValue />
                </SelectTrigger>
                <SelectContent>
                  <SelectItem value="Date">Date</SelectItem>
                  <SelectItem value="Quantité">Quantité</SelectItem>
                  <SelectItem value="Lot">Lot</SelectItem>
                </SelectContent>
              </Select>
            </div>
          </div>
        </div>

        {/* Row 2 – legend + excel */}
        <div className="flex flex-wrap items-center gap-2">
          <Button className="bg-[#3CBAAE] hover:bg-[#35a89d] h-8 text-xs" onClick={handleExcelExport}>
            <FileSpreadsheet className="h-3.5 w-3.5 mr-1.5" />
            Excel
          </Button>
          {viewMode === 'Date' && (
            <>
              <span className="text-[11px] font-medium px-2 py-0.5 bg-red-500 text-white rounded">Date échéance atteinte</span>
              <span className="text-[11px] font-medium px-2 py-0.5 bg-red-500 text-white rounded">1 – 2 mois</span>
              <span className="text-[11px] font-medium px-2 py-0.5 bg-orange-500 text-white rounded">3 – 5 mois</span>
              <span className="text-[11px] font-medium px-2 py-0.5 bg-yellow-400 text-gray-900 rounded">6 – 8 mois</span>
              <span className="text-[11px] font-medium px-2 py-0.5 bg-[#4ec9c0] text-white rounded">9 mois +</span>
            </>
          )}
        </div>
      </div>

      {/* ── Table ── */}
      <div className="flex-1 overflow-auto">
        <table className="w-full border-collapse text-sm">
          <thead>
            <tr className="bg-[#3CBAAE] text-white sticky top-0 z-30 shadow">
              <th className="px-3 py-2 text-left font-semibold text-xs sticky left-0 z-40 bg-[#3CBAAE] border-r border-white/20 min-w-[120px] uppercase">
                Référence
              </th>
              <th className="px-3 py-2 text-left font-semibold text-xs sticky left-[120px] z-40 bg-[#3CBAAE] border-r border-white/20 min-w-[220px] uppercase">
                Désignation
              </th>
              {data.depots.map(dep => (
                <th key={dep.deNo} className="px-2 py-2 text-center font-semibold text-[11px] bg-[#3CBAAE] border-r border-white/10 min-w-[120px] uppercase leading-tight">
                  {dep.deIntitule}
                </th>
              ))}
              <th className="px-3 py-2 text-center font-semibold text-xs bg-[#3CBAAE] uppercase">Total</th>
            </tr>
          </thead>

          <tbody>
            {filtered.length === 0 && (
              <tr>
                <td colSpan={data.depots.length + 3} className="text-center py-12 text-gray-400 text-sm">
                  Aucun article trouvé
                </td>
              </tr>
            )}

            {filtered.map((art, idx) => (
              <tr
                key={art.arRef}
                className={`border-b border-gray-100 ${idx % 2 === 0 ? 'bg-white' : 'bg-gray-50/40'}`}
              >
                {/* Ref */}
                <td className="px-3 py-2 font-mono text-xs text-gray-600 sticky left-0 z-20 bg-inherit border-r border-gray-100 min-w-[120px]">
                  {art.arRef}
                </td>

                {/* Design */}
                <td className="px-3 py-2 font-medium text-gray-800 sticky left-[120px] z-20 bg-inherit border-r border-gray-100 min-w-[220px]">
                  {art.arDesign}
                  <span className="ml-2 text-[10px] text-gray-400 font-normal">{art.faCodeFamille}</span>
                </td>

                {/* Per depot */}
                {data.depots.map(dep => {
                  const depData = art.depots.find(d => d.depotId === dep.deNo);

                  if (viewMode === 'Quantité') {
                    return (
                      <td key={dep.deNo} className="px-2 py-2 border-r border-gray-100 text-center min-w-[120px]">
                        {depData && depData.totalQte > 0 ? (
                          <span className="font-bold text-[#3CBAAE] text-sm">{depData.totalQte}</span>
                        ) : (
                          <span className="text-gray-300 text-xs">-</span>
                        )}
                      </td>
                    );
                  }

                  return (
                    <td key={dep.deNo} className="px-2 py-2 border-r border-gray-50 min-w-[120px]">
                      <div className="space-y-1">
                        {depData && depData.lots.length > 0 ? (
                          depData.lots.map((lot, li) => (
                            <div key={li}>
                              {viewMode === 'Lot' ? (
                                <div className="text-center text-gray-800 font-medium text-xs">
                                  {lot.lot || '-'}
                                  {lot.quantite > 1 && (
                                    <span className="ml-1 text-gray-500">×{lot.quantite}</span>
                                  )}
                                </div>
                              ) : (
                                <>
                                  {/* Date pill */}
                                  <div className={`px-2 py-0.5 rounded text-center text-[11px] font-bold ${getCriticalClass(lot.criticalPeriodMonths)}`}>
                                    XD: {formatDate(lot.dateExpiration)} ({lot.quantite})
                                  </div>
                                  {/* ± controls */}
                                  <div className="flex items-center justify-center gap-2 mt-1 py-0.5 px-2 bg-white rounded border border-gray-200 shadow-sm h-6">
                                    <button
                                      className="text-red-500 hover:bg-red-50 p-0.5 rounded-full transition-all active:scale-90"
                                      onClick={async () => {
                                        if (lot.quantite <= 0) return;
                                        updateLocal(art.arRef, lot.id, -1);
                                        try {
                                          await adjustQty(lot.id, -1);
                                          toast.success('Mis à jour');
                                        } catch {
                                          updateLocal(art.arRef, lot.id, 1);
                                          toast.error('Erreur lors de la mise à jour');
                                        }
                                      }}
                                    >
                                      <Minus className="h-3 w-3 stroke-[3px]" />
                                    </button>
                                    <span className="text-xs font-bold text-gray-900 w-5 text-center tabular-nums">
                                      {lot.quantite}
                                    </span>
                                    <button
                                      className="text-green-500 hover:bg-green-50 p-0.5 rounded-full transition-all active:scale-90"
                                      onClick={async () => {
                                        updateLocal(art.arRef, lot.id, 1);
                                        try {
                                          await adjustQty(lot.id, 1);
                                          toast.success('Mis à jour');
                                        } catch {
                                          updateLocal(art.arRef, lot.id, -1);
                                          toast.error('Erreur lors de la mise à jour');
                                        }
                                      }}
                                    >
                                      <Plus className="h-3 w-3 stroke-[3px]" />
                                    </button>
                                  </div>
                                </>
                              )}
                            </div>
                          ))
                        ) : (
                          <div className="flex justify-center">
                            <span className="text-gray-300 text-xs">-</span>
                          </div>
                        )}
                      </div>
                    </td>
                  );
                })}

                {/* Total */}
                <td className="px-3 py-2 text-center font-bold text-[#3CBAAE] border-l border-[#3CBAAE]/10 bg-[#f0fdfc] text-sm">
                  {art.total}
                </td>
              </tr>
            ))}
          </tbody>

          {/* Footer totals */}
          {filtered.length > 0 && (
            <tfoot className="sticky bottom-0 z-20">
              <tr className="bg-[#e6f7f6] border-t-2 border-[#3CBAAE]/30">
                <td className="px-3 py-2 font-bold text-gray-700 text-xs sticky left-0 bg-[#e6f7f6]" colSpan={2}>
                  Total ({filtered.length} articles)
                </td>
                {data.depots.map(dep => (
                  <td key={dep.deNo} className="px-2 py-2 text-center font-bold text-[#3CBAAE] border-r border-gray-200 text-sm">
                    {depotTotals[dep.deNo] ?? 0}
                  </td>
                ))}
                <td className="px-3 py-2 text-center font-bold text-[#3CBAAE] bg-[#d4f2ef] text-sm">
                  {grandTotal}
                </td>
              </tr>
            </tfoot>
          )}
        </table>
      </div>
    </div>
  );
}
