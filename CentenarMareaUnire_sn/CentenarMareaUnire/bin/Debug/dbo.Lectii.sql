CREATE TABLE [dbo].[Lectii]
(
	[IdLectie] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdUtilizator] INT NULL, 
    [TitluLectie] VARCHAR(50) NULL, 
    [Regiune] VARCHAR(50) NULL, 
    [DataCreare] DATETIME NULL, 
    [NumeImagine] VARCHAR(50) NULL
)
