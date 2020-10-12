CREATE PROCEDURE [dbo].[spIntervention_GetByAppointmentId]
	@AppointmentId INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT AppointmentId, ToothId, [Description]
	FROM Interventions
	WHERE AppointmentId = @AppointmentId;
END
