CREATE PROCEDURE [dbo].[spAppointments_GetById]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT a.[PatientId], CONCAT(b.LastName, ' ', b.FirstName) as FullName, a.[AppointmentDate], a.[AppointmentDuration] 
	FROM Appointments a
		LEFT JOIN Patients b on a.PatientId = b.Id
	WHERE a.Id = @Id;
END
