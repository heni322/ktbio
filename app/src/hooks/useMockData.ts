import { useState } from 'react';
import type { Depot, Famille, SousFamille, Utilisateur, Etat, InventoryGroupView } from '@/types';

const mockDepots: Depot[] = [
  { deNo: 1, deIntitule: "DEPOT KTBIO" },
  { deNo: 2, deIntitule: "POLYCLINIQUE TAOUFIK" },
  { deNo: 3, deIntitule: "POLYCLINIQUE EL BASSATINE" },
  { deNo: 4, deIntitule: "CLINIQUE LES BERGES DU LAC" },
  { deNo: 5, deIntitule: "POLYCLINIQUE ERRAHMA EL MAHDIA" },
  { deNo: 6, deIntitule: "CLINIQUE IBN ANNAFIS" },
  { deNo: 7, deIntitule: "CLINIQUE MUTUALISTE" },
  { deNo: 8, deIntitule: "NEURO - LA SOUKRA" },
  { deNo: 9, deIntitule: "DR BEN AYED BELHASSAN" },
  { deNo: 10, deIntitule: "RYM CHARLES NICOLLE" },
  { deNo: 11, deIntitule: "DR BEN AYED NABIL" },
];

const initialMockFamilles: Famille[] = [
  { cbMarq: 1, faCodeFamille: "CARD01", faIntitule: "STENT SYNERGY" },
  { cbMarq: 2, faCodeFamille: "CARD05", faIntitule: "STENT RESOLUTE" },
  { cbMarq: 3, faCodeFamille: "CARD29", faIntitule: "STENT XIENCE" },
  { cbMarq: 4, faCodeFamille: "CARD30", faIntitule: "STENT PROMUS" },
  { cbMarq: 5, faCodeFamille: "ONCO05", faIntitule: "ONCOLOGIE" },
  { cbMarq: 6, faCodeFamille: "ONCO06", faIntitule: "CHIMIOTHERAPIE" },
];

const mockSousFamilles: SousFamille[] = [
  { cbMarq: 1, code: "381205", nom: "V5/5.5", fCodeFFamille: "ONCO05", dateCreation: "2023-01-15T00:00:00" },
  { cbMarq: 2, code: "381204", nom: "V4/4", fCodeFFamille: "ONCO05", dateCreation: "2023-02-20T00:00:00" },
  { cbMarq: 3, code: "39666", nom: "SH", fCodeFFamille: "CARD01", dateCreation: "2023-03-10T00:00:00" },
  { cbMarq: 4, code: "39222", nom: "Agent", fCodeFFamille: "CARD29", dateCreation: "2023-04-05T00:00:00" },
  { cbMarq: 5, code: "39200", nom: "PP", fCodeFFamille: "CARD01", dateCreation: "2023-05-12T00:00:00" },
  { cbMarq: 6, code: "39201", nom: "PE", fCodeFFamille: "CARD01", dateCreation: "2023-06-08T00:00:00" },
  { cbMarq: 7, code: "39202", nom: "S", fCodeFFamille: "CARD05", dateCreation: "2023-07-15T00:00:00" },
  { cbMarq: 8, code: "39203", nom: "SM", fCodeFFamille: "CARD05", dateCreation: "2023-08-20T00:00:00" },
  { cbMarq: 9, code: "39204", nom: "XD", fCodeFFamille: "CARD29", dateCreation: "2023-09-10T00:00:00" },
  { cbMarq: 10, code: "39205", nom: "PPs", fCodeFFamille: "CARD30", dateCreation: "2023-10-05T00:00:00" },
  { cbMarq: 11, code: "39206", nom: "SH", fCodeFFamille: "CARD30", dateCreation: "2023-11-12T00:00:00" }
];

const mockUtilisateurs: Utilisateur[] = [
  { id: 1, username: "anis.bk", fullName: "Anis Ben Khadija", email: "anis@ktbio.tn", role: "Admin" },
  { id: 2, username: "yamen.h", fullName: "Yamen Hadhri", email: "yamen@ktbio.tn", role: "User" },
  { id: 3, username: "mourad.bk", fullName: "Mourad Ben Khadija", email: "mourad@ktbio.tn", role: "User" },
];

const mockEtats: Etat[] = [
  { id: 1, nom: "TEST", familles: ["CARD01"], utilisateurs: ["Anis Ben Khadija"], depots: [1] },
];

const sousFamillesList = ["XD", "SH", "PP", "PE", "S", "SM", "PPs"];

function generateMockInventory(): InventoryGroupView[] {
  const items: InventoryGroupView[] = [];
  const longueurs = [12, 8, 15, 18, 20, 22, 25, 28, 30, 38];
  const diametres = [2.25, 2.50, 2.75, 3.00, 3.50, 4.00, 4.50, 5.00, 5.50, 6.00];

  let itemId = 1;
  for (const longueur of longueurs) {
    for (const diametre of diametres) {
      const depots: InventoryGroupView['depots'] = [];
      let total = 0;

      for (const depot of mockDepots) {
        const sf = sousFamillesList[Math.floor(Math.random() * sousFamillesList.length)];
        const qty = Math.floor(Math.random() * 10);

        if (qty > 0) {
          const monthsToAdd = Math.floor(Math.random() * 27) - 3;
          const expDate = new Date();
          expDate.setMonth(expDate.getMonth() + monthsToAdd);

          depots.push({
            depotId: depot.deNo,
            depotName: depot.deIntitule,
            items: [{
              id: itemId++,
              sousFamille: sf,
              quantite: qty,
              dateExpiration: expDate.toISOString(),
              lot: `LOT${Math.floor(Math.random() * 90000) + 10000}`,
              criticalPeriodMonths: monthsToAdd
            }]
          });
          total += qty;
        } else {
          depots.push({
            depotId: depot.deNo,
            depotName: depot.deIntitule,
            items: []
          });
        }
      }

      if (total > 0) {
        items.push({ longueur, diametre, depots, total });
      }
    }
  }

  return items.sort((a, b) => a.longueur - b.longueur || a.diametre - b.diametre);
}

export function useMockData() {
  const [etats, setEtats] = useState<Etat[]>(mockEtats);
  const [familles, setFamilles] = useState<Famille[]>(initialMockFamilles);

  const addEtat = (etat: Omit<Etat, 'id'>) => {
    const newEtat = { ...etat, id: Math.max(...etats.map(e => e.id), 0) + 1 };
    setEtats([...etats, newEtat]);
    return newEtat;
  };

  const updateEtat = (id: number, etat: Omit<Etat, 'id'>) => {
    setEtats(etats.map(e => e.id === id ? { ...etat, id } : e));
  };

  const deleteEtat = (id: number) => {
    setEtats(etats.filter(e => e.id !== id));
  };

  const addFamille = (famille: Omit<Famille, 'cbMarq'>) => {
    const newFamille = { ...famille, cbMarq: Math.max(...familles.map(f => f.cbMarq), 0) + 1 };
    setFamilles([...familles, newFamille]);
    return newFamille;
  };

  return {
    depots: mockDepots,
    familles,
    sousFamilles: mockSousFamilles,
    utilisateurs: mockUtilisateurs,
    etats,
    inventory: generateMockInventory(),
    addEtat,
    updateEtat,
    deleteEtat,
    addFamille
  };
}
