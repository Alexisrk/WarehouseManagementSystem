CREATE TABLE [dbo].[AuthorizationCode]
(
	[IdClient] NVARCHAR(255) NOT NULL PRIMARY KEY, 
    [IdUser] INT NOT NULL, 
    [Code] NVARCHAR(255) NULL, 
    [Redirect_Uri] NVARCHAR(1000) NULL, 
    [Expiration] DATETIME NULL
)
