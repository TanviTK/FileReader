--use Hemanth_All_Test
--Go
-- drop table Mapping
--  drop table OutputData
--   drop table Files
--    drop table Settings

--CREATE TABLE Settings (
--    SettingId int NOT NULL PRIMARY KEY IDENTITY(1,1),
--    [Broker] varchar(255)  not null,
--    Attachment varchar(255)  not null,
--    [Subject] varchar(255)  not null,
--	FileType varchar(10) not null,
--);

--CREATE TABLE Files (
--    FileId int NOT NULL PRIMARY KEY IDENTITY(1,1),
--    ReceviedDate DateTime NOT NULL,
--    FileLocation varchar(255) NOT NULL,
--	IsProcessed bit NOT NULL default 0,
--    SettingId int FOREIGN KEY REFERENCES Settings(SettingId) NOT NULL
--);

--CREATE TABLE OutputData (
--    OutputId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
--    DataType varchar(20) NOT NULL,
--    [Value] varchar(100) NOT NULL,
--    FileId int FOREIGN KEY REFERENCES Files(FileId) NOT NULL
--);

--CREATE TABLE Mapping (
--    MappingId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
--    MapType varchar(20) NOT NULL,
--    MapName varchar(255) NOT NULL,
--    ExecutionType varchar(20) NOT NULL,
--	SettingId int FOREIGN KEY REFERENCES Settings(SettingId) NOT NULL
--);
