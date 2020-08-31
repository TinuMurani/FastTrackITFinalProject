CREATE PROCEDURE [dbo].[spAppointments_GetById]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [PatientId], [AppointmentDate], [AppointmentDuration] FROM Appointments
	WHERE Id = @Id;
END
