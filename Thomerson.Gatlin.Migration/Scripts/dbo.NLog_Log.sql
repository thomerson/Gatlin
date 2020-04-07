IF NOT EXISTS (SELECT 1 FROM sysObjects  WHERE Id=OBJECT_ID(N'[dbo].[NLog_Log]') and xtype='U')
BEGIN
CREATE TABLE [dbo].[NLog_Log](
    [ID] [int] IDENTITY(1,1) NOT NULL,
    [Origin] [nvarchar](500) NULL,
    [LogLevel] [nvarchar](500) NULL,
    [Message] [nvarchar](500) NULL,
    [Desc] [nvarchar](500) NULL,
    [Exception] [nvarchar](500) NULL,
    [StackTrace] [nvarchar](500) NULL,
    [CreateOn] [datetime] NULL
) ON [PRIMARY]
END
