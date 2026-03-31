using KTBioAPI.Models;
using KTBioAPI.Helpers;

namespace KTBioAPI.Data
{
    public static class MockData
    {
        // Default password for all seed users: "KTBio@2026"
        // Users can change their password after first login
        private const string DEFAULT_PASSWORD = "KTBio@2026";
        
        public static List<Depot> Depots { get; set; } = new()
        {
            new Depot { deNo = 1, deIntitule = "DEPOT KTBIO" },
            new Depot { deNo = 2, deIntitule = "POLYCLINIQUE TAOUFIK" },
            new Depot { deNo = 3, deIntitule = "POLYCLINIQUE EL BASSATINE" },
            new Depot { deNo = 4, deIntitule = "CLINIQUE LES BERGES DU LAC" },
            new Depot { deNo = 5, deIntitule = "POLYCLINIQUE ERRAHMA EL MAHDIA" },
            new Depot { deNo = 6, deIntitule = "CLINIQUE IBN ANNAFIS" },
            new Depot { deNo = 7, deIntitule = "CLINIQUE MUTUALISTE" },
            new Depot { deNo = 8, deIntitule = "NEURO - LA SOUKRA" },
            new Depot { deNo = 9, deIntitule = "DR BEN AYED BELHASSAN" },
            new Depot { deNo = 10, deIntitule = "RYM CHARLES NICOLLE" },
            new Depot { deNo = 11, deIntitule = "DR BEN AYED NABIL" }
        };

        // Familles mock alignées sur les 5 codes autorisés :
        // CARD01, CARD02, CARD03, CARD29, CARD30
        // (identique au filtre SQL : WHERE FA_CodeFamille IN (...))
        public static List<Famille> Familles { get; set; } = new()
        {
            new Famille { cbMarq = 1, faCodeFamille = "CARD01", faIntitule = "STENT SYNERGY" },
            new Famille { cbMarq = 2, faCodeFamille = "CARD02", faIntitule = "STENT RESOLUTE ONYX" },
            new Famille { cbMarq = 3, faCodeFamille = "CARD03", faIntitule = "STENT XIENCE SIERRA" },
            new Famille { cbMarq = 4, faCodeFamille = "CARD29", faIntitule = "STENT XIENCE" },
            new Famille { cbMarq = 5, faCodeFamille = "CARD30", faIntitule = "STENT PROMUS" },
        };

        public static List<SousFamille> SousFamilles { get; set; } = new()
        {
            new SousFamille { cbMarq = 1, code = "381205", nom = "V5/5.5", fCodeFFamille = "ONCO05", dateCreation = new DateTime(2023, 1, 15) },
            new SousFamille { cbMarq = 2, code = "381204", nom = "V4/4", fCodeFFamille = "ONCO05", dateCreation = new DateTime(2023, 2, 20) },
            new SousFamille { cbMarq = 3, code = "39666", nom = "SH", fCodeFFamille = "CARD01", dateCreation = new DateTime(2023, 3, 10) },
            new SousFamille { cbMarq = 4, code = "39222", nom = "Agent", fCodeFFamille = "CARD29", dateCreation = new DateTime(2023, 4, 5) },
            new SousFamille { cbMarq = 5, code = "39200", nom = "PP", fCodeFFamille = "CARD01", dateCreation = new DateTime(2023, 5, 12) },
            new SousFamille { cbMarq = 6, code = "39201", nom = "PE", fCodeFFamille = "CARD01", dateCreation = new DateTime(2023, 6, 8) },
            new SousFamille { cbMarq = 7, code = "39202", nom = "S", fCodeFFamille = "CARD05", dateCreation = new DateTime(2023, 7, 15) },
            new SousFamille { cbMarq = 8, code = "39203", nom = "SM", fCodeFFamille = "CARD05", dateCreation = new DateTime(2023, 8, 20) },
            new SousFamille { cbMarq = 9, code = "39204", nom = "XD", fCodeFFamille = "CARD29", dateCreation = new DateTime(2023, 9, 10) },
            new SousFamille { cbMarq = 10, code = "39205", nom = "PPs", fCodeFFamille = "CARD30", dateCreation = new DateTime(2023, 10, 5) },
            new SousFamille { cbMarq = 11, code = "39206", nom = "SH", fCodeFFamille = "CARD30", dateCreation = new DateTime(2023, 11, 12) }
        };

        // Seed users with BCrypt hashed passwords
        // Default password for all users: "KTBio@2026"
        // BCrypt hash: $2a$12$LQ7Z8VqF5X9mKxF9YZ9Z9.9Z9Z9Z9Z9Z9Z9Z9Z9Z9Z9Z9Z9Z9Z9Z9
        public static List<Utilisateur> Utilisateurs { get; set; } = new()
        {
            new Utilisateur 
            { 
                Id = 1, 
                Username = "admin", 
                PasswordHash = PasswordHelper.HashPassword(DEFAULT_PASSWORD),
                Role = "Admin", 
                FullName = "Administrateur KTBio", 
                Email = "admin@ktbio.tn" 
            },
            new Utilisateur 
            { 
                Id = 2, 
                Username = "anis.bk", 
                PasswordHash = PasswordHelper.HashPassword(DEFAULT_PASSWORD),
                Role = "Admin", 
                FullName = "Anis Ben Khadija", 
                Email = "anis@ktbio.tn" 
            },
            new Utilisateur 
            { 
                Id = 3, 
                Username = "yamen.h", 
                PasswordHash = PasswordHelper.HashPassword(DEFAULT_PASSWORD),
                Role = "User", 
                FullName = "Yamen Hadhri", 
                Email = "yamen@ktbio.tn" 
            },
            new Utilisateur 
            { 
                Id = 4, 
                Username = "mourad.bk", 
                PasswordHash = PasswordHelper.HashPassword(DEFAULT_PASSWORD),
                Role = "User", 
                FullName = "Mourad Ben Khadija", 
                Email = "mourad@ktbio.tn" 
            },
            new Utilisateur 
            { 
                Id = 5, 
                Username = "iheb.b", 
                PasswordHash = PasswordHelper.HashPassword(DEFAULT_PASSWORD),
                Role = "User", 
                FullName = "Iheb Belarbi", 
                Email = "iheb@ktbio.tn" 
            },
            new Utilisateur 
            { 
                Id = 6, 
                Username = "imen.l", 
                PasswordHash = PasswordHelper.HashPassword(DEFAULT_PASSWORD),
                Role = "User", 
                FullName = "Imen Lahouioui", 
                Email = "imen@ktbio.tn" 
            },
            new Utilisateur 
            { 
                Id = 7, 
                Username = "marwa.t", 
                PasswordHash = PasswordHelper.HashPassword(DEFAULT_PASSWORD),
                Role = "Vendeur", 
                FullName = "Marwa Troudi", 
                Email = "marwa@ktbio.tn" 
            },
            new Utilisateur 
            { 
                Id = 8, 
                Username = "ines.bk", 
                PasswordHash = PasswordHelper.HashPassword(DEFAULT_PASSWORD),
                Role = "User", 
                FullName = "Ines Ben Khadija", 
                Email = "ines@ktbio.tn" 
            },
            new Utilisateur 
            { 
                Id = 9, 
                Username = "lilia.c", 
                PasswordHash = PasswordHelper.HashPassword(DEFAULT_PASSWORD),
                Role = "User", 
                FullName = "Lilia Charmiti", 
                Email = "lilia@ktbio.tn" 
            }
        };

        public static List<Etat> Etats { get; set; } = new()
        {
            new Etat { Id = 1, Nom = "ETAT BIOLOR", Familles = new() { "BIOLOR" }, Utilisateurs = new() { "Anis Ben Khadija" }, Depots = new() { 1 } },
            new Etat { Id = 2, Nom = "ETAT CARDIOLOGIE", Familles = new() { "CARDIO" }, Utilisateurs = new() { "Anis Ben Khadija", "Yamen Hadhri" }, Depots = new() { 1, 2 } },
            new Etat { Id = 3, Nom = "ETAT ONCOLOGIE", Familles = new() { "ONCO07" }, Utilisateurs = new() { "Yamen Hadhri", "Mourad Ben Khadija", "Iheb Belarbi" }, Depots = new() { 1, 2, 3 } },
            new Etat { Id = 4, Nom = "ETAT UROLOGIE", Familles = new() { "UR12" }, Utilisateurs = new() { "Iheb Belarbi", "Anis Ben Khadija", "Mourad Ben Khadija" }, Depots = new() { 1, 2, 3, 4 } },
            new Etat { Id = 5, Nom = "ETAT GENERAL", Familles = new() { "CARD01", "CARD05", "CARD29", "CARD30" }, Utilisateurs = new() { "Administrateur KTBio" }, Depots = new() { 1, 2, 3, 4, 5 } }
        };

        public static List<InventoryItem> InventoryItems { get; set; } = GenerateInventoryItems();

        private static List<InventoryItem> GenerateInventoryItems()
        {
            var items = new List<InventoryItem>();
            var random = new Random(42);
            var sousFamilles = new[] { "XD", "SH", "PP", "PE", "S", "SM", "PPs" };
            var longueurs = new[] { 12m, 8m, 15m, 18m, 20m, 22m, 25m, 28m, 30m, 38m };
            var diametres = new[] { 2.25m, 2.50m, 2.75m, 3.00m, 3.50m, 4.00m, 4.50m, 5.00m, 5.50m, 6.00m };
            
            int id = 1;
            
            foreach (var longueur in longueurs)
            {
                foreach (var diametre in diametres)
                {
                    foreach (var depot in Depots.Take(7))
                    {
                        var sf = sousFamilles[random.Next(sousFamilles.Length)];
                        var qty = random.Next(0, 10);
                        
                        if (qty > 0)
                        {
                            var monthsToAdd = random.Next(-3, 24);
                            var expDate = DateTime.Now.AddMonths(monthsToAdd);
                            var criticalMonths = monthsToAdd < 0 ? -1 : monthsToAdd;
                            
                            items.Add(new InventoryItem
                            {
                                Id = id++,
                                CodeFamille = "CARD01",
                                ReferenceArticle = $"39262-{random.Next(1000, 9999)}",
                                Designation = "STENT SYNERGY",
                                SousFamille = sf,
                                Longueur = longueur,
                                Diametre = diametre,
                                DepotId = depot.deNo,
                                DepotName = depot.deIntitule,
                                Quantite = qty,
                                DateExpiration = expDate,
                                Lot = $"LOT{random.Next(10000, 99999)}",
                                CriticalPeriodMonths = criticalMonths
                            });
                        }
                    }
                }
            }
            
            return items;
        }
        
        /// <summary>
        /// Get information about default seed users
        /// </summary>
        public static string GetDefaultUserInfo()
        {
            return $@"
╔══════════════════════════════════════════════════════════════════╗
║                   SEED USERS INFORMATION                         ║
╠══════════════════════════════════════════════════════════════════╣
║ Default Password for ALL users: {DEFAULT_PASSWORD}                    ║
║                                                                  ║
║ Users:                                                           ║
║   1. admin (Admin)         - admin@ktbio.tn                      ║
║   2. anis.bk (Admin)       - anis@ktbio.tn                       ║
║   3. yamen.h (User)        - yamen@ktbio.tn                      ║
║   4. mourad.bk (User)      - mourad@ktbio.tn                     ║
║   5. iheb.b (User)         - iheb@ktbio.tn                       ║
║   6. imen.l (User)         - imen@ktbio.tn                       ║
║   7. marwa.t (Vendeur)     - marwa@ktbio.tn                      ║
║   8. ines.bk (User)        - ines@ktbio.tn                       ║
║   9. lilia.c (User)        - lilia@ktbio.tn                      ║
║                                                                  ║
║ Total Seed Data:                                                 ║
║   - Depots: 11                                                   ║
║   - Familles: 10                                                 ║
║   - SousFamilles: 11                                             ║
║   - Utilisateurs: 9                                              ║
║   - Etats: 5                                                     ║
║   - InventoryItems: ~Generated dynamically                       ║
╚══════════════════════════════════════════════════════════════════╝
";
        }
    }
}
