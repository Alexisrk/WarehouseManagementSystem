CREATE TABLE [dbo].[Role]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [IdParentRole] INT NULL, 
    [IdRoleDefinition] INT NULL, 
)

GO

CREATE INDEX [IdIndex] ON [dbo].[Role] (Id)
