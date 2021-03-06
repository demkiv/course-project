USE [master]
GO
/****** Object:  Database [DeanerySystemDb_v1]    Script Date: 2/3/2018 6:02:18 PM ******/
CREATE DATABASE [DeanerySystemDb_v1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DeanerySystemDb_v1', FILENAME = N'C:\Users\mfost\DeanerySystemDb_v1.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DeanerySystemDb_v1_log', FILENAME = N'C:\Users\mfost\DeanerySystemDb_v1_log.ldf' , SIZE = 1088KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DeanerySystemDb_v1] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DeanerySystemDb_v1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DeanerySystemDb_v1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DeanerySystemDb_v1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DeanerySystemDb_v1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DeanerySystemDb_v1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DeanerySystemDb_v1] SET ARITHABORT OFF 
GO
ALTER DATABASE [DeanerySystemDb_v1] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DeanerySystemDb_v1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DeanerySystemDb_v1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DeanerySystemDb_v1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DeanerySystemDb_v1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DeanerySystemDb_v1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DeanerySystemDb_v1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DeanerySystemDb_v1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DeanerySystemDb_v1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DeanerySystemDb_v1] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DeanerySystemDb_v1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DeanerySystemDb_v1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DeanerySystemDb_v1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DeanerySystemDb_v1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DeanerySystemDb_v1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DeanerySystemDb_v1] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [DeanerySystemDb_v1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DeanerySystemDb_v1] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DeanerySystemDb_v1] SET  MULTI_USER 
GO
ALTER DATABASE [DeanerySystemDb_v1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DeanerySystemDb_v1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DeanerySystemDb_v1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DeanerySystemDb_v1] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [DeanerySystemDb_v1]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 2/3/2018 6:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 2/3/2018 6:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2/3/2018 6:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2/3/2018 6:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2/3/2018 6:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 2/3/2018 6:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cellules]    Script Date: 2/3/2018 6:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cellules](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Mark] [nvarchar](max) NULL,
	[Journal_Id] [int] NOT NULL,
	[Student_Id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.Cellules] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Classes]    Script Date: 2/3/2018 6:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ClassType] [int] NOT NULL,
	[Professor_Id] [uniqueidentifier] NOT NULL,
	[Subject_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Classes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ClassNumberTimes]    Script Date: 2/3/2018 6:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassNumberTimes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [int] NOT NULL,
	[Start] [time](7) NOT NULL,
	[End] [time](7) NOT NULL,
	[TimeTable_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ClassNumberTimes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DeaneryUsers]    Script Date: 2/3/2018 6:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeaneryUsers](
	[Id] [uniqueidentifier] NOT NULL DEFAULT (newsequentialid()),
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[MiddleName] [nvarchar](max) NULL,
	[Identity_Id] [nvarchar](128) NOT NULL,
	[LatinFirstName] [nvarchar](max) NULL,
	[LatinLastName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.DeaneryUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Departments]    Script Date: 2/3/2018 6:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Number] [int] NOT NULL,
	[Head_Id] [uniqueidentifier] NULL,
	[Stream_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Departments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
WITH
(
FILETABLE_STREAMID_UNIQUE_CONSTRAINT_NAME=[IX_Stream_Id]
)

GO
/****** Object:  Table [dbo].[EducationalPlans]    Script Date: 2/3/2018 6:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EducationalPlans](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Group_Id] [int] NOT NULL,
	[Semester_Id] [int] NOT NULL,
	[Subject_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.EducationalPlans] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Faculties]    Script Date: 2/3/2018 6:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculties](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Dean_Id] [uniqueidentifier] NULL,
	[University_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Faculties] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FailureTickets]    Script Date: 2/3/2018 6:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FailureTickets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PassingDate] [datetime] NOT NULL,
	[Type] [int] NOT NULL,
	[IsPassed] [bit] NOT NULL,
	[Student_Id] [uniqueidentifier] NOT NULL,
	[Subject_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.FailureTickets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Groups]    Script Date: 2/3/2018 6:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Tuition] [int] NOT NULL,
	[Mentor_Id] [uniqueidentifier] NOT NULL,
	[Department_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Groups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Journals]    Script Date: 2/3/2018 6:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Journals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JournalType] [int] NOT NULL,
	[Class_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Journals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Professors]    Script Date: 2/3/2018 6:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professors](
	[Id] [uniqueidentifier] NOT NULL,
	[Department_Id] [int] NOT NULL,
	[Position] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Professors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProgressRecords]    Script Date: 2/3/2018 6:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProgressRecords](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TermMark] [float] NOT NULL,
	[ExamMark] [float] NOT NULL,
	[Student_Id] [uniqueidentifier] NOT NULL,
	[Subject_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ProgressRecords] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Semesters]    Script Date: 2/3/2018 6:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Semesters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Start] [datetime] NOT NULL,
	[CreditSessionStart] [datetime] NOT NULL,
	[SessionStart] [datetime] NOT NULL,
	[SecondWritingStart] [datetime] NOT NULL,
	[ThirdWritingStart] [datetime] NOT NULL,
	[End] [datetime] NOT NULL,
	[Number] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Semesters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Streams]    Script Date: 2/3/2018 6:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Streams](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[StreamAbbreviation] [nvarchar](max) NULL,
	[Faculty_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Streams] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Students]    Script Date: 2/3/2018 6:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [uniqueidentifier] NOT NULL,
	[Group_Id] [int] NOT NULL,
	[StudentCode] [nvarchar](max) NULL,
	[TuitionFee] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StudentsSemesters]    Script Date: 2/3/2018 6:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentsSemesters](
	[SemesterId] [int] NOT NULL,
	[StudentId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.StudentsSemesters] PRIMARY KEY CLUSTERED 
(
	[SemesterId] ASC,
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 2/3/2018 6:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[NumberOfLectures] [int] NOT NULL,
	[NumberOfPracticalClasses] [int] NOT NULL,
	[NumberOflLaboratoryClasses] [int] NOT NULL,
	[NumberOfConsultations] [int] NOT NULL,
	[SemesterControl] [int] NOT NULL,
	[PassingDate] [datetime] NULL,
 CONSTRAINT [PK_dbo.Subjects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TimeTables]    Script Date: 2/3/2018 6:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeTables](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DayOfWeek] [int] NOT NULL,
	[Fraction] [int] NOT NULL,
	[Class_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.TimeTables] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Universities]    Script Date: 2/3/2018 6:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Universities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Rector_Id] [uniqueidentifier] NULL,
 CONSTRAINT [PK_dbo.Universities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 2/3/2018 6:02:18 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 2/3/2018 6:02:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 2/3/2018 6:02:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 2/3/2018 6:02:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 2/3/2018 6:02:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 2/3/2018 6:02:18 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Journal_Id]    Script Date: 2/3/2018 6:02:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Journal_Id] ON [dbo].[Cellules]
(
	[Journal_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Student_Id]    Script Date: 2/3/2018 6:02:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Student_Id] ON [dbo].[Cellules]
(
	[Student_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Professor_Id]    Script Date: 2/3/2018 6:02:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Professor_Id] ON [dbo].[Classes]
(
	[Professor_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Subject_Id]    Script Date: 2/3/2018 6:02:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Subject_Id] ON [dbo].[Classes]
(
	[Subject_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TimeTable_Id]    Script Date: 2/3/2018 6:02:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_TimeTable_Id] ON [dbo].[ClassNumberTimes]
(
	[TimeTable_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Identity_Id]    Script Date: 2/3/2018 6:02:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Identity_Id] ON [dbo].[DeaneryUsers]
(
	[Identity_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Head_Id]    Script Date: 2/3/2018 6:02:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Head_Id] ON [dbo].[Departments]
(
	[Head_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Stream_Id]    Script Date: 2/3/2018 6:02:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Stream_Id] ON [dbo].[Departments]
(
	[Stream_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Group_Id]    Script Date: 2/3/2018 6:02:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Group_Id] ON [dbo].[EducationalPlans]
(
	[Group_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Semester_Id]    Script Date: 2/3/2018 6:02:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Semester_Id] ON [dbo].[EducationalPlans]
(
	[Semester_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Subject_Id]    Script Date: 2/3/2018 6:02:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Subject_Id] ON [dbo].[EducationalPlans]
(
	[Subject_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Dean_Id]    Script Date: 2/3/2018 6:02:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Dean_Id] ON [dbo].[Faculties]
(
	[Dean_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_University_Id]    Script Date: 2/3/2018 6:02:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_University_Id] ON [dbo].[Faculties]
(
	[University_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Student_Id]    Script Date: 2/3/2018 6:02:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Student_Id] ON [dbo].[FailureTickets]
(
	[Student_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Subject_Id]    Script Date: 2/3/2018 6:02:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Subject_Id] ON [dbo].[FailureTickets]
(
	[Subject_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Department_Id]    Script Date: 2/3/2018 6:02:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Department_Id] ON [dbo].[Groups]
(
	[Department_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Mentor_Id]    Script Date: 2/3/2018 6:02:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Mentor_Id] ON [dbo].[Groups]
(
	[Mentor_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Class_Id]    Script Date: 2/3/2018 6:02:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Class_Id] ON [dbo].[Journals]
(
	[Class_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Department_Id]    Script Date: 2/3/2018 6:02:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Department_Id] ON [dbo].[Professors]
(
	[Department_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Id]    Script Date: 2/3/2018 6:02:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Id] ON [dbo].[Professors]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Student_Id]    Script Date: 2/3/2018 6:02:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Student_Id] ON [dbo].[ProgressRecords]
(
	[Student_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Subject_Id]    Script Date: 2/3/2018 6:02:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Subject_Id] ON [dbo].[ProgressRecords]
(
	[Subject_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Faculty_Id]    Script Date: 2/3/2018 6:02:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Faculty_Id] ON [dbo].[Streams]
(
	[Faculty_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Group_Id]    Script Date: 2/3/2018 6:02:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Group_Id] ON [dbo].[Students]
(
	[Group_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Id]    Script Date: 2/3/2018 6:02:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Id] ON [dbo].[Students]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SemesterId]    Script Date: 2/3/2018 6:02:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_SemesterId] ON [dbo].[StudentsSemesters]
(
	[SemesterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_StudentId]    Script Date: 2/3/2018 6:02:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_StudentId] ON [dbo].[StudentsSemesters]
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Class_Id]    Script Date: 2/3/2018 6:02:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Class_Id] ON [dbo].[TimeTables]
(
	[Class_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Rector_Id]    Script Date: 2/3/2018 6:02:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Rector_Id] ON [dbo].[Universities]
(
	[Rector_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Cellules]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cellules_dbo.Journals_Journal_Id] FOREIGN KEY([Journal_Id])
REFERENCES [dbo].[Journals] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cellules] CHECK CONSTRAINT [FK_dbo.Cellules_dbo.Journals_Journal_Id]
GO
ALTER TABLE [dbo].[Cellules]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cellules_dbo.Students_Student_Id] FOREIGN KEY([Student_Id])
REFERENCES [dbo].[Students] ([Id])
GO
ALTER TABLE [dbo].[Cellules] CHECK CONSTRAINT [FK_dbo.Cellules_dbo.Students_Student_Id]
GO
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Classes_dbo.Professors_Professor_Id] FOREIGN KEY([Professor_Id])
REFERENCES [dbo].[Professors] ([Id])
GO
ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [FK_dbo.Classes_dbo.Professors_Professor_Id]
GO
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Classes_dbo.Subjects_Subject_Id] FOREIGN KEY([Subject_Id])
REFERENCES [dbo].[Subjects] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [FK_dbo.Classes_dbo.Subjects_Subject_Id]
GO
ALTER TABLE [dbo].[ClassNumberTimes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ClassNumberTimes_dbo.TimeTables_TimeTable_Id] FOREIGN KEY([TimeTable_Id])
REFERENCES [dbo].[TimeTables] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClassNumberTimes] CHECK CONSTRAINT [FK_dbo.ClassNumberTimes_dbo.TimeTables_TimeTable_Id]
GO
ALTER TABLE [dbo].[DeaneryUsers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DeaneryUsers_dbo.AspNetUsers_Identity_Id] FOREIGN KEY([Identity_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DeaneryUsers] CHECK CONSTRAINT [FK_dbo.DeaneryUsers_dbo.AspNetUsers_Identity_Id]
GO
ALTER TABLE [dbo].[Departments]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Departments_dbo.Professors_Head_Id] FOREIGN KEY([Head_Id])
REFERENCES [dbo].[Professors] ([Id])
GO
ALTER TABLE [dbo].[Departments] CHECK CONSTRAINT [FK_dbo.Departments_dbo.Professors_Head_Id]
GO
ALTER TABLE [dbo].[Departments]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Departments_dbo.Streams_Stream_Id] FOREIGN KEY([Stream_Id])
REFERENCES [dbo].[Streams] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Departments] CHECK CONSTRAINT [FK_dbo.Departments_dbo.Streams_Stream_Id]
GO
ALTER TABLE [dbo].[EducationalPlans]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EducationalPlans_dbo.Groups_Group_Id] FOREIGN KEY([Group_Id])
REFERENCES [dbo].[Groups] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EducationalPlans] CHECK CONSTRAINT [FK_dbo.EducationalPlans_dbo.Groups_Group_Id]
GO
ALTER TABLE [dbo].[EducationalPlans]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EducationalPlans_dbo.Semesters_Semester_Id] FOREIGN KEY([Semester_Id])
REFERENCES [dbo].[Semesters] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EducationalPlans] CHECK CONSTRAINT [FK_dbo.EducationalPlans_dbo.Semesters_Semester_Id]
GO
ALTER TABLE [dbo].[EducationalPlans]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EducationalPlans_dbo.Subjects_Subject_Id] FOREIGN KEY([Subject_Id])
REFERENCES [dbo].[Subjects] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EducationalPlans] CHECK CONSTRAINT [FK_dbo.EducationalPlans_dbo.Subjects_Subject_Id]
GO
ALTER TABLE [dbo].[Faculties]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Faculties_dbo.Professors_Dean_Id] FOREIGN KEY([Dean_Id])
REFERENCES [dbo].[Professors] ([Id])
GO
ALTER TABLE [dbo].[Faculties] CHECK CONSTRAINT [FK_dbo.Faculties_dbo.Professors_Dean_Id]
GO
ALTER TABLE [dbo].[Faculties]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Faculties_dbo.Universities_University_Id] FOREIGN KEY([University_Id])
REFERENCES [dbo].[Universities] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Faculties] CHECK CONSTRAINT [FK_dbo.Faculties_dbo.Universities_University_Id]
GO
ALTER TABLE [dbo].[FailureTickets]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FailureTickets_dbo.Students_Student_Id] FOREIGN KEY([Student_Id])
REFERENCES [dbo].[Students] ([Id])
GO
ALTER TABLE [dbo].[FailureTickets] CHECK CONSTRAINT [FK_dbo.FailureTickets_dbo.Students_Student_Id]
GO
ALTER TABLE [dbo].[FailureTickets]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FailureTickets_dbo.Subjects_Subject_Id] FOREIGN KEY([Subject_Id])
REFERENCES [dbo].[Subjects] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FailureTickets] CHECK CONSTRAINT [FK_dbo.FailureTickets_dbo.Subjects_Subject_Id]
GO
ALTER TABLE [dbo].[Groups]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Groups_dbo.Departments_Department_Id] FOREIGN KEY([Department_Id])
REFERENCES [dbo].[Departments] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Groups] CHECK CONSTRAINT [FK_dbo.Groups_dbo.Departments_Department_Id]
GO
ALTER TABLE [dbo].[Groups]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Groups_dbo.Professors_Mentor_Id] FOREIGN KEY([Mentor_Id])
REFERENCES [dbo].[Professors] ([Id])
GO
ALTER TABLE [dbo].[Groups] CHECK CONSTRAINT [FK_dbo.Groups_dbo.Professors_Mentor_Id]
GO
ALTER TABLE [dbo].[Journals]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Journals_dbo.Classes_Class_Id] FOREIGN KEY([Class_Id])
REFERENCES [dbo].[Classes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Journals] CHECK CONSTRAINT [FK_dbo.Journals_dbo.Classes_Class_Id]
GO
ALTER TABLE [dbo].[Professors]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Professors_dbo.DeaneryUsers_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[DeaneryUsers] ([Id])
GO
ALTER TABLE [dbo].[Professors] CHECK CONSTRAINT [FK_dbo.Professors_dbo.DeaneryUsers_Id]
GO
ALTER TABLE [dbo].[Professors]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Professors_dbo.Departments_Department_Id] FOREIGN KEY([Department_Id])
REFERENCES [dbo].[Departments] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Professors] CHECK CONSTRAINT [FK_dbo.Professors_dbo.Departments_Department_Id]
GO
ALTER TABLE [dbo].[ProgressRecords]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ProgressRecorsds_dbo.Students_Student_Id] FOREIGN KEY([Student_Id])
REFERENCES [dbo].[Students] ([Id])
GO
ALTER TABLE [dbo].[ProgressRecords] CHECK CONSTRAINT [FK_dbo.ProgressRecorsds_dbo.Students_Student_Id]
GO
ALTER TABLE [dbo].[ProgressRecords]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ProgressRecorsds_dbo.Subjects_Subject_Id] FOREIGN KEY([Subject_Id])
REFERENCES [dbo].[Subjects] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProgressRecords] CHECK CONSTRAINT [FK_dbo.ProgressRecorsds_dbo.Subjects_Subject_Id]
GO
ALTER TABLE [dbo].[Streams]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Streams_dbo.Faculties_Faculty_Id] FOREIGN KEY([Faculty_Id])
REFERENCES [dbo].[Faculties] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Streams] CHECK CONSTRAINT [FK_dbo.Streams_dbo.Faculties_Faculty_Id]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Students_dbo.DeaneryUsers_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[DeaneryUsers] ([Id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_dbo.Students_dbo.DeaneryUsers_Id]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Students_dbo.Groups_Group_Id] FOREIGN KEY([Group_Id])
REFERENCES [dbo].[Groups] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_dbo.Students_dbo.Groups_Group_Id]
GO
ALTER TABLE [dbo].[StudentsSemesters]  WITH CHECK ADD  CONSTRAINT [FK_dbo.StudentsSemesters_dbo.Semesters_SemesterId] FOREIGN KEY([SemesterId])
REFERENCES [dbo].[Semesters] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentsSemesters] CHECK CONSTRAINT [FK_dbo.StudentsSemesters_dbo.Semesters_SemesterId]
GO
ALTER TABLE [dbo].[StudentsSemesters]  WITH CHECK ADD  CONSTRAINT [FK_dbo.StudentsSemesters_dbo.Students_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentsSemesters] CHECK CONSTRAINT [FK_dbo.StudentsSemesters_dbo.Students_StudentId]
GO
ALTER TABLE [dbo].[TimeTables]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TimeTables_dbo.Classes_Class_Id] FOREIGN KEY([Class_Id])
REFERENCES [dbo].[Classes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TimeTables] CHECK CONSTRAINT [FK_dbo.TimeTables_dbo.Classes_Class_Id]
GO
ALTER TABLE [dbo].[Universities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Universities_dbo.Professors_Rector_Id] FOREIGN KEY([Rector_Id])
REFERENCES [dbo].[Professors] ([Id])
GO
ALTER TABLE [dbo].[Universities] CHECK CONSTRAINT [FK_dbo.Universities_dbo.Professors_Rector_Id]
GO
USE [master]
GO
ALTER DATABASE [DeanerySystemDb_v1] SET  READ_WRITE 
GO
