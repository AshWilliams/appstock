ALTER TABLE [dbo].[Platillos] DROP CONSTRAINT [DF_Platillos_fechaCreacion]
GO

/****** Object:  Table [dbo].[Platillos]    Script Date: 12-08-2019 21:36:10 ******/
DROP TABLE [dbo].[Platillos]
GO

/****** Object:  Table [dbo].[Platillos]    Script Date: 12-08-2019 21:36:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Platillos](
	[idPlatillo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](150) NOT NULL,
	[descripcion] [varchar](350) NULL,
	[fechaCreacion] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Platillos] PRIMARY KEY CLUSTERED 
(
	[idPlatillo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Platillos] ADD  CONSTRAINT [DF_Platillos_fechaCreacion]  DEFAULT (getdate()) FOR [fechaCreacion]
GO


