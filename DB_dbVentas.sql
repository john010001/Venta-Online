USE [master]
GO
/****** Object:  Database [dbVentas]    Script Date: 19/11/2021 12:07:18 p. m. ******/
CREATE DATABASE [dbVentas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbVentas', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER2017\MSSQL\DATA\dbVentas.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbVentas_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER2017\MSSQL\DATA\dbVentas_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [dbVentas] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbVentas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbVentas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbVentas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbVentas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbVentas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbVentas] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbVentas] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbVentas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbVentas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbVentas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbVentas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbVentas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbVentas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbVentas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbVentas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbVentas] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbVentas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbVentas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbVentas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbVentas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbVentas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbVentas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbVentas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbVentas] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbVentas] SET  MULTI_USER 
GO
ALTER DATABASE [dbVentas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbVentas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbVentas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbVentas] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbVentas] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbVentas] SET QUERY_STORE = OFF
GO
USE [dbVentas]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 19/11/2021 12:07:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 19/11/2021 12:07:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[Ciudad] [nvarchar](100) NOT NULL,
	[DNI] [nvarchar](8) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[Password] [nvarchar](100) NULL,
	[Estado] [bit] NOT NULL,
	[FechaCreacion] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 19/11/2021 12:07:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[Stock] [decimal](18, 2) NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[FechaModificacion] [datetime] NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductoImagen]    Script Date: 19/11/2021 12:07:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductoImagen](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdProducto] [int] NOT NULL,
	[ImagenSrc] [nvarchar](200) NOT NULL,
	[Orden] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_ProductoImagen] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 19/11/2021 12:07:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[IdCliente] [int] NOT NULL,
 CONSTRAINT [PK_Venta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VentaDetalle]    Script Date: 19/11/2021 12:07:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VentaDetalle](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdVenta] [bigint] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [decimal](18, 2) NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 
GO
INSERT [dbo].[Categoria] ([Id], [Nombre], [Estado]) VALUES (1, N'Computadoras', 1)
GO
INSERT [dbo].[Categoria] ([Id], [Nombre], [Estado]) VALUES (2, N'Teclados25', 1)
GO
INSERT [dbo].[Categoria] ([Id], [Nombre], [Estado]) VALUES (3, N'Categoria 3', 0)
GO
INSERT [dbo].[Categoria] ([Id], [Nombre], [Estado]) VALUES (4, N'Categoria 3', 1)
GO
INSERT [dbo].[Categoria] ([Id], [Nombre], [Estado]) VALUES (5, N'Categoria 3', 1)
GO
INSERT [dbo].[Categoria] ([Id], [Nombre], [Estado]) VALUES (6, N'Categoria 3', 0)
GO
INSERT [dbo].[Categoria] ([Id], [Nombre], [Estado]) VALUES (7, N'Categoria 3', 1)
GO
INSERT [dbo].[Categoria] ([Id], [Nombre], [Estado]) VALUES (8, N'Categoria 3', 1)
GO
INSERT [dbo].[Categoria] ([Id], [Nombre], [Estado]) VALUES (9, N'Categoria 3', 1)
GO
INSERT [dbo].[Categoria] ([Id], [Nombre], [Estado]) VALUES (10, N'Categoria 3', 1)
GO
INSERT [dbo].[Categoria] ([Id], [Nombre], [Estado]) VALUES (11, N'Categoria 3', 0)
GO
INSERT [dbo].[Categoria] ([Id], [Nombre], [Estado]) VALUES (12, N'Categoria 4', 1)
GO
INSERT [dbo].[Categoria] ([Id], [Nombre], [Estado]) VALUES (13, N'Categoria test', 1)
GO
INSERT [dbo].[Categoria] ([Id], [Nombre], [Estado]) VALUES (14, N'categoria 2', 1)
GO
INSERT [dbo].[Categoria] ([Id], [Nombre], [Estado]) VALUES (15, N'categoria 3', 1)
GO
INSERT [dbo].[Categoria] ([Id], [Nombre], [Estado]) VALUES (16, N'prueba 1', 1)
GO
INSERT [dbo].[Categoria] ([Id], [Nombre], [Estado]) VALUES (17, N'nueva categoria 001', 1)
GO
INSERT [dbo].[Categoria] ([Id], [Nombre], [Estado]) VALUES (18, N'Test-Categoria', 1)
GO
INSERT [dbo].[Categoria] ([Id], [Nombre], [Estado]) VALUES (19, N'Test-Categoria', 1)
GO
INSERT [dbo].[Categoria] ([Id], [Nombre], [Estado]) VALUES (20, N'Test-Categoria', 1)
GO
INSERT [dbo].[Categoria] ([Id], [Nombre], [Estado]) VALUES (21, N'Test-Categoria', 1)
GO
INSERT [dbo].[Categoria] ([Id], [Nombre], [Estado]) VALUES (22, N'Test-Categoria', 1)
GO
INSERT [dbo].[Categoria] ([Id], [Nombre], [Estado]) VALUES (23, N'Test-Categoria-25538db3-1315-4b18-b177-dfe42a5eb3a3', 1)
GO
INSERT [dbo].[Categoria] ([Id], [Nombre], [Estado]) VALUES (24, N'Test-Categoria-97c6f64b-6cac-4b2b-ad8d-f3450e33aa04', 1)
GO
INSERT [dbo].[Categoria] ([Id], [Nombre], [Estado]) VALUES (25, N'Test-Categoria-88914cb7-2652-4e18-81eb-6ad1f5c0159d', 1)
GO
INSERT [dbo].[Categoria] ([Id], [Nombre], [Estado]) VALUES (26, N'Test-Categoria-1da0b0dc-6f45-4e50-8e47-f056a084e9c5', 1)
GO
INSERT [dbo].[Categoria] ([Id], [Nombre], [Estado]) VALUES (28, N'Test-Categoria-7a2e943b-45f9-4b1f-9822-9d7b4e85a0de', 1)
GO
INSERT [dbo].[Categoria] ([Id], [Nombre], [Estado]) VALUES (29, N'Test-Categoria-67a1d907-1da1-4bff-8ea2-004939a9d5b5', 1)
GO
INSERT [dbo].[Categoria] ([Id], [Nombre], [Estado]) VALUES (40, N'ejemplo2', 1)
GO
INSERT [dbo].[Categoria] ([Id], [Nombre], [Estado]) VALUES (41, N'ejemplo3', 1)
GO
INSERT [dbo].[Categoria] ([Id], [Nombre], [Estado]) VALUES (42, N'ejemplo50', 1)
GO
SET IDENTITY_INSERT [dbo].[Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 
GO
INSERT [dbo].[Cliente] ([Id], [Nombre], [Direccion], [Ciudad], [DNI], [Email], [Password], [Estado], [FechaCreacion], [FechaModificacion]) VALUES (1, N'Javier Tunoque', N'Los alamos', N'Lima', N'40780001', N'javiertuga@gmail.com', N'123456', 1, CAST(N'2021-05-18T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Cliente] ([Id], [Nombre], [Direccion], [Ciudad], [DNI], [Email], [Password], [Estado], [FechaCreacion], [FechaModificacion]) VALUES (2, N'John', N'Av.Peru', N'Lima', N'46956958', N'j.espino@gmail.com', N'152200', 1, CAST(N'1894-06-28T00:00:00.000' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 
GO
INSERT [dbo].[Producto] ([Id], [IdCategoria], [Nombre], [Precio], [Stock], [Estado], [FechaCreacion], [FechaModificacion]) VALUES (1, 4, N'pruebas de producto 1', CAST(10.00 AS Decimal(18, 2)), CAST(15.00 AS Decimal(18, 2)), 1, CAST(N'2021-05-12T01:09:14.590' AS DateTime), NULL)
GO
INSERT [dbo].[Producto] ([Id], [IdCategoria], [Nombre], [Precio], [Stock], [Estado], [FechaCreacion], [FechaModificacion]) VALUES (2, 13, N'pruebas de producto 1', CAST(20.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), 1, CAST(N'2021-05-14T01:45:07.047' AS DateTime), NULL)
GO
INSERT [dbo].[Producto] ([Id], [IdCategoria], [Nombre], [Precio], [Stock], [Estado], [FechaCreacion], [FechaModificacion]) VALUES (3, 14, N'test 455', CAST(10.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), 1, CAST(N'2021-05-19T03:27:23.583' AS DateTime), NULL)
GO
INSERT [dbo].[Producto] ([Id], [IdCategoria], [Nombre], [Precio], [Stock], [Estado], [FechaCreacion], [FechaModificacion]) VALUES (4, 12, N'pruebas de producto 1', CAST(20.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), 1, CAST(N'2021-05-22T20:30:13.543' AS DateTime), NULL)
GO
INSERT [dbo].[Producto] ([Id], [IdCategoria], [Nombre], [Precio], [Stock], [Estado], [FechaCreacion], [FechaModificacion]) VALUES (5, 14, N'test cat 4-1', CAST(10.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), 1, CAST(N'2021-05-22T20:55:22.913' AS DateTime), NULL)
GO
INSERT [dbo].[Producto] ([Id], [IdCategoria], [Nombre], [Precio], [Stock], [Estado], [FechaCreacion], [FechaModificacion]) VALUES (6, 14, N'cap 04', CAST(10.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), 1, CAST(N'2021-05-22T21:03:33.700' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([Id])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Categoria]
GO
ALTER TABLE [dbo].[ProductoImagen]  WITH CHECK ADD  CONSTRAINT [FK_ProductoImagen_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([Id])
GO
ALTER TABLE [dbo].[ProductoImagen] CHECK CONSTRAINT [FK_ProductoImagen_Producto]
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_Cliente]
GO
ALTER TABLE [dbo].[VentaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_VentaDetalle_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([Id])
GO
ALTER TABLE [dbo].[VentaDetalle] CHECK CONSTRAINT [FK_VentaDetalle_Producto]
GO
ALTER TABLE [dbo].[VentaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_VentaDetalle_Venta] FOREIGN KEY([IdVenta])
REFERENCES [dbo].[Venta] ([Id])
GO
ALTER TABLE [dbo].[VentaDetalle] CHECK CONSTRAINT [FK_VentaDetalle_Venta]
GO
USE [master]
GO
ALTER DATABASE [dbVentas] SET  READ_WRITE 
GO
