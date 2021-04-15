CREATE TABLE [dbo].[Mapping] (
    [MappingId]     INT           IDENTITY (1, 1) NOT NULL,
    [MapType]       VARCHAR (20)  NOT NULL,
    [MapName]       VARCHAR (255) NOT NULL,
    [ExecutionType] VARCHAR (20)  NOT NULL,
    [SettingId]     INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([MappingId] ASC),
    FOREIGN KEY ([SettingId]) REFERENCES [dbo].[Settings] ([SettingId])
);

