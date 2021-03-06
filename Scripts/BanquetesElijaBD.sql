USE [master]
GO
/****** Object:  Database [BanquetesElija]    Script Date: 17/02/2014 03:23:55 p.m. ******/
CREATE DATABASE [BanquetesElija]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BanquetesElija', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\BanquetesElija.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BanquetesElija_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\BanquetesElija_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BanquetesElija] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BanquetesElija].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BanquetesElija] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BanquetesElija] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BanquetesElija] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BanquetesElija] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BanquetesElija] SET ARITHABORT OFF 
GO
ALTER DATABASE [BanquetesElija] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BanquetesElija] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [BanquetesElija] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BanquetesElija] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BanquetesElija] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BanquetesElija] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BanquetesElija] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BanquetesElija] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BanquetesElija] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BanquetesElija] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BanquetesElija] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BanquetesElija] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BanquetesElija] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BanquetesElija] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BanquetesElija] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BanquetesElija] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BanquetesElija] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BanquetesElija] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BanquetesElija] SET RECOVERY FULL 
GO
ALTER DATABASE [BanquetesElija] SET  MULTI_USER 
GO
ALTER DATABASE [BanquetesElija] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BanquetesElija] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BanquetesElija] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BanquetesElija] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BanquetesElija', N'ON'
GO
USE [BanquetesElija]
GO
/****** Object:  Table [dbo].[Authentication]    Script Date: 17/02/2014 03:23:56 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Authentication](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Token] [varchar](50) NOT NULL,
	[Expiration] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Device]    Script Date: 17/02/2014 03:23:57 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Device](
	[DeviceId] [int] IDENTITY(1,1) NOT NULL,
	[IMEI] [int] NULL,
	[Brand] [varchar](50) NOT NULL,
	[Device] [varchar](50) NOT NULL,
	[Display] [int] NOT NULL,
	[Manufacturer] [varchar](50) NOT NULL,
	[Model] [varchar](50) NOT NULL,
	[Product] [varchar](50) NOT NULL,
	[Operator] [varchar](50) NULL,
	[AndroidId] [varchar](50) NOT NULL,
	[OsVersion] [varchar](20) NOT NULL,
	[CodeVersion] [varchar](20) NOT NULL,
	[ReleaseVersion] [varchar](20) NOT NULL,
	[IsPhone] [bit] NOT NULL,
	[RegistrationDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DeviceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Image]    Script Date: 17/02/2014 03:23:57 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Image](
	[ImageId] [int] IDENTITY(1,1) NOT NULL,
	[Url] [varchar](255) NOT NULL,
	[Width] [int] NOT NULL,
	[Height] [int] NOT NULL,
	[Size] [int] NOT NULL,
	[ImageTypeId] [int] NOT NULL,
	[NodeId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ImageType]    Script Date: 17/02/2014 03:23:57 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ImageType](
	[ImageTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ImageTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Node]    Script Date: 17/02/2014 03:23:57 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Node](
	[NodeId] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NOT NULL,
	[Level] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Text] [varchar](500) NULL,
	[NodeTypeId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NodeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NodeType]    Script Date: 17/02/2014 03:23:57 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NodeType](
	[NodeTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NodeTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 17/02/2014 03:23:57 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FacebookId] [int] NULL,
	[FirstName] [varchar](100) NULL,
	[LastName] [varchar](100) NULL,
	[Age] [int] NULL,
	[Birthday] [date] NULL,
	[Gender] [varchar](10) NULL,
	[FacebookLink] [varchar](150) NULL,
	[TelephoneHome] [varchar](20) NULL,
	[TelephoneOffice] [varchar](20) NULL,
	[TelephoneMobile] [varchar](20) NULL,
	[Email] [varchar](100) NULL,
	[City] [varchar](50) NULL,
	[Address] [varchar](255) NULL,
	[RegistrationDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserDevice]    Script Date: 17/02/2014 03:23:57 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDevice](
	[UserDeviceId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[DeviceId] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[LastActivityDate] [datetime] NOT NULL,
	[AuthenticationId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserDeviceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Image]  WITH CHECK ADD FOREIGN KEY([ImageTypeId])
REFERENCES [dbo].[ImageType] ([ImageTypeId])
GO
ALTER TABLE [dbo].[Image]  WITH CHECK ADD FOREIGN KEY([NodeId])
REFERENCES [dbo].[Node] ([NodeId])
GO
ALTER TABLE [dbo].[Node]  WITH CHECK ADD FOREIGN KEY([NodeTypeId])
REFERENCES [dbo].[NodeType] ([NodeTypeId])
GO
ALTER TABLE [dbo].[UserDevice]  WITH CHECK ADD FOREIGN KEY([AuthenticationId])
REFERENCES [dbo].[Authentication] ([Id])
GO
ALTER TABLE [dbo].[UserDevice]  WITH CHECK ADD FOREIGN KEY([DeviceId])
REFERENCES [dbo].[Device] ([DeviceId])
GO
ALTER TABLE [dbo].[UserDevice]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
USE [master]
GO
ALTER DATABASE [BanquetesElija] SET  READ_WRITE 
GO
