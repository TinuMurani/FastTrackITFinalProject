CREATE PROCEDURE [dbo].[spPatients_Insert]
	@FirstName NVARCHAR(100),
	@LastName NVARCHAR(100),
	@Address NVARCHAR(200),
	@PhoneNumber NVARCHAR(20),
	@Email NVARCHAR(100)
	
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Patients (FirstName, LastName, [Address], PhoneNumber, Email)
	VALUES (TRIM(@FirstName), TRIM(@LastName), TRIM(@Address), TRIM(@PhoneNumber), TRIM(@Email));
END
