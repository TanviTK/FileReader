
CREATE PROCEDURE [dbo].[UpdateFileTable] @id int
AS
BEGIN
Update Files 
set IsProcessed = 1
WHERE FileId = @id
END