CREATE PROCEDURE [dbo].[spAppointments_DeleteById]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM Appointments
	WHERE Id = @Id;
END
