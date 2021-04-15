CREATE TABLE [dbo].[Settings] (
    [SettingId]  INT           IDENTITY (1, 1) NOT NULL,
    [Broker]     VARCHAR (255) NOT NULL,
    [Attachment] VARCHAR (255) NOT NULL,
    [Subject]    VARCHAR (255) NOT NULL,
    [FileType]   VARCHAR (10)  NOT NULL,
    PRIMARY KEY CLUSTERED ([SettingId] ASC)
);

