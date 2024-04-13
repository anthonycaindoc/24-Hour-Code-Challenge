CREATE TABLE [dbo].[orderDetails]
(
	[orderDetailId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [orderId] INT NULL, 
    [pizzaCode] VARCHAR(50) NULL, 
    [quantity] INT NULL 
)

CREATE TABLE [dbo].[orders]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[orderId] INT NOT NULL,
    [orderDate] DATETIME NOT NULL DEFAULT GETDATE() 
)

CREATE TABLE [dbo].[pizzas]
(
	[pizzaId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [code] VARCHAR(50) NULL, 
    [pizzaTypeCode] VARCHAR(50) NULL, 
    [size] VARCHAR(5) NULL, 
    [price] DECIMAL(18, 2) NULL, 
    [dateUpdated] DATETIME NULL DEFAULT GETDATE() 
)

CREATE TABLE [dbo].[pizzaTypes]
(
	[pizzaTypeId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [code] VARCHAR(50) NULL, 
    [name] VARCHAR(100) NULL, 
    [category] VARCHAR(20) NULL, 
    [ingredients] VARCHAR(500) NULL, 
    [dateUpdated] DATETIME NULL DEFAULT GETDATE() 
)