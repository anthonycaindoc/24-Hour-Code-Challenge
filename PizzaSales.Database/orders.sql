﻿CREATE TABLE [dbo].[orders]
(
	[orderId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [orderDate] DATETIME NOT NULL DEFAULT GETDATE()
)
