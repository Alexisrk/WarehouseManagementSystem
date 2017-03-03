CREATE TABLE [dbo].[Location]
(
	[Name] NVARCHAR(255) NOT NULL PRIMARY KEY, 
    [Description] NVARCHAR(255) NULL, 
    [Type] INT NULL, 
    [W] INT NULL, 
    [B] INT NULL, 
    [A] INT NULL, 
    [X] INT NULL, 
    [Y] INT NULL, 
    [Z] INT NULL, 
    [Capacity] INT NULL
)
