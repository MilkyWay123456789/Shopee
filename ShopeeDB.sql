USE [Shopee]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 9/29/2022 10:30:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 9/29/2022 10:30:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Email] [nvarchar](250) NULL,
	[Picture] [nvarchar](500) NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 9/29/2022 10:30:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[OldPrice] [int] NULL,
	[NewPrice] [int] NULL,
	[Sale] [int] NULL,
	[Travel] [nvarchar](50) NULL,
	[Count] [int] NULL,
	[CategoryId] [uniqueidentifier] NULL,
	[Review] [nvarchar](500) NULL,
	[Bought] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[Picture] [nvarchar](500) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductOfMember]    Script Date: 9/29/2022 10:30:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductOfMember](
	[Id] [uniqueidentifier] NOT NULL,
	[ProductId] [uniqueidentifier] NULL,
	[MemberId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_ProductOfMember] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Category] ([Id], [Name]) VALUES (N'f7daff60-d748-4846-b5d4-5aa3223436e3', N'Trang điểm môi')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (N'b1fc2669-5f07-4204-ae20-65a1e3ba9011', N'Trang điểm mắt')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (N'f94b517a-de92-4e99-a366-b55e3f29120f', N'Áo thun')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (N'3699fd43-9610-44ad-85c1-b799022b4812', N'Phụ kiện điện thoại')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (N'1ee9457a-fc7e-494a-a70a-bf65aab970d6', N'Trang điểm mặt')
GO
INSERT [dbo].[Member] ([Id], [Name], [Password], [Email], [Picture]) VALUES (N'efa9c012-c068-4f40-86a5-229d28427acf', N'Milky Way', N'c4ca4238a0b923820dcc509a6f75849b', N'way@gmail.com', N'/assets/img/avt.jpg')
INSERT [dbo].[Member] ([Id], [Name], [Password], [Email], [Picture]) VALUES (N'65e30992-ff6c-4dcf-8087-3e5f56a93077', N'Son Dang', N'c81e728d9d4c2f636f067f89cc14862c', N'tun@gmail.com', NULL)
INSERT [dbo].[Member] ([Id], [Name], [Password], [Email], [Picture]) VALUES (N'd44ee535-4f00-43b0-a972-5f5df2b91dbb', NULL, N'c20ad4d76fe97759aa27a0c99bff6710', N'an@gmail.com', NULL)
INSERT [dbo].[Member] ([Id], [Name], [Password], [Email], [Picture]) VALUES (N'074d1108-4d9f-4bda-9f26-97c35f621c3c', N'TI ', N'c4ca4238a0b923820dcc509a6f75849b', N'ti@gmail.com', NULL)
INSERT [dbo].[Member] ([Id], [Name], [Password], [Email], [Picture]) VALUES (N'a532b30f-1ffc-48cb-ab3a-98eaddc25f74', N'Pham Tien', N'202cb962ac59075b964b07152d234b70', N'tien@gmail.com', N'/assets/img/avt.jpg')
GO
INSERT [dbo].[Product] ([Id], [Name], [OldPrice], [NewPrice], [Sale], [Travel], [Count], [CategoryId], [Review], [Bought], [CreatedDate], [Picture]) VALUES (N'ab51b686-288d-4c6f-a199-27cadf4ae0cb', N'Chuột Logitech', 20000, 20000, 0, N'Miễn phí vận chuyển', 3, N'3699fd43-9610-44ad-85c1-b799022b4812', N'56', 4, CAST(N'2022-05-23T00:00:00.000' AS DateTime), N'/assets/img/mouse.jpg')
INSERT [dbo].[Product] ([Id], [Name], [OldPrice], [NewPrice], [Sale], [Travel], [Count], [CategoryId], [Review], [Bought], [CreatedDate], [Picture]) VALUES (N'd4920dff-2377-40b0-9643-46ac899ec9f7', N'Set dưỡng da', 120000, 110000, 100, N'Miễn phí vận chuyển', 7, N'b1fc2669-5f07-4204-ae20-65a1e3ba9011', N'90', 54, CAST(N'2019-11-11T00:00:00.000' AS DateTime), N'/assets/img/kemduongdatay.jpg')
INSERT [dbo].[Product] ([Id], [Name], [OldPrice], [NewPrice], [Sale], [Travel], [Count], [CategoryId], [Review], [Bought], [CreatedDate], [Picture]) VALUES (N'5bf0824b-f8b6-4f9f-a05c-48affb6aa856', N'Sét dưỡng trắng Whoo', 1000000, 950000, 10, N'Miễn phí vận chuyển', 2, N'1ee9457a-fc7e-494a-a70a-bf65aab970d6', N'40', 100, CAST(N'2019-07-02T00:00:00.000' AS DateTime), N'/assets/img/myphamitem.jpg')
INSERT [dbo].[Product] ([Id], [Name], [OldPrice], [NewPrice], [Sale], [Travel], [Count], [CategoryId], [Review], [Bought], [CreatedDate], [Picture]) VALUES (N'b81a16fb-9c59-431d-9906-5ca15503a0c1', N'Loa Bluetooth', 200000, 200000, 0, N'Miễn phí vận chuyển', 3, N'3699fd43-9610-44ad-85c1-b799022b4812', N'32', 89, CAST(N'2019-05-30T00:00:00.000' AS DateTime), N'/assets/img/loabt.jpg')
INSERT [dbo].[Product] ([Id], [Name], [OldPrice], [NewPrice], [Sale], [Travel], [Count], [CategoryId], [Review], [Bought], [CreatedDate], [Picture]) VALUES (N'b598c83e-f0f2-41d3-b67d-6edcbf7cfd67', N'Body Wash', 500000, 450000, 50, N'Miễn phí vận chuyển', 6, N'1ee9457a-fc7e-494a-a70a-bf65aab970d6', N'60', 50, CAST(N'2022-08-14T00:00:00.000' AS DateTime), N'/assets/img/bodywash.jpg')
INSERT [dbo].[Product] ([Id], [Name], [OldPrice], [NewPrice], [Sale], [Travel], [Count], [CategoryId], [Review], [Bought], [CreatedDate], [Picture]) VALUES (N'66afd044-dad3-4295-8295-951cbb9209b7', N'Áo thun RF', 110000, 100000, 10, N'Miễn phí vận chuyển', 1, N'f94b517a-de92-4e99-a366-b55e3f29120f', N'37', 23, CAST(N'2020-08-10T00:00:00.000' AS DateTime), N'/assets/img/revengeflash.jpeg')
INSERT [dbo].[Product] ([Id], [Name], [OldPrice], [NewPrice], [Sale], [Travel], [Count], [CategoryId], [Review], [Bought], [CreatedDate], [Picture]) VALUES (N'8b19e9c9-2803-4dc7-af32-9d7451c7571f', N'Bàn phím cơ', 100000, 95000, 5, N'Miễn phí vận chuyển', 4, N'3699fd43-9610-44ad-85c1-b799022b4812', N'4', 6, CAST(N'2019-07-10T00:00:00.000' AS DateTime), N'/assets/img/keyboard.jpg')
INSERT [dbo].[Product] ([Id], [Name], [OldPrice], [NewPrice], [Sale], [Travel], [Count], [CategoryId], [Review], [Bought], [CreatedDate], [Picture]) VALUES (N'3dbf984f-d1f3-4cd6-9087-a3946dfe9ce2', N'Ten Pot', 476000, 450000, 45, N'Miễn phí vận chuyển', 5, N'b1fc2669-5f07-4204-ae20-65a1e3ba9011', N'59', 34, CAST(N'2021-08-06T00:00:00.000' AS DateTime), N'/assets/img/tenpot.jpg')
INSERT [dbo].[Product] ([Id], [Name], [OldPrice], [NewPrice], [Sale], [Travel], [Count], [CategoryId], [Review], [Bought], [CreatedDate], [Picture]) VALUES (N'5b6d45f5-9e45-455a-a968-b527ae74dc16', N'Mary Kay', 230000, 210000, 20, N'Miễn phí vận chuyển', 4, N'1ee9457a-fc7e-494a-a70a-bf65aab970d6', N'90', 45, CAST(N'2018-12-12T00:00:00.000' AS DateTime), N'/assets/img/marykay.jpg')
INSERT [dbo].[Product] ([Id], [Name], [OldPrice], [NewPrice], [Sale], [Travel], [Count], [CategoryId], [Review], [Bought], [CreatedDate], [Picture]) VALUES (N'3bbe4125-7e5b-4a84-9796-c277290b63bb', N'Áo thun Demon Slayer', 60000, 52000, 8, N'Miễn phí vận chuyển', 7, N'f94b517a-de92-4e99-a366-b55e3f29120f', N'20', 10, CAST(N'2021-04-11T00:00:00.000' AS DateTime), N'/assets/img/kimetsuyaiba.jpg')
INSERT [dbo].[Product] ([Id], [Name], [OldPrice], [NewPrice], [Sale], [Travel], [Count], [CategoryId], [Review], [Bought], [CreatedDate], [Picture]) VALUES (N'4662317e-150f-4e00-bcd8-ce0dd6eb402c', N'Sạc dự phòng', 340000, 300000, 40, N'Miễn phí vận chuyển', 10, N'3699fd43-9610-44ad-85c1-b799022b4812', N'78', 23, CAST(N'2022-01-21T00:00:00.000' AS DateTime), N'/assets/img/sacduphong.jpg')
INSERT [dbo].[Product] ([Id], [Name], [OldPrice], [NewPrice], [Sale], [Travel], [Count], [CategoryId], [Review], [Bought], [CreatedDate], [Picture]) VALUES (N'8d407c50-67e5-455d-a46d-d22e362e5b00', N'Áo thun Genshin Impact', 200000, 99000, 5, N'Miễn phí vận chuyển', 1, N'f94b517a-de92-4e99-a366-b55e3f29120f', N'11', 58, CAST(N'2022-06-05T00:00:00.000' AS DateTime), N'/assets/img/genshin.jpg')
GO
INSERT [dbo].[ProductOfMember] ([Id], [ProductId], [MemberId]) VALUES (N'3954a03f-8474-4c1b-8791-3f01961b28e6', N'8b19e9c9-2803-4dc7-af32-9d7451c7571f', N'a532b30f-1ffc-48cb-ab3a-98eaddc25f74')
INSERT [dbo].[ProductOfMember] ([Id], [ProductId], [MemberId]) VALUES (N'996ac6c3-f6bc-44da-b6f6-4cc3d89ce589', N'b81a16fb-9c59-431d-9906-5ca15503a0c1', N'074d1108-4d9f-4bda-9f26-97c35f621c3c')
INSERT [dbo].[ProductOfMember] ([Id], [ProductId], [MemberId]) VALUES (N'86870426-5fd9-4a11-b2a1-59ba3d93c346', N'ab51b686-288d-4c6f-a199-27cadf4ae0cb', N'a532b30f-1ffc-48cb-ab3a-98eaddc25f74')
INSERT [dbo].[ProductOfMember] ([Id], [ProductId], [MemberId]) VALUES (N'1e5a1f21-9f65-451e-8893-9e2f1d18427f', N'b81a16fb-9c59-431d-9906-5ca15503a0c1', N'a532b30f-1ffc-48cb-ab3a-98eaddc25f74')
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[ProductOfMember]  WITH CHECK ADD  CONSTRAINT [FK_ProductOfMember_Member] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Member] ([Id])
GO
ALTER TABLE [dbo].[ProductOfMember] CHECK CONSTRAINT [FK_ProductOfMember_Member]
GO
ALTER TABLE [dbo].[ProductOfMember]  WITH CHECK ADD  CONSTRAINT [FK_ProductOfMember_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[ProductOfMember] CHECK CONSTRAINT [FK_ProductOfMember_Product]
GO
