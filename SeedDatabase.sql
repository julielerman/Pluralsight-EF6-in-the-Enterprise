USE [GeekStuffSales]
GO
SET IDENTITY_INSERT [Maintenance].[Customers] ON 

INSERT [Maintenance].[Customers] ([CustomerId], [FirstName], [LastName], [DateOfBirth], [CustomerCookie]) VALUES (1, N'Julie', N'Lerman', CAST(0x00009CF100000000 AS DateTime), N'CustomerCookieABCDE')
INSERT [Maintenance].[Customers] ([CustomerId], [FirstName], [LastName], [DateOfBirth], [CustomerCookie]) VALUES (2, N'Jason', N'Salmond', CAST(0x0000796500000000 AS DateTime), N'CustomerCookieXYZ')
SET IDENTITY_INSERT [Maintenance].[Customers] OFF
SET IDENTITY_INSERT [Maintenance].[Orders] ON 

INSERT [Maintenance].[Orders] ([OrderId], [OrderDate], [OrderSource], [CustomerId]) VALUES (1, CAST(0x0000A57900000000 AS DateTime), 1, 2)
INSERT [Maintenance].[Orders] ([OrderId], [OrderDate], [OrderSource], [CustomerId]) VALUES (2, CAST(0x0000A57800000000 AS DateTime), 5, 1)
INSERT [Maintenance].[Orders] ([OrderId], [OrderDate], [OrderSource], [CustomerId]) VALUES (3, CAST(0x0000A57700000000 AS DateTime), 2, 2)
SET IDENTITY_INSERT [Maintenance].[Orders] OFF
SET IDENTITY_INSERT [Maintenance].[Categories] ON 

INSERT [Maintenance].[Categories] ([CategoryId], [Name]) VALUES (1, N'Everything')
SET IDENTITY_INSERT [Maintenance].[Categories] OFF
SET IDENTITY_INSERT [Maintenance].[Products] ON 

INSERT [Maintenance].[Products] ([ProductId], [Description], [Name], [ProductionStart], [IsAvailable], [CategoryId], [MaxQuantity], [CurrentPrice]) VALUES (1, N'32" Curved Monitor', N'Primo Monitor', CAST(0x0000A58300000000 AS DateTime), 1, 1, 10, CAST(120.00 AS Decimal(18, 2)))
INSERT [Maintenance].[Products] ([ProductId], [Description], [Name], [ProductionStart], [IsAvailable], [CategoryId], [MaxQuantity], [CurrentPrice]) VALUES (2, N'Super clicky keyboard', N'Coder Keyboard', CAST(0x0000A58300000000 AS DateTime), 1, 1, 50, CAST(55.00 AS Decimal(18, 2)))
INSERT [Maintenance].[Products] ([ProductId], [Description], [Name], [ProductionStart], [IsAvailable], [CategoryId], [MaxQuantity], [CurrentPrice]) VALUES (3, N'Super ergo keyboard', N'Comfy Keyboard', CAST(0x0000A58300000000 AS DateTime), 1, 1, 50, CAST(65.00 AS Decimal(18, 2)))
INSERT [Maintenance].[Products] ([ProductId], [Description], [Name], [ProductionStart], [IsAvailable], [CategoryId], [MaxQuantity], [CurrentPrice]) VALUES (4, N'Automatic Elevating Standing Desk', N'Primo Desk', CAST(0x0000A58300000000 AS DateTime), 0, 1, 5, CAST(500.00 AS Decimal(18, 2)))
INSERT [Maintenance].[Products] ([ProductId], [Description], [Name], [ProductionStart], [IsAvailable], [CategoryId], [MaxQuantity], [CurrentPrice]) VALUES (5, N'Walk while you work', N'Desk Treadmill', CAST(0x0000A58300000000 AS DateTime), 1, 1, 5, CAST(500.00 AS Decimal(18, 2)))
INSERT [Maintenance].[Products] ([ProductId], [Description], [Name], [ProductionStart], [IsAvailable], [CategoryId], [MaxQuantity], [CurrentPrice]) VALUES (6, N'Touch Screen Monitory', N'Touchy Monitor', CAST(0x0000A58300000000 AS DateTime), 1, 1, 10, CAST(150.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [Maintenance].[Products] OFF
SET IDENTITY_INSERT [Maintenance].[LineItems] ON 

INSERT [Maintenance].[LineItems] ([LineItemId], [Quantity], [OrderId], [ProductId]) VALUES (1, 6, 2, 2)
INSERT [Maintenance].[LineItems] ([LineItemId], [Quantity], [OrderId], [ProductId]) VALUES (2, 7, 2, 3)
INSERT [Maintenance].[LineItems] ([LineItemId], [Quantity], [OrderId], [ProductId]) VALUES (3, 1, 3, 3)
SET IDENTITY_INSERT [Maintenance].[LineItems] OFF
