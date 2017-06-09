CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(255) NULL, 
    [Password] NVARCHAR(255) NULL, 
    [IdRole] INT NULL, 
    CONSTRAINT [FK_User_Role] FOREIGN KEY (IdRole) REFERENCES Role(Id)
)
