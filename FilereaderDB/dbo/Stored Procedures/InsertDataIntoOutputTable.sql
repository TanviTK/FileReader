CREATE PROCEDURE InsertDataIntoOutputTable (

  @dataType nvarchar(20),
  @outVal nvarchar(100),
  @fileId int
) AS
BEGIN
    INSERT INTO OutputData(DataType, [Value], FileId)
    VALUES (@dataType, @outVal, @fileId);

END