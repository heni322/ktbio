USE [KTBIO2014]
GO

SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
SET ARITHABORT ON
SET CONCAT_NULL_YIELDS_NULL ON
SET QUOTED_IDENTIFIER ON
GO

INSERT INTO [dbo].[F_COLLABORATEUR] ([CO_No], [CO_Nom], [CO_Prenom], [CO_Email], [CO_Vendeur])
VALUES 
(1, 'Ben Khadija', 'Anis', 'anis@ktbio.tn', 1),
(2, 'Hadhri', 'Yamen', 'yamen@ktbio.tn', 0),
(3, 'Ben Khadija', 'Mourad', 'mourad@ktbio.tn', 0),
(4, 'Belarbi', 'Iheb', 'iheb@ktbio.tn', 0),
(5, 'Lahouioui', 'Imen', 'imen@ktbio.tn', 0),
(6, 'Troudi', 'Marwa', 'marwa@ktbio.tn', 0),
(7, 'Ben Khadija', 'Ines', 'ines@ktbio.tn', 0),
(8, 'Charmiti', 'Lilia', 'lilia@ktbio.tn', 0);
GO
