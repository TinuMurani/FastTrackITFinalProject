CREATE PROCEDURE [dbo].[spTooth_GetById]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT ToothCode, ToothDescription
	FROM Teeth
	WHERE Id = @Id;
END