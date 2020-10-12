CREATE PROCEDURE [dbo].[spIntervention_Insert]
	@AppointmentId INT,
	@ToothId INT,
	@Description NVARCHAR(500)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Interventions (AppointmentId, ToothId, [Description])
	VALUES (@AppointmentId, @ToothId, @Description);
END