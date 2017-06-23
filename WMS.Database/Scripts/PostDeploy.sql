/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

-- ROLE AUTHORIZATION
IF NOT EXISTS (select 1 from [RoleAuthorization] where [IdRoleDefinition] = 1 and [Authorization] = 1) BEGIN INSERT INTO [RoleAuthorization] ([IdRoleDefinition], [Authorization], [Access]) VALUES (1, 1, 3) END;
IF NOT EXISTS (select 1 from [RoleAuthorization] where [IdRoleDefinition] = 1 and [Authorization] = 2) BEGIN INSERT INTO [RoleAuthorization] ([IdRoleDefinition], [Authorization], [Access]) VALUES (1, 2, 3) END;
IF NOT EXISTS (select 1 from [RoleAuthorization] where [IdRoleDefinition] = 1 and [Authorization] = 3) BEGIN INSERT INTO [RoleAuthorization] ([IdRoleDefinition], [Authorization], [Access]) VALUES (1, 3, 3) END;
IF NOT EXISTS (select 1 from [RoleAuthorization] where [IdRoleDefinition] = 1 and [Authorization] = 4) BEGIN INSERT INTO [RoleAuthorization] ([IdRoleDefinition], [Authorization], [Access]) VALUES (1, 4, 3) END;
IF NOT EXISTS (select 1 from [RoleAuthorization] where [IdRoleDefinition] = 1 and [Authorization] = 5) BEGIN INSERT INTO [RoleAuthorization] ([IdRoleDefinition], [Authorization], [Access]) VALUES (1, 5, 3) END;
IF NOT EXISTS (select 1 from [RoleAuthorization] where [IdRoleDefinition] = 1 and [Authorization] = 6) BEGIN INSERT INTO [RoleAuthorization] ([IdRoleDefinition], [Authorization], [Access]) VALUES (1, 6, 3) END;
IF NOT EXISTS (select 1 from [RoleAuthorization] where [IdRoleDefinition] = 1 and [Authorization] = 7) BEGIN INSERT INTO [RoleAuthorization] ([IdRoleDefinition], [Authorization], [Access]) VALUES (1, 7, 3) END;
IF NOT EXISTS (select 1 from [RoleAuthorization] where [IdRoleDefinition] = 1 and [Authorization] = 8) BEGIN INSERT INTO [RoleAuthorization] ([IdRoleDefinition], [Authorization], [Access]) VALUES (1, 8, 3) END;
IF NOT EXISTS (select 1 from [RoleAuthorization] where [IdRoleDefinition] = 1 and [Authorization] = 9) BEGIN INSERT INTO [RoleAuthorization] ([IdRoleDefinition], [Authorization], [Access]) VALUES (1, 9, 3) END;
IF NOT EXISTS (select 1 from [RoleAuthorization] where [IdRoleDefinition] = 1 and [Authorization] = 10) BEGIN INSERT INTO [RoleAuthorization] ([IdRoleDefinition], [Authorization], [Access]) VALUES (1, 10, 3) END;
IF NOT EXISTS (select 1 from [RoleAuthorization] where [IdRoleDefinition] = 1 and [Authorization] = 11) BEGIN INSERT INTO [RoleAuthorization] ([IdRoleDefinition], [Authorization], [Access]) VALUES (1, 11, 3) END;
IF NOT EXISTS (select 1 from [RoleAuthorization] where [IdRoleDefinition] = 1 and [Authorization] = 12) BEGIN INSERT INTO [RoleAuthorization] ([IdRoleDefinition], [Authorization], [Access]) VALUES (1, 12, 3) END;
IF NOT EXISTS (select 1 from [RoleAuthorization] where [IdRoleDefinition] = 1 and [Authorization] = 13) BEGIN INSERT INTO [RoleAuthorization] ([IdRoleDefinition], [Authorization], [Access]) VALUES (1, 13, 3) END;
IF NOT EXISTS (select 1 from [RoleAuthorization] where [IdRoleDefinition] = 1 and [Authorization] = 14) BEGIN INSERT INTO [RoleAuthorization] ([IdRoleDefinition], [Authorization], [Access]) VALUES (1, 14, 3) END;
IF NOT EXISTS (select 1 from [RoleAuthorization] where [IdRoleDefinition] = 1 and [Authorization] = 15) BEGIN INSERT INTO [RoleAuthorization] ([IdRoleDefinition], [Authorization], [Access]) VALUES (1, 15, 3) END;

IF NOT EXISTS (select 1 from [RoleAuthorization] where [IdRoleDefinition] = 2 and [Authorization] = 1) BEGIN INSERT INTO [RoleAuthorization] ([IdRoleDefinition], [Authorization], [Access]) VALUES (2, 1, 3) END;
IF NOT EXISTS (select 1 from [RoleAuthorization] where [IdRoleDefinition] = 2 and [Authorization] = 2) BEGIN INSERT INTO [RoleAuthorization] ([IdRoleDefinition], [Authorization], [Access]) VALUES (2, 2, 3) END;
IF NOT EXISTS (select 1 from [RoleAuthorization] where [IdRoleDefinition] = 2 and [Authorization] = 3) BEGIN INSERT INTO [RoleAuthorization] ([IdRoleDefinition], [Authorization], [Access]) VALUES (2, 3, 3) END;
IF NOT EXISTS (select 1 from [RoleAuthorization] where [IdRoleDefinition] = 2 and [Authorization] = 5) BEGIN INSERT INTO [RoleAuthorization] ([IdRoleDefinition], [Authorization], [Access]) VALUES (2, 5, 3) END;
IF NOT EXISTS (select 1 from [RoleAuthorization] where [IdRoleDefinition] = 2 and [Authorization] = 6) BEGIN INSERT INTO [RoleAuthorization] ([IdRoleDefinition], [Authorization], [Access]) VALUES (2, 6, 3) END;
IF NOT EXISTS (select 1 from [RoleAuthorization] where [IdRoleDefinition] = 2 and [Authorization] = 7) BEGIN INSERT INTO [RoleAuthorization] ([IdRoleDefinition], [Authorization], [Access]) VALUES (2, 7, 3) END;
IF NOT EXISTS (select 1 from [RoleAuthorization] where [IdRoleDefinition] = 2 and [Authorization] = 9) BEGIN INSERT INTO [RoleAuthorization] ([IdRoleDefinition], [Authorization], [Access]) VALUES (2, 9, 3) END;
IF NOT EXISTS (select 1 from [RoleAuthorization] where [IdRoleDefinition] = 2 and [Authorization] = 10) BEGIN INSERT INTO [RoleAuthorization] ([IdRoleDefinition], [Authorization], [Access]) VALUES (2, 10, 3) END;
IF NOT EXISTS (select 1 from [RoleAuthorization] where [IdRoleDefinition] = 2 and [Authorization] = 11) BEGIN INSERT INTO [RoleAuthorization] ([IdRoleDefinition], [Authorization], [Access]) VALUES (2, 11, 3) END;


-- ROLE DEFINITION
IF NOT EXISTS (select 1 from [RoleDefinition] where Id = 1) BEGIN INSERT INTO [RoleDefinition] (Id, Name) VALUES (1, 'Administrator') END;
IF NOT EXISTS (select 1 from [RoleDefinition] where Id = 2) BEGIN INSERT INTO [RoleDefinition] (Id, Name) VALUES (2, 'Operator') END;

-- ROLE
IF NOT EXISTS (select 1 from [Role] where Id = 1) BEGIN INSERT INTO [Role] (Id, IdParentRole, IdRoleDefinition) VALUES (1, NULL, 1) END;
IF NOT EXISTS (select 1 from [Role] where Id = 2) BEGIN INSERT INTO [Role] (Id, IdParentRole, IdRoleDefinition) VALUES (2, 1, 2) END;

-- USER PROFILE
IF NOT EXISTS (select 1 from [User] where Id = 1) BEGIN INSERT INTO [User] (Id, Name, Password, IdRole) VALUES (1, 'user', 'user', 1) END;
IF NOT EXISTS (select 1 from [User] where Id = 2) BEGIN INSERT INTO [User] (Id, Name, Password, IdRole) VALUES (2, 'Alexisk', 'Alexisk', 2) END;

-- BASIC LAYOUT
IF NOT EXISTS (select 1 from Location where Name = 'LOC_W1B1A1X1Y1Z1') BEGIN INSERT INTO Location (Name, Description, W,B,A,X,Y,Z, Capacity) VALUES ('LOC_W1B1A1X1Y1Z1', 'LOCATION W1-B1-A1-X1-Y1-Z1', 1,1,1,1,1,1,1) END;
IF NOT EXISTS (select 1 from Location where Name = 'LOC_W1B1A1X1Y1Z2') BEGIN INSERT INTO Location (Name, Description, W,B,A,X,Y,Z, Capacity) VALUES ('LOC_W1B1A1X1Y1Z2', 'LOCATION W1-B1-A1-X1-Y1-Z2', 1,1,1,1,1,2,1) END;
IF NOT EXISTS (select 1 from Location where Name = 'LOC_W1B1A1X1Y1Z3') BEGIN INSERT INTO Location (Name, Description, W,B,A,X,Y,Z, Capacity) VALUES ('LOC_W1B1A1X1Y1Z3', 'LOCATION W1-B1-A1-X1-Y1-Z3', 1,1,1,1,1,3,1) END;
IF NOT EXISTS (select 1 from Location where Name = 'LOC_W1B1A1X2Y1Z1') BEGIN INSERT INTO Location (Name, Description, W,B,A,X,Y,Z, Capacity) VALUES ('LOC_W1B1A1X2Y1Z1', 'LOCATION W1-B1-A1-X2-Y1-Z1', 1,1,1,2,1,1,1) END;
IF NOT EXISTS (select 1 from Location where Name = 'LOC_W1B1A1X2Y1Z2') BEGIN INSERT INTO Location (Name, Description, W,B,A,X,Y,Z, Capacity) VALUES ('LOC_W1B1A1X2Y1Z2', 'LOCATION W1-B1-A1-X2-Y1-Z2', 1,1,1,2,1,2,1) END;
IF NOT EXISTS (select 1 from Location where Name = 'LOC_W1B1A1X2Y1Z3') BEGIN INSERT INTO Location (Name, Description, W,B,A,X,Y,Z, Capacity) VALUES ('LOC_W1B1A1X2Y1Z3', 'LOCATION W1-B1-A1-X2-Y1-Z3', 1,1,1,2,1,3,1) END;
IF NOT EXISTS (select 1 from Location where Name = 'LOC_W1B1A1X1Y2Z1') BEGIN INSERT INTO Location (Name, Description, W,B,A,X,Y,Z, Capacity) VALUES ('LOC_W1B1A1X1Y2Z1', 'LOCATION W1-B1-A1-X1-Y2-Z1', 1,1,1,1,2,1,1) END;
IF NOT EXISTS (select 1 from Location where Name = 'LOC_W1B1A1X1Y2Z2') BEGIN INSERT INTO Location (Name, Description, W,B,A,X,Y,Z, Capacity) VALUES ('LOC_W1B1A1X1Y2Z2', 'LOCATION W1-B1-A1-X1-Y2-Z2', 1,1,1,1,2,2,1) END;
IF NOT EXISTS (select 1 from Location where Name = 'LOC_W1B1A1X1Y2Z3') BEGIN INSERT INTO Location (Name, Description, W,B,A,X,Y,Z, Capacity) VALUES ('LOC_W1B1A1X1Y2Z3', 'LOCATION W1-B1-A1-X1-Y2-Z3', 1,1,1,1,2,3,1) END;
IF NOT EXISTS (select 1 from Location where Name = 'LOC_W1B1A1X2Y2Z1') BEGIN INSERT INTO Location (Name, Description, W,B,A,X,Y,Z, Capacity) VALUES ('LOC_W1B1A1X2Y2Z1', 'LOCATION W1-B1-A1-X2-Y2-Z1', 1,1,1,2,2,1,1) END;
IF NOT EXISTS (select 1 from Location where Name = 'LOC_W1B1A1X2Y2Z2') BEGIN INSERT INTO Location (Name, Description, W,B,A,X,Y,Z, Capacity) VALUES ('LOC_W1B1A1X2Y2Z2', 'LOCATION W1-B1-A1-X2-Y2-Z2', 1,1,1,2,2,2,1) END;
IF NOT EXISTS (select 1 from Location where Name = 'LOC_W1B1A1X2Y2Z3') BEGIN INSERT INTO Location (Name, Description, W,B,A,X,Y,Z, Capacity) VALUES ('LOC_W1B1A1X2Y2Z3', 'LOCATION W1-B1-A1-X2-Y2-Z3', 1,1,1,2,2,3,1) END;


