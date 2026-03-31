-- ============================================================
-- Script de migration : rendre App_Utilisateurs.Id IDENTITY
-- À exécuter UNE SEULE FOIS sur KTBIO2014 si la table existe
-- déjà avec Id INT PRIMARY KEY (sans IDENTITY).
-- ============================================================

USE KTBIO2014;
GO

-- 1. Vérifier si la colonne Id est déjà IDENTITY
IF EXISTS (
    SELECT 1 FROM sys.columns c
    JOIN sys.objects o ON c.object_id = o.object_id
    WHERE o.name = 'App_Utilisateurs'
      AND c.name = 'Id'
      AND c.is_identity = 0
)
BEGIN
    PRINT 'Migration nécessaire : Id n''est pas IDENTITY. Démarrage de la migration...';

    -- 2. Sauvegarder les données existantes
    SELECT * INTO App_Utilisateurs_Backup FROM App_Utilisateurs;

    -- 3. Supprimer l'ancienne table
    DROP TABLE App_Utilisateurs;

    -- 4. Recréer avec IDENTITY et PasswordHash plus large
    CREATE TABLE [dbo].[App_Utilisateurs] (
        [Id]           INT IDENTITY(1,1) PRIMARY KEY,
        [Username]     NVARCHAR(100)     NOT NULL,
        [PasswordHash] NVARCHAR(400)     NOT NULL,
        [Role]         NVARCHAR(50)      NOT NULL,
        [FullName]     NVARCHAR(200)     NOT NULL,
        [Email]        NVARCHAR(200)     NOT NULL
    );

    -- 5. Réinsérer les données (Id sera réattribué par IDENTITY)
    SET IDENTITY_INSERT App_Utilisateurs ON;
    INSERT INTO App_Utilisateurs (Id, Username, PasswordHash, Role, FullName, Email)
    SELECT Id, Username, PasswordHash, Role, FullName, Email
    FROM App_Utilisateurs_Backup;
    SET IDENTITY_INSERT App_Utilisateurs OFF;

    -- 6. Supprimer la sauvegarde
    DROP TABLE App_Utilisateurs_Backup;

    PRINT 'Migration terminée avec succès.';
END
ELSE
BEGIN
    -- Juste élargir PasswordHash si elle est trop courte
    IF EXISTS (
        SELECT 1 FROM sys.columns c
        JOIN sys.objects o ON c.object_id = o.object_id
        WHERE o.name = 'App_Utilisateurs'
          AND c.name = 'PasswordHash'
          AND c.max_length < 400
    )
    BEGIN
        ALTER TABLE App_Utilisateurs ALTER COLUMN [PasswordHash] NVARCHAR(400) NOT NULL;
        PRINT 'PasswordHash élargi à NVARCHAR(400).';
    END

    PRINT 'App_Utilisateurs.Id est déjà IDENTITY — aucune migration nécessaire.';
END
GO
