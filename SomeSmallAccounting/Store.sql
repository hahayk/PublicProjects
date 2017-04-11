USE [For_Tests]
GO

/****** Object:  Table [dbo].[Store]    Script Date: 11.04.2017 22:38:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Store](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Product] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Quantity_Start] [int] NULL,
	[Quantity_Now] [int] NULL,
	[Real_Price_USD] [float] NULL,
	[Real_Price_AMD] [float] NULL,
	[Sale_Price_AMD] [float] NULL,
	[Link] [text] NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


