CREATE TABLE [dbo].[Files] (
    [FileId]       INT           IDENTITY (1, 1) NOT NULL,
    [ReceviedDate] DATETIME      NOT NULL,
    [FileLocation] VARCHAR (255) NOT NULL,
    [IsProcessed]  BIT           DEFAULT ((0)) NOT NULL,
    [SettingId]    INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([FileId] ASC),
    FOREIGN KEY ([SettingId]) REFERENCES [dbo].[Settings] ([SettingId])
);

