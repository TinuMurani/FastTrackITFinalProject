CREATE PROCEDURE [dbo].[spIntervention_Update]
	@Id INT,
	@AppointmentId INT,
	@ToothId INT,
	@Description NVARCHAR(500)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE Interventions
	SET AppointmentId = @AppointmentId, ToothId = @ToothId, [Description] = @Description
	WHERE Id = @Id;
END
