-- ============================================================
-- Script de nettoyage et synchronisation des Familles / Dépôts
-- Base : KTBIO2014
-- À exécuter MANUELLEMENT dans SSMS si les tables App_ existent déjà
-- Le DbInitializer le fera automatiquement au prochain démarrage.
-- ============================================================

USE KTBIO2014;
GO

PRINT '======================================================';
PRINT ' Nettoyage des tables App_Familles et App_Depots';
PRINT '======================================================';

-- 1. Supprimer App_Familles (lecture désormais depuis F_FAMILLE)
IF EXISTS (
    SELECT * FROM sys.objects
    WHERE object_id = OBJECT_ID(N'[dbo].[App_Familles]') AND type = 'U'
)
BEGIN
    DROP TABLE [dbo].[App_Familles];
    PRINT '✓ Table App_Familles supprimée.';
END
ELSE
BEGIN
    PRINT '  App_Familles n''existait pas — rien à faire.';
END

-- 2. Supprimer App_Depots (lecture désormais depuis F_DEPOT)
IF EXISTS (
    SELECT * FROM sys.objects
    WHERE object_id = OBJECT_ID(N'[dbo].[App_Depots]') AND type = 'U'
)
BEGIN
    DROP TABLE [dbo].[App_Depots];
    PRINT '✓ Table App_Depots supprimée.';
END
ELSE
BEGIN
    PRINT '  App_Depots n''existait pas — rien à faire.';
END

PRINT '';
PRINT '======================================================';
PRINT ' Vérification des données sources Sage';
PRINT '======================================================';

-- 3. Afficher les dépôts disponibles dans Sage
PRINT '';
PRINT '--- Dépôts (F_DEPOT) ---';
SELECT DE_No, DE_Intitule
FROM dbo.F_DEPOT
ORDER BY DE_No;

-- 4. Afficher les familles autorisées dans Sage
PRINT '';
PRINT '--- Familles filtrées (F_FAMILLE) ---';
SELECT FA_CodeFamille, FA_Intitule
FROM dbo.F_FAMILLE
WHERE FA_CodeFamille IN ('CARD01', 'CARD02', 'CARD03', 'CARD29', 'CARD30')
ORDER BY FA_CodeFamille;

PRINT '';
PRINT '======================================================';
PRINT ' Terminé. Redémarrez l''API pour appliquer les changements.';
PRINT '======================================================';
GO
