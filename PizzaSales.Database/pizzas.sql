CREATE TABLE [dbo].[pizzas]
(
	[pizzaId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [pizzaTypeId] INT NULL, 
    [size] VARCHAR(5) NULL, 
    [price] DECIMAL(18, 2) NULL, 
    [dateUpdated] DATETIME NULL
)
