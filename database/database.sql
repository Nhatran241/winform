USE [dulichdb]
GO
/****** Object:  Table [dbo].[ChiTietTours]    Script Date: 10/3/2020 9:18:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietTours](
	[MaChiTietTour] [int] IDENTITY(1,1) NOT NULL,
	[MaDiaDiem] [int] NOT NULL,
	[MaTour] [int] NOT NULL,
	[ThuTu] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ChiTietTours] PRIMARY KEY CLUSTERED 
(
	[MaChiTietTour] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiaDiems]    Script Date: 10/3/2020 9:18:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiaDiems](
	[MaDienDiem] [int] IDENTITY(1,1) NOT NULL,
	[TenDiaDiem] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.DiaDiems] PRIMARY KEY CLUSTERED 
(
	[MaDienDiem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gias]    Script Date: 10/3/2020 9:18:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gias](
	[MaGia] [int] IDENTITY(1,1) NOT NULL,
	[GiaTri] [bigint] NOT NULL,
	[ThoiGianBatDau] [datetime] NOT NULL,
	[ThoiGianKetThuc] [datetime] NOT NULL,
	[TourisId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Gias] PRIMARY KEY CLUSTERED 
(
	[MaGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Loais]    Script Date: 10/3/2020 9:18:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loais](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenLoai] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Loais] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Touris]    Script Date: 10/3/2020 9:18:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Touris](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[LoaiId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Touris] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ChiTietTours] ON 

INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (1076, 2, 1005, 1)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (1077, 5, 1005, 4)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (1078, 5, 1005, 5)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (1079, 4, 1005, 8)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (2002, 4, 1005, 9)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (3002, 2, 1005, 2)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (3003, 3, 1005, 3)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (3004, 6, 1005, 6)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (3005, 6, 1005, 7)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (3006, 8, 1005, 10)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (3007, 8, 1005, 11)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (4003, 4, 3011, 1)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (4004, 8, 3011, 2)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (4005, 6, 3011, 3)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (5002, 2, 4008, 1)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (5003, 3, 4008, 2)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (5004, 6, 4008, 3)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (5006, 3, 1008, 1)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (5007, 6, 1008, 2)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (5008, 7, 4009, 1)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (5009, 5, 4009, 2)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (5010, 4, 4012, 1)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (5011, 6, 4012, 2)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (5012, 3, 4012, 3)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (5013, 3, 2018, 1)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (5014, 2, 2018, 2)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (5015, 3, 4013, 1)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (5016, 4, 4013, 2)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (5017, 8, 4013, 3)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (5019, 4, 2008, 1)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (5020, 6, 2008, 2)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (5021, 2, 2009, 1)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (5022, 4, 2009, 2)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (6002, 3, 5008, 1)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (6003, 5, 5008, 2)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (7002, 2, 1008, 3)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (8002, 7, 5008, 3)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (9002, 5, 6008, 1)
INSERT [dbo].[ChiTietTours] ([MaChiTietTour], [MaDiaDiem], [MaTour], [ThuTu]) VALUES (9003, 3, 6008, 2)
SET IDENTITY_INSERT [dbo].[ChiTietTours] OFF
GO
SET IDENTITY_INSERT [dbo].[DiaDiems] ON 

INSERT [dbo].[DiaDiems] ([MaDienDiem], [TenDiaDiem]) VALUES (1, N'Đà Lạt')
INSERT [dbo].[DiaDiems] ([MaDienDiem], [TenDiaDiem]) VALUES (2, N'Hà Nội')
INSERT [dbo].[DiaDiems] ([MaDienDiem], [TenDiaDiem]) VALUES (3, N'Đà Nẵng')
INSERT [dbo].[DiaDiems] ([MaDienDiem], [TenDiaDiem]) VALUES (4, N'Tp Hồ Chí Minh')
INSERT [dbo].[DiaDiems] ([MaDienDiem], [TenDiaDiem]) VALUES (5, N'Vũng Tàu')
INSERT [dbo].[DiaDiems] ([MaDienDiem], [TenDiaDiem]) VALUES (6, N'Nha Trang')
INSERT [dbo].[DiaDiems] ([MaDienDiem], [TenDiaDiem]) VALUES (7, N'Phan Thiết')
INSERT [dbo].[DiaDiems] ([MaDienDiem], [TenDiaDiem]) VALUES (8, N'Mũi Né')
INSERT [dbo].[DiaDiems] ([MaDienDiem], [TenDiaDiem]) VALUES (9, N'Vịnh Hạ Long')
INSERT [dbo].[DiaDiems] ([MaDienDiem], [TenDiaDiem]) VALUES (10, N'Huế')
SET IDENTITY_INSERT [dbo].[DiaDiems] OFF
GO
SET IDENTITY_INSERT [dbo].[Gias] ON 

INSERT [dbo].[Gias] ([MaGia], [GiaTri], [ThoiGianBatDau], [ThoiGianKetThuc], [TourisId]) VALUES (1024, 12000000, CAST(N'2020-09-25T00:00:00.000' AS DateTime), CAST(N'2020-10-02T00:00:00.000' AS DateTime), 1008)
INSERT [dbo].[Gias] ([MaGia], [GiaTri], [ThoiGianBatDau], [ThoiGianKetThuc], [TourisId]) VALUES (1025, 2000000, CAST(N'2020-09-26T00:00:00.000' AS DateTime), CAST(N'2020-09-26T00:00:00.000' AS DateTime), 2008)
INSERT [dbo].[Gias] ([MaGia], [GiaTri], [ThoiGianBatDau], [ThoiGianKetThuc], [TourisId]) VALUES (1026, 5000000, CAST(N'2020-09-26T00:00:00.000' AS DateTime), CAST(N'2020-09-28T00:00:00.000' AS DateTime), 2008)
INSERT [dbo].[Gias] ([MaGia], [GiaTri], [ThoiGianBatDau], [ThoiGianKetThuc], [TourisId]) VALUES (1027, 100000000, CAST(N'2020-09-26T00:00:00.000' AS DateTime), CAST(N'2020-10-26T00:00:00.000' AS DateTime), 2008)
INSERT [dbo].[Gias] ([MaGia], [GiaTri], [ThoiGianBatDau], [ThoiGianKetThuc], [TourisId]) VALUES (1028, 10000000, CAST(N'2020-09-29T00:00:00.000' AS DateTime), CAST(N'2020-10-02T00:00:00.000' AS DateTime), 2009)
INSERT [dbo].[Gias] ([MaGia], [GiaTri], [ThoiGianBatDau], [ThoiGianKetThuc], [TourisId]) VALUES (1029, 15000000, CAST(N'2020-10-01T00:00:00.000' AS DateTime), CAST(N'2020-10-03T00:00:00.000' AS DateTime), 2009)
INSERT [dbo].[Gias] ([MaGia], [GiaTri], [ThoiGianBatDau], [ThoiGianKetThuc], [TourisId]) VALUES (2008, 100000000, CAST(N'2020-09-29T00:00:00.000' AS DateTime), CAST(N'2020-10-02T00:00:00.000' AS DateTime), 5008)
INSERT [dbo].[Gias] ([MaGia], [GiaTri], [ThoiGianBatDau], [ThoiGianKetThuc], [TourisId]) VALUES (3008, 5000000, CAST(N'2020-09-26T00:00:00.000' AS DateTime), CAST(N'2020-09-26T00:00:00.000' AS DateTime), 6008)
INSERT [dbo].[Gias] ([MaGia], [GiaTri], [ThoiGianBatDau], [ThoiGianKetThuc], [TourisId]) VALUES (3009, 2000000, CAST(N'2020-09-26T00:00:00.000' AS DateTime), CAST(N'2020-09-28T00:00:00.000' AS DateTime), 6008)
SET IDENTITY_INSERT [dbo].[Gias] OFF
GO
SET IDENTITY_INSERT [dbo].[Loais] ON 

INSERT [dbo].[Loais] ([Id], [TenLoai]) VALUES (5, N'Tour Trải Nghiệm')
INSERT [dbo].[Loais] ([Id], [TenLoai]) VALUES (6, N'Tour Truyền Thống')
INSERT [dbo].[Loais] ([Id], [TenLoai]) VALUES (7, N'Tour Cao Cấp')
INSERT [dbo].[Loais] ([Id], [TenLoai]) VALUES (8, N'Tour Bình Dân')
SET IDENTITY_INSERT [dbo].[Loais] OFF
GO
SET IDENTITY_INSERT [dbo].[Touris] ON 

INSERT [dbo].[Touris] ([Id], [name], [LoaiId]) VALUES (1008, N'Du lịch Đà Nẵng - Nha Trang', 8)
INSERT [dbo].[Touris] ([Id], [name], [LoaiId]) VALUES (2008, N'Du lich TpHCM - Nha Trang', 7)
INSERT [dbo].[Touris] ([Id], [name], [LoaiId]) VALUES (2009, N'Du lịch Hà Nội - Tp HCM', 6)
INSERT [dbo].[Touris] ([Id], [name], [LoaiId]) VALUES (5008, N'TOURA', 7)
INSERT [dbo].[Touris] ([Id], [name], [LoaiId]) VALUES (6008, N'Tour A', 5)
SET IDENTITY_INSERT [dbo].[Touris] OFF
GO
ALTER TABLE [dbo].[Gias]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Gias_dbo.Touris_TourisId] FOREIGN KEY([TourisId])
REFERENCES [dbo].[Touris] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Gias] CHECK CONSTRAINT [FK_dbo.Gias_dbo.Touris_TourisId]
GO
ALTER TABLE [dbo].[Touris]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Touris_dbo.Loais_LoaiId] FOREIGN KEY([LoaiId])
REFERENCES [dbo].[Loais] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Touris] CHECK CONSTRAINT [FK_dbo.Touris_dbo.Loais_LoaiId]
GO
