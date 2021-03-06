USE [TestDB_Muhammad]
GO
/****** Object:  StoredProcedure [dbo].[GetStudentInfo]    Script Date: 2018/11/21 12:57:38 PM ******/
DROP PROCEDURE [dbo].[GetStudentInfo]
GO
ALTER TABLE [dbo].[Student_Course] DROP CONSTRAINT [FK_Student_Course_Student_Course]
GO
ALTER TABLE [dbo].[Student_Course] DROP CONSTRAINT [FK_Student_Course_Course]
GO
/****** Object:  Table [dbo].[Student_Course]    Script Date: 2018/11/21 12:57:38 PM ******/
DROP TABLE [dbo].[Student_Course]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 2018/11/21 12:57:38 PM ******/
DROP TABLE [dbo].[Student]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 2018/11/21 12:57:38 PM ******/
DROP TABLE [dbo].[Course]
GO
USE [master]
GO
/****** Object:  Database [TestDB_Muhammad]    Script Date: 2018/11/21 12:57:38 PM ******/
DROP DATABASE [TestDB_Muhammad]
GO
/****** Object:  Database [TestDB_Muhammad]    Script Date: 2018/11/21 12:57:38 PM ******/
CREATE DATABASE [TestDB_Muhammad]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TestDB_Muhammad', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER2\MSSQL\DATA\TestDB_Muhammad.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TestDB_Muhammad_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER2\MSSQL\DATA\TestDB_Muhammad_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TestDB_Muhammad] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TestDB_Muhammad].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TestDB_Muhammad] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TestDB_Muhammad] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TestDB_Muhammad] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TestDB_Muhammad] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TestDB_Muhammad] SET ARITHABORT OFF 
GO
ALTER DATABASE [TestDB_Muhammad] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TestDB_Muhammad] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TestDB_Muhammad] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TestDB_Muhammad] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TestDB_Muhammad] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TestDB_Muhammad] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TestDB_Muhammad] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TestDB_Muhammad] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TestDB_Muhammad] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TestDB_Muhammad] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TestDB_Muhammad] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TestDB_Muhammad] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TestDB_Muhammad] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TestDB_Muhammad] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TestDB_Muhammad] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TestDB_Muhammad] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TestDB_Muhammad] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TestDB_Muhammad] SET RECOVERY FULL 
GO
ALTER DATABASE [TestDB_Muhammad] SET  MULTI_USER 
GO
ALTER DATABASE [TestDB_Muhammad] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TestDB_Muhammad] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TestDB_Muhammad] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TestDB_Muhammad] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TestDB_Muhammad] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TestDB_Muhammad', N'ON'
GO
ALTER DATABASE [TestDB_Muhammad] SET QUERY_STORE = OFF
GO
USE [TestDB_Muhammad]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 2018/11/21 12:57:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [varchar](50) NOT NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 2018/11/21 12:57:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[Surname] [varchar](50) NOT NULL,
	[EmailAddress] [varchar](50) NOT NULL,
	[IDNumber] [varchar](13) NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student_Course]    Script Date: 2018/11/21 12:57:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student_Course](
	[Student_CourseId] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_Student_Course] PRIMARY KEY CLUSTERED 
(
	[Student_CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Student_Course]  WITH CHECK ADD  CONSTRAINT [FK_Student_Course_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[Student_Course] CHECK CONSTRAINT [FK_Student_Course_Course]
GO
ALTER TABLE [dbo].[Student_Course]  WITH CHECK ADD  CONSTRAINT [FK_Student_Course_Student_Course] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
ALTER TABLE [dbo].[Student_Course] CHECK CONSTRAINT [FK_Student_Course_Student_Course]
GO
/****** Object:  StoredProcedure [dbo].[GetStudentInfo]    Script Date: 2018/11/21 12:57:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetStudentInfo] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Student.FirstName, Student.Surname, Course.CourseName, Course.StartDate, Course.EndDate
	FROM ((Student_Course
	INNER JOIN Student ON Student.StudentId = Student_Course.StudentId)
	INNER JOIN Course ON Course.CourseId = Student_Course.CourseId)
	Order By Student.Surname, Student.FirstName;
END
RETURN
GO
USE [master]
GO
ALTER DATABASE [TestDB_Muhammad] SET  READ_WRITE 
GO
