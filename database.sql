USE [master]
GO
/****** Object:  Database [AssemblyProject]    Script Date: 12/03/2025 17:59:12 ******/
CREATE DATABASE [AssemblyProject]
 CONTAINMENT = NONE
 
USE [AssemblyProject]
GO
/****** Object:  Table [dbo].[Booking_Classes]    Script Date: 12/03/2025 17:59:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking_Classes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[studentId] [int] NULL,
	[classId] [int] NULL,
	[teacherId] [int] NULL,
 CONSTRAINT [PK__Booking___3213E83F33DBF4AC] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 12/03/2025 17:59:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[className] [nvarchar](50) NOT NULL,
	[classRoom] [nvarchar](50) NOT NULL,
	[capacity] [int] NOT NULL,
	[time] [datetime] NULL,
 CONSTRAINT [PK__Classes__3213E83F7AA2A5CF] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 12/03/2025 17:59:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nvarchar](50) NOT NULL,
	[lastName] [nvarchar](50) NOT NULL,
	[username] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
 CONSTRAINT [PK__Students__3213E83F84F2012F] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 12/03/2025 17:59:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nvarchar](50) NOT NULL,
	[lastName] [nvarchar](50) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__Teachers__03AE777E7C9D258C] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Booking_Classes] ON 

INSERT [dbo].[Booking_Classes] ([id], [studentId], [classId], [teacherId]) VALUES (5, 1, 3, 1)
INSERT [dbo].[Booking_Classes] ([id], [studentId], [classId], [teacherId]) VALUES (1005, 1, 3, 1)
INSERT [dbo].[Booking_Classes] ([id], [studentId], [classId], [teacherId]) VALUES (2005, 2037, 3, 1)
INSERT [dbo].[Booking_Classes] ([id], [studentId], [classId], [teacherId]) VALUES (2006, 2037, 15, 1)
INSERT [dbo].[Booking_Classes] ([id], [studentId], [classId], [teacherId]) VALUES (2007, NULL, NULL, NULL)
INSERT [dbo].[Booking_Classes] ([id], [studentId], [classId], [teacherId]) VALUES (3005, 2037, 12, 3004)
INSERT [dbo].[Booking_Classes] ([id], [studentId], [classId], [teacherId]) VALUES (3006, 2037, 12, NULL)
SET IDENTITY_INSERT [dbo].[Booking_Classes] OFF
GO
SET IDENTITY_INSERT [dbo].[Classes] ON 

INSERT [dbo].[Classes] ([id], [className], [classRoom], [capacity], [time]) VALUES (3, N'CSS', N'5', 21, CAST(N'2025-11-19T19:00:00.000' AS DateTime))
INSERT [dbo].[Classes] ([id], [className], [classRoom], [capacity], [time]) VALUES (12, N'HTML', N'2', 4, CAST(N'2024-11-19T19:00:00.000' AS DateTime))
INSERT [dbo].[Classes] ([id], [className], [classRoom], [capacity], [time]) VALUES (15, N'SQL', N'3', 4, CAST(N'2024-11-19T19:00:00.000' AS DateTime))
INSERT [dbo].[Classes] ([id], [className], [classRoom], [capacity], [time]) VALUES (63, N'CSHAP', N'2', 10, CAST(N'2003-12-12T18:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Classes] OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([id], [firstName], [lastName], [username], [password]) VALUES (1, N'João', N'Silva', N'joao', N'123')
INSERT [dbo].[Students] ([id], [firstName], [lastName], [username], [password]) VALUES (2, N'Carlos', N'Souza', N'carlos', N'123')
INSERT [dbo].[Students] ([id], [firstName], [lastName], [username], [password]) VALUES (3, N'Bruna', N'Lopes', N'bruna', N'123')
INSERT [dbo].[Students] ([id], [firstName], [lastName], [username], [password]) VALUES (1028, N'John', N'lendo', N'jhom', N'123')
INSERT [dbo].[Students] ([id], [firstName], [lastName], [username], [password]) VALUES (2037, N'Amanda', N'Lemos', N'mdlemos', N'123')
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([id], [firstName], [lastName], [username], [password]) VALUES (1, N'admin', N'admin', N'admin', N'admin')
INSERT [dbo].[Teacher] ([id], [firstName], [lastName], [username], [password]) VALUES (2, N'Nuno', N'Santos', N'nuno', N'123')
INSERT [dbo].[Teacher] ([id], [firstName], [lastName], [username], [password]) VALUES (1002, N'Ana', N'Maria', N'ana', N'123')
INSERT [dbo].[Teacher] ([id], [firstName], [lastName], [username], [password]) VALUES (1003, N'Tio', N'Ben', N'ben', N'123')
INSERT [dbo].[Teacher] ([id], [firstName], [lastName], [username], [password]) VALUES (1004, N'Pele', N'pele', N'pele', N'123')
INSERT [dbo].[Teacher] ([id], [firstName], [lastName], [username], [password]) VALUES (2004, N'joao', N'ronaldo', N'teste', N'123')
INSERT [dbo].[Teacher] ([id], [firstName], [lastName], [username], [password]) VALUES (3004, N'maria', N'lemos', N'mlemoz', N'123')
SET IDENTITY_INSERT [dbo].[Teacher] OFF
GO
ALTER TABLE [dbo].[Booking_Classes]  WITH CHECK ADD  CONSTRAINT [FK__Booking_C__stude__3B75D760] FOREIGN KEY([studentId])
REFERENCES [dbo].[Students] ([id])
GO
ALTER TABLE [dbo].[Booking_Classes] CHECK CONSTRAINT [FK__Booking_C__stude__3B75D760]
GO
ALTER TABLE [dbo].[Booking_Classes]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Classes_Booking_Classes] FOREIGN KEY([classId])
REFERENCES [dbo].[Classes] ([id])
GO
ALTER TABLE [dbo].[Booking_Classes] CHECK CONSTRAINT [FK_Booking_Classes_Booking_Classes]
GO
ALTER TABLE [dbo].[Booking_Classes]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Classes_Teachers] FOREIGN KEY([teacherId])
REFERENCES [dbo].[Teacher] ([id])
GO
ALTER TABLE [dbo].[Booking_Classes] CHECK CONSTRAINT [FK_Booking_Classes_Teachers]
GO
USE [master]
GO
ALTER DATABASE [AssemblyProject] SET  READ_WRITE 
GO
