IF DB_ID(N'HRMDB') IS NULL
	CREATE DATABASE HRMDB;
GO

USE HRMDB;
GO

IF OBJECT_ID(N'dbo.PhongBan', N'U') IS NULL
BEGIN
	CREATE TABLE dbo.PhongBan
	(
		MaPB int IDENTITY(1,1) NOT NULL CONSTRAINT PK_PhongBan PRIMARY KEY,
		TenPB nvarchar(100) NOT NULL,
		Mota nvarchar(255) NULL
	);
END;
GO

IF OBJECT_ID(N'dbo.NhanVien', N'U') IS NULL
BEGIN
	CREATE TABLE dbo.NhanVien
	(
		MaNV int IDENTITY(1,1) NOT NULL CONSTRAINT PK_NhanVien PRIMARY KEY,
		HoTen nvarchar(100) NOT NULL,
		NgaySinh datetime NULL,
		CCCD varchar(20) NULL,
		MaPB int NULL,
		LuongCoBan decimal(18,2) NOT NULL,
		HeSoLuong float NOT NULL CONSTRAINT DF_NhanVien_HeSoLuong DEFAULT (1.0),
		CONSTRAINT UQ_NhanVien_CCCD UNIQUE (CCCD),
		CONSTRAINT CK_NhanVien_LuongCoBan CHECK (LuongCoBan > 0),
		CONSTRAINT FK_NhanVien_PhongBan FOREIGN KEY (MaPB) REFERENCES dbo.PhongBan(MaPB)
	);
END;
GO

IF OBJECT_ID(N'dbo.BangChamCong', N'U') IS NULL
BEGIN
	CREATE TABLE dbo.BangChamCong
	(
		MaCong int IDENTITY(1,1) NOT NULL CONSTRAINT PK_BangChamCong PRIMARY KEY,
		MaNV int NOT NULL,
		ThangNam varchar(7) NOT NULL,
		SoNgayCong float NOT NULL CONSTRAINT DF_BangChamCong_SoNgayCong DEFAULT (0),
		SoGioOT float NOT NULL CONSTRAINT DF_BangChamCong_SoGioOT DEFAULT (0),
		CONSTRAINT CK_BangChamCong_SoNgayCong CHECK (SoNgayCong >= 0 AND SoNgayCong <= 31),
		CONSTRAINT CK_BangChamCong_SoGioOT CHECK (SoGioOT >= 0),
		CONSTRAINT UQ_BangChamCong_NhanVien_Thang UNIQUE (MaNV, ThangNam),
		CONSTRAINT FK_BangChamCong_NhanVien FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV)
	);
END;
GO

IF OBJECT_ID(N'dbo.BangLuong', N'U') IS NULL
BEGIN
	CREATE TABLE dbo.BangLuong
	(
		MaLuong int IDENTITY(1,1) NOT NULL CONSTRAINT PK_BangLuong PRIMARY KEY,
		MaNV int NOT NULL,
		ThangNam varchar(7) NOT NULL,
		ThucLinh decimal(18,2) NOT NULL,
		CONSTRAINT UQ_BangLuong_NhanVien_Thang UNIQUE (MaNV, ThangNam),
		CONSTRAINT FK_BangLuong_NhanVien FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV)
	);
END;
GO

IF OBJECT_ID(N'dbo.ThangLuongDaChot', N'U') IS NULL
BEGIN
	CREATE TABLE dbo.ThangLuongDaChot
	(
		ThangNam varchar(7) NOT NULL CONSTRAINT PK_ThangLuongDaChot PRIMARY KEY,
		NgayChot datetime2 NOT NULL CONSTRAINT DF_ThangLuongDaChot_NgayChot DEFAULT (SYSUTCDATETIME())
	);
END;
GO

CREATE OR ALTER TRIGGER dbo.TR_BangChamCong_KhoaThangDaChot
ON dbo.BangChamCong
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
	SET NOCOUNT ON;

	IF EXISTS
	(
		SELECT 1
		FROM dbo.ThangLuongDaChot AS t
		WHERE EXISTS (SELECT 1 FROM inserted AS i WHERE i.ThangNam = t.ThangNam)
		   OR EXISTS (SELECT 1 FROM deleted AS d WHERE d.ThangNam = t.ThangNam)
	)
	BEGIN
		THROW 51000, N'Không thể thay đổi chấm công của tháng đã chốt lương.', 1;
	END;
END;
GO
