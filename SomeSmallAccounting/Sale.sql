USE [For_Tests]
GO

/****** Object:  Table [dbo].[Sale]    Script Date: 12/26/2013 14:56:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sale](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_Product] [int] NOT NULL,
	[Sale_Price] [float] NOT NULL,
	[Sold_Qnt] [int] NOT NULL,
	[Price_Sum] [float] NOT NULL,
	[Sale_Date] [datetime] NOT NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_Sale] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


