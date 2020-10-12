CREATE PROCEDURE [dbo].[spTooth_GetByCode]
	@ToothCode INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, ToothCode, ToothDescription
	FROM Teeth
	WHERE ToothCode = @ToothCode;
END
