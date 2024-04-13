CREATE TABLE [dbo].[pizzaTypes]
(
	[pizzaTypeId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [name] VARCHAR(100) NULL, 
    [category] VARCHAR(20) NULL, 
    [ingredients] VARCHAR(500) NULL, 
    [dateUpdated] DATETIME NULL DEFAULT GETDATE()
)
