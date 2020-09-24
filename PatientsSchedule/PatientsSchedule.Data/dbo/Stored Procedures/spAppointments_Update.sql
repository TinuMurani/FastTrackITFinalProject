CREATE PROCEDURE [dbo].[spAppointments_Update]
	@Id INT,
	@PatientId INT,
	@AppointmentDate DATETIME2(7),
	@AppointmentDuration NVARCHAR(8)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE Appointments
	SET PatientId = @PatientId, AppointmentDate = @AppointmentDate, AppointmentDuration = @AppointmentDuration
	WHERE Id = @Id;
END
