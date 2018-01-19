CREATE TABLE [dbo].[UserMessage]
(
	[Id] [uniqueidentifier] ROWGUIDCOL NOT NULL CONSTRAINT [DF_UserMessage_Id] DEFAULT newsequentialid(),
	[Message] NVARCHAR (500) NULL,
	[Type] [int] NOT NULL,
	[Checked] BIT NOT NULL,
    [From] NVARCHAR (255) NULL,
	[To] NVARCHAR (255) NULL,
    [CreatedAt] DATETIME NULL,
	CONSTRAINT [PK_UserMessage] PRIMARY KEY CLUSTERED ([Id] ASC)
)
