/*CREATE DATABASE QLGarageOto
GO
USE QLGarageOto
GO*/

CREATE TABLE TAIKHOAN(
   MaTK int primary key,
   TenChuTaiKhoan nvarchar(50),
   TenDangNhap varchar(50),
   MatKhau varchar(50),
   TenQH varchar (50)
)

CREATE TABLE THAMSO(
	MaThamSo varchar(5), 
	TenThamSo nvarchar(50) primary key,
	GiaTri int
)

CREATE TABLE HIEUXE
(
	MaHX int PRIMARY KEY,
	TenHieuXe varchar(30)
)

CREATE TABLE TIENCONG(
	MaTC int primary key,
	TenTienCong varchar(50),
	ChiPhi int
) 

CREATE TABLE KHACHHANG(
	MaKH int primary key,
	TenKH nvarchar(50),
	DienThoai int,
	DiaChi varchar(100)
)

CREATE TABLE XE(
	BienSo varchar(10) primary key,
	MaHX int,
	MaKH int,
	TienNo int,
	NgayTiepNhan datetime
)

ALTER TABLE XE ADD FOREIGN KEY (MaHX) REFERENCES HIEUXE(MaHX)
ALTER TABLE XE ADD FOREIGN KEY (MaKH) REFERENCES KHACHHANG(MaKH)

CREATE TABLE VATTUPHUTUNG(
	MaVTPT int primary key,
	TenVTPT nvarchar(50),
	DonGiaNhap int,
	DonGiaBan float,
	SoLuong int
)

CREATE TABLE PHIEUTHUTIEN(
	MaPhieuThuTien int primary key,
	BienSo varchar(10),
	TienThu int,
	NgayThuTien datetime
)

ALTER TABLE PHIEUTHUTIEN ADD FOREIGN KEY (BienSo) REFERENCES XE(BienSo)


CREATE TABLE PHIEUSUACHUA(
	MaPhieuSuaChua int primary key,
	BienSo varchar(10) NULL,
	MaKH int NULL,
	TienCong int NULL,
	TienVTPT int NULL,
	TongTien int NULL)

ALTER TABLE PHIEUSUACHUA ADD FOREIGN KEY (BienSo) REFERENCES XE (BienSo)
ALTER TABLE PHIEUSUACHUA  WITH CHECK ADD FOREIGN KEY(MaKH) REFERENCES KHACHHANG (MaKH)

CREATE TABLE CT_PHIEUSUACHUA(
	MaPhieuSuaChua int,
	MaTC int,
	MaVTPT int,
	SoLuongVTPT int
)

ALTER TABLE CT_PHIEUSUACHUA ADD FOREIGN KEY (MaPhieuSuaChua) REFERENCES PHIEUSUACHUA(MaPhieuSuaChua)
ALTER TABLE CT_PHIEUSUACHUA ADD FOREIGN KEY (MaTC) REFERENCES TIENCONG(MaTC)
ALTER TABLE CT_PHIEUSUACHUA ADD FOREIGN KEY (MaVTPT) REFERENCES VATTUPHUTUNG(MaVTPT)

CREATE TABLE PHIEUNHAPVTPT
(
	MaPNVTPT int primary key,
	ThanhTienPN int,
	ThoiDiem datetime
)

CREATE TABLE CT_PHIEUNHAPVTPT
(
	MaPNVTPT int,
	MaVTPT int,
	SoLuong int,
	DonGiaNhap int,
	PRIMARY KEY (MaPNVTPT, MaVTPT)
)
ALTER TABLE CT_PHIEUNHAPVTPT ADD FOREIGN KEY (MaPNVTPT) REFERENCES PHIEUNHAPVTPT
ALTER TABLE CT_PHIEUNHAPVTPT ADD FOREIGN KEY (MaVTPT) REFERENCES VATTUPHUTUNG(MaVTPT)

CREATE TABLE BAOCAODOANHSO(
	MaBCDS int,
	Thang int,
	Nam int,
	TongDoanhThu int,
	primary key (MaBCDS)
)


CREATE TABLE CT_BAOCAODOANHSO(
 MaBCDS int,
 MaHX int,
 SoLuotSua int,
 ThanhTien int,
 TiLe float,
 primary key (MaBCDS, MaHX)
)

ALTER TABLE CT_BAOCAODOANHSO add constraint A foreign key (MaBCDS) REFERENCES BAOCAODOANHSO(MaBCDS)
ALTER TABLE CT_BAOCAODOANHSO ADD FOREIGN KEY (MaHX) REFERENCES HIEUXE(MaHX)


CREATE TABLE BAOCAOTON(
	MaBCT int PRIMARY KEY,
	ThoiDiemBaoCao datetime)

CREATE TABLE CT_BAOCAOTON(
	MaBCT int,
	MaVTPT int,
	TonDau int,
	PhatSinh int,
	TonCuoi int,
	 primary key (MaBCT,MaVTPT)
)
ALTER TABLE CT_BAOCAOTON ADD FOREIGN KEY (MaBCT) REFERENCES BAOCAOTON(MaBCT)
ALTER TABLE CT_BAOCAOTON ADD FOREIGN KEY (MaVTPT) REFERENCES VATTUPHUTUNG(MaVTPT)

CREATE TABLE PHIEUNHAPHX
(
	MaPNHX int,
	MaHX int,
	ThoiDiem datetime
	PRIMARY KEY(MaPNHX, MaHX)
)
ALTER TABLE PHIEUNHAPHX ADD FOREIGN KEY (MaHX) REFERENCES HIEUXE(MaHX)
-------------------------------------------------------------
SET DATEFORMAT dmy

INSERT [dbo].[THAMSO] ([MaThamSo], [TenThamSo], [GiaTri]) VALUES (N'TS1', N'Phần trăm tỉ lệ giá bán', 125)
INSERT [dbo].[THAMSO] ([MaThamSo], [TenThamSo], [GiaTri]) VALUES (N'TS2', N'Số xe sửa chữa tối đa', 30)

INSERT [dbo].[HIEUXE] ([MaHX], [TenHieuXe]) VALUES (0, N'Lexus')
INSERT [dbo].[HIEUXE] ([MaHX], [TenHieuXe]) VALUES (1, N'Audi')
INSERT [dbo].[HIEUXE] ([MaHX], [TenHieuXe]) VALUES (2, N'Mazda')
INSERT [dbo].[HIEUXE] ([MaHX], [TenHieuXe]) VALUES (3, N'Mercedes')
INSERT [dbo].[HIEUXE] ([MaHX], [TenHieuXe]) VALUES (4, N'Ford')

INSERT [dbo].[TIENCONG] ([MaTC], [TenTienCong], [ChiPhi]) VALUES (0, N'Thay den xe', 50000)
INSERT [dbo].[TIENCONG] ([MaTC], [TenTienCong], [ChiPhi]) VALUES (1, N'Thay guong chieu hau', 100000)
INSERT [dbo].[TIENCONG] ([MaTC], [TenTienCong], [ChiPhi]) VALUES (2, N'Thay kinh chan gio', 70000)
INSERT [dbo].[TIENCONG] ([MaTC], [TenTienCong], [ChiPhi]) VALUES (3, N'Thay bugi', 150000)
INSERT [dbo].[TIENCONG] ([MaTC], [TenTienCong], [ChiPhi]) VALUES (4, N'Thay lop xe', 60000)

INSERT [dbo].[VATTUPHUTUNG] ([MaVTPT], [TenVTPT], [DonGiaNhap], [DonGiaBan], [SoLuong]) VALUES (0, N'den xe', 100000, 125000, 3)

INSERT [dbo].[TAIKHOAN] ([MaTK], [TenChuTaiKhoan], [TenDangNhap], [MatKhau], [TenQH]) VALUES (0, N'Đoàn Ngọc Quỳnh Thư', N'boss', N'0', N'admin')
INSERT [dbo].[TAIKHOAN] ([MaTK], [TenChuTaiKhoan], [TenDangNhap], [MatKhau], [TenQH]) VALUES (1, N'Nguyễn Văn A', N'A', N'1234', N'staff')
-------------------------------------------------------------
GO
CREATE PROCEDURE [dbo].[ThemKhachHang]
	@TenKH varchar(30),
	@DienThoai varchar(10),
	@DiaChi varchar(100)
AS
BEGIN
	DECLARE @test int
	SELECT @test=COUNT(MaKH) FROM KHACHHANG WHERE (@TenKH = TenKH) and (@DienThoai = DienThoai) 
	if @test = 0
	BEGIN
		DECLARE @imakh int
		select  @imakh = MAX(MaKH) from KHACHHANG
		IF (@imakh is null) set @imakh = 0
		else set @imakh = @imakh + 1			
		INSERT INTO KHACHHANG (MaKH, TenKH, DiaChi, DienThoai) VALUES (@imakh, @TenKH, @DiaChi,@DienThoai)
	END
END;
GO

CREATE PROCEDURE [dbo].[ThemXe]
	@BienSo varchar(10) ,
	@HieuXe int,
	@NgayTiepNhan datetime,
	@MaKH int,
	@TienNo int
AS
BEGIN
	INSERT INTO XE (BienSo, MaHX, NgayTiepNhan, MaKH, TienNo) VALUES (@BienSo, @HieuXe, @NgayTiepNhan, @MaKH, @TienNo)
END;
GO

CREATE PROCEDURE TuDongTaoMaPN
AS
BEGIN
	DECLARE @MaPNVTPT int
    SELECT @MaPNVTPT = ISNULL(MAX(MaPNVTPT), 0) + 1 FROM PHIEUNHAPVTPT

    INSERT INTO PHIEUNHAPVTPT (MaPNVTPT, ThanhTienPN, ThoiDiem)
    VALUES (@MaPNVTPT, NULL, NULL)
END
GO

create procedure [dbo].[NhapVTPT]
	@MPNVTPT int,
	@TenPhuTung nvarchar(30),
	@SoLuong int,
	@DonGiaNhap int
AS
BEGIN
	DECLARE @iMaPT int
	SELECT @iMaPT = MaVTPT FROM VATTUPHUTUNG WHERE TenVTPT = @TenPhuTung

	INSERT INTO CT_PHIEUNHAPVTPT (MaPNVTPT, MaVTPT, SoLuong, DonGiaNhap) VALUES (@MPNVTPT, @iMaPT, @SoLuong, @DonGiaNhap)
	UPDATE VATTUPHUTUNG SET SoLuong = SoLuong + @SoLuong, DonGiaNhap = @DonGiaNhap WHERE MaVTPT = @iMaPT
END
GO

create procedure [dbo].[NhapMoiVTPT]
	@MPNVTPT int,
	@TenPhuTung nvarchar(30),
	@SoLuong int,
	@DonGiaNhap int
AS
BEGIN
	DECLARE @iMVTPT int
	SELECT @iMVTPT = COUNT(MaVTPT) FROM VATTUPHUTUNG
	SET @iMVTPT = @iMVTPT + 1

	INSERT INTO VATTUPHUTUNG (MaVTPT, TenVTPT, DonGiaNhap, SoLuong) VALUES (@iMVTPT, @TenPhuTung, @DonGiaNhap, @SoLuong)
	INSERT INTO CT_PHIEUNHAPVTPT (MaPNVTPT, MaVTPT, SoLuong, DonGiaNhap) VALUES (@MPNVTPT, @iMVTPT, @SoLuong, @DonGiaNhap)
END
GO

CREATE PROCEDURE XoaVTPTTrongPN
	@MaPN int,
	@TenVTPT nvarchar(30)
AS
BEGIN
	DECLARE @iMaPT int
	SELECT @iMaPT = MaVTPT FROM VATTUPHUTUNG WHERE TenVTPT = @TenVTPT

	DECLARE @SoLuong int
	SELECT @SoLuong = SoLuong FROM CT_PHIEUNHAPVTPT WHERE MaPNVTPT = @MaPN AND MaVTPT = @iMaPT

	DELETE FROM CT_PHIEUNHAPVTPT WHERE MaVTPT = @iMaPT
	UPDATE VATTUPHUTUNG SET SoLuong = SoLuong - @SoLuong WHERE MaVTPT = @iMaPT

	SELECT @SoLuong = SoLuong FROM VATTUPHUTUNG WHERE MaVTPT = @iMaPT
	IF(@SoLuong = 0) DELETE FROM VATTUPHUTUNG WHERE MaVTPT = @iMaPT
END
GO

CREATE PROCEDURE [dbo].[ThemPhieuThuTien]
	@BienSo varchar(10),
	@TienThu int,
	@NgayThuTien datetime
AS
BEGIN
		DECLARE @imaptt int
		SELECT @imaptt = COUNT(MaPhieuThuTien) from PHIEUTHUTIEN
		SET @imaptt = @imaptt + 1
		INSERT INTO PHIEUTHUTIEN (MaPhieuThuTien, BienSo, TienThu, NgayThuTien) VALUES (@imaptt, @BienSo, @TienThu, @NgayThuTien)
		UPDATE XE SET TienNo = TienNo - @TienThu WHERE BienSo = @BienSo
END
GO

create procedure [dbo].[TimKiemTuongDoi]
	@DuLieu varchar(100)
AS
BEGIN
SELECT XE.BienSo as 'Biển số',
       TenHieuXe as 'Tên hiệu xe',
       TenKH as 'Tên khách hàng',
       NULLIF(MaPhieuSuaChua, '') as 'Mã phiếu sửa chữa hiện có',
       CASE WHEN TongTien = 0 THEN NULL ELSE TongTien END as 'Tổng tiền phiếu sửa chữa',
       CASE WHEN TienNo = 0 THEN NULL ELSE TienNo END as 'Tổng tiền nợ hiện tại'
FROM XE
INNER JOIN HIEUXE as HX ON XE.MaHX = HX.MaHX
INNER JOIN KHACHHANG as KH ON KH.MaKH = XE.MaKH
LEFT JOIN PHIEUSUACHUA ON PHIEUSUACHUA.BienSo = XE.BienSo
WHERE ((XE.BienSo LIKE '%'+@DuLieu+'%') or (TenHieuXe LIKE '%'+@DuLieu+'%') or (TenKH LIKE '%'+@DuLieu+'%') or (TienNo LIKE '%'+@DuLieu+'%'))
END
GO

create procedure [dbo].[TimKiemChinhXac]
	@BienSo varchar(10),
	@HieuXe varchar(30)
AS
BEGIN
	SELECT XE.BienSo as 'Biển số',
       TenHieuXe as 'Tên hiệu xe',
       TenKH as 'Tên khách hàng',
       NULLIF(MaPhieuSuaChua, '') as 'Mã phiếu sửa chữa hiện có',
       CASE WHEN TongTien = 0 THEN NULL ELSE TongTien END as 'Tổng tiền phiếu sửa chữa',
       CASE WHEN TienNo = 0 THEN NULL ELSE TienNo END as 'Tổng tiền nợ hiện tại'
FROM XE
INNER JOIN HIEUXE as HX ON XE.MaHX = HX.MaHX
INNER JOIN KHACHHANG as KH ON KH.MaKH = XE.MaKH
LEFT JOIN PHIEUSUACHUA ON PHIEUSUACHUA.BienSo = XE.BienSo
WHERE @BienSo = XE.BienSo and @HieuXe = HX.TenHieuXe 
END
GO

create procedure [dbo].[BaoCaoDoanhThu]
		@Thang int,
		@Nam int
AS
BEGIN
	select HX.TenHieuXe as 'Hiệu Xe', COUNT(PSC.MaPhieuSuaChua) as 'Số Lượt Sửa', SUM(PTT.TienThu) as 'Thành Tiền', CAST((SUM(PTT.TienThu)*100*1.0/(select sum(PTT.TienThu) from PHIEUTHUTIEN as PTT WHERE Month(PTT.NgayThuTien) = @Thang and YEAR(PTT.NgayThuTien) = @Nam )) AS DECIMAL(10, 2)) as 'Tỉ Lệ'
	FROM KHACHHANG as KH, XE, HIEUXE as HX, PHIEUTHUTIEN as PTT, PHIEUSUACHUA as PSC
	WHERE KH.MaKH = XE.MaKH and XE.MaHX = HX.MaHX and PTT.BienSo = PSC.BienSo and PSC.BienSo = Xe.BienSo and Month(PTT.NgayThuTien) = @Thang and YEAR(PTT.NgayThuTien) = @Nam
	Group by HX.TenHieuXe, Month(PTT.NgayThuTien),YEAR(PTT.NgayThuTien)
END
GO

create procedure [dbo].[TongTienDoanhThu]
		@Thang int,
		@Nam int
AS
BEGIN
	select sum(PTT.TienThu)
	from PHIEUTHUTIEN as PTT
	WHERE Month(PTT.NgayThuTien) = @Thang and YEAR(PTT.NgayThuTien) = @Nam
END
GO

CREATE PROC [dbo].[USP_DangNhap]
@TenDangNhap nvarchar(50), @MatKhau nvarchar(50)
AS
BEGIN
	SELECT * FROM TAIKHOAN WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau
END
GO

create procedure [dbo].[DoiMK]
	@MaTK int,
	@MatKhauMoi varchar(20)
AS
BEGIN
	UPDATE TAIKHOAN
	SET MatKhau = @MatKhauMoi 
	WHERE MaTK = @MaTK
END
GO

CREATE PROCEDURE [dbo].[XoaVTPT]
    @mavtpt int
AS
BEGIN
    DECLARE @SoLuong int
	SELECT @SoLuong = SoLuong FROM VATTUPHUTUNG WHERE MaVTPT = @mavtpt
    
    -- Kiểm tra xem vật tư phụ tùng có số lượng tồn = 0 hay không
    IF ( EXISTS (SELECT 1 FROM CT_PHIEUSUACHUA WHERE MaVTPT = @mavtpt) OR @SoLuong = 0)
    BEGIN
        -- Xóa các bản ghi liên quan đến vật tư phụ tùng
		DELETE FROM CT_PHIEUNHAPVTPT WHERE MaVTPT = @mavtpt
		DELETE FROM CT_PHIEUSUACHUA WHERE MaVTPT = @mavtpt
        DELETE FROM VATTUPHUTUNG WHERE MaVTPT = @mavtpt
    END
END;
GO

create procedure [dbo].[NhapMoiHX]
	@TenHieuXe varchar(100),
	@ThoiDiem datetime
AS
BEGIN
	DECLARE @iMPNHX int
	SELECT @iMPNHX = COUNT(MaPNHX) FROM PHIEUNHAPHX
	SET @iMPNHX = @iMPNHX + 1
	DECLARE @iMHX int
	SELECT @iMHX = COUNT(MaHX) FROM HIEUXE
	SET @iMHX = @iMHX + 1
	INSERT INTO HIEUXE (MaHX, TenHieuXe) VALUES (@iMHX, @TenHieuXe)
	INSERT INTO PHIEUNHAPHX (MaPNHX, MaHX, ThoiDiem) VALUES (@iMPNHX, @iMHX, @ThoiDiem)
END
GO

CREATE PROCEDURE XoaPTNXe
    @MaKH int,
    @BienSo varchar(10)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM PHIEUSUACHUA WHERE BienSo = @BienSo)
    BEGIN
        DELETE FROM XE WHERE BienSo = @BienSo;
		DELETE FROM KHACHHANG WHERE MaKH = @MaKH;
    END
END
GO

