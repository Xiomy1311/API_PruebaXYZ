USE [master]
GO
/****** Object:  Database [DB_XYZ]    Script Date: 3/14/2024 8:58:27 PM ******/
CREATE DATABASE [DB_XYZ]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_XYZ', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\DB_XYZ.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DB_XYZ_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\DB_XYZ_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [DB_XYZ] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_XYZ].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_XYZ] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_XYZ] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_XYZ] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_XYZ] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_XYZ] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_XYZ] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_XYZ] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_XYZ] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_XYZ] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_XYZ] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_XYZ] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_XYZ] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_XYZ] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_XYZ] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_XYZ] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DB_XYZ] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_XYZ] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_XYZ] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_XYZ] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_XYZ] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_XYZ] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_XYZ] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_XYZ] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DB_XYZ] SET  MULTI_USER 
GO
ALTER DATABASE [DB_XYZ] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_XYZ] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_XYZ] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_XYZ] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_XYZ] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DB_XYZ] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DB_XYZ] SET QUERY_STORE = ON
GO
ALTER DATABASE [DB_XYZ] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [DB_XYZ]
GO
/****** Object:  User [admin]    Script Date: 3/14/2024 8:58:28 PM ******/
CREATE USER [admin] FOR LOGIN [admin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[dt_Comments]    Script Date: 3/14/2024 8:58:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dt_Comments](
	[PostId] [bigint] NOT NULL,
	[Id] [bigint] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Body] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dt_Logs]    Script Date: 3/14/2024 8:58:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dt_Logs](
	[Date] [datetime] NULL,
	[ServiceName] [nvarchar](max) NULL,
	[Response] [nvarchar](max) NULL,
	[Event] [nvarchar](max) NULL,
	[UserId] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dt_Posts]    Script Date: 3/14/2024 8:58:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dt_Posts](
	[UserID] [bigint] NOT NULL,
	[Id] [bigint] NOT NULL,
	[Tittle] [nvarchar](max) NULL,
	[Body] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dt_Users]    Script Date: 3/14/2024 8:58:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dt_Users](
	[UserID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dt_UsersFamily]    Script Date: 3/14/2024 8:58:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dt_UsersFamily](
	[FamilyID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NOT NULL,
	[Indetification] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Gender] [nvarchar](max) NULL,
	[Relationship] [nvarchar](max) NULL,
	[Age] [int] NOT NULL,
	[Younger] [bit] NULL,
	[Birthdate] [datetime] NULL,
	[Date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[FamilyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[dt_UsersFamily]  WITH CHECK ADD  CONSTRAINT [FK_UsersFamily] FOREIGN KEY([UserID])
REFERENCES [dbo].[dt_Users] ([UserID])
GO
ALTER TABLE [dbo].[dt_UsersFamily] CHECK CONSTRAINT [FK_UsersFamily]
GO
/****** Object:  StoredProcedure [dbo].[DeleteComments]    Script Date: 3/14/2024 8:58:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Xiomara Zapata
-- Create date: 13/03/2024
-- Description: Delete comments by id
-- =============================================
CREATE PROCEDURE [dbo].[DeleteComments]
         (
		   @Id bigint
         )
	
AS
BEGIN
	
	SET NOCOUNT ON;

  DELETE FROM [dbo].[dt_Comments]
      WHERE  Id=  @Id	  
	END
GO
/****** Object:  StoredProcedure [dbo].[DeleteFamilyGroupByUser]    Script Date: 3/14/2024 8:58:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Xiomara Zapata
-- Create date: 13/03/2024
-- Description: Delete family group by login user
-- =============================================
CREATE PROCEDURE [dbo].[DeleteFamilyGroupByUser]
         (
		   @UserId bigint
         )
	
AS
BEGIN
	
	SET NOCOUNT ON;

  DELETE FROM [dbo].[dt_UsersFamily]
      WHERE  UserID=  @UserId	  
	END
GO
/****** Object:  StoredProcedure [dbo].[DeletePosts]    Script Date: 3/14/2024 8:58:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Xiomara Zapata
-- Create date: 13/03/2024
-- Description: Delete psts by id
-- =============================================
CREATE PROCEDURE [dbo].[DeletePosts]
         (
		   @Id bigint
         )
	
AS
BEGIN
	
	SET NOCOUNT ON;

  DELETE FROM [dbo].[dt_Posts]
      WHERE  Id=  @Id	  
	END
GO
/****** Object:  StoredProcedure [dbo].[GetComments]    Script Date: 3/14/2024 8:58:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Xiomara Zapata
-- Create date: 13/03/2024
-- Description:	Consultar comments
-- =============================================
CREATE PROCEDURE [dbo].[GetComments]
	
	
AS
BEGIN
	
	SET NOCOUNT ON;

    
	SELECT  Id,PostId,Name,Email,Body
	from dt_Comments
	order by Id
	END
GO
/****** Object:  StoredProcedure [dbo].[GetPosts]    Script Date: 3/14/2024 8:58:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Xiomara Zapata
-- Create date: 13/03/2024
-- Description:	Consultar familiares
-- =============================================
CREATE PROCEDURE [dbo].[GetPosts]
	
	
AS
BEGIN
	
	SET NOCOUNT ON;

    
	SELECT  Id,UserID,Tittle,Body
	from dt_Posts
	order by Id
	END
GO
/****** Object:  StoredProcedure [dbo].[GetUserByUserName]    Script Date: 3/14/2024 8:58:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Xiomara Zapata
-- Create date: 13/03/2024
-- Description:	Consultar usuario logueado
-- =============================================
CREATE PROCEDURE [dbo].[GetUserByUserName]
	
	@UserName nvarchar(max),
	@Pass nvarchar(max)
AS
BEGIN
	
	SET NOCOUNT ON;

    
	SELECT  UserID, UserName,Password, Date
	from dt_Users
	where UserName= @UserName
	and Password= @Pass
	order by UserName

	END
GO
/****** Object:  StoredProcedure [dbo].[GetUsersFamily]    Script Date: 3/14/2024 8:58:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Xiomara Zapata
-- Create date: 13/03/2024
-- Description:	Consultar familiares
-- =============================================
CREATE PROCEDURE [dbo].[GetUsersFamily]
	
	
AS
BEGIN
	
	SET NOCOUNT ON;

    
	SELECT  UserID,FamilyID,Indetification,Name,LastName,Gender,Relationship,Age,Younger,Birthdate,Date
	from dt_UsersFamily
	order by LastName
	END
GO
/****** Object:  StoredProcedure [dbo].[InsertFamilyGroupByUser]    Script Date: 3/14/2024 8:58:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Xiomara Zapata
-- Create date: 13/03/2024
-- Description:	Create family group by login user
-- =============================================
CREATE PROCEDURE [dbo].[InsertFamilyGroupByUser]
         ( @UserID bigint,
           @Indetification nvarchar(max),
           @Name nvarchar(max),
           @LastName nvarchar(max),
           @Gender nvarchar(max),
           @Relationship nvarchar(max),
           @Age nvarchar(max),
           @Younger nvarchar(max),
           @Birthdate nvarchar(max)
         )
	
AS
BEGIN
	
	SET NOCOUNT ON;

    
	INSERT INTO [dbo].[dt_UsersFamily]
           ([UserID]
           ,[Indetification]
           ,[Name]
           ,[LastName]
           ,[Gender]
           ,[Relationship]
           ,[Age]
           ,[Younger]
           ,[Birthdate]
           ,[Date])
     VALUES
           ( @UserID ,
           @Indetification ,
           @Name ,
           @LastName,
           @Gender,
           @Relationship ,
           @Age,
           @Younger ,
           @Birthdate, 
		   GETDATE() )
		 
		  
	END
GO
/****** Object:  StoredProcedure [dbo].[UpdateComments]    Script Date: 3/14/2024 8:58:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Xiomara Zapata
-- Create date: 13/03/2024
-- Description: Update Comments by id
-- =============================================
CREATE PROCEDURE [dbo].[UpdateComments]
         (
		   @Id bigint,
		   @Name nvarchar(max),
		   @Email nvarchar(max),
		   @Body nvarchar(max)
         
         )
	
AS
BEGIN
	
	SET NOCOUNT ON;

    
	UPDATE  dt_Comments
   SET
       [Name] = @Name
      ,[Email] = @Email
	  ,[Body] = @Body
     
 WHERE  Id= @Id 
		  
	END
GO
/****** Object:  StoredProcedure [dbo].[UpdateFamilyGroupByUser]    Script Date: 3/14/2024 8:58:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Xiomara Zapata
-- Create date: 13/03/2024
-- Description: Update family group by login user
-- =============================================
CREATE PROCEDURE [dbo].[UpdateFamilyGroupByUser]
         (
		   @UserId bigint,
           @Gender nvarchar(max),
           @Relationship nvarchar(max),
           @Age nvarchar(max),
           @Younger nvarchar(max)
          
         )
	
AS
BEGIN
	
	SET NOCOUNT ON;

    
	UPDATE [dbo].[dt_UsersFamily]
   SET
       [Gender] = @Gender
      ,[Relationship] = @Relationship
      ,[Age] = @Age
      ,[Younger] =  @Younger
      ,[Date] =GETDATE()
 WHERE  UserID= @UserId 
		  
	END
GO
/****** Object:  StoredProcedure [dbo].[UpdatePosts]    Script Date: 3/14/2024 8:58:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Xiomara Zapata
-- Create date: 13/03/2024
-- Description: Update posts by id
-- =============================================
CREATE PROCEDURE [dbo].[UpdatePosts]
         (
		   @Id bigint,
		   @Tittle nvarchar(max),
		   @Body nvarchar(max)
         
         )
	
AS
BEGIN
	
	SET NOCOUNT ON;

    
	UPDATE  dt_Posts
   SET
       [Tittle] = @Tittle
      ,[Body] = @Body
     
 WHERE  Id= @Id 
		  
	END
GO
USE [master]
GO
ALTER DATABASE [DB_XYZ] SET  READ_WRITE 
GO
