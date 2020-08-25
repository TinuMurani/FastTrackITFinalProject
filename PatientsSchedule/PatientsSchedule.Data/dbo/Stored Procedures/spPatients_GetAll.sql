CREATE PROCEDURE [dbo].[spPatients_GetAll]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id], [FirstName], [LastName], [Address], [PhoneNumber], [Email] 
	FROM Patients
	ORDER BY LastName, FirstName;
END
