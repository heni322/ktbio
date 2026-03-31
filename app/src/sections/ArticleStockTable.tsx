import { useState, useMemo, useEffect, useCallback, useRef } from 'react';
import { useNavigate } from 'react-router-dom';
import * as XLSX from 'xlsx';
import {
  ArrowLeft,
  FileSpreadsheet,
  Minus,
  Plus,
  Search,
  ChevronLeft,
  ChevronRight,
  ChevronsLeft,
  ChevronsRight,
  Package,
  Filter,
  LayoutGrid,
  RefreshCw,
  TrendingUp,
  X,
} from 'lucide-react';
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

interface ArticleStockPagedResponse {
  articles: ArticleStockRow[];
  depots: DepotInfo[];
  totalCount: number;
  page: number;
  pageSize: number;
}

interface FilterRequest {
  familles: string[];
  depots: number[];
  search: string;
  page: number;
  pageSize: number;
}

// ── Helpers ──────────────────────────────────────────────────────────────────

function getCriticalClass(months: number): string {
  if (months < 0)  return 'bg-red-500    text-white';
  if (months <= 2) return 'bg-red-500    text-white';
  if (months <= 5) return 'bg-orange-500 text-white';
  if (months <= 8) return 'bg-amber-400  text-gray-900';
  return                  'bg-teal-500   text-white';
}

function getCriticalBorder(months: number): string {
  if (months < 0)  return 'border-red-200    bg-red-50';
  if (months <= 2) return 'border-red-200    bg-red-50';
  if (months <= 5) return 'border-orange-200 bg-orange-50';
  if (months <= 8) return 'border-amber-200  bg-amber-50';
  return                  'border-teal-200   bg-teal-50';
}

function formatDate(d: string | null): string {
  if (!d) return '—';
  const dt = new Date(d);
  return `${String(dt.getMonth() + 1).padStart(2, '0')}/${dt.getFullYear()}`;
}

// ── API ──────────────────────────────────────────────────────────────────────

async function fetchPage(req: FilterRequest): Promise<ArticleStockPagedResponse> {
  const res = await api.post<ArticleStockPagedResponse>('/ArticleStock/filter', req);
  return res.data;
}

async function adjustQty(id: number, delta: number) {
  await api.put(`/ArticleStock/${id}/adjust/${delta}`);
}

// ── Pagination ───────────────────────────────────────────────────────────────

function Pagination({
  page, totalPages, pageSize, totalCount,
  onPage, onPageSize,
}: {
  page: number; totalPages: number; pageSize: number; totalCount: number;
  onPage: (p: number) => void; onPageSize: (s: number) => void;
}) {
  const start = totalCount === 0 ? 0 : (page - 1) * pageSize + 1;
  const end   = Math.min(page * pageSize, totalCount);

  const pages = useMemo(() => {
    const p: (number | '…')[] = [];
    if (totalPages <= 7) { for (let i = 1; i <= totalPages; i++) p.push(i); }
    else {
      p.push(1);
      if (page > 3) p.push('…');
      for (let i = Math.max(2, page - 1); i <= Math.min(totalPages - 1, page + 1); i++) p.push(i);
      if (page < totalPages - 2) p.push('…');
      p.push(totalPages);
    }
    return p;
  }, [page, totalPages]);

  const btn = (disabled: boolean, onClick: () => void, icon: React.ReactNode) => (
    <button
      disabled={disabled} onClick={onClick}
      className="h-7 w-7 flex items-center justify-center rounded-md text-gray-500
                 hover:bg-teal-50 hover:text-teal-600 disabled:opacity-30
                 disabled:cursor-not-allowed transition-all"
    >
      {icon}
    </button>
  );

  return (
    <div className="flex flex-wrap items-center justify-between gap-3 px-4 py-2.5 bg-white border-t border-gray-100">
      <div className="flex items-center gap-3">
        <span className="text-sm text-gray-500">
          <b className="text-gray-800">{start}–{end}</b> sur{' '}
          <b className="text-gray-800">{totalCount}</b> articles
        </span>
        <div className="flex items-center gap-1.5">
          <span className="text-[11px] text-gray-400">Lignes :</span>
          <Select value={String(pageSize)} onValueChange={v => onPageSize(Number(v))}>
            <SelectTrigger className="h-7 w-16 text-xs border-gray-200">
              <SelectValue />
            </SelectTrigger>
            <SelectContent>
              {[10, 20, 50, 100].map(n => (
                <SelectItem key={n} value={String(n)} className="text-xs">{n}</SelectItem>
              ))}
            </SelectContent>
          </Select>
        </div>
      </div>

      <div className="flex items-center gap-0.5">
        {btn(page === 1, () => onPage(1), <ChevronsLeft className="h-3.5 w-3.5" />)}
        {btn(page === 1, () => onPage(page - 1), <ChevronLeft className="h-3.5 w-3.5" />)}
        {pages.map((p, i) =>
          p === '…' ? (
            <span key={`d${i}`} className="h-7 w-5 flex items-center justify-center text-gray-300 text-xs">···</span>
          ) : (
            <button
              key={p}
              onClick={() => onPage(p as number)}
              className={`h-7 w-7 flex items-center justify-center rounded-md text-xs font-medium transition-all
                ${page === p
                  ? 'bg-teal-500 text-white shadow-sm shadow-teal-200'
                  : 'text-gray-600 hover:bg-teal-50 hover:text-teal-600'}`}
            >
              {p}
            </button>
          )
        )}
        {btn(page >= totalPages || totalPages === 0, () => onPage(page + 1), <ChevronRight className="h-3.5 w-3.5" />)}
        {btn(page >= totalPages || totalPages === 0, () => onPage(totalPages), <ChevronsRight className="h-3.5 w-3.5" />)}
      </div>
    </div>
  );
}

// ── Stats bar ─────────────────────────────────────────────────────────────────

function StatsBar({ total, pageTotal, critical, pageCount }: {
  total: number; pageTotal: number; critical: number; pageCount: number;
}) {
  const stat = (icon: React.ReactNode, label: string, value: React.ReactNode, bg: string) => (
    <div className="flex items-center gap-2.5">
      <div className={`h-8 w-8 rounded-lg flex items-center justify-center ${bg}`}>{icon}</div>
      <div>
        <p className="text-[10px] text-gray-400 uppercase tracking-wide font-semibold">{label}</p>
        <p className="text-base font-bold text-gray-800 leading-none">{value}</p>
      </div>
    </div>
  );

  return (
    <div className="grid grid-cols-4 gap-2 px-4 py-2.5 bg-gradient-to-r from-slate-50 to-teal-50/20 border-b border-gray-100">
      {stat(<Package className="h-4 w-4 text-teal-600" />, 'Total articles', total.toLocaleString('fr-FR'), 'bg-teal-100')}
      {stat(<LayoutGrid className="h-4 w-4 text-indigo-600" />, 'Cette page', pageCount, 'bg-indigo-100')}
      {stat(<TrendingUp className="h-4 w-4 text-blue-600" />, 'Stock (page)', pageTotal.toLocaleString('fr-FR'), 'bg-blue-100')}
      {stat(
        <span className="text-xs font-extrabold text-red-600">!</span>,
        'Critiques (page)',
        <span className={critical > 0 ? 'text-red-600' : ''}>{critical}</span>,
        'bg-red-100'
      )}
    </div>
  );
}

// ── Main component ────────────────────────────────────────────────────────────

export function ArticleStockTable() {
  const navigate = useNavigate();

  const [resp,       setResp]       = useState<ArticleStockPagedResponse | null>(null);
  const [loading,    setLoading]    = useState(true);
  const [refreshing, setRefreshing] = useState(false);

  // Filter & pagination state (all here → single source of truth)
  const [search,      setSearch]      = useState('');
  const [searchInput, setSearchInput] = useState('');   // debounced separately
  const [famille,     setFamille]     = useState('tout');
  const [viewMode,    setViewMode]    = useState<'Date' | 'Quantité' | 'Lot'>('Date');
  const [page,        setPage]        = useState(1);
  const [pageSize,    setPageSize]    = useState(20);

  // Debounce search
  const debounceRef = useRef<ReturnType<typeof setTimeout> | null>(null);
  const handleSearchInput = (v: string) => {
    setSearchInput(v);
    if (debounceRef.current) clearTimeout(debounceRef.current);
    debounceRef.current = setTimeout(() => {
      setSearch(v);
      setPage(1);
    }, 400);
  };

  // Build request
  const buildRequest = useCallback(
    (p: number, ps: number, s: string, fam: string): FilterRequest => ({
      familles: fam !== 'tout' ? [fam] : [],
      depots:   [],
      search:   s,
      page:     p,
      pageSize: ps,
    }),
    []
  );

  const load = useCallback(
    async (p: number, ps: number, s: string, fam: string, silent = false) => {
      if (!silent) setLoading(true);
      else         setRefreshing(true);
      try {
        const data = await fetchPage(buildRequest(p, ps, s, fam));
        setResp(data);
      } catch {
        toast.error('Erreur lors du chargement du stock articles');
      } finally {
        setLoading(false);
        setRefreshing(false);
      }
    },
    [buildRequest]
  );

  // Reload when any filter / page changes
  useEffect(() => {
    load(page, pageSize, search, famille);
  }, [page, pageSize, search, famille]); // eslint-disable-line react-hooks/exhaustive-deps

  const handleFamille = (v: string) => { setFamille(v); setPage(1); };
  const handlePageSize = (s: number) => { setPageSize(s); setPage(1); };

  // Optimistic local update (no refetch needed)
  const updateLocal = (articleRef: string, id: number, delta: number) => {
    setResp(prev => prev ? ({
      ...prev,
      articles: prev.articles.map(art =>
        art.arRef !== articleRef ? art : {
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
    }) : prev);
  };

  // Derived
  const articles   = resp?.articles ?? [];
  const depots     = resp?.depots   ?? [];
  const totalCount = resp?.totalCount ?? 0;
  const totalPages = Math.ceil(totalCount / pageSize);

  const pageTotal = useMemo(() => articles.reduce((s, a) => s + a.total, 0), [articles]);
  const critical  = useMemo(
    () => articles.filter(a => a.depots.some(d => d.lots.some(l => l.criticalPeriodMonths <= 2))).length,
    [articles]
  );

  // Famille list comes from loaded data (all familles visible for current filters)
  // We also maintain a persistent list across page changes from the first load
  const [familleCodes, setFamilleCodes] = useState<string[]>([]);
  useEffect(() => {
    if (resp && famille === 'tout') {
      // Collect from current page only – not ideal but avoids extra call
      // A better approach is a dedicated /familles endpoint; this is good enough
      setFamilleCodes(prev => {
        const all = new Set([...prev, ...resp.articles.map(a => a.faCodeFamille)]);
        return Array.from(all).sort();
      });
    }
  }, [resp, famille]);

  function handleExcelExport() {
    toast.info('Export en cours… (données de la page courante)');
    const headers = ['Référence', 'Désignation', 'Famille', ...depots.map(d => d.deIntitule), 'Total'];
    const rows = articles.map(art => {
      const row: Record<string, string | number> = {
        'Référence': art.arRef,
        'Désignation': art.arDesign,
        'Famille': art.faCodeFamille,
      };
      depots.forEach(dep => {
        const d = art.depots.find(x => x.depotId === dep.deNo);
        row[dep.deIntitule] = d ? d.totalQte : 0;
      });
      row['Total'] = art.total;
      return row;
    });
    const ws = XLSX.utils.json_to_sheet(rows, { header: headers });
    const wb = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Stock Articles');
    XLSX.writeFile(wb, `StockArticles_p${page}_${new Date().toISOString().split('T')[0]}.xlsx`);
    toast.success('Export Excel généré');
  }

  // ── Loading skeleton ──────────────────────────────────────────────────────
  if (loading && !resp) {
    return (
      <div className="h-full flex flex-col bg-gray-50">
        <div className="p-4 bg-white border-b border-gray-100 space-y-3">
          <div className="h-8 w-40 bg-gray-200 rounded-lg animate-pulse" />
          <div className="flex gap-3">
            {[52, 36, 32].map(w => (
              <div key={w} className={`h-9 w-${w} bg-gray-100 rounded-lg animate-pulse`} />
            ))}
          </div>
        </div>
        <div className="flex-1 p-4 space-y-2">
          {[...Array(10)].map((_, i) => (
            <div key={i} className="h-12 bg-white rounded-xl border border-gray-100 animate-pulse"
              style={{ opacity: 1 - i * 0.08 }} />
          ))}
        </div>
        <div className="flex items-center justify-center py-8 gap-3 text-teal-600">
          <div className="animate-spin rounded-full h-5 w-5 border-2 border-teal-500 border-t-transparent" />
          <span className="text-sm font-medium">Chargement du stock…</span>
        </div>
      </div>
    );
  }

  // ── Render ────────────────────────────────────────────────────────────────
  return (
    <div className="h-full flex flex-col bg-gray-50">

      {/* ── Toolbar ── */}
      <div className="bg-white border-b border-gray-100 shadow-sm">

        {/* Title row */}
        <div className="px-4 pt-3.5 pb-2.5 flex items-center justify-between">
          <div className="flex items-center gap-3">
            <button
              onClick={() => navigate(-1)}
              className="h-8 w-8 flex items-center justify-center rounded-lg border border-gray-200
                         text-gray-500 hover:border-teal-300 hover:text-teal-600 hover:bg-teal-50 transition-all"
            >
              <ArrowLeft className="h-4 w-4" />
            </button>
            <div>
              <h1 className="text-base font-bold text-gray-900 leading-tight">Stock Articles</h1>
              <p className="text-[11px] text-gray-400">
                {totalCount.toLocaleString('fr-FR')} article{totalCount !== 1 ? 's' : ''}
                {famille !== 'tout' && <> · famille <b className="text-teal-600">{famille}</b></>}
                {search && <> · "{search}"</>}
              </p>
            </div>
          </div>

          <div className="flex items-center gap-2">
            <button
              onClick={() => load(page, pageSize, search, famille, true)}
              disabled={refreshing}
              className="h-8 w-8 flex items-center justify-center rounded-lg border border-gray-200
                         text-gray-400 hover:border-teal-300 hover:text-teal-600 hover:bg-teal-50
                         transition-all disabled:opacity-50"
              title="Actualiser"
            >
              <RefreshCw className={`h-3.5 w-3.5 ${refreshing ? 'animate-spin' : ''}`} />
            </button>
            <Button
              className="h-8 bg-teal-500 hover:bg-teal-600 text-white text-xs px-3 shadow-sm shadow-teal-200"
              onClick={handleExcelExport}
            >
              <FileSpreadsheet className="h-3.5 w-3.5 mr-1.5" />
              Exporter
            </Button>
          </div>
        </div>

        {/* Filters */}
        <div className="px-4 pb-2.5 flex flex-wrap items-center gap-2">
          {/* Search — sent to server */}
          <div className="relative">
            <Search className="h-3.5 w-3.5 absolute left-2.5 top-1/2 -translate-y-1/2 text-gray-400" />
            <input
              type="text"
              value={searchInput}
              onChange={e => handleSearchInput(e.target.value)}
              placeholder="Référence ou désignation…"
              className="pl-8 pr-7 py-1.5 text-sm border border-gray-200 rounded-lg bg-gray-50
                         focus:outline-none focus:ring-2 focus:ring-teal-400/40 focus:border-teal-400
                         w-52 placeholder:text-gray-300 transition-all"
            />
            {searchInput && (
              <button
                onClick={() => { setSearchInput(''); setSearch(''); setPage(1); }}
                className="absolute right-2 top-1/2 -translate-y-1/2 text-gray-300 hover:text-gray-500"
              >
                <X className="h-3.5 w-3.5" />
              </button>
            )}
          </div>

          <div className="h-5 w-px bg-gray-200" />

          {/* Famille */}
          <div className="flex items-center gap-1.5">
            <Filter className="h-3.5 w-3.5 text-gray-400" />
            <Select value={famille} onValueChange={handleFamille}>
              <SelectTrigger className="h-8 w-40 text-xs border-gray-200 bg-gray-50">
                <SelectValue placeholder="Toutes familles" />
              </SelectTrigger>
              <SelectContent>
                <SelectItem value="tout" className="text-xs">Toutes les familles</SelectItem>
                {familleCodes.map(c => (
                  <SelectItem key={c} value={c} className="text-xs">{c}</SelectItem>
                ))}
              </SelectContent>
            </Select>
          </div>

          {/* View mode */}
          <div className="flex items-center gap-1.5">
            <LayoutGrid className="h-3.5 w-3.5 text-gray-400" />
            <Select value={viewMode} onValueChange={v => setViewMode(v as typeof viewMode)}>
              <SelectTrigger className="h-8 w-32 text-xs border-gray-200 bg-gray-50">
                <SelectValue />
              </SelectTrigger>
              <SelectContent>
                <SelectItem value="Date" className="text-xs">Par date</SelectItem>
                <SelectItem value="Quantité" className="text-xs">Par quantité</SelectItem>
                <SelectItem value="Lot" className="text-xs">Par lot</SelectItem>
              </SelectContent>
            </Select>
          </div>

          {/* Active chips */}
          {famille !== 'tout' && (
            <span className="inline-flex items-center gap-1 px-2 py-0.5 bg-teal-100 text-teal-700 rounded-full text-[11px] font-medium">
              {famille}
              <button onClick={() => handleFamille('tout')}><X className="h-2.5 w-2.5" /></button>
            </span>
          )}
          {search && (
            <span className="inline-flex items-center gap-1 px-2 py-0.5 bg-blue-100 text-blue-700 rounded-full text-[11px] font-medium">
              "{search}"
              <button onClick={() => { setSearchInput(''); setSearch(''); setPage(1); }}><X className="h-2.5 w-2.5" /></button>
            </span>
          )}
        </div>

        {/* Legend */}
        {viewMode === 'Date' && (
          <div className="px-4 pb-2 flex flex-wrap items-center gap-1.5">
            <span className="text-[10px] font-semibold text-gray-400 uppercase tracking-wide mr-1">Légende :</span>
            {[
              { label: 'Dépassée', cls: 'bg-red-500 text-white' },
              { label: '1–2 mois', cls: 'bg-red-500 text-white' },
              { label: '3–5 mois', cls: 'bg-orange-500 text-white' },
              { label: '6–8 mois', cls: 'bg-amber-400 text-gray-900' },
              { label: '9 m+',     cls: 'bg-teal-500 text-white' },
            ].map(l => (
              <span key={l.label} className={`text-[10px] font-semibold px-2 py-0.5 rounded-full ${l.cls}`}>
                {l.label}
              </span>
            ))}
          </div>
        )}
      </div>

      {/* ── Stats ── */}
      <StatsBar
        total={totalCount}
        pageCount={articles.length}
        pageTotal={pageTotal}
        critical={critical}
      />

      {/* ── Table ── */}
      <div className="flex-1 overflow-auto relative">
        {/* Subtle overlay while refreshing */}
        {(loading || refreshing) && resp && (
          <div className="absolute inset-0 bg-white/50 z-50 flex items-center justify-center pointer-events-none">
            <div className="flex items-center gap-2 bg-white shadow-lg rounded-xl px-4 py-2 border border-gray-100">
              <div className="animate-spin rounded-full h-4 w-4 border-2 border-teal-500 border-t-transparent" />
              <span className="text-xs text-gray-600 font-medium">Chargement…</span>
            </div>
          </div>
        )}

        <table className="w-full border-collapse text-sm">
          <thead>
            <tr className="bg-gradient-to-r from-teal-600 to-teal-500 text-white sticky top-0 z-30">
              <th className="px-3 py-2.5 text-left text-[11px] font-semibold uppercase tracking-wide sticky left-0 z-40 bg-teal-600 border-r border-white/10 min-w-[120px]">
                Référence
              </th>
              <th className="px-3 py-2.5 text-left text-[11px] font-semibold uppercase tracking-wide sticky left-[120px] z-40 bg-teal-600 border-r border-white/10 min-w-[220px]">
                Désignation
              </th>
              {depots.map(dep => (
                <th key={dep.deNo} className="px-2 py-2.5 text-center text-[11px] font-semibold uppercase tracking-wide bg-teal-600 border-r border-white/10 min-w-[130px] leading-tight">
                  {dep.deIntitule}
                </th>
              ))}
              <th className="px-3 py-2.5 text-center text-[11px] font-semibold uppercase tracking-wide bg-teal-700 min-w-[80px]">
                Total
              </th>
            </tr>
          </thead>

          <tbody>
            {articles.length === 0 ? (
              <tr>
                <td colSpan={depots.length + 3} className="py-20 text-center">
                  <div className="flex flex-col items-center gap-3 text-gray-400">
                    <Package className="h-10 w-10 opacity-30" />
                    <p className="font-medium text-sm">Aucun article trouvé</p>
                    {(search || famille !== 'tout') && (
                      <button
                        className="text-xs text-teal-600 hover:underline"
                        onClick={() => { setSearchInput(''); setSearch(''); setFamille('tout'); setPage(1); }}
                      >
                        Effacer les filtres
                      </button>
                    )}
                  </div>
                </td>
              </tr>
            ) : articles.map((art, idx) => {
              const even = idx % 2 === 0;
              const base = even ? 'bg-white' : 'bg-slate-50/60';
              const hover = 'hover:bg-teal-50/30';

              return (
                <tr key={art.arRef} className={`border-b border-gray-100 transition-colors group ${base} ${hover}`}>

                  {/* Ref */}
                  <td className={`px-3 py-2.5 sticky left-0 z-20 border-r border-gray-100 min-w-[120px] ${base} group-hover:bg-teal-50/30`}>
                    <span className="font-mono text-[11px] text-gray-500 bg-gray-100 px-1.5 py-0.5 rounded">
                      {art.arRef}
                    </span>
                  </td>

                  {/* Design + famille */}
                  <td className={`px-3 py-2.5 sticky left-[120px] z-20 border-r border-gray-100 min-w-[220px] ${base} group-hover:bg-teal-50/30`}>
                    <p className="font-medium text-gray-800 text-sm leading-tight">{art.arDesign}</p>
                    <span className="mt-0.5 inline-block text-[10px] font-medium text-teal-600 bg-teal-50 px-1.5 py-0.5 rounded-full">
                      {art.faCodeFamille}
                    </span>
                  </td>

                  {/* Per depot */}
                  {depots.map(dep => {
                    const depData = art.depots.find(d => d.depotId === dep.deNo);

                    if (viewMode === 'Quantité') {
                      return (
                        <td key={dep.deNo} className="px-2 py-2.5 border-r border-gray-100 text-center min-w-[130px]">
                          {depData?.totalQte ? (
                            <span className="inline-flex items-center justify-center h-7 min-w-[2.5rem] px-2 rounded-lg bg-teal-500 text-white text-sm font-bold shadow-sm shadow-teal-200">
                              {depData.totalQte}
                            </span>
                          ) : (
                            <span className="text-gray-200">—</span>
                          )}
                        </td>
                      );
                    }

                    return (
                      <td key={dep.deNo} className="px-2 py-2 border-r border-gray-100 min-w-[130px]">
                        <div className="space-y-1.5">
                          {depData?.lots?.length ? depData.lots.map((lot, li) => (
                            <div key={li}>
                              {viewMode === 'Lot' ? (
                                <div className="text-center">
                                  <span className="inline-flex items-center px-2 py-0.5 bg-gray-100 text-gray-700 rounded text-[11px] font-medium">
                                    {lot.lot || '—'}
                                    {lot.quantite > 1 && <span className="ml-1 text-gray-400">×{lot.quantite}</span>}
                                  </span>
                                </div>
                              ) : (
                                <div className={`rounded-lg border px-2 py-1 ${getCriticalBorder(lot.criticalPeriodMonths)}`}>
                                  <div className={`px-2 py-0.5 rounded-md text-center text-[10px] font-bold mb-1 shadow-sm ${getCriticalClass(lot.criticalPeriodMonths)}`}>
                                    XD: {formatDate(lot.dateExpiration)} ({lot.quantite})
                                  </div>
                                  <div className="flex items-center justify-center gap-1.5">
                                    <button
                                      className="h-5 w-5 flex items-center justify-center rounded-full bg-white border border-red-200 text-red-500 hover:bg-red-50 hover:border-red-400 transition-all active:scale-90 shadow-sm"
                                      onClick={async () => {
                                        if (lot.quantite <= 0) return;
                                        updateLocal(art.arRef, lot.id, -1);
                                        try { await adjustQty(lot.id, -1); toast.success('Mis à jour'); }
                                        catch { updateLocal(art.arRef, lot.id, 1); toast.error('Erreur'); }
                                      }}
                                    >
                                      <Minus className="h-2.5 w-2.5 stroke-[3px]" />
                                    </button>
                                    <span className="text-xs font-bold text-gray-900 w-5 text-center tabular-nums">
                                      {lot.quantite}
                                    </span>
                                    <button
                                      className="h-5 w-5 flex items-center justify-center rounded-full bg-white border border-green-200 text-green-500 hover:bg-green-50 hover:border-green-400 transition-all active:scale-90 shadow-sm"
                                      onClick={async () => {
                                        updateLocal(art.arRef, lot.id, 1);
                                        try { await adjustQty(lot.id, 1); toast.success('Mis à jour'); }
                                        catch { updateLocal(art.arRef, lot.id, -1); toast.error('Erreur'); }
                                      }}
                                    >
                                      <Plus className="h-2.5 w-2.5 stroke-[3px]" />
                                    </button>
                                  </div>
                                </div>
                              )}
                            </div>
                          )) : (
                            <div className="flex justify-center text-gray-200 text-lg">—</div>
                          )}
                        </div>
                      </td>
                    );
                  })}

                  {/* Row total */}
                  <td className="px-3 py-2.5 text-center min-w-[80px]">
                    <span className="inline-flex items-center justify-center h-7 min-w-[2.5rem] px-2 bg-teal-600 text-white text-sm font-bold rounded-lg shadow-sm shadow-teal-300">
                      {art.total}
                    </span>
                  </td>
                </tr>
              );
            })}
          </tbody>

          {/* Footer */}
          {articles.length > 0 && (
            <tfoot className="sticky bottom-0 z-20">
              <tr className="bg-gradient-to-r from-teal-50 to-teal-100/50 border-t-2 border-teal-200">
                <td className="px-3 py-2 font-bold text-xs sticky left-0 bg-teal-50" colSpan={2}>
                  <span className="text-teal-700">Sous-total ({articles.length} articles)</span>
                  <span className="ml-2 text-[10px] text-gray-400 font-normal">/ {totalCount} total</span>
                </td>
                {depots.map(dep => {
                  const dTotal = articles.reduce((s, a) => {
                    const d = a.depots.find(x => x.depotId === dep.deNo);
                    return s + (d?.totalQte ?? 0);
                  }, 0);
                  return (
                    <td key={dep.deNo} className="px-2 py-2 text-center font-bold text-teal-700 border-r border-teal-200/50 text-sm">
                      {dTotal}
                    </td>
                  );
                })}
                <td className="px-3 py-2 text-center">
                  <span className="inline-flex items-center justify-center px-2 py-1 bg-teal-600 text-white text-sm font-bold rounded-lg">
                    {pageTotal}
                  </span>
                </td>
              </tr>
            </tfoot>
          )}
        </table>
      </div>

      {/* ── Pagination ── */}
      <Pagination
        page={page}
        totalPages={totalPages}
        pageSize={pageSize}
        totalCount={totalCount}
        onPage={setPage}
        onPageSize={handlePageSize}
      />
    </div>
  );
}
