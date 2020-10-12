CREATE PROCEDURE [dbo].[spIntervention_GetByPatientId]
	@PatientId INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT p.Id, a.AppointmentDate, t.ToothCode, t.ToothDescription, i.[Description]
	FROM Interventions i left join Appointments a ON i.AppointmentId = a.Id
						 left join Teeth t ON i.ToothId = t.Id
						 left join Patients p ON a.PatientId = p.Id
	WHERE p.Id = @PatientId
	ORDER BY t.ToothCode;
END
