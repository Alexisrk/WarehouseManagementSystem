CREATE TABLE [dbo].[Role]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [IdParentRole] INT NULL, 
    [IdRoleDefinition] INT NULL, 
    CONSTRAINT [FK_Role_RoleDefinition] FOREIGN KEY (IdRoleDefinition) REFERENCES RoleDefinition(Id)
)

GO

CREATE INDEX [IdIndex] ON [dbo].[Role] (Id)
