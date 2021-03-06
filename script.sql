USE [biblio]
GO
/****** Object:  Table [dbo].[Auteur]    Script Date: 02/08/2021 20:21:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Auteur](
	[id_auteur] [int] NOT NULL,
	[nom_auteur] [nvarchar](50) NOT NULL,
	[prenom_auteur] [nvarchar](50) NOT NULL,
	[nationalite] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Auteur] PRIMARY KEY CLUSTERED 
(
	[id_auteur] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courant]    Script Date: 02/08/2021 20:21:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courant](
	[id_courant] [int] NOT NULL,
	[libelle_courant] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Courant] PRIMARY KEY CLUSTERED 
(
	[id_courant] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 02/08/2021 20:21:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[id_genre] [int] NOT NULL,
	[libelle_genre] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Genre] PRIMARY KEY CLUSTERED 
(
	[id_genre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Livre]    Script Date: 02/08/2021 20:21:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Livre](
	[id_livre] [int] NOT NULL,
	[titre] [char](50) NULL,
	[langue] [char](50) NULL,
	[nbre_page] [int] NULL,
	[image_livre] [char](50) NULL,
	[date_parution] [date] NULL,
	[id_auteur] [int] NULL,
	[id_genre] [int] NULL,
	[id_courant] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_livre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Livre]  WITH CHECK ADD FOREIGN KEY([id_auteur])
REFERENCES [dbo].[Auteur] ([id_auteur])
GO
ALTER TABLE [dbo].[Livre]  WITH CHECK ADD FOREIGN KEY([id_courant])
REFERENCES [dbo].[Courant] ([id_courant])
GO
ALTER TABLE [dbo].[Livre]  WITH CHECK ADD FOREIGN KEY([id_genre])
REFERENCES [dbo].[Genre] ([id_genre])
GO
