CREATE PROCEDURE [dbo].[spAppointments_GetByDate]
	@AppointmentDate NVARCHAR(8)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT a.Id, CONCAT(b.LastName, ' ', b.FirstName) as FullName, a.AppointmentDate, a.AppointmentDuration as AppointmentDuration
		FROM Appointments a
			LEFT JOIN Patients b on a.PatientId = b.Id
		WHERE a.AppointmentDate = @AppointmentDate
		ORDER BY AppointmentDuration;
END
