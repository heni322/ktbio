using KTBioAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace KTBioAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(KTBioContext context)
        {
            // Manually create tables if they don't exist
            context.Database.ExecuteSqlRaw(@"
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[App_Depots]') AND type = 'U')
                CREATE TABLE [dbo].[App_Depots] (
                    [deNo] INT PRIMARY KEY,
                    [deIntitule] NVARCHAR(200) NOT NULL
                );

                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[App_Familles]') AND type = 'U')
                CREATE TABLE [dbo].[App_Familles] (
                    [cbMarq] INT PRIMARY KEY,
                    [faCodeFamille] NVARCHAR(50) NOT NULL,
                    [faIntitule] NVARCHAR(200) NOT NULL
                );

                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[App_SousFamilles]') AND type = 'U')
                CREATE TABLE [dbo].[App_SousFamilles] (
                    [cbMarq] INT PRIMARY KEY,
                    [code] NVARCHAR(50) NOT NULL,
                    [nom] NVARCHAR(200) NOT NULL,
                    [fCodeFFamille] NVARCHAR(50) NOT NULL,
                    [dateCreation] DATETIME NOT NULL
                );

                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[App_Utilisateurs]') AND type = 'U')
                CREATE TABLE [dbo].[App_Utilisateurs] (
                    [Id] INT PRIMARY KEY,
                    [Username] NVARCHAR(100) NOT NULL,
                    [PasswordHash] NVARCHAR(200) NOT NULL,
                    [Role] NVARCHAR(50) NOT NULL,
                    [FullName] NVARCHAR(200) NOT NULL,
                    [Email] NVARCHAR(200) NOT NULL
                );

                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[App_InventoryItems]') AND type = 'U')
                CREATE TABLE [dbo].[App_InventoryItems] (
                    [Id] INT PRIMARY KEY,
                    [CodeFamille] NVARCHAR(50) NOT NULL,
                    [ReferenceArticle] NVARCHAR(100) NOT NULL,
                    [Designation] NVARCHAR(200) NOT NULL,
                    [SousFamille] NVARCHAR(100) NOT NULL,
                    [Longueur] DECIMAL(18,2) NOT NULL,
                    [Diametre] DECIMAL(18,2) NOT NULL,
                    [DepotId] INT NOT NULL,
                    [DepotName] NVARCHAR(200) NOT NULL,
                    [Quantite] INT NOT NULL,
                    [DateExpiration] DATETIME NOT NULL,
                    [Lot] NVARCHAR(100) NOT NULL,
                    [CriticalPeriodMonths] INT NOT NULL
                );

                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[App_Etats]') AND type = 'U')
                CREATE TABLE [dbo].[App_Etats] (
                    [Id] INT IDENTITY(1,1) PRIMARY KEY,
                    [Nom] NVARCHAR(100) NOT NULL,
                    [FamillesJson] NVARCHAR(MAX) NOT NULL,
                    [UtilisateursJson] NVARCHAR(MAX) NOT NULL,
                    [DepotsJson] NVARCHAR(MAX) NOT NULL
                );
            ");

            // Seed Depots
            if (!context.Depots.Any())
            {
                context.Depots.AddRange(MockData.Depots);
                context.SaveChanges();
                Console.WriteLine($"[DB] Seeded {MockData.Depots.Count} Depots.");
            }

            // Seed Familles
            if (!context.Familles.Any())
            {
                context.Familles.AddRange(MockData.Familles);
                context.SaveChanges();
                Console.WriteLine($"[DB] Seeded {MockData.Familles.Count} Familles.");
            }

            // Seed SousFamilles
            if (!context.SousFamilles.Any())
            {
                context.SousFamilles.AddRange(MockData.SousFamilles);
                context.SaveChanges();
                Console.WriteLine($"[DB] Seeded {MockData.SousFamilles.Count} SousFamilles.");
            }

            // Seed Utilisateurs
            if (!context.Utilisateurs.Any())
            {
                context.Utilisateurs.AddRange(MockData.Utilisateurs);
                context.SaveChanges();
                Console.WriteLine($"[DB] Seeded {MockData.Utilisateurs.Count} Utilisateurs.");
            }

            // Seed InventoryItems
            if (!context.InventoryItems.Any())
            {
                context.InventoryItems.AddRange(MockData.InventoryItems);
                context.SaveChanges();
                Console.WriteLine($"[DB] Seeded {MockData.InventoryItems.Count} InventoryItems.");
            }

            // Seed Etats
            if (!context.Etats.Any())
            {
                context.Etats.AddRange(new List<EtatEntity>
                {
                    new() { Nom = "ETAT BIOLOR",      FamillesJson = "[\"BIOLOR\"]",  UtilisateursJson = "[\"Anis Ben Khadija\"]",                    DepotsJson = "[1]"       },
                    new() { Nom = "ETAT CARDIOLOGIE", FamillesJson = "[\"CARDIO\"]",  UtilisateursJson = "[\"Anis Ben Khadija\"]",                    DepotsJson = "[1,2]"     },
                    new() { Nom = "ETAT ONCO",        FamillesJson = "[\"ONCO07\"]",  UtilisateursJson = "[\"Yamen Hadhri\",\"Mourad Ben Khadija\"]", DepotsJson = "[1,2,3]"   },
                    new() { Nom = "ETAT UR12",        FamillesJson = "[\"UR12\"]",    UtilisateursJson = "[\"Iheb Belarbi\",\"Anis Ben Khadija\"]",   DepotsJson = "[1,2,3,4]" }
                });
                context.SaveChanges();
                Console.WriteLine("[DB] Seeded Etats.");
            }
        }
    }
}