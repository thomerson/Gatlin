IF NOT EXISTS (SELECT 1 FROM sysObjects  WHERE Id=OBJECT_ID(N'[dbo].[User]') and xtype='U')
BEGIN
CREATE TABLE [dbo].[User](
    [ID] [UNIQUEIDENTIFIER] PRIMARY KEY NOT NULL DEFAULT(NEWSEQUENTIALID()),
    [UserId] [varchar](128) NULL,
    [Name] [varchar](128) NULL,
    [EnglishName] [varchar](128) NULL,
    [Phone] [varchar](128) NULL,
    [Email] [varchar](128) NULL,
    [Password] [varchar](256) NULL,
    [Salt] [varchar](256) NULL,
    [Remark] [varchar](max) NULL,
    [Disable] BIT NOT NULL DEFAULT(0),
    [Deleted] BIT NOT NULL DEFAULT(0),
    [CreateStamp] DATETIME NOT NULL DEFAULT(GETDATE()),
    [CreateBy] [varchar](128) NULL,
    [LastUpdateStamp] DATETIME NOT NULL DEFAULT(GETDATE()),
    [LastUpdateBy] [varchar](128) NULL,
) ON [PRIMARY]
END
