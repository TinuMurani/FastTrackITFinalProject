CREATE TABLE [dbo].[Appointments]
(
	[Id] INT NOT NULL IDENTITY,
	[PatientId] INT NOT NULL,
	[AppointmentDate] DATETIME2 NOT NULL,
	[AppointmentDuration] NVARCHAR(8) NOT NULL 
		CHECK (CAST(SUBSTRING(AppointmentDuration, 0, 4) as INT) < CAST(SUBSTRING(AppointmentDuration, 4, 4) as INT)),

	CONSTRAINT PK_Programari PRIMARY KEY (Id),
	CONSTRAINT FK_Pacienti FOREIGN KEY (PatientId) REFERENCES Patients (Id)
)

