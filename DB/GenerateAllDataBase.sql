USE [master]
GO

CREATE DATABASE [LEA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LEA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\LEA.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LEA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\LEA_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [LEA] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LEA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LEA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LEA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LEA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LEA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LEA] SET ARITHABORT OFF 
GO
ALTER DATABASE [LEA] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LEA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LEA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LEA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LEA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LEA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LEA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LEA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LEA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LEA] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LEA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LEA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LEA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LEA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LEA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LEA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LEA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LEA] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LEA] SET  MULTI_USER 
GO
ALTER DATABASE [LEA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LEA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LEA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LEA] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LEA] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LEA] SET QUERY_STORE = OFF
GO
USE [LEA]
GO
/****** Object:  Table [dbo].[VoiceCall]    Script Date: 12/21/18 2:06:51 AM ******/
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
/****** Object:  Table [dbo].[Product]    Script Date: 12/21/18 2:06:51 AM ******/
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
/****** Object:  View [dbo].[AllVoice]    Script Date: 12/21/18 2:06:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[AllVoice]  
AS 

select product.*,voice.* from VoiceCall as voice
left join product as product 
on voice.ProductId = product.id;
GO
/****** Object:  Table [dbo].[SmsMessage]    Script Date: 12/21/18 2:06:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SmsMessage](
	[ProductId] [int] NOT NULL,
	[Text] [nvarchar](max) NULL,
 CONSTRAINT [PK_SmsMessage] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[AllSmsMessage]    Script Date: 12/21/18 2:06:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[AllSmsMessage]  
AS 

select product.*,smsMessage.* from SmsMessage as smsMessage
left join product as product 
on smsMessage.ProductId = product.id;
GO
/****** Object:  Table [dbo].[Investigation]    Script Date: 12/21/18 2:06:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Investigation](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[CreationDate] [date] NULL,
 CONSTRAINT [PK_Investigation] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [idx_ProductCreatedDate]    Script Date: 12/21/18 2:06:51 AM ******/
CREATE NONCLUSTERED INDEX [idx_ProductCreatedDate] ON [dbo].[Product]
(
	[CreationDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [idx_ProductInvestigation]    Script Date: 12/21/18 2:06:51 AM ******/
CREATE NONCLUSTERED INDEX [idx_ProductInvestigation] ON [dbo].[Product]
(
	[InvestigationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Investigation] ADD  CONSTRAINT [DF_Investigation_CreationDate]  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [col_type_def]  DEFAULT ((1)) FOR [Type]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_CreationDate]  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Source]  DEFAULT ('') FOR [Source]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Destination]  DEFAULT ('') FOR [Destination]
GO
/****** Object:  StoredProcedure [dbo].[SelectProduct]    Script Date: 12/21/18 2:06:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SelectProduct]
	
	@InvestigationId int 
	
AS
BEGIN
	SET NOCOUNT ON;

   IF @InvestigationId > 0 
   BEGIN 
	  SELECT t1.*,t2.Name as Investigation from Product t1
      left join Investigation t2 on t1.InvestigationId = t2.id
	   where t1.InvestigationId = @InvestigationId
	   order by t1.CreationDate;

   END
   ELSE 
   BEGIN
   	  SELECT t1.*,t2.Name as Investigation from Product t1
      left join [Investigation] t2 on t1.InvestigationId = t2.id
	   order by t1.CreationDate;
   END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_AddInvestigation]    Script Date: 12/21/18 2:06:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_AddInvestigation]

	
AS
BEGIN
    DECLARE @Id as INT;
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Investigation]
           ([Name])
     VALUES
           ('');
     SET @Id = SCOPE_IDENTITY();

	 SELECT *
       FROM [dbo].[Investigation]
	   WHERE id = @Id;

END
GO
/****** Object:  StoredProcedure [dbo].[sp_AddProduct]    Script Date: 12/21/18 2:06:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_AddProduct]
	
	@InvestigationId int 
	
AS
BEGIN
    DECLARE @Id as INT;
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Product]
           ([InvestigationId])
     VALUES
           (@InvestigationId);
     SET @Id = SCOPE_IDENTITY();

   	  SELECT t1.*,t2.Name as Investigation from Product t1
      inner join [Investigation] t2 on t1.InvestigationId = t2.id
	   WHERE t1.Id = @Id;

END
GO
USE [master]
GO
ALTER DATABASE [LEA] SET  READ_WRITE 
GO
