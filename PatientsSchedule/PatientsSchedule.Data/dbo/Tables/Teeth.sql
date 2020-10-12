CREATE TABLE [dbo].[Teeth]
(
	[Id] INT NOT NULL IDENTITY,
	[ToothCode] INT NOT NULL,
	[ToothDescription] NVARCHAR(100)

	CONSTRAINT PK_Teeth PRIMARY KEY (Id)
)

