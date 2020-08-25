CREATE PROCEDURE [dbo].[spPatients_GetById]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id], [FirstName], [LastName], [Address], [PhoneNumber], [Email]
	FROM Patients
	WHERE Id = @Id;
END
