CREATE TABLE [dbo].[RoleAuthorization]
(
				[IdRoleDefinition] INT NOT NULL , 
    [Authorization] INT NOT NULL, 
    [Access] INT NOT NULL, 
    PRIMARY KEY ([IdRoleDefinition], [Authorization]), 
    CONSTRAINT [FK_RoleAuthorization_RolDefinition] FOREIGN KEY ([IdRoleDefinition]) REFERENCES RoleDefinition(Id), 
)

GO
