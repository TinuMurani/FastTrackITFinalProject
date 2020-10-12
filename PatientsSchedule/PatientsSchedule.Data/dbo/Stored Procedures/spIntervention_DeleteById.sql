CREATE PROCEDURE [dbo].[spIntervention_DeleteById]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM Interventions where Id = @Id;
END
