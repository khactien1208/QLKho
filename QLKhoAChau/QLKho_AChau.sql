/* =====================================================================
   HỆ THỐNG QUẢN LÝ NHẬP - XUẤT - TỒN KHO
   Doanh nghiệp bánh kẹo Á Châu
   CSDL: SQL Server 2016+
   ===================================================================== */

IF DB_ID('QLKho_AChau') IS NOT NULL
BEGIN
    ALTER DATABASE QLKho_AChau SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QLKho_AChau;
END
GO
CREATE DATABASE QLKho_AChau;
GO
USE QLKho_AChau;
GO

/* ---------- BẢNG ---------- */
CREATE TABLE NguoiDung (
    MaND     INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap NVARCHAR(50) NOT NULL UNIQUE,
    MatKhau  NVARCHAR(255) NOT NULL,
    HoTen    NVARCHAR(100) NOT NULL,
    VaiTro   NVARCHAR(20)  NOT NULL CHECK (VaiTro IN (N'Admin',N'ThuKho',N'NhanVien')),
    TrangThai BIT DEFAULT 1
);

CREATE TABLE DanhMuc (
    MaDM   INT IDENTITY(1,1) PRIMARY KEY,
    TenDM  NVARCHAR(100) NOT NULL,
    MoTa   NVARCHAR(255)
);

CREATE TABLE NhaCungCap (
    MaNCC    INT IDENTITY(1,1) PRIMARY KEY,
    TenNCC   NVARCHAR(150) NOT NULL,
    DiaChi   NVARCHAR(255),
    DienThoai NVARCHAR(20),
    Email    NVARCHAR(100)
);

CREATE TABLE KhachHang (
    MaKH     INT IDENTITY(1,1) PRIMARY KEY,
    TenKH    NVARCHAR(150) NOT NULL,
    DiaChi   NVARCHAR(255),
    DienThoai NVARCHAR(20),
    Email    NVARCHAR(100)
);

CREATE TABLE HangHoa (
    MaHH      INT IDENTITY(1,1) PRIMARY KEY,
    MaSP      NVARCHAR(20) NOT NULL UNIQUE,
    TenHH     NVARCHAR(200) NOT NULL,
    MaDM      INT NOT NULL FOREIGN KEY REFERENCES DanhMuc(MaDM),
    DonViTinh NVARCHAR(20) NOT NULL,
    GiaNhap   DECIMAL(18,2) DEFAULT 0,
    GiaBan    DECIMAL(18,2) DEFAULT 0,
    TonKho    INT DEFAULT 0,
    TonToiThieu INT DEFAULT 10,    -- ngưỡng cảnh báo
    HanSuDung DATE NULL,
    TrangThai BIT DEFAULT 1
);

CREATE TABLE PhieuNhap (
    MaPN     INT IDENTITY(1,1) PRIMARY KEY,
    SoPhieu  NVARCHAR(20) NOT NULL UNIQUE,
    NgayNhap DATETIME DEFAULT GETDATE(),
    MaNCC    INT NOT NULL FOREIGN KEY REFERENCES NhaCungCap(MaNCC),
    MaND     INT NOT NULL FOREIGN KEY REFERENCES NguoiDung(MaND),
    TongTien DECIMAL(18,2) DEFAULT 0,
    GhiChu   NVARCHAR(255)
);

CREATE TABLE ChiTietNhap (
    MaPN     INT NOT NULL FOREIGN KEY REFERENCES PhieuNhap(MaPN) ON DELETE CASCADE,
    MaHH     INT NOT NULL FOREIGN KEY REFERENCES HangHoa(MaHH),
    SoLuong  INT NOT NULL CHECK (SoLuong > 0),
    DonGia   DECIMAL(18,2) NOT NULL,
    ThanhTien AS (SoLuong * DonGia) PERSISTED,
    PRIMARY KEY (MaPN, MaHH)
);

CREATE TABLE PhieuXuat (
    MaPX     INT IDENTITY(1,1) PRIMARY KEY,
    SoPhieu  NVARCHAR(20) NOT NULL UNIQUE,
    NgayXuat DATETIME DEFAULT GETDATE(),
    MaKH     INT NOT NULL FOREIGN KEY REFERENCES KhachHang(MaKH),
    MaND     INT NOT NULL FOREIGN KEY REFERENCES NguoiDung(MaND),
    TongTien DECIMAL(18,2) DEFAULT 0,
    GhiChu   NVARCHAR(255)
);

CREATE TABLE ChiTietXuat (
    MaPX     INT NOT NULL FOREIGN KEY REFERENCES PhieuXuat(MaPX) ON DELETE CASCADE,
    MaHH     INT NOT NULL FOREIGN KEY REFERENCES HangHoa(MaHH),
    SoLuong  INT NOT NULL CHECK (SoLuong > 0),
    DonGia   DECIMAL(18,2) NOT NULL,
    ThanhTien AS (SoLuong * DonGia) PERSISTED,
    PRIMARY KEY (MaPX, MaHH)
);
GO

/* ---------- TRIGGER: tự cập nhật tồn kho & tổng tiền phiếu ---------- */
CREATE TRIGGER trg_CTNhap_Insert ON ChiTietNhap AFTER INSERT AS
BEGIN
    SET NOCOUNT ON;
    UPDATE h SET TonKho = h.TonKho + i.SoLuong
      FROM HangHoa h JOIN inserted i ON h.MaHH = i.MaHH;
    UPDATE p SET TongTien = ISNULL((SELECT SUM(ThanhTien) FROM ChiTietNhap WHERE MaPN = p.MaPN),0)
      FROM PhieuNhap p JOIN inserted i ON p.MaPN = i.MaPN;
END
GO
CREATE TRIGGER trg_CTNhap_Delete ON ChiTietNhap AFTER DELETE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE h SET TonKho = h.TonKho - d.SoLuong
      FROM HangHoa h JOIN deleted d ON h.MaHH = d.MaHH;
    UPDATE p SET TongTien = ISNULL((SELECT SUM(ThanhTien) FROM ChiTietNhap WHERE MaPN = p.MaPN),0)
      FROM PhieuNhap p JOIN deleted d ON p.MaPN = d.MaPN;
END
GO
CREATE TRIGGER trg_CTXuat_Insert ON ChiTietXuat AFTER INSERT AS
BEGIN
    SET NOCOUNT ON;
    -- kiểm tra tồn
    IF EXISTS (SELECT 1 FROM inserted i JOIN HangHoa h ON h.MaHH=i.MaHH WHERE h.TonKho < i.SoLuong)
    BEGIN
        RAISERROR(N'Số lượng xuất vượt quá tồn kho!',16,1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
    UPDATE h SET TonKho = h.TonKho - i.SoLuong
      FROM HangHoa h JOIN inserted i ON h.MaHH = i.MaHH;
    UPDATE p SET TongTien = ISNULL((SELECT SUM(ThanhTien) FROM ChiTietXuat WHERE MaPX = p.MaPX),0)
      FROM PhieuXuat p JOIN inserted i ON p.MaPX = i.MaPX;
END
GO
CREATE TRIGGER trg_CTXuat_Delete ON ChiTietXuat AFTER DELETE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE h SET TonKho = h.TonKho + d.SoLuong
      FROM HangHoa h JOIN deleted d ON h.MaHH = d.MaHH;
    UPDATE p SET TongTien = ISNULL((SELECT SUM(ThanhTien) FROM ChiTietXuat WHERE MaPX = p.MaPX),0)
      FROM PhieuXuat p JOIN deleted d ON p.MaPX = d.MaPX;
END
GO

/* ---------- VIEW: Báo cáo Nhập - Xuất - Tồn ---------- */
CREATE VIEW vw_NhapXuatTon AS
SELECT h.MaHH, h.MaSP, h.TenHH, h.DonViTinh, dm.TenDM,
       ISNULL((SELECT SUM(SoLuong) FROM ChiTietNhap ct JOIN PhieuNhap p ON p.MaPN=ct.MaPN WHERE ct.MaHH=h.MaHH),0) AS TongNhap,
       ISNULL((SELECT SUM(SoLuong) FROM ChiTietXuat ct JOIN PhieuXuat p ON p.MaPX=ct.MaPX WHERE ct.MaHH=h.MaHH),0) AS TongXuat,
       h.TonKho, h.TonToiThieu,
       CASE WHEN h.TonKho <= h.TonToiThieu THEN N'Cảnh báo' ELSE N'Bình thường' END AS TrangThaiTon
FROM HangHoa h JOIN DanhMuc dm ON dm.MaDM = h.MaDM;
GO

/* ---------- STORED PROCEDURE: Cảnh báo tồn thấp ---------- */
CREATE PROCEDURE sp_CanhBaoTonThap AS
BEGIN
    SET NOCOUNT ON;
    SELECT h.MaSP, h.TenHH, dm.TenDM, h.DonViTinh, h.TonKho, h.TonToiThieu,
           (h.TonToiThieu - h.TonKho) AS CanNhapThem
    FROM HangHoa h JOIN DanhMuc dm ON dm.MaDM = h.MaDM
    WHERE h.TrangThai = 1 AND h.TonKho <= h.TonToiThieu
    ORDER BY (h.TonKho - h.TonToiThieu);
END
GO

/* ---------- DỮ LIỆU MẪU ---------- */
INSERT INTO NguoiDung(TenDangNhap,MatKhau,HoTen,VaiTro) VALUES
(N'admin',N'admin123',N'Quản trị hệ thống',N'Admin'),
(N'thukho',N'123456',N'Nguyễn Văn Mười',N'ThuKho');


INSERT INTO DanhMuc(TenDM,MoTa) VALUES
(N'Bánh quy',N'Các loại bánh quy, cookies'),
(N'Kẹo cứng',N'Kẹo cứng, kẹo mút'),
(N'Kẹo mềm',N'Kẹo dẻo, kẹo socola mềm'),
(N'Socola',N'Socola các loại'),
(N'Bánh trung thu',N'Bánh trung thu mùa vụ');

INSERT INTO NhaCungCap(TenNCC,DiaChi,DienThoai,Email) VALUES
(N'Cty Bánh kẹo Hải Hà',N'25 Trương Định, Hà Nội',N'02438631944',N'sales@haiha.com.vn'),
(N'Cty Kinh Đô',N'KCN Tân Bình, TP.HCM',N'02838154410',N'cs@kinhdo.vn'),
(N'Cty Bibica',N'Đồng Nai',N'02513836446',N'info@bibica.com.vn');

INSERT INTO KhachHang(TenKH,DiaChi,DienThoai,Email) VALUES
(N'Siêu thị Coopmart Q1',N'Quận 1, TP.HCM',N'02838222222',N'coop1@coop.vn'),
(N'Tạp hóa Minh Anh',N'Cầu Giấy, Hà Nội',N'0912345678',N'minhanh@gmail.com'),
(N'Cửa hàng Bánh Ngọt',N'Hải Châu, Đà Nẵng',N'0905111222',N'banhngot@gmail.com');

INSERT INTO HangHoa(MaSP,TenHH,MaDM,DonViTinh,GiaNhap,GiaBan,TonKho,TonToiThieu,HanSuDung) VALUES
(N'BQ001',N'Bánh quy bơ Cosy 132g',1,N'Hộp',18000,25000,150,30,'2026-06-30'),
(N'BQ002',N'Bánh AFC vị rau 200g',1,N'Gói',22000,30000,80,20,'2026-08-15'),
(N'KC001',N'Kẹo cứng Alpenliebe 32 viên',2,N'Gói',12000,18000,5,15,'2026-12-31'),  -- dưới ngưỡng
(N'KC002',N'Kẹo mút Chupa Chups',2,N'Cây',2500,5000,500,100,'2027-01-31'),
(N'KM001',N'Kẹo dẻo Haribo 80g',3,N'Gói',25000,38000,8,20,'2026-05-30'),           -- dưới ngưỡng
(N'SC001',N'Socola Kitkat 4 thanh',4,N'Hộp',32000,45000,200,40,'2026-09-30'),
(N'SC002',N'Socola Snickers 50g',4,N'Thanh',12000,18000,12,30,'2026-07-15'),       -- dưới ngưỡng
(N'BTT001',N'Bánh trung thu Kinh Đô 2 trứng',5,N'Hộp',180000,250000,60,20,'2025-10-15');

DECLARE @MaND INT = 1;
INSERT INTO PhieuXuat(SoPhieu,MaKH,MaND,GhiChu) VALUES (N'PX0001',1,@MaND,N'Xuất sỉ Coopmart');
INSERT INTO ChiTietXuat(MaPX,MaHH,SoLuong,DonGia) VALUES
((SELECT MaPX FROM PhieuXuat WHERE SoPhieu='PX0001'),1,20,25000),
((SELECT MaPX FROM PhieuXuat WHERE SoPhieu='PX0001'),6,30,45000);
GO

PRINT N'>>> Đã tạo CSDL QLKho_AChau thành công!';
PRINT N'>>> Tài khoản: admin/admin123, thukho/123456;
GO

--thêm cột maNC 
ALTER TABLE HangHoa
ADD MaNCC INT;

-- thêm khóa ngoại
ALTER TABLE HangHoa
ADD CONSTRAINT FK_HangHoa_NCC
FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC);

--thêm NSX
ALTER TABLE HangHoa
ADD NgaySanXuat DATE;

/* =====================================================================
   MIGRATION: Nâng cấp sang quản lý theo LÔ HÀNG
   Chạy trên DB đã tồn tại — KHÔNG tạo lại DB
   ===================================================================== */
USE QLKho_AChau;
GO

-- BƯỚC 1: Bỏ UNIQUE trên MaSP để cho phép nhiều lô cùng mã
DECLARE @uq NVARCHAR(200);
SELECT @uq = kc.CONSTRAINT_NAME
FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE kc
JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc ON kc.CONSTRAINT_NAME = tc.CONSTRAINT_NAME
WHERE kc.TABLE_NAME='HangHoa' AND kc.COLUMN_NAME='MaSP' AND tc.CONSTRAINT_TYPE='UNIQUE';
IF @uq IS NOT NULL EXEC('ALTER TABLE HangHoa DROP CONSTRAINT ' + @uq);
GO

-- BƯỚC 2: Thêm NgayNhapLo
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='HangHoa' AND COLUMN_NAME='NgayNhapLo')
    ALTER TABLE HangHoa ADD NgayNhapLo DATETIME NOT NULL DEFAULT GETDATE();
GO

-- BƯỚC 3: Thêm TrangThaiLo
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='HangHoa' AND COLUMN_NAME='TrangThaiLo')
    ALTER TABLE HangHoa ADD TrangThaiLo NVARCHAR(20) NOT NULL DEFAULT N'BinhThuong';
GO

-- BƯỚC 4: Thêm LoaiPhieu vào PhieuXuat
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='PhieuXuat' AND COLUMN_NAME='LoaiPhieu')
    ALTER TABLE PhieuXuat ADD LoaiPhieu NVARCHAR(20) NOT NULL DEFAULT N'XuatBan';
GO

-- BƯỚC 5: Sửa trigger nhập — KHÔNG cộng dồn TonKho vào dòng cũ
--         TonKho đã = SoLuong ngay lúc INSERT HangHoa mới trong DAL
ALTER TRIGGER trg_CTNhap_Insert ON ChiTietNhap AFTER INSERT AS
BEGIN
    SET NOCOUNT ON;
    UPDATE p SET TongTien = ISNULL((SELECT SUM(ThanhTien) FROM ChiTietNhap WHERE MaPN=p.MaPN),0)
    FROM PhieuNhap p JOIN inserted i ON p.MaPN=i.MaPN;
END
GO

-- BƯỚC 6: Sửa trigger nhập delete — đánh dấu lô vô hiệu thay vì trừ TonKho
ALTER TRIGGER trg_CTNhap_Delete ON ChiTietNhap AFTER DELETE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE HangHoa SET TrangThai=0 WHERE MaHH IN (SELECT MaHH FROM deleted);
    UPDATE p SET TongTien = ISNULL((SELECT SUM(ThanhTien) FROM ChiTietNhap WHERE MaPN=p.MaPN),0)
    FROM PhieuNhap p JOIN deleted d ON p.MaPN=d.MaPN;
END
GO

-- BƯỚC 7: Sửa trigger xuất — trừ đúng lô + đánh dấu TrangThaiLo=Huy khi TonKho=0
ALTER TRIGGER trg_CTXuat_Insert ON ChiTietXuat AFTER INSERT AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM inserted i JOIN HangHoa h ON h.MaHH=i.MaHH WHERE h.TonKho < i.SoLuong)
    BEGIN RAISERROR(N'Số lượng xuất vượt quá tồn kho của lô này!',16,1); ROLLBACK TRANSACTION; RETURN; END
    UPDATE h SET TonKho = h.TonKho - i.SoLuong FROM HangHoa h JOIN inserted i ON h.MaHH=i.MaHH;
    UPDATE HangHoa SET TrangThaiLo=N'Huy' WHERE MaHH IN (SELECT MaHH FROM inserted) AND TonKho=0;
    UPDATE p SET TongTien = ISNULL((SELECT SUM(ThanhTien) FROM ChiTietXuat WHERE MaPX=p.MaPX),0)
    FROM PhieuXuat p JOIN inserted i ON p.MaPX=i.MaPX;
END
GO

-- BƯỚC 8: Sửa trigger xuất delete — hoàn lại TonKho đúng lô
ALTER TRIGGER trg_CTXuat_Delete ON ChiTietXuat AFTER DELETE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE h SET TonKho = h.TonKho + d.SoLuong FROM HangHoa h JOIN deleted d ON h.MaHH=d.MaHH;
    UPDATE HangHoa SET TrangThaiLo=N'BinhThuong'
    WHERE MaHH IN (SELECT MaHH FROM deleted) AND TonKho>0 AND TrangThaiLo=N'Huy'
      AND HanSuDung >= CAST(GETDATE() AS DATE);
    UPDATE p SET TongTien = ISNULL((SELECT SUM(ThanhTien) FROM ChiTietXuat WHERE MaPX=p.MaPX),0)
    FROM PhieuXuat p JOIN deleted d ON p.MaPX=d.MaPX;
END
GO

-- BƯỚC 9: Sửa VIEW — hiển thị theo từng lô (bỏ GROUP BY MaSP cũ)
DROP VIEW IF EXISTS vw_NhapXuatTon;
GO
CREATE VIEW vw_NhapXuatTon AS
SELECT h.MaHH, h.MaSP, h.TenHH, h.DonViTinh, dm.TenDM, ncc.TenNCC,
       h.NgayNhapLo, h.NgaySanXuat, h.HanSuDung, h.TrangThaiLo,
       ISNULL((SELECT SUM(ct.SoLuong) FROM ChiTietNhap ct WHERE ct.MaHH=h.MaHH),0) AS TongNhap,
       ISNULL((SELECT SUM(ct.SoLuong) FROM ChiTietXuat ct WHERE ct.MaHH=h.MaHH),0) AS TongXuat,
       h.TonKho, h.TonToiThieu,
       CASE
           WHEN h.HanSuDung < CAST(GETDATE() AS DATE)                  THEN N'HetHan'
           WHEN h.HanSuDung <= CAST(DATEADD(DAY,7,GETDATE()) AS DATE)  THEN N'SapHetHan'
           WHEN h.TonKho <= h.TonToiThieu                              THEN N'TonThap'
           ELSE N'BinhThuong'
       END AS TrangThaiTon
FROM HangHoa h
JOIN DanhMuc dm ON dm.MaDM=h.MaDM
LEFT JOIN NhaCungCap ncc ON ncc.MaNCC=h.MaNCC
WHERE h.TrangThai=1;
GO

-- BƯỚC 10: Sửa SP cảnh báo — thêm cảnh báo hết hạn / sắp hết hạn
ALTER PROCEDURE sp_CanhBaoTonThap AS
BEGIN
    SET NOCOUNT ON;
    SELECT h.MaHH, h.MaSP, h.TenHH, dm.TenDM, h.DonViTinh, h.TonKho, h.TonToiThieu,
           h.HanSuDung, h.NgayNhapLo,
           CASE
               WHEN h.HanSuDung < CAST(GETDATE() AS DATE)                  THEN N'Hết hạn'
               WHEN h.HanSuDung <= CAST(DATEADD(DAY,7,GETDATE()) AS DATE)  THEN N'Sắp hết hạn'
               ELSE N'Tồn thấp'
           END AS TinhTrang,
           (h.TonToiThieu - h.TonKho) AS CanNhapThem
    FROM HangHoa h JOIN DanhMuc dm ON dm.MaDM=h.MaDM
    WHERE h.TrangThai=1
      AND (h.TonKho <= h.TonToiThieu OR h.HanSuDung <= CAST(DATEADD(DAY,7,GETDATE()) AS DATE))
    ORDER BY
        CASE WHEN h.HanSuDung < CAST(GETDATE() AS DATE) THEN 2 ELSE 1 END,
        h.HanSuDung ASC;
END
GO

PRINT N'>>> Migration lô hàng hoàn tất!';
GO
