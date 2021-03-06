USE [master]
GO
/****** Object:  Database [FoundingSouqExerciseDb]    Script Date: 1/26/2022 8:43:05 PM ******/
CREATE DATABASE [FoundingSouqExerciseDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FoundingSouqExerciseDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\FoundingSouqExerciseDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FoundingSouqExerciseDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\FoundingSouqExerciseDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [FoundingSouqExerciseDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FoundingSouqExerciseDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FoundingSouqExerciseDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FoundingSouqExerciseDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FoundingSouqExerciseDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FoundingSouqExerciseDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FoundingSouqExerciseDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [FoundingSouqExerciseDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FoundingSouqExerciseDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FoundingSouqExerciseDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FoundingSouqExerciseDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FoundingSouqExerciseDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FoundingSouqExerciseDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FoundingSouqExerciseDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FoundingSouqExerciseDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FoundingSouqExerciseDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FoundingSouqExerciseDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FoundingSouqExerciseDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FoundingSouqExerciseDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FoundingSouqExerciseDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FoundingSouqExerciseDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FoundingSouqExerciseDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FoundingSouqExerciseDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FoundingSouqExerciseDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FoundingSouqExerciseDb] SET RECOVERY FULL 
GO
ALTER DATABASE [FoundingSouqExerciseDb] SET  MULTI_USER 
GO
ALTER DATABASE [FoundingSouqExerciseDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FoundingSouqExerciseDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FoundingSouqExerciseDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FoundingSouqExerciseDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FoundingSouqExerciseDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FoundingSouqExerciseDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'FoundingSouqExerciseDb', N'ON'
GO
ALTER DATABASE [FoundingSouqExerciseDb] SET QUERY_STORE = OFF
GO
USE [FoundingSouqExerciseDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1/26/2022 8:43:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientAccounts]    Script Date: 1/26/2022 8:43:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientAccounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[AccoundName] [nvarchar](max) NULL,
 CONSTRAINT [PK_ClientAccounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientFilters]    Script Date: 1/26/2022 8:43:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientFilters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ClientId] [int] NULL,
	[Firstname] [nvarchar](max) NULL,
	[Lastname] [nvarchar](max) NULL,
	[Sex] [nvarchar](max) NULL,
	[PersonalId] [nvarchar](max) NULL,
	[ProfilePhoto] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[MobileNumber] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[Street] [nvarchar](max) NULL,
	[ZipCode] [nvarchar](max) NULL,
 CONSTRAINT [PK_ClientFilters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 1/26/2022 8:43:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [nvarchar](max) NULL,
	[Lastname] [nvarchar](max) NULL,
	[Sex] [nvarchar](max) NULL,
	[PersonalId] [nvarchar](max) NULL,
	[ProfilePhoto] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[MobileNumber] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[Street] [nvarchar](max) NULL,
	[ZipCode] [nvarchar](max) NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 1/26/2022 8:43:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NULL,
	[PasswordHash] [varbinary](max) NULL,
	[PasswordSalt] [varbinary](max) NULL,
	[UserTypeId] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTypes]    Script Date: 1/26/2022 8:43:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_ClientAccounts_ClientId]    Script Date: 1/26/2022 8:43:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_ClientAccounts_ClientId] ON [dbo].[ClientAccounts]
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClientFilters_UserId]    Script Date: 1/26/2022 8:43:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_ClientFilters_UserId] ON [dbo].[ClientFilters]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users_UserTypeId]    Script Date: 1/26/2022 8:43:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_Users_UserTypeId] ON [dbo].[Users]
(
	[UserTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ClientAccounts]  WITH CHECK ADD  CONSTRAINT [FK_ClientAccounts_Clients_ClientId] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClientAccounts] CHECK CONSTRAINT [FK_ClientAccounts_Clients_ClientId]
GO
ALTER TABLE [dbo].[ClientFilters]  WITH CHECK ADD  CONSTRAINT [FK_ClientFilters_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClientFilters] CHECK CONSTRAINT [FK_ClientFilters_Users_UserId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_UserTypes_UserTypeId] FOREIGN KEY([UserTypeId])
REFERENCES [dbo].[UserTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_UserTypes_UserTypeId]
GO
USE [master]
GO
ALTER DATABASE [FoundingSouqExerciseDb] SET  READ_WRITE 
GO
