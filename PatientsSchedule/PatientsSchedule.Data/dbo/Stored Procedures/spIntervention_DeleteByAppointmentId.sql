CREATE PROCEDURE [dbo].[spIntervention_DeleteByAppointmentId]
	@AppointmentId INT
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM Interventions
	WHERE AppointmentId = @AppointmentId;
END
