USE [KTBIO2014]
GO

SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
GO

-- Disable triggers safely
IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'TG_CBINS_F_COLLABORATEUR')
    DISABLE TRIGGER [TG_CBINS_F_COLLABORATEUR] ON [F_COLLABORATEUR];
IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'TG_CBDEL_F_COLLABORATEUR')
    DISABLE TRIGGER [TG_CBDEL_F_COLLABORATEUR] ON [F_COLLABORATEUR];
GO

-- Clean up any tests
DELETE FROM [F_COLLABORATEUR] WHERE [CO_No] BETWEEN 1 AND 99;
GO

-- Insert test users
INSERT INTO [F_COLLABORATEUR] ([CO_No], [CO_Nom], [CO_Prenom], [CO_EMail], [CO_Vendeur], [cbCreateur])
VALUES 
(1, 'Ben Khadija', 'Anis', 'anis@ktbio.tn', 1, 'ADM'),
(2, 'Hadhri', 'Yamen', 'yamen@ktbio.tn', 0, 'ADM'),
(3, 'Ben Khadija', 'Mourad', 'mourad@ktbio.tn', 0, 'ADM'),
(4, 'Belarbi', 'Iheb', 'iheb@ktbio.tn', 0, 'ADM'),
(5, 'Lahouioui', 'Imen', 'imen@ktbio.tn', 0, 'ADM'),
(6, 'Troudi', 'Marwa', 'marwa@ktbio.tn', 0, 'ADM'),
(7, 'Ben Khadija', 'Ines', 'ines@ktbio.tn', 0, 'ADM'),
(8, 'Charmiti', 'Lilia', 'lilia@ktbio.tn', 0, 'ADM');
GO

-- Re-enable triggers
IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'TG_CBINS_F_COLLABORATEUR')
    ENABLE TRIGGER [TG_CBINS_F_COLLABORATEUR] ON [F_COLLABORATEUR];
IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'TG_CBDEL_F_COLLABORATEUR')
    ENABLE TRIGGER [TG_CBDEL_F_COLLABORATEUR] ON [F_COLLABORATEUR];
GO

SELECT 'Import successful: ' + CAST(COUNT(*) AS VARCHAR) + ' users in table.' FROM F_COLLABORATEUR;
GO
