USE [LandLyst_Db]
GO
/****** Object:  Table [dbo].[CostumerModel]    Script Date: 11-12-2020 08:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CostumerModel](
	[PhoneNumber] [int] NOT NULL,
	[FKPostalCode_Number] [int] NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](35) NULL,
	[FirstName] [varchar](20) NULL,
	[LastName] [varchar](20) NULL,
	[Address] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[PhoneNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CostumerOrders]    Script Date: 11-12-2020 08:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CostumerOrders](
	[FKCostOrd_OrdNum] [int] NULL,
	[FKCostOrd_PhoneNum] [int] NULL,
	[FKRoom_Number] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FurnitureModel]    Script Date: 11-12-2020 08:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FurnitureModel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Price] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderModel]    Script Date: 11-12-2020 08:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderModel](
	[Number] [int] IDENTITY(1,1) NOT NULL,
	[FKRoom_Number] [int] NULL,
	[CheckInDate] [datetime] NULL,
	[CheckOutDate] [datetime] NULL,
	[TotalPrice] [float] NULL,
	[RentingPeriod] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostalCode]    Script Date: 11-12-2020 08:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostalCode](
	[Number] [int] NOT NULL,
	[CityName] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomFurniture]    Script Date: 11-12-2020 08:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomFurniture](
	[FKFurniture_Id] [int] NULL,
	[FKRoom_Number] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomModel]    Script Date: 11-12-2020 08:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomModel](
	[Number] [int] NOT NULL,
	[Clean] [bit] NULL,
	[Rented] [bit] NULL,
	[PricePerNight] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomModel_Audit]    Script Date: 11-12-2020 08:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomModel_Audit](
	[TimeStamp] [datetime] NULL,
	[RoomNumber] [int] NULL,
	[audit_action] [varchar](100) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CostumerModel]  WITH CHECK ADD FOREIGN KEY([FKPostalCode_Number])
REFERENCES [dbo].[PostalCode] ([Number])
GO
ALTER TABLE [dbo].[CostumerOrders]  WITH CHECK ADD FOREIGN KEY([FKCostOrd_OrdNum])
REFERENCES [dbo].[OrderModel] ([Number])
GO
ALTER TABLE [dbo].[CostumerOrders]  WITH CHECK ADD FOREIGN KEY([FKCostOrd_PhoneNum])
REFERENCES [dbo].[CostumerModel] ([PhoneNumber])
GO
ALTER TABLE [dbo].[OrderModel]  WITH CHECK ADD FOREIGN KEY([FKRoom_Number])
REFERENCES [dbo].[RoomModel] ([Number])
GO
ALTER TABLE [dbo].[RoomFurniture]  WITH CHECK ADD FOREIGN KEY([FKFurniture_Id])
REFERENCES [dbo].[FurnitureModel] ([Id])
GO
ALTER TABLE [dbo].[RoomFurniture]  WITH CHECK ADD FOREIGN KEY([FKRoom_Number])
REFERENCES [dbo].[RoomModel] ([Number])
GO
/****** Object:  StoredProcedure [dbo].[GetRoomsAndFurniture]    Script Date: 11-12-2020 08:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRoomsAndFurniture]
AS
SELECT * FROM FurnitureModel, RoomModel;
GO
