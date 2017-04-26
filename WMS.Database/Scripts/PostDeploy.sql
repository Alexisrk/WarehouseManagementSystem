﻿/*
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

-- CLIENT
--IF NOT EXISTS (select 1 from Client where Id = 'bXljbGllbnRpZA==') BEGIN INSERT INTO Client (Id, Name, Secret, Url) VALUES ('bXljbGllbnRpZA==', 'WMS Application', 'aXQnc2FzZWNyZXQ=', 'MyUrl') END;

--AUTHORIZATION CODE
--IF NOT EXISTS (select 1 from AuthorizationCode where IdClient = 'bXljbGllbnRpZA==') BEGIN INSERT INTO AuthorizationCode (IdClient, IdUser, Code, Redirect_Uri) VALUES ('bXljbGllbnRpZA==', 2, 'Kdh/ncUvPHX6wZYz9UNcy2YYKyVlrdPCtr6fDVEyioA=','http://localhost:3525/Home/Connect') END;

-- USER PROFILE
IF NOT EXISTS (select 1 from [User] where Id = 1) BEGIN INSERT INTO [User] (Id, Name, Password) VALUES (1, 'user', 'user') END;
IF NOT EXISTS (select 1 from [User] where Id = 2) BEGIN INSERT INTO [User] (Id, Name, Password) VALUES (2, 'Alexisk', 'Alexisk') END;


-- USER PROFILE
IF NOT EXISTS (select 1 from UserProfile where Id = 1) BEGIN INSERT INTO UserProfile (Id, Name) VALUES (1, 'user') END;
IF NOT EXISTS (select 1 from UserProfile where Id = 2) BEGIN INSERT INTO UserProfile (Id, Name) VALUES (2, 'Alexisk') END;

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


