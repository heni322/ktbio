USE [KTBIO2014]
GO

-- Nettoyage des anciens états pour repartir sur des bases propres et fonctionnelles
DELETE FROM [dbo].[App_Etats];
GO

-- Insertion de 3 états basés sur des données réelles existantes dans la base Sage
INSERT INTO [dbo].[App_Etats] ([Nom], [FamillesJson], [UtilisateursJson], [DepotsJson])
VALUES 
(
    'INVENTAIRE CARDIOLOGIE', 
    '["CARD01","CARD04","CARD09"]', 
    '["Anis Ben Khadija","Yamen Hadhri"]', 
    '[1,5,6,8,9,38]'
),
(
    'INVENTAIRE GASTROLOGIE', 
    '["GAST09","GAST01","GAST05"]', 
    '["Anis Ben Khadija","Mourad Ben Khadija"]', 
    '[1,38]'
),
(
    'INVENTAIRE PROTHESES (PI)', 
    '["PI05","PI01","PI02"]', 
    '["Anis Ben Khadija","Marwa Troudi"]', 
    '[1,38]'
);
GO

SELECT 'Nouveaux états créés avec succès.' as Status;
GO
