USE [LEA]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [int] NOT NULL,
	[CreationDate] [date] NULL,
	[Source] [nvarchar](250) NULL,
	[Destination] [nvarchar](250) NULL,
	[InvestigationId] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [col_type_def]  DEFAULT ((1)) FOR [Type]
GO

ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_CreationDate]  DEFAULT (getdate()) FOR [CreationDate]
GO

ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Source]  DEFAULT ('') FOR [Source]
GO

ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Destination]  DEFAULT ('') FOR [Destination]
GO


