CREATE PROCEDURE [dbo].[spTeeth_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, ToothCode, ToothDescription
	FROM Teeth
	ORDER BY Id
END
