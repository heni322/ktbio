const fs = require('fs');
const path = 'C:\\Users\\heniz\\Desktop\\j\\j\\app\\src\\sections\\ArticleStockTable.tsx';

let content = fs.readFileSync(path, 'utf8');

const oldExcel = `  function handleExcelExport() {
    toast.info('Export en cours\u2026');
    const headers = ['Longueur', 'Diam\u00e8tre', 'R\u00e9f\u00e9rence', 'D\u00e9signation', 'Famille',
      ...depots.map(d => d.deIntitule), 'Total'];
    const rows = articles.map(art => {
      const row: Record<string, string | number> = {
        'Longueur':    art.longueur  ?? '\u2014',
        'Diam\u00e8tre':    art.diametre  != null ? art.diametre.toFixed(1) : '\u2014',
        'R\u00e9f\u00e9rence':   art.arRef,
        'D\u00e9signation': art.arDesign,
        'Famille':     art.faCodeFamille,
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
    XLSX.writeFile(wb, \`StockArticles_p\${page}_\${new Date().toISOString().split('T')[0]}.xlsx\`);
    toast.success('Export Excel g\u00e9n\u00e9r\u00e9');
  }`;

const newExcel = `  // Bug Fix 2: Excel avec fusion Longueur + ligne TOTAL + largeurs colonnes
  function handleExcelExport() {
    toast.info('Export en cours\u2026');
    const headers = ['Longueur', 'Diam\u00e8tre', 'R\u00e9f\u00e9rence', 'D\u00e9signation', 'Famille',
      ...depots.map(d => d.deIntitule), 'Total'];

    // Lignes de donn\u00e9es
    const rows: Record<string, string | number>[] = articles.map(art => {
      const row: Record<string, string | number> = {
        'Longueur':    art.longueur  ?? '\u2014',
        'Diam\u00e8tre':    art.diametre  != null ? art.diametre.toFixed(1) : '\u2014',
        'R\u00e9f\u00e9rence':   art.arRef,
        'D\u00e9signation': art.arDesign,
        'Famille':     art.faCodeFamille,
      };
      depots.forEach(dep => {
        const d = art.depots.find(x => x.depotId === dep.deNo);
        row[dep.deIntitule] = d ? d.totalQte : 0;
      });
      row['Total'] = art.total;
      return row;
    });

    // Ligne TOTAL (sous-total de la page)
    const totalRow: Record<string, string | number> = {
      'Longueur': 'TOTAL', 'Diam\u00e8tre': '', 'R\u00e9f\u00e9rence': '',
      'D\u00e9signation': \`\${articles.length} articles (page \${page})\`, 'Famille': '',
    };
    depots.forEach(dep => {
      totalRow[dep.deIntitule] = articles.reduce((s, a) => {
        const d = a.depots.find(x => x.depotId === dep.deNo);
        return s + (d?.totalQte ?? 0);
      }, 0);
    });
    totalRow['Total'] = pageTotal;
    rows.push(totalRow);

    const ws = XLSX.utils.json_to_sheet(rows, { header: headers });

    // Fusion des cellules Longueur (colonne A = index 0) pour les groupes identiques
    const merges: XLSX.Range[] = [];
    let groupStart = 1; // ligne 1 = premi\u00e8re donn\u00e9e (ligne 0 = en-t\u00eate)
    for (let i = 1; i <= articles.length; i++) {
      const currLon = articles[i]?.longueur;
      const prevLon = articles[i - 1]?.longueur;
      if (currLon !== prevLon || i === articles.length) {
        if (i - groupStart > 0) {
          merges.push({ s: { r: groupStart, c: 0 }, e: { r: i, c: 0 } });
        }
        groupStart = i + 1;
      }
    }
    if (merges.length) ws['!merges'] = merges;

    // Largeurs colonnes
    ws['!cols'] = [
      { wch: 10 }, { wch: 10 }, { wch: 16 }, { wch: 30 }, { wch: 12 },
      ...depots.map(() => ({ wch: 16 })),
      { wch: 10 },
    ];

    const wb = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Stock Articles');
    XLSX.writeFile(wb, \`StockArticles_p\${page}_\${new Date().toISOString().split('T')[0]}.xlsx\`);
    toast.success('Export Excel g\u00e9n\u00e9r\u00e9');
  }`;

if (content.includes(oldExcel)) {
  content = content.replace(oldExcel, newExcel);
  fs.writeFileSync(path, content, 'utf8');
  console.log('handleExcelExport patched OK');
} else {
  console.log('handleExcelExport NOT FOUND - trying substring search');
  const idx = content.indexOf('function handleExcelExport()');
  console.log('Found at index:', idx);
}
