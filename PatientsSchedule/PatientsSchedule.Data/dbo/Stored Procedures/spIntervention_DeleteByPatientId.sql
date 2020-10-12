CREATE PROCEDURE [dbo].[spIntervention_DeleteByPatientId]
	@PatientId INT
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM Interventions
	WHERE AppointmentId 
		IN (SELECT Id FROM Appointments WHERE PatientId = @PatientId);
END