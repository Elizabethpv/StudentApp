USE [SchoolManagementSystem]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 18-03-2021 17:15:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](15) NOT NULL,
	[Email] [nvarchar](30) NOT NULL,
	[Maths] [int] NOT NULL,
	[English] [int] NOT NULL,
	[Malayalam] [int] NOT NULL,
	[UserName] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[Color] [nvarchar](20) NOT NULL,
	[Left] [int] NULL,
	[Top] [int] NULL,
 CONSTRAINT [PK__Student__3214EC07D5E4F3BE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([Id], [Name], [Email], [Maths], [English], [Malayalam], [UserName], [Password], [Color], [Left], [Top]) VALUES (1, N'Jaisus', N'jaisus@gmail.com', 89, 78, 67, N'jai', N'jai', N'-65536', 448, 69)
INSERT [dbo].[Student] ([Id], [Name], [Email], [Maths], [English], [Malayalam], [UserName], [Password], [Color], [Left], [Top]) VALUES (2, N'Mariya', N'mariya123@gmail.com', 67, 80, 90, N'mariya', N'mariya', N'-65536', 130, 130)
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [DF__Student__Color__37A5467C]  DEFAULT ('-65536') FOR [Color]
GO
/****** Object:  StoredProcedure [dbo].[StudentList]    Script Date: 18-03-2021 17:15:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[StudentList]
		@Id INT


AS
BEGIN
	SELECT *FROM [dbo].[Student]
	WHERE [Id]=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[StudentLogin]    Script Date: 18-03-2021 17:15:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[StudentLogin]
		@UserName   NVARCHAR(20)
		,@Password  NVARCHAR(20)

AS
BEGIN
	SELECT *FROM [dbo].[Student]
	WHERE [UserName]=@UserName
	AND [Password]=@Password
END
GO
/****** Object:  StoredProcedure [dbo].[StudentPageColorSet]    Script Date: 18-03-2021 17:15:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[StudentPageColorSet]
      @Id  INT
	 ,@Color NVARCHAR(20)
AS
BEGIN
	UPDATE [dbo].[Student]
	SET [Color]=@Color
	WHERE [Id]=@Id

END
GO
/****** Object:  StoredProcedure [dbo].[StudentRegister]    Script Date: 18-03-2021 17:15:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[StudentRegister]
		 @Name			NVARCHAR(15)
		,@Email			NVARCHAR(30)
		,@Maths 		INT
		,@English		INT
		,@Malayalam		INT
		,@UserName	    NVARCHAR(20)
		,@Password      NVARCHAR(20)
		,@Left          INT
		,@Top			INT

AS
BEGIN
	INSERT INTO Student
	(
      [Name]
	,[Email]
	,[Maths]
	,[English]
	,[Malayalam]
	,[UserName]
	,[Password]
	,[Left]
	,[Top]
	
	)
	VALUES
	(
	 @Name		
	,@Email		
	,@Maths 	
	,@English	
	,@Malayalam	
	,@UserName	 
	,@Password   
	,@Left  
	,@Top	
	)
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateWindowPosition]    Script Date: 18-03-2021 17:15:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateWindowPosition]
    @Id     INT
   ,@left   INT
   ,@top    INT
AS
BEGIN
    UPDATE[dbo].[Student]
	SET [Left]=@left
	, [Top]=@top
	WHERE [Id]= @Id
	
END
GO
