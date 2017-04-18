CREATE TABLE [dbo].[AccessToken]
(
	[IdUser] INT NOT NULL PRIMARY KEY, 
    [IdClient] NVARCHAR(255) NULL, 
    [Token] NVARCHAR(255) NULL, 
    [Type] NVARCHAR(255) NULL, 
    [Expiration] DATETIME NULL, 
    [RefreshToken] NVARCHAR(255) NULL, 
    [Scope] NVARCHAR(255) NULL 
)

GO
