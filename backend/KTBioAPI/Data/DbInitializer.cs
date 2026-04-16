using KTBioAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace KTBioAPI.Data
{
    public static class DbInitializer
    {
        // Codes de familles autorisés — cohérent avec FamilleController
        private static readonly string[] FamilleAllowedCodes =
            { "CARD01", "CARD02", "CARD03", "CARD29", "CARD30" };

        public static void Initialize(KTBioContext context)
        {
            Console.WriteLine("\n" + new string('=', 70));
            Console.WriteLine("                 KTBio API - Database Initialization");
            Console.WriteLine(new string('=', 70) + "\n");

            // ── 1. Créer uniquement les tables App_ qui appartiennent à l'appli ──
            // NOTE: App_Depots et App_Familles sont supprimées — on lit directement
            //       depuis F_DEPOT et F_FAMILLE (Sage).
            context.Database.ExecuteSqlRaw(@"
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[App_SousFamilles]') AND type = 'U')
                CREATE TABLE [dbo].[App_SousFamilles] (
                    [cbMarq]       INT           PRIMARY KEY,
                    [code]         NVARCHAR(50)  NOT NULL,
                    [nom]          NVARCHAR(200) NOT NULL,
                    [fCodeFFamille] NVARCHAR(50) NOT NULL,
                    [dateCreation] DATETIME      NOT NULL
                );

                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[App_Utilisateurs]') AND type = 'U')
                CREATE TABLE [dbo].[App_Utilisateurs] (
                    [Id]           INT IDENTITY(1,1) PRIMARY KEY,
                    [Username]     NVARCHAR(100) NOT NULL,
                    [PasswordHash] NVARCHAR(400) NOT NULL,
                    [Role]         NVARCHAR(50)  NOT NULL,
                    [FullName]     NVARCHAR(200) NOT NULL,
                    [Email]        NVARCHAR(200) NOT NULL
                );

                -- Élargir PasswordHash si nécessaire (migration en place)
                IF EXISTS (
                    SELECT 1 FROM sys.columns c
                    JOIN sys.objects o ON c.object_id = o.object_id
                    WHERE o.name = 'App_Utilisateurs' AND c.name = 'PasswordHash' AND c.max_length < 400
                )
                BEGIN
                    ALTER TABLE [dbo].[App_Utilisateurs] ALTER COLUMN [PasswordHash] NVARCHAR(400) NOT NULL;
                END

                -- FIX CRITIQUE : rendre Id IDENTITY si la table a été créée sans
                -- (cas seed_users_manual.sql qui crée Id INT PRIMARY KEY sans IDENTITY)
                IF EXISTS (
                    SELECT 1 FROM sys.columns c
                    JOIN sys.objects o ON c.object_id = o.object_id
                    WHERE o.name = 'App_Utilisateurs' AND c.name = 'Id' AND c.is_identity = 0
                )
                BEGIN
                    SELECT * INTO [dbo].[App_Utilisateurs_Backup] FROM [dbo].[App_Utilisateurs];
                    DROP TABLE [dbo].[App_Utilisateurs];
                    CREATE TABLE [dbo].[App_Utilisateurs] (
                        [Id]           INT IDENTITY(1,1) PRIMARY KEY,
                        [Username]     NVARCHAR(100) NOT NULL,
                        [PasswordHash] NVARCHAR(400) NOT NULL,
                        [Role]         NVARCHAR(50)  NOT NULL,
                        [FullName]     NVARCHAR(200) NOT NULL,
                        [Email]        NVARCHAR(200) NOT NULL
                    );
                    SET IDENTITY_INSERT [dbo].[App_Utilisateurs] ON;
                    INSERT INTO [dbo].[App_Utilisateurs] (Id, Username, PasswordHash, Role, FullName, Email)
                    SELECT Id, Username, PasswordHash, Role, FullName, Email
                    FROM [dbo].[App_Utilisateurs_Backup];
                    SET IDENTITY_INSERT [dbo].[App_Utilisateurs] OFF;
                    DROP TABLE [dbo].[App_Utilisateurs_Backup];
                    PRINT 'App_Utilisateurs.Id migré vers IDENTITY(1,1) avec succès.';
                END

                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[App_InventoryItems]') AND type = 'U')
                CREATE TABLE [dbo].[App_InventoryItems] (
                    [Id]                  INT            PRIMARY KEY,
                    [CodeFamille]         NVARCHAR(50)   NOT NULL,
                    [ReferenceArticle]    NVARCHAR(100)  NOT NULL,
                    [Designation]         NVARCHAR(200)  NOT NULL,
                    [SousFamille]         NVARCHAR(100)  NOT NULL,
                    [Longueur]            DECIMAL(18,2)  NOT NULL,
                    [Diametre]            DECIMAL(18,2)  NOT NULL,
                    [DepotId]             INT            NOT NULL,
                    [DepotName]           NVARCHAR(200)  NOT NULL,
                    [Quantite]            INT            NOT NULL,
                    [DateExpiration]      DATETIME       NOT NULL,
                    [Lot]                 NVARCHAR(100)  NOT NULL,
                    [CriticalPeriodMonths] INT           NOT NULL
                );

                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[App_Etats]') AND type = 'U')
                CREATE TABLE [dbo].[App_Etats] (
                    [Id]              INT IDENTITY(1,1) PRIMARY KEY,
                    [Nom]             NVARCHAR(100)     NOT NULL,
                    [FamillesJson]    NVARCHAR(MAX)     NOT NULL,
                    [UtilisateursJson] NVARCHAR(MAX)    NOT NULL,
                    [DepotsJson]      NVARCHAR(MAX)     NOT NULL
                );

                -- Supprimer les anciennes tables App_Familles et App_Depots
                -- (maintenant on lit directement depuis F_FAMILLE et F_DEPOT)
                IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[App_Familles]') AND type = 'U')
                BEGIN
                    DROP TABLE [dbo].[App_Familles];
                    PRINT 'Table App_Familles supprimée — lecture désormais depuis F_FAMILLE.';
                END

                IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[App_Depots]') AND type = 'U')
                BEGIN
                    DROP TABLE [dbo].[App_Depots];
                    PRINT 'Table App_Depots supprimée — lecture désormais depuis F_DEPOT.';
                END
            ");

            Console.WriteLine("✓ Tables App_ vérifiées / créées");
            Console.WriteLine("✓ Migration IDENTITY vérifiée sur App_Utilisateurs");
            Console.WriteLine("✓ App_Familles et App_Depots supprimées (lecture directe Sage)");

            bool seededAny = false;

            // ── 2. Seed SousFamilles ─────────────────────────────────────────
            if (!context.SousFamilles.Any())
            {
                context.SousFamilles.AddRange(MockData.SousFamilles);
                context.SaveChanges();
                Console.WriteLine($"✓ Seeded {MockData.SousFamilles.Count} SousFamilles");
                seededAny = true;
            }
            else
            {
                // UPDATE existing SousFamilles codes to correct values from Excel
                // FIX: Use YYYYMMDD date format (no dashes) to avoid SQL Server locale
                //      datetime conversion errors (varchar → datetime out of range).
                context.Database.ExecuteSqlRaw(@"
                    DELETE FROM [dbo].[App_SousFamilles];
                    INSERT INTO [dbo].[App_SousFamilles] ([cbMarq],[code],[nom],[fCodeFFamille],[dateCreation]) VALUES
                    (1,  '39417', 'XD',  'CARD01', '20230115'),
                    (2,  '39666', 'SH',  'CARD01', '20230220'),
                    (3,  '39399', 'PPs', 'CARD01', '20230310'),
                    (4,  '39427', 'SM',  'CARD01', '20230405'),
                    (5,  '39413', 'PE',  'CARD01', '20230512'),
                    (6,  '39273', 'R',   'CARD02', '20230608'),
                    (7,  '39124', 'Q',   'CARD03', '20230715'),
                    (8,  '39276', 'NCE', 'CARD03', '20230820'),
                    (9,  '39193', 'E',   'CARD03', '20230910'),
                    (10, '39195', 'OTW', 'CARD03', '20231005'),
                    (11, '39222', 'DCB', 'CARD29', '20231112'),
                    (12, '39403', 'CB',  'CARD30', '20231201');
                ");
                Console.WriteLine("✓ SousFamilles updated with correct codes from Excel");
            }

            // ── 3. Seed Utilisateurs ─────────────────────────────────────────
            if (!context.Utilisateurs.Any())
            {
                context.Utilisateurs.AddRange(MockData.Utilisateurs);
                context.SaveChanges();
                Console.WriteLine($"✓ Seeded {MockData.Utilisateurs.Count} Utilisateurs");
                seededAny = true;
            }

            // ── 4. Seed InventoryItems ───────────────────────────────────────
            if (!context.InventoryItems.Any())
            {
                context.InventoryItems.AddRange(MockData.InventoryItems);
                context.SaveChanges();
                Console.WriteLine($"✓ Seeded {MockData.InventoryItems.Count} InventoryItems");
                seededAny = true;
            }

            // ── 5. Seed Etats ────────────────────────────────────────────────
            if (!context.Etats.Any())
            {
                context.Etats.AddRange(new List<EtatEntity>
                {
                    new() { Nom = "ETAT BIOLOR",      FamillesJson = "[\"BIOLOR\"]",                                   UtilisateursJson = "[\"Anis Ben Khadija\"]",                                        DepotsJson = "[1]"         },
                    new() { Nom = "ETAT CARDIOLOGIE", FamillesJson = "[\"CARDIO\"]",                                   UtilisateursJson = "[\"Anis Ben Khadija\",\"Yamen Hadhri\"]",                       DepotsJson = "[1,2]"       },
                    new() { Nom = "ETAT ONCOLOGIE",   FamillesJson = "[\"ONCO07\"]",                                   UtilisateursJson = "[\"Yamen Hadhri\",\"Mourad Ben Khadija\",\"Iheb Belarbi\"]",   DepotsJson = "[1,2,3]"     },
                    new() { Nom = "ETAT UROLOGIE",    FamillesJson = "[\"UR12\"]",                                     UtilisateursJson = "[\"Iheb Belarbi\",\"Anis Ben Khadija\",\"Mourad Ben Khadija\"]", DepotsJson = "[1,2,3,4]"  },
                    new() { Nom = "ETAT GENERAL",     FamillesJson = "[\"CARD01\",\"CARD02\",\"CARD03\",\"CARD29\",\"CARD30\"]", UtilisateursJson = "[\"Administrateur KTBio\"]",                         DepotsJson = "[1,2,3,4,5]" }
                });
                context.SaveChanges();
                Console.WriteLine("✓ Seeded 5 Etats");
                seededAny = true;
            }

            // ── 6. Rapport ───────────────────────────────────────────────────
            if (seededAny)
            {
                Console.WriteLine("\n" + new string('-', 70));
                Console.WriteLine(MockData.GetDefaultUserInfo());
                Console.WriteLine(new string('-', 70));
            }
            else
            {
                Console.WriteLine("\n✓ Base déjà initialisée — aucune nouvelle donnée insérée");
                Console.WriteLine("  Enregistrements existants :");
                Console.WriteLine($"    - SousFamilles : {context.SousFamilles.Count()}");
                Console.WriteLine($"    - Utilisateurs : {context.Utilisateurs.Count()}");
                Console.WriteLine($"    - InventoryItems : {context.InventoryItems.Count()}");
                Console.WriteLine($"    - Etats : {context.Etats.Count()}");
            }

            // ── 7. Vérification de la connexion Sage ─────────────────────────
            try
            {
                var nbDepots   = context.FDepots.Count();
                var nbFamilles = context.FFamilles
                    .Count(f => FamilleAllowedCodes.Contains(f.FaCodeFamille.Trim()));

                Console.WriteLine($"\n✓ Sage connecté — {nbDepots} dépôts, {nbFamilles} familles autorisées trouvées");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n⚠ Impossible de lire les tables Sage (F_DEPOT / F_FAMILLE) : {ex.Message}");
                Console.WriteLine("  → Vérifiez la connexion à MEGATRON\\SQLEXPRESS");
            }

            Console.WriteLine("\n" + new string('=', 70));
            Console.WriteLine("                    Database Ready ✓");
            Console.WriteLine(new string('=', 70) + "\n");
        }
    }
}
