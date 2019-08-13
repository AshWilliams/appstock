ALTER TABLE [dbo].[Ingredientes] DROP CONSTRAINT [DF_Ingredientes_fechaCreacion]
GO

/****** Object:  Table [dbo].[Ingredientes]    Script Date: 12-08-2019 21:35:47 ******/
DROP TABLE [dbo].[Ingredientes]
GO

/****** Object:  Table [dbo].[Ingredientes]    Script Date: 12-08-2019 21:35:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Ingredientes](
	[idIngrediente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](150) NOT NULL,
	[descripcion] [varchar](350) NULL,
	[cantidad] [int] NOT NULL,
	[fechaCreacion] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Ingredientes] PRIMARY KEY CLUSTERED 
(
	[idIngrediente] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Ingredientes] ADD  CONSTRAINT [DF_Ingredientes_fechaCreacion]  DEFAULT (getdate()) FOR [fechaCreacion]
GO


