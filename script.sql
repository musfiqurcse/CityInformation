USE [master]
GO
/****** Object:  Database [CityInformation_DB]    Script Date: 5/17/2015 9:37:12 PM ******/
CREATE DATABASE [CityInformation_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CityInformation_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\CityInformation_DB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CityInformation_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\CityInformation_DB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CityInformation_DB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CityInformation_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CityInformation_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CityInformation_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CityInformation_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CityInformation_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CityInformation_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CityInformation_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CityInformation_DB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [CityInformation_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CityInformation_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CityInformation_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CityInformation_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CityInformation_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CityInformation_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CityInformation_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CityInformation_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CityInformation_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CityInformation_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CityInformation_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CityInformation_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CityInformation_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CityInformation_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CityInformation_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CityInformation_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CityInformation_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CityInformation_DB] SET  MULTI_USER 
GO
ALTER DATABASE [CityInformation_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CityInformation_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CityInformation_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CityInformation_DB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [CityInformation_DB]
GO
/****** Object:  Table [dbo].[CityInformation_Table]    Script Date: 5/17/2015 9:37:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CityInformation_Table](
	[City_ID] [int] IDENTITY(1,1) NOT NULL,
	[City_Name] [varchar](50) NOT NULL,
	[About] [varchar](50) NOT NULL,
	[Country] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CityInformation_Table] PRIMARY KEY CLUSTERED 
(
	[City_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[CityInformation_Table] ON 

INSERT [dbo].[CityInformation_Table] ([City_ID], [City_Name], [About], [Country]) VALUES (1, N'Dhaka', N'Capital', N'Bangladesh')
INSERT [dbo].[CityInformation_Table] ([City_ID], [City_Name], [About], [Country]) VALUES (2, N'Delhi', N'Capital', N'Malaysia')
INSERT [dbo].[CityInformation_Table] ([City_ID], [City_Name], [About], [Country]) VALUES (3, N'Singapore City', N'Capital', N'Singapore')
INSERT [dbo].[CityInformation_Table] ([City_ID], [City_Name], [About], [Country]) VALUES (4, N'Sylhet', N'Town', N'Bangladesh')
SET IDENTITY_INSERT [dbo].[CityInformation_Table] OFF
/****** Object:  Index [IX_CityInformation_Table]    Script Date: 5/17/2015 9:37:13 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_CityInformation_Table] ON [dbo].[CityInformation_Table]
(
	[City_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [CityInformation_DB] SET  READ_WRITE 
GO
