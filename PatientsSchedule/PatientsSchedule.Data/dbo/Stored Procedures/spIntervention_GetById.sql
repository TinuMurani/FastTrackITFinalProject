CREATE PROCEDURE [dbo].[spIntervention_GetById]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, AppointmentId, ToothId, [Description]
	FROM Interventions
	WHERE Id = @Id;
END
