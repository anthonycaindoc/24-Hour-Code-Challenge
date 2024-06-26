﻿CREATE TABLE [dbo].[pizzas]
(
	[pizzaId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [code] VARCHAR(50) NULL, 
    [pizzaTypeCode] VARCHAR(50) NULL, 
    [size] VARCHAR(5) NULL, 
    [price] DECIMAL(18, 2) NULL, 
    [dateUpdated] DATETIME NULL DEFAULT GETDATE() 
)

GO

CREATE INDEX [IX_pizzas_Column] ON [dbo].[pizzas] ([code], [pizzaTypeCode])
