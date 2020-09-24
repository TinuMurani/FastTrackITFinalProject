CREATE PROCEDURE [dbo].[spAppointments_GetByDate]
	@AppointmentDate DATETIME2(7)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT a.Id, b.Id as PatientId, CONCAT(b.LastName, ' ', b.FirstName) as FullName, a.AppointmentDate, a.AppointmentDuration as AppointmentDuration
		FROM Appointments a
			LEFT JOIN Patients b on a.PatientId = b.Id
		WHERE a.AppointmentDate = @AppointmentDate
		ORDER BY AppointmentDuration;
END
