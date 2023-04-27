USE [SCCRUMDB]
GO

/****** Object:  Table [dbo].[Product]    Script Date: 27-04-2023 19:31:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product](
	[Title] [nvarchar](50) NULL,
	[Image] [nvarchar](4000) NULL,
	[Price] [int] NOT NULL,
	[Stock] [int] NOT NULL,
	[Product_ID] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Product_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Product] ADD  DEFAULT ((0)) FOR [Price]
GO

ALTER TABLE [dbo].[Product] ADD  DEFAULT ((0)) FOR [Stock]
GO


