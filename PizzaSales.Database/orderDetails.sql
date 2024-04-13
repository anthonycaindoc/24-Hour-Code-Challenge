CREATE TABLE [dbo].[orderDetails]
(
	[orderDetailId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [orderId] INT NULL, 
    [pizzaId] INT NULL, 
    [quantity] INT NULL
)
