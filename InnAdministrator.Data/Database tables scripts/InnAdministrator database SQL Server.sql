USE [InnAdministrator]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 1/9/2017 3:56:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Items_Id]  DEFAULT (newid()),
	[Name] [nvarchar](150) NULL,
	[SellIn] [int] NULL,
	[Quality] [int] NULL,
 CONSTRAINT [PK_Items_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ItemsProperties]    Script Date: 1/9/2017 3:56:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemsProperties](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ItemsProperies_Id]  DEFAULT (newid()),
	[Name] [nvarchar](150) NOT NULL,
	[Value] [nvarchar](150) NULL,
	[ItemId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ItemsProperties_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Items] ([Id], [Name], [SellIn], [Quality]) VALUES (N'5ec9c56f-3b95-4de6-bf1d-05d7efd1e9d9', N'Backstage passes to a TAFKAL80ETC concert', 15, 20)
INSERT [dbo].[Items] ([Id], [Name], [SellIn], [Quality]) VALUES (N'48f1569b-d87e-49c1-b772-2644fb3a41fd', N'Sulfuras, Hand of Ragnaros', 0, 80)
INSERT [dbo].[Items] ([Id], [Name], [SellIn], [Quality]) VALUES (N'96313403-0341-4378-9712-68cbfb7da5b1', N'+5 Dexterity Vest', 10, 20)
INSERT [dbo].[Items] ([Id], [Name], [SellIn], [Quality]) VALUES (N'44444af7-a9ba-418e-adf1-8117ec5e1728', N'Aged Brie', 2, 0)
INSERT [dbo].[Items] ([Id], [Name], [SellIn], [Quality]) VALUES (N'649a9e53-b0a0-416f-8e87-b553511d63a3', N'Elixir of the Mongoose', 5, 7)
INSERT [dbo].[Items] ([Id], [Name], [SellIn], [Quality]) VALUES (N'a38d80b4-2069-4bf5-b8ca-c81fc91ce11e', N'Conjured Mana Cake', 3, 6)
INSERT [dbo].[ItemsProperties] ([Id], [Name], [Value], [ItemId]) VALUES (N'9e3249ae-cf51-4625-a511-2b383ad4d5d3', N'ItemType', N'Ordinary', N'649a9e53-b0a0-416f-8e87-b553511d63a3')
INSERT [dbo].[ItemsProperties] ([Id], [Name], [Value], [ItemId]) VALUES (N'ece554b2-ef73-474a-b278-5a41ded7348d', N'ItemType', N'Conjured', N'a38d80b4-2069-4bf5-b8ca-c81fc91ce11e')
INSERT [dbo].[ItemsProperties] ([Id], [Name], [Value], [ItemId]) VALUES (N'9a2932eb-75fb-4636-83b2-b44ed4558389', N'ItemType', N'AgedCheese', N'44444af7-a9ba-418e-adf1-8117ec5e1728')
INSERT [dbo].[ItemsProperties] ([Id], [Name], [Value], [ItemId]) VALUES (N'c3fbd31c-739f-4546-9ebe-d83518e50766', N'ItemType', N'Legendary', N'48f1569b-d87e-49c1-b772-2644fb3a41fd')
INSERT [dbo].[ItemsProperties] ([Id], [Name], [Value], [ItemId]) VALUES (N'c3998faa-dc5d-4755-8386-e28a094cfb37', N'ItemType', N'Ordinary', N'96313403-0341-4378-9712-68cbfb7da5b1')
INSERT [dbo].[ItemsProperties] ([Id], [Name], [Value], [ItemId]) VALUES (N'47f903b8-e781-4c4e-9369-ffca6ffb734e', N'ItemType', N'BackstagePass', N'5ec9c56f-3b95-4de6-bf1d-05d7efd1e9d9')
SET ANSI_PADDING ON

GO
/****** Object:  Index [UC_Items_Name]    Script Date: 1/9/2017 3:56:40 PM ******/
ALTER TABLE [dbo].[Items] ADD  CONSTRAINT [UC_Items_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UC_ItemsProperties_Name]    Script Date: 1/9/2017 3:56:40 PM ******/
ALTER TABLE [dbo].[ItemsProperties] ADD  CONSTRAINT [UC_ItemsProperties_Name] UNIQUE NONCLUSTERED 
(
	[Id] ASC,
	[Name] ASC,
	[Value] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ItemsProperties]  WITH CHECK ADD  CONSTRAINT [FK_ItemsProperties_ItemId] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Items] ([Id])
GO
ALTER TABLE [dbo].[ItemsProperties] CHECK CONSTRAINT [FK_ItemsProperties_ItemId]
GO
