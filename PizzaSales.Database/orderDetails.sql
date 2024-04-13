CREATE TABLE [dbo].[orderDetails]
(
	[orderDetailId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [orderId] INT NULL, 
    [pizzaCode] VARCHAR(50) NULL, 
    [quantity] INT NULL, 
    CONSTRAINT [FK_orderDetails_ToTable] FOREIGN KEY ([orderId]) REFERENCES [orders]([orderId])
)

GO

CREATE INDEX [IX_orderDetails_Column] ON [dbo].[orderDetails] ([orderId], [pizzaCode])
