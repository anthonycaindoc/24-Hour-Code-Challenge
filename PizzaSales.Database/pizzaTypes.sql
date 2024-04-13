CREATE TABLE [dbo].[pizzaTypes]
(
	[pizzaTypeId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [code] VARCHAR(50) NULL, 
    [name] VARCHAR(100) NULL, 
    [category] VARCHAR(20) NULL, 
    [ingredients] VARCHAR(500) NULL, 
    [dateUpdated] DATETIME NULL DEFAULT GETDATE(), 
    CONSTRAINT [AK_pizzaTypes_Column] UNIQUE ([code])
)

GO

CREATE INDEX [IX_pizzaTypes_Column] ON [dbo].[pizzaTypes] ([code], [category])
