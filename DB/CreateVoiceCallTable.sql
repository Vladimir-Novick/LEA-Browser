USE [LEA]
GO

/****** Object:  Table [dbo].[VoiceCall]    Script Date: 12/11/18 2:01:50 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VoiceCall](
	[ProductId] [int] NOT NULL,
	[Path] [nvarchar](250) NULL,
	[CallLengthInMs] [int] NULL,
 CONSTRAINT [PK_VoiceCall] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


