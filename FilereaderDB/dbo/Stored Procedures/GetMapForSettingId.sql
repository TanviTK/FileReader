CREATE PROCEDURE GetMapForSettingId @id int
AS
BEGIN
SELECT * FROM Mapping WHERE SettingId = @id
END