CREATE PROCEDURE GetUnprocessedFiles
AS
BEGIN
    SELECT *
    FROM Files
	where IsProcessed = 0
END