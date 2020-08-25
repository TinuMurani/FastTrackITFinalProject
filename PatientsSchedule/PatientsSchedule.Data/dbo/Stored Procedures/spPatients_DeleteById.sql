CREATE PROCEDURE [dbo].[spPatients_DeleteById]
	@Id INT
AS
BEGIN
	DELETE FROM Patients WHERE Id = @Id;
END