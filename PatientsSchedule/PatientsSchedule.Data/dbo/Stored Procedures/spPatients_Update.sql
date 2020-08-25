CREATE PROCEDURE [dbo].[spPatients_Update]
	@Id INT,
	@FirstName NVARCHAR(100),
	@LastName NVARCHAR(100),
	@Address NVARCHAR(100),
	@PhoneNumber NVARCHAR(20),
	@Email NVARCHAR(100)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE Patients
	SET
		FirstName = TRIM(@FirstName),
		LastName = TRIM(@LastName),
		[Address] = TRIM(@Address),
		PhoneNumber = TRIM(@PhoneNumber),
		Email = TRIM(@Email)
	WHERE Id = @Id;
END
