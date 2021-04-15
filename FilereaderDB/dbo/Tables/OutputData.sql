CREATE TABLE [dbo].[OutputData] (
    [OutputId] INT           IDENTITY (1, 1) NOT NULL,
    [DataType] VARCHAR (20)  NOT NULL,
    [Value]    VARCHAR (100) NOT NULL,
    [FileId]   INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([OutputId] ASC),
    FOREIGN KEY ([FileId]) REFERENCES [dbo].[Files] ([FileId])
);

