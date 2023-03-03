USE [master]
GO
/****** Object:  Database [LearnCodeTest]    Script Date: 03/03/2023 09:26:17 ******/
CREATE DATABASE [LearnCodeTest]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LearnCodeTest', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\LearnCodeTest.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LearnCodeTest_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\LearnCodeTest_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [LearnCodeTest] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LearnCodeTest].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LearnCodeTest] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LearnCodeTest] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LearnCodeTest] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LearnCodeTest] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LearnCodeTest] SET ARITHABORT OFF 
GO
ALTER DATABASE [LearnCodeTest] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [LearnCodeTest] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LearnCodeTest] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LearnCodeTest] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LearnCodeTest] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LearnCodeTest] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LearnCodeTest] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LearnCodeTest] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LearnCodeTest] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LearnCodeTest] SET  ENABLE_BROKER 
GO
ALTER DATABASE [LearnCodeTest] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LearnCodeTest] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LearnCodeTest] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LearnCodeTest] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LearnCodeTest] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LearnCodeTest] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LearnCodeTest] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LearnCodeTest] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LearnCodeTest] SET  MULTI_USER 
GO
ALTER DATABASE [LearnCodeTest] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LearnCodeTest] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LearnCodeTest] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LearnCodeTest] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LearnCodeTest] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LearnCodeTest] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [LearnCodeTest] SET QUERY_STORE = ON
GO
ALTER DATABASE [LearnCodeTest] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [LearnCodeTest]
GO
/****** Object:  Table [dbo].[Aula]    Script Date: 03/03/2023 09:26:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aula](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [text] NOT NULL,
	[Esboco] [text] NOT NULL,
	[Tipo] [varchar](60) NULL,
	[DataAgendamento] [date] NULL,
 CONSTRAINT [PK__Aula__3214EC07CBE77CDD] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Documentos]    Script Date: 03/03/2023 09:26:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documentos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NomeArquivo] [nvarchar](100) NULL,
	[TipoArquivo] [nvarchar](50) NULL,
	[DadosArquivo] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [LearnCodeTest] SET  READ_WRITE 
GO
