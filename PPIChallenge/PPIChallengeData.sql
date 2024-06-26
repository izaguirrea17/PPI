USE [PPIChallenge]
GO
/****** Object:  Table [dbo].[Activos]    Script Date: 27/5/2024 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ticker] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[IDTipoActivo] [int] NOT NULL,
	[PrecioUnitario] [decimal](18, 4) NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuentas]    Script Date: 27/5/2024 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuentas](
	[IDCuenta] [int] IDENTITY(1,1) NOT NULL,
	[IDPersona] [int] NULL,
	[VigenciaDesde] [datetime] NOT NULL,
	[VigenciaHasta] [datetime] NULL,
 CONSTRAINT [PK_Cuentas] PRIMARY KEY CLUSTERED 
(
	[IDCuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estados]    Script Date: 27/5/2024 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estados](
	[ID] [int] IDENTITY(0,1) NOT NULL,
	[DescripcionEstado] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Estados] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ordenes]    Script Date: 27/5/2024 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ordenes](
	[IDOrden] [int] IDENTITY(1,1) NOT NULL,
	[IDCuenta] [int] NOT NULL,
	[IDActivo] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[Operacion] [varchar](1) NOT NULL,
	[Estado] [int] NOT NULL,
	[MontoTotal] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Ordenes] PRIMARY KEY CLUSTERED 
(
	[IDOrden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personas]    Script Date: 27/5/2024 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personas](
	[IDPersona] [int] IDENTITY(1,1) NOT NULL,
	[CUIL] [varchar](100) NOT NULL,
	[RazonSocial] [varchar](100) NOT NULL,
	[Mail] [varchar](100) NOT NULL,
	[Telefono] [varchar](100) NOT NULL,
	[Direccion] [varchar](100) NOT NULL,
	[IDTipoPersona] [int] NOT NULL,
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[IDPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposDeActivos]    Script Date: 27/5/2024 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposDeActivos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_TiposDeActivos] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposDePersona]    Script Date: 27/5/2024 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposDePersona](
	[IDTipoPersona] [int] IDENTITY(1,1) NOT NULL,
	[TipoDePersona] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TiposDePersona] PRIMARY KEY CLUSTERED 
(
	[IDTipoPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Activos] ON 

INSERT [dbo].[Activos] ([ID], [Ticker], [Nombre], [IDTipoActivo], [PrecioUnitario]) VALUES (1, N'AAPL', N'Apple', 1, CAST(177.9700 AS Decimal(18, 4)))
INSERT [dbo].[Activos] ([ID], [Ticker], [Nombre], [IDTipoActivo], [PrecioUnitario]) VALUES (2, N'GOOGL', N'Alphabet Inc', 1, CAST(138.2100 AS Decimal(18, 4)))
INSERT [dbo].[Activos] ([ID], [Ticker], [Nombre], [IDTipoActivo], [PrecioUnitario]) VALUES (3, N'MSFT', N'Microsoft', 1, CAST(329.0400 AS Decimal(18, 4)))
INSERT [dbo].[Activos] ([ID], [Ticker], [Nombre], [IDTipoActivo], [PrecioUnitario]) VALUES (4, N'KO', N'Coca Cola', 1, CAST(58.3000 AS Decimal(18, 4)))
INSERT [dbo].[Activos] ([ID], [Ticker], [Nombre], [IDTipoActivo], [PrecioUnitario]) VALUES (5, N'WMT', N'Walmart', 1, CAST(163.4200 AS Decimal(18, 4)))
INSERT [dbo].[Activos] ([ID], [Ticker], [Nombre], [IDTipoActivo], [PrecioUnitario]) VALUES (6, N'AL30', N'BONOS ARGENTINA USD 2030 L.A', 2, CAST(307.4000 AS Decimal(18, 4)))
INSERT [dbo].[Activos] ([ID], [Ticker], [Nombre], [IDTipoActivo], [PrecioUnitario]) VALUES (7, N'GD30', N'Bonos Globales Argentina USD Step Up 2030', 2, CAST(336.1000 AS Decimal(18, 4)))
INSERT [dbo].[Activos] ([ID], [Ticker], [Nombre], [IDTipoActivo], [PrecioUnitario]) VALUES (8, N'Delta.Pesos', N'Delta Pesos Clase A', 3, CAST(0.0181 AS Decimal(18, 4)))
INSERT [dbo].[Activos] ([ID], [Ticker], [Nombre], [IDTipoActivo], [PrecioUnitario]) VALUES (9, N'Fima.Premium', N'Fima Premium Clase A', 3, CAST(0.0317 AS Decimal(18, 4)))
SET IDENTITY_INSERT [dbo].[Activos] OFF
GO
SET IDENTITY_INSERT [dbo].[Cuentas] ON 

INSERT [dbo].[Cuentas] ([IDCuenta], [IDPersona], [VigenciaDesde], [VigenciaHasta]) VALUES (1, 1, CAST(N'2010-10-10T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Cuentas] ([IDCuenta], [IDPersona], [VigenciaDesde], [VigenciaHasta]) VALUES (2, 2, CAST(N'2022-10-10T00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Cuentas] OFF
GO
SET IDENTITY_INSERT [dbo].[Estados] ON 

INSERT [dbo].[Estados] ([ID], [DescripcionEstado]) VALUES (0, N'En proceso')
INSERT [dbo].[Estados] ([ID], [DescripcionEstado]) VALUES (1, N'Ejecutada')
INSERT [dbo].[Estados] ([ID], [DescripcionEstado]) VALUES (3, N'Cancelada')
SET IDENTITY_INSERT [dbo].[Estados] OFF
GO
SET IDENTITY_INSERT [dbo].[Ordenes] ON 

INSERT [dbo].[Ordenes] ([IDOrden], [IDCuenta], [IDActivo], [Cantidad], [Precio], [Operacion], [Estado], [MontoTotal]) VALUES (5, 1, 4, 5, CAST(2.00 AS Decimal(18, 2)), N'C', 3, CAST(79.87 AS Decimal(18, 2)))
INSERT [dbo].[Ordenes] ([IDOrden], [IDCuenta], [IDActivo], [Cantidad], [Precio], [Operacion], [Estado], [MontoTotal]) VALUES (6, 2, 5, 6, CAST(2.00 AS Decimal(18, 2)), N'V', 3, CAST(268.66 AS Decimal(18, 2)))
INSERT [dbo].[Ordenes] ([IDOrden], [IDCuenta], [IDActivo], [Cantidad], [Precio], [Operacion], [Estado], [MontoTotal]) VALUES (7, 2, 1, 2, CAST(2.00 AS Decimal(18, 2)), N'V', 1, CAST(97.53 AS Decimal(18, 2)))
INSERT [dbo].[Ordenes] ([IDOrden], [IDCuenta], [IDActivo], [Cantidad], [Precio], [Operacion], [Estado], [MontoTotal]) VALUES (13, 1, 5, 5, CAST(3.00 AS Decimal(18, 2)), N'V', 1, CAST(223.89 AS Decimal(18, 2)))
INSERT [dbo].[Ordenes] ([IDOrden], [IDCuenta], [IDActivo], [Cantidad], [Precio], [Operacion], [Estado], [MontoTotal]) VALUES (14, 1, 5, 2, CAST(20.00 AS Decimal(18, 2)), N'V', 1, CAST(89.55 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Ordenes] OFF
GO
SET IDENTITY_INSERT [dbo].[Personas] ON 

INSERT [dbo].[Personas] ([IDPersona], [CUIL], [RazonSocial], [Mail], [Telefono], [Direccion], [IDTipoPersona]) VALUES (1, N'20350802089', N'Alan Izaguirre', N'izaguirrea17@gmail.com', N'3412586993', N'F Bilbao 1349', 1)
INSERT [dbo].[Personas] ([IDPersona], [CUIL], [RazonSocial], [Mail], [Telefono], [Direccion], [IDTipoPersona]) VALUES (2, N'20378964567', N'Empresa SA', N'empresa@gmail.com', N'34125784563', N'Directorio 5000', 2)
SET IDENTITY_INSERT [dbo].[Personas] OFF
GO
SET IDENTITY_INSERT [dbo].[TiposDeActivos] ON 

INSERT [dbo].[TiposDeActivos] ([ID], [Descripcion]) VALUES (1, N'Acción')
INSERT [dbo].[TiposDeActivos] ([ID], [Descripcion]) VALUES (2, N'Bono')
INSERT [dbo].[TiposDeActivos] ([ID], [Descripcion]) VALUES (3, N'FCI')
SET IDENTITY_INSERT [dbo].[TiposDeActivos] OFF
GO
SET IDENTITY_INSERT [dbo].[TiposDePersona] ON 

INSERT [dbo].[TiposDePersona] ([IDTipoPersona], [TipoDePersona]) VALUES (1, N'Fisica')
INSERT [dbo].[TiposDePersona] ([IDTipoPersona], [TipoDePersona]) VALUES (2, N'Juridica')
SET IDENTITY_INSERT [dbo].[TiposDePersona] OFF
GO
ALTER TABLE [dbo].[Activos]  WITH CHECK ADD  CONSTRAINT [FK_Activos_Ta] FOREIGN KEY([IDTipoActivo])
REFERENCES [dbo].[TiposDeActivos] ([ID])
GO
ALTER TABLE [dbo].[Activos] CHECK CONSTRAINT [FK_Activos_Ta]
GO
ALTER TABLE [dbo].[Ordenes]  WITH CHECK ADD  CONSTRAINT [FK_Ordenes_Activos] FOREIGN KEY([IDActivo])
REFERENCES [dbo].[Activos] ([ID])
GO
ALTER TABLE [dbo].[Ordenes] CHECK CONSTRAINT [FK_Ordenes_Activos]
GO
ALTER TABLE [dbo].[Ordenes]  WITH CHECK ADD  CONSTRAINT [FK_Ordenes_Cuentas] FOREIGN KEY([IDCuenta])
REFERENCES [dbo].[Cuentas] ([IDCuenta])
GO
ALTER TABLE [dbo].[Ordenes] CHECK CONSTRAINT [FK_Ordenes_Cuentas]
GO
ALTER TABLE [dbo].[Ordenes]  WITH CHECK ADD  CONSTRAINT [FK_Ordenes_Estados] FOREIGN KEY([Estado])
REFERENCES [dbo].[Estados] ([ID])
GO
ALTER TABLE [dbo].[Ordenes] CHECK CONSTRAINT [FK_Ordenes_Estados]
GO
ALTER TABLE [dbo].[Personas]  WITH CHECK ADD  CONSTRAINT [FK_Personas_TiposPersonas] FOREIGN KEY([IDTipoPersona])
REFERENCES [dbo].[TiposDePersona] ([IDTipoPersona])
GO
ALTER TABLE [dbo].[Personas] CHECK CONSTRAINT [FK_Personas_TiposPersonas]
GO
ALTER TABLE [dbo].[TiposDeActivos]  WITH CHECK ADD  CONSTRAINT [FK_TiposDeActivos_Activos] FOREIGN KEY([ID])
REFERENCES [dbo].[TiposDeActivos] ([ID])
GO
ALTER TABLE [dbo].[TiposDeActivos] CHECK CONSTRAINT [FK_TiposDeActivos_Activos]
GO
