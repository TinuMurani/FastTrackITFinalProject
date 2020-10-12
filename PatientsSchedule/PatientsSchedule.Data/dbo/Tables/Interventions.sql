CREATE TABLE [dbo].[Interventions]
(
	[Id] INT NOT NULL IDENTITY,
	[AppointmentId] INT NOT NULL,
	[ToothId] INT NOT NULL,
	[Description] NVARCHAR(500)

	CONSTRAINT PK_Interventions PRIMARY KEY (Id),
	CONSTRAINT FK_Appointments FOREIGN KEY (AppointmentId) REFERENCES Appointments (Id),
	CONSTRAINT FK_Teeth FOREIGN KEY (ToothId) REFERENCES Teeth (Id)
)
