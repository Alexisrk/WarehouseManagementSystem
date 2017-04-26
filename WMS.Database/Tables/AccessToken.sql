CREATE TABLE [dbo].[AccessToken]
(
				[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY CLUSTERED DEFAULT newsequentialid(),
				[IdUser] INT NULL, 
    [IdClient] NVARCHAR(255) NULL, 
    [Token] NVARCHAR(255) NULL, 
    [Type] NVARCHAR(255) NULL, 
    [Expiration] DATETIME NULL, 
    [RefreshToken] NVARCHAR(255) NULL, 
    [Scope] NVARCHAR(255) NULL
)

GO
