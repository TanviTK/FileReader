--CREATE PROCEDURE GetUnprocessedFiles
--AS
--BEGIN
--    SELECT *
--    FROM Files
--	where IsProcessed = 0
--END

--CREATE PROCEDURE GetMapForSettingId @id int
--AS
--BEGIN
--SELECT * FROM Mapping WHERE SettingId = @id
--END


--CREATE PROCEDURE InsertDataIntoOutputTable (

--  @dataType nvarchar(20),
--  @outVal nvarchar(100),
--  @fileId int
--) AS
--BEGIN
--    INSERT INTO OutputData(DataType, [Value], FileId)
--    VALUES (@dataType, @outVal, @fileId);

--END

--CREATE PROCEDURE UpdateFileTable @id int
--AS
--BEGIN
--Update Files 
--set IsProcessed = 1
--WHERE FileId = @id
--END
