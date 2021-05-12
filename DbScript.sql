USE [Jwelery_DB]
GO
/****** Object:  Table [dbo].[UserData]    Script Date: 5/12/2021 6:56:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserData](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](100) NULL,
	[IsPriviledgedUser] [bit] NOT NULL,
	[Password] [nvarchar](100) NULL,
 CONSTRAINT [PK_UserData] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[UserData] ON 
GO
INSERT [dbo].[UserData] ([UserId], [UserName], [IsPriviledgedUser], [Password]) VALUES (1, N'admin@gmail.com', 1, N'admin')
GO
INSERT [dbo].[UserData] ([UserId], [UserName], [IsPriviledgedUser], [Password]) VALUES (2, N'john@gmail.com', 0, N'sara')
GO
SET IDENTITY_INSERT [dbo].[UserData] OFF
GO
