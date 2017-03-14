CREATE TABLE [dbo].[Material]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [LocationName] NVARCHAR(255) NOT NULL, 
    CONSTRAINT [FK_Material_Location] FOREIGN KEY ([LocationName]) REFERENCES [Location]([Name])
)

GO
