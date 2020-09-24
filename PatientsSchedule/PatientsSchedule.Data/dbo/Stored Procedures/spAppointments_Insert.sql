CREATE PROCEDURE [dbo].[spAppointments_Insert]
	@PatientId int,
	@AppointmentDate DATETIME2(7),
	@AppointmentDuration NVARCHAR(8)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Appointments(PatientId, AppointmentDate, AppointmentDuration)
	VALUES(@PatientId, @AppointmentDate, @AppointmentDuration);
END
