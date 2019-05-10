CREATE TABLE BannerQC(
	MaQC Number(10)  NOT NULL,
	NoiDungQC Nvarchar2(200) NULL,
	NgayTao Timestamp(3) NULL,
	Hinh Varchar2(50) NULL,
	NgayBatDau Timestamp(3) NULL,
	NgayKetThucQC Timestamp(3) NULL,
 CONSTRAINT PK_BannerQC PRIMARY KEY (MaQC) 
);
CREATE SEQUENCE BannerQC_seq START WITH 1 INCREMENT BY 1;
CREATE OR REPLACE TRIGGER BannerQC_seq_tr
 BEFORE INSERT ON BannerQC FOR EACH ROW
 WHEN (NEW.MaQC IS NULL)
BEGIN
 SELECT BannerQC_seq.NEXTVAL INTO :NEW.MaQC FROM DUAL;
END;

CREATE TABLE BinhLuanSP(
	MaBL Number(10)  NOT NULL,
	NoiDung Nvarchar2(100) NULL,
	NgayBL Timestamp(3) NULL,
	MaKH Number(10) NULL,
	MaHh Number(10) NULL,
 CONSTRAINT PK_BinhLuanSP PRIMARY KEY(MaBL) 
);
CREATE SEQUENCE BinhLuanSP_seq START WITH 1 INCREMENT BY 1;
CREATE OR REPLACE TRIGGER BinhLuanSP_seq_tr
 BEFORE INSERT ON BinhLuanSP FOR EACH ROW
 WHEN (NEW.MaBL IS NULL)
BEGIN
 SELECT BinhLuanSP_seq.NEXTVAL INTO :NEW.MaBL FROM DUAL;
END;

CREATE TABLE ChiTietHD(
	MaCT Number(10)  NOT NULL,
	MaHD Number(10) NOT NULL,
	MaHH Number(10) NOT NULL,
	DonGia Binary_double NOT NULL,
	GiamGia Binary_double NULL,
	SoLuong Number(10) NOT NULL,
	KichCo Varchar2(5) NULL,
 CONSTRAINT PK_ChiTietHD PRIMARY KEY(MaCT) 
);
CREATE SEQUENCE ChiTietHD_seq START WITH 1 INCREMENT BY 1;
CREATE OR REPLACE TRIGGER ChiTietHD_seq_tr
 BEFORE INSERT ON ChiTietHD FOR EACH ROW
 WHEN (NEW.MaCT IS NULL)
BEGIN
 SELECT ChiTietHD_seq.NEXTVAL INTO :NEW.MaCT FROM DUAL;
END;

CREATE TABLE ChiTietPhieuNhap(
	MaPN Number(10) NOT NULL,
	MaHH Number(10) NOT NULL,
	KichCo char(5) NOT NULL,
	SoLuongNhap Number(10) DEFAULT ((0)) NULL  ,
	DonGiaNhap Binary_double NULL,
 CONSTRAINT PK_ChiTietPhieuNhap_1 PRIMARY KEY(MaPN,MaHH,KichCo)
 );
 
 CREATE TABLE HangHoa(
	MaHH Number(10)  NOT NULL,
	TenHH Nvarchar2(60) NOT NULL,
	MaLoai Varchar2(8) NOT NULL,
	Hinh Nvarchar2(50) NOT NULL,
	DonGia Binary_double NOT NULL,
	GiamGia Binary_double NOT NULL,
	MoTa long NULL,
	MaNCC Nvarchar2(50) NOT NULL,
	SanPhamKho Number(10) NULL,
 CONSTRAINT PK__HangHoa__2725A6E407332647 PRIMARY KEY(MaHH) 
);
CREATE SEQUENCE HangHoa_seq START WITH 1 INCREMENT BY 1;
CREATE OR REPLACE TRIGGER HangHoa_seq_tr
 BEFORE INSERT ON HangHoa FOR EACH ROW
 WHEN (NEW.MaHH IS NULL)
BEGIN
 SELECT HangHoa_seq.NEXTVAL INTO :NEW.MaHH FROM DUAL;
END;
 
CREATE TABLE HoaDon(
	MaHD Number(10)  NOT NULL,
	MaKH Number(10) NOT NULL,
	NgayDat Timestamp(3) NOT NULL,
	NgayGiao Timestamp(3) NULL,
	HoTen Nvarchar2(50) NULL,
	DiaChi Nvarchar2(60) NOT NULL,
	SDT_nguoinhan Varchar2(20) NULL,
	GhiChu Nvarchar2(50) NULL,
	PhiVanChuyen Binary_double NOT NULL,
	MaTrangThai Number(10) NOT NULL,
	MaNV Nvarchar2(50) NULL,
	TongTienHang Binary_double NULL,
	MaVoucher Varchar2(10) NULL,
	TongThucThu Binary_double NULL,
 CONSTRAINT PK__HoaDon__2725A6E0959C19DB PRIMARY KEY (MaHD) 
);
CREATE SEQUENCE HoaDon_seq START WITH 1 INCREMENT BY 1;
CREATE OR REPLACE TRIGGER HoaDon_seq_tr
 BEFORE INSERT ON HoaDon FOR EACH ROW
 WHEN (NEW.MaHD IS NULL)
BEGIN
 SELECT HoaDon_seq.NEXTVAL INTO :NEW.MaHD FROM DUAL;
END;

CREATE TABLE HoiDap(
	MaHD Number(10)  NOT NULL,
	MaKH Number(10) NOT NULL,
	MaNV Number(10) NULL,
	CauHoi Nvarchar2(50) NOT NULL,
	TraLoi Nvarchar2(50) NULL,
	NgayDua date NOT NULL,
	TrangThaiTL Number(1) DEFAULT ((0)) NOT NULL  ,
 CONSTRAINT PK__HoiDap__2725A6E0D415BDE9 PRIMARY KEY(MaHD) 
);
CREATE SEQUENCE HoiDap_seq START WITH 1 INCREMENT BY 1;
CREATE OR REPLACE TRIGGER HoiDap_seq_tr
 BEFORE INSERT ON HoiDap FOR EACH ROW
 WHEN (NEW.MaHD IS NULL)
BEGIN
 SELECT HoiDap_seq.NEXTVAL INTO :NEW.MaHD FROM DUAL;
END;

CREATE TABLE KhachHang(
	MaKH Number(10)  NOT NULL,
	MatKhau Nvarchar2(50) NULL,
	HoTen Nvarchar2(50) NOT NULL,
	DiaChi Nvarchar2(60) NULL,
	DienThoai Nvarchar2(24) NULL,
	Email Nvarchar2(50) NOT NULL,
	Hinh Nvarchar2(50) NULL,
	LoaiKH Number(1) NULL,
	TaiKhoan Varchar2(30) NULL,
	GioiTinh Nvarchar2(50) NULL,
	NgaySinh Timestamp(3) NULL,
	TrangThaiHD Number(1) NULL,
 CONSTRAINT PK__KhachHan__2725CF1EA73C617F PRIMARY KEY(MaKH) 
);
CREATE SEQUENCE KhachHang_seq START WITH 1 INCREMENT BY 1;
CREATE OR REPLACE TRIGGER KhachHang_seq_tr
 BEFORE INSERT ON KhachHang FOR EACH ROW
 WHEN (NEW.MaKH IS NULL)
BEGIN
 SELECT KhachHang_seq.NEXTVAL INTO :NEW.MaKH FROM DUAL;
END;

CREATE TABLE Loai(
	MaLoai Varchar2(8) NOT NULL,
	GioiTinh Number(1) NOT NULL,
	TenLoai Nvarchar2(30) NOT NULL,
 CONSTRAINT PK_Loai PRIMARY KEY (MaLoai) 
);

CREATE TABLE LoaiTinTuc(
	LoaiTT Varchar2(6) NOT NULL,
	TenTT Nvarchar2(30) NULL,
 CONSTRAINT PK_LoaiTinTuc PRIMARY KEY(LoaiTT) 
);

CREATE TABLE NhaCungCap(
	MaNCC Nvarchar2(50) NOT NULL,
	TenCongTy Nvarchar2(50) NOT NULL,
	Email Nvarchar2(50) NOT NULL,
	DienThoai Nvarchar2(50) NULL,
	DiaChi Nvarchar2(50) NULL,
	MoTa long NULL,
	Hinh nchar(50) NULL,
PRIMARY KEY (MaNCC) 
);

CREATE TABLE NhanVien(
	MaNV Number(10)  NOT NULL,
	HoTen Nvarchar2(50) NOT NULL,
	Email Nvarchar2(50) NOT NULL,
	MatKhau Nvarchar2(50) NULL,
	MaPQ Number(10) NOT NULL,
	TrangThaiHD Number(1) NULL,
 CONSTRAINT PK__NhanVien__2725D70A11D9BA6E PRIMARY KEY(MaNV) 
);

CREATE SEQUENCE NhanVien_seq START WITH 1 INCREMENT BY 1;
CREATE OR REPLACE TRIGGER NhanVien_seq_tr
 BEFORE INSERT ON NhanVien FOR EACH ROW
 WHEN (NEW.MaNV IS NULL)
BEGIN
 SELECT NhanVien_seq.NEXTVAL INTO :NEW.MaNV FROM DUAL;
END;

CREATE TABLE PhanQuyen(
	MaPQ Number(10)  NOT NULL,
	Them Number(1) NOT NULL,
	Sua Number(1) NOT NULL,
	Xoa Number(1) NOT NULL,
	Xem Number(1) NOT NULL,
PRIMARY KEY(MaPQ) 
);
CREATE SEQUENCE PhanQuyen_seq START WITH 1 INCREMENT BY 1;
CREATE OR REPLACE TRIGGER PhanQuyen_seq_tr
 BEFORE INSERT ON PhanQuyen FOR EACH ROW
 WHEN (NEW.MaPQ IS NULL)
BEGIN
 SELECT PhanQuyen_seq.NEXTVAL INTO :NEW.MaPQ FROM DUAL;
END;

CREATE TABLE PhieuNhapHang(
	MaPN Number(10)  NOT NULL,
	NgayNhap Timestamp(3) NOT NULL,
	TongTien Binary_double NULL,
 CONSTRAINT PK_PhieuNhapHang PRIMARY KEY(MaPN) 
);
CREATE SEQUENCE PhieuNhapHang_seq START WITH 1 INCREMENT BY 1;
CREATE OR REPLACE TRIGGER PhieuNhapHang_seq_tr
 BEFORE INSERT ON PhieuNhapHang FOR EACH ROW
 WHEN (NEW.MaPN IS NULL)
BEGIN
 SELECT PhieuNhapHang_seq.NEXTVAL INTO :NEW.MaPN FROM DUAL;
END;

CREATE TABLE SanPham_Kho(
	MaSP_Kho Number(10)  NOT NULL,
	MaHh Number(10) NOT NULL,
	KichCo char(5) NULL,
	SoLuong Number(10) NULL,
 CONSTRAINT PK_SanPham_Kho PRIMARY KEY(MaSP_Kho,MaHh) 
);
CREATE SEQUENCE SanPham_Kho_seq START WITH 1 INCREMENT BY 1;
CREATE OR REPLACE TRIGGER SanPham_Kho_seq_tr
 BEFORE INSERT ON SanPham_Kho FOR EACH ROW
 WHEN (NEW.MaSP_Kho IS NULL)
BEGIN
 SELECT SanPham_Kho_seq.NEXTVAL INTO :NEW.MaSP_Kho FROM DUAL;
END;

CREATE TABLE TB_ThongKe(
	MaTB Number(10)  NOT NULL,
	ThoiGian Timestamp(3) NOT NULL,
	SoTruyCap Number(19) NOT NULL,
 CONSTRAINT PK_TB_ThongKe PRIMARY KEY (MaTB) 
);
CREATE SEQUENCE TB_ThongKe_seq START WITH 1 INCREMENT BY 1;
CREATE OR REPLACE TRIGGER TB_ThongKe_seq_tr
 BEFORE INSERT ON TB_ThongKe FOR EACH ROW
 WHEN (NEW.MaTB IS NULL)
BEGIN
 SELECT TB_ThongKe_seq.NEXTVAL INTO :NEW.MaTB FROM DUAL;
END;

CREATE TABLE TinTuc(
	MaTT Number(10)  NOT NULL,
	TieuDe Nvarchar2(100) NULL,
	NoiDung Clob NULL,
	Hinh Varchar2(50) NULL,
	NgayTao Timestamp(3) NULL,
	MaNV Number(10) NULL,
	LoaiTT Varchar2(6) NULL,
	TrangThai Number(1) NULL,
 CONSTRAINT PK_TinTuc PRIMARY KEY(MaTT) 
);
CREATE SEQUENCE TinTuc_seq START WITH 1 INCREMENT BY 1;
CREATE OR REPLACE TRIGGER TinTuc_seq_tr
 BEFORE INSERT ON TinTuc FOR EACH ROW
 WHEN (NEW.MaTT IS NULL)
BEGIN
 SELECT TinTuc_seq.NEXTVAL INTO :NEW.MaTT FROM DUAL;
END;

CREATE TABLE TrangThai(
	MaTrangThai Number(10) NOT NULL,
	TenTrangThai Nvarchar2(30) NOT NULL,
PRIMARY KEY (MaTrangThai) 
);

CREATE TABLE Voucher(
	MaVC Nvarchar2(10) NOT NULL,
	NoiDung long NULL,
	NgayTao Timestamp(3) NULL,
	NgayBatDau Timestamp(3) NULL,
	NgayHetHan Timestamp(3) NULL,
	GiamGia Binary_double NULL,
	TongTienDK Number(19) NULL,
	TrangThai Number(1) DEFAULT ((0)) NULL  ,
 CONSTRAINT PK_Voucher PRIMARY KEY (MaVC) 
);

CREATE TABLE YeuThich(
	MaYT Number(10)  NOT NULL,
	MaHH Number(10) NULL,
	MaKH Number(10) NULL,
	NgayChon Timestamp(3) NULL,
	DiemDanhGia Binary_double DEFAULT ((5)) NOT NULL  ,
	MaBL Number(10) NULL,
 CONSTRAINT PK_YeuThich PRIMARY KEY (MaYT) 
);

CREATE SEQUENCE YeuThich_seq START WITH 1 INCREMENT BY 1;
CREATE OR REPLACE TRIGGER YeuThich_seq_tr
 BEFORE INSERT ON YeuThich FOR EACH ROW
 WHEN (NEW.MaYT IS NULL)
BEGIN
 SELECT YeuThich_seq.NEXTVAL INTO :NEW.MaYT FROM DUAL;
END;

--SET IDENTITY_INSERT dbo.BannerQC ON 

INSERT ALL
into BannerQC (MaQC, NoiDungQC, NgayTao, Hinh, NgayBatDau, NgayKetThucQC) values (1, N'Đại khuyến mãi Flash Sales', TO_TIMESTAMP('2018-12-19 00:00:00.000','YYYY-MM-DD HH24:MI:SS.FF3'), N'banner1.jpg', TO_TIMESTAMP ('2018-12-19 00:00:00.000','YYYY-MM-DD HH24:MI:SS.FF3') , TO_TIMESTAMP ('2018-12-20 12:00:00.000','YYYY-MM-DD HH24:MI:SS.FF3') )
into BannerQC (MaQC, NoiDungQC, NgayTao, Hinh, NgayBatDau, NgayKetThucQC) values (2, N'Sự kiện khuyến mãi giáng sinh', TO_TIMESTAMP ('2018-12-19 00:00:00.000','YYYY-MM-DD HH24:MI:SS.FF3') , N'banner4.jpg', TO_TIMESTAMP ('2018-12-19 12:17:00.000','YYYY-MM-DD HH24:MI:SS.FF3') , TO_TIMESTAMP ('2018-12-24 23:59:59.000','YYYY-MM-DD HH24:MI:SS.FF3') )
into BannerQC (MaQC, NoiDungQC, NgayTao, Hinh, NgayBatDau, NgayKetThucQC) values (3, N'Tiệc ưu đãi tết Tây', TO_TIMESTAMP ('2018-12-24 23:59:59.000','YYYY-MM-DD HH24:MI:SS.FF3') , N'banner3.jpg', TO_TIMESTAMP ('2018-12-19 00:00:00.000','YYYY-MM-DD HH24:MI:SS.FF3') , TO_TIMESTAMP ('2018-12-31 23:59:59.000','YYYY-MM-DD HH24:MI:SS.FF3') )
into BannerQC (MaQC, NoiDungQC, NgayTao, Hinh, NgayBatDau, NgayKetThucQC) values (4, N'ESHOP', TO_TIMESTAMP ('1975-01-01 00:00:00.000','YYYY-MM-DD HH24:MI:SS.FF3'), N'banner2.jpg', TO_TIMESTAMP ('1975-01-01 00:00:00.000','YYYY-MM-DD HH24:MI:SS.FF3') , TO_TIMESTAMP ('9999-12-31 00:00:00.000','YYYY-MM-DD HH24:MI:SS.FF3') )
SELECT * FROM dual;
--SET IDENTITY_INSERT dbo.BannerQC OFF
--SET IDENTITY_INSERT BinhLuanSP ON 

INSERT ALL
into BinhLuanSP (MaBL, NoiDung, NgayBL, MaKH, MaHh) values (13, N'Vải đẹp ok', TO_TIMESTAMP ('2018-12-03 13:26:04.810','YYYY-MM-DD HH24:MI:SS.FF3') , 6, 7)
into BinhLuanSP (MaBL, NoiDung, NgayBL, MaKH, MaHh) values (14, N'hàng bị rách nách', TO_TIMESTAMP ('2018-12-03 13:27:05.703','YYYY-MM-DD HH24:MI:SS.FF3') , 6, 7)
into BinhLuanSP (MaBL, NoiDung, NgayBL, MaKH, MaHh) values (15, N'tạm được', TO_TIMESTAMP ('2018-12-03 13:54:30.360','YYYY-MM-DD HH24:MI:SS.FF3') , 5, 7)
SELECT * FROM dual;

--SET IDENTITY_INSERT BinhLuanSP OFF
--SET IDENTITY_INSERT ChiTietHD ON 
insert all
into ChiTietHD (MaCT, MaHD, MaHH, DonGia, GiamGia, SoLuong, KichCo) values (1, 3, 20, 300000, 0.2, 2, N'M')
into ChiTietHD (MaCT, MaHD, MaHH, DonGia, GiamGia, SoLuong, KichCo) values (2, 3, 20, 300000, 0.2, 1, N'S')
into ChiTietHD (MaCT, MaHD, MaHH, DonGia, GiamGia, SoLuong, KichCo) values (3, 3, 24, 300000, 0.2, 2, N'M')
into ChiTietHD (MaCT, MaHD, MaHH, DonGia, GiamGia, SoLuong, KichCo) values  (4, 4, 7, 350000, 0.15, 3, N'M')
into ChiTietHD (MaCT, MaHD, MaHH, DonGia, GiamGia, SoLuong, KichCo) values  (5, 4, 20, 300000, 0.2, 2, N'M')
into ChiTietHD (MaCT, MaHD, MaHH, DonGia, GiamGia, SoLuong, KichCo) values  (6, 5, 26, 110000, 0.2, 2, N'M')
into ChiTietHD (MaCT, MaHD, MaHH, DonGia, GiamGia, SoLuong, KichCo) values  (7, 5, 25, 300000, 0.2, 1, N'S')
into ChiTietHD (MaCT, MaHD, MaHH, DonGia, GiamGia, SoLuong, KichCo) values  (8, 5, 20, 300000, 0.2, 2, N'L')
into ChiTietHD (MaCT, MaHD, MaHH, DonGia, GiamGia, SoLuong, KichCo) values  (9, 6, 19, 320000, 0.2, 2, N'M')
into ChiTietHD (MaCT, MaHD, MaHH, DonGia, GiamGia, SoLuong, KichCo) values  (10, 6, 21, 300000, 0.2, 3, N'M')
into ChiTietHD (MaCT, MaHD, MaHH, DonGia, GiamGia, SoLuong, KichCo) values  (11, 7, 7, 350000, 0.15, 2, N'M')
into ChiTietHD (MaCT, MaHD, MaHH, DonGia, GiamGia, SoLuong, KichCo) values  (12, 7, 22, 300000, 0.2, 2, N'M')
into ChiTietHD (MaCT, MaHD, MaHH, DonGia, GiamGia, SoLuong, KichCo) values  (13, 8, 19, 320000, 0.2, 1, N'M')
into ChiTietHD (MaCT, MaHD, MaHH, DonGia, GiamGia, SoLuong, KichCo) values  (14, 8, 20, 300000, 0.2, 1, N'M')
into ChiTietHD (MaCT, MaHD, MaHH, DonGia, GiamGia, SoLuong, KichCo) values  (17, 10, 21, 300000, 0.2, 2, N'S')
into ChiTietHD (MaCT, MaHD, MaHH, DonGia, GiamGia, SoLuong, KichCo) values  (18, 10, 22, 300000, 0.2, 1, N'M')
into ChiTietHD (MaCT, MaHD, MaHH, DonGia, GiamGia, SoLuong, KichCo) values  (19, 11, 20, 300000, 0.2, 2, N'S')
into ChiTietHD (MaCT, MaHD, MaHH, DonGia, GiamGia, SoLuong, KichCo) values  (20, 11, 20, 300000, 0.2, 1, N'M')
into ChiTietHD (MaCT, MaHD, MaHH, DonGia, GiamGia, SoLuong, KichCo) values  (29, 19, 7, 350000, 0.15, 3, N'S')
into ChiTietHD (MaCT, MaHD, MaHH, DonGia, GiamGia, SoLuong, KichCo) values  (30, 20, 20, 300000, 0.2, 2, N'S')
into ChiTietHD (MaCT, MaHD, MaHH, DonGia, GiamGia, SoLuong, KichCo) values  (31, 20, 19, 320000, 0.2, 3, N'M')
into ChiTietHD (MaCT, MaHD, MaHH, DonGia, GiamGia, SoLuong, KichCo) values  (32, 22, 7, 350000, 0.15, 1, N'S')
SELECT * FROM dual;
--SET IDENTITY_INSERT ChiTietHD OFF
INSERT all
into ChiTietPhieuNhap (MaPN, MaHH, KichCo, SoLuongNhap, DonGiaNhap) values (13, 20, N'L', 30, 300000)
into ChiTietPhieuNhap (MaPN, MaHH, KichCo, SoLuongNhap, DonGiaNhap) values (13, 20, N'M', 0, 300000)
into ChiTietPhieuNhap (MaPN, MaHH, KichCo, SoLuongNhap, DonGiaNhap) values (13, 20, N'S', 20, 300000)
into ChiTietPhieuNhap (MaPN, MaHH, KichCo, SoLuongNhap, DonGiaNhap) values (14, 7, N'L', 35, 350000)
into ChiTietPhieuNhap (MaPN, MaHH, KichCo, SoLuongNhap, DonGiaNhap) values (14, 7, N'M', 20, 350000)
into ChiTietPhieuNhap (MaPN, MaHH, KichCo, SoLuongNhap, DonGiaNhap) values (14, 7, N'S', 20, 350000)
into ChiTietPhieuNhap (MaPN, MaHH, KichCo, SoLuongNhap, DonGiaNhap) values (14, 18, N'L', 20, 300000)
into ChiTietPhieuNhap (MaPN, MaHH, KichCo, SoLuongNhap, DonGiaNhap) values (14, 18, N'M', 60, 300000)
into ChiTietPhieuNhap (MaPN, MaHH, KichCo, SoLuongNhap, DonGiaNhap) values (14, 18, N'S', 10, 300000)
into ChiTietPhieuNhap (MaPN, MaHH, KichCo, SoLuongNhap, DonGiaNhap) values (15, 7, N'L', 20, 350000)
into ChiTietPhieuNhap (MaPN, MaHH, KichCo, SoLuongNhap, DonGiaNhap) values (15, 7, N'M', 15, 350000)
into ChiTietPhieuNhap (MaPN, MaHH, KichCo, SoLuongNhap, DonGiaNhap) values (15, 7, N'S', 20, 350000)
into ChiTietPhieuNhap (MaPN, MaHH, KichCo, SoLuongNhap, DonGiaNhap) values (16, 20, N'L', 20, 300000)
into ChiTietPhieuNhap (MaPN, MaHH, KichCo, SoLuongNhap, DonGiaNhap) values (16, 20, N'M', 10, 300000)
into ChiTietPhieuNhap (MaPN, MaHH, KichCo, SoLuongNhap, DonGiaNhap) values (16, 20, N'S', 10, 300000)
SELECT * FROM dual;
--SET IDENTITY_INSERT HangHoa ON 

INSERT all
into HangHoa (MaHH, TenHH, MaLoai, Hinh, DonGia, GiamGia, MoTa, MaNCC, SanPhamKho) values (7, N'ÁO SƠ MI NAM DÀI TAY TRẮNG SMT16', N'ESAO001', N'so_mi_nam_16.jpg', 350000, 0.15, N'Sơ mi tay dài trắng phong cách tinh sảo', N'ESHOP', NULL)
into HangHoa (MaHH, TenHH, MaLoai, Hinh, DonGia, GiamGia, MoTa, MaNCC, SanPhamKho) values (11, N'ÁO SƠ MI NAM DÀI TAY TRẮNG SMT12', N'ESAO001', N'so_mi_nam_012.jpg', 280000, 0.12, N'Sơ mi body hoa văn họa tiết tinh sảo', N'ESHOP', NULL)
into HangHoa (MaHH, TenHH, MaLoai, Hinh, DonGia, GiamGia, MoTa, MaNCC, SanPhamKho) values (17, N'ÁO SƠ MI NAM DÀI TAY TRẮNG SMT12', N'ESAO001', N'so_mi_nam_01.jpg', 280000, 0, N'Sơ mi tay dài nam trắng phong cách', N'ESHOP', NULL)
into HangHoa (MaHH, TenHH, MaLoai, Hinh, DonGia, GiamGia, MoTa, MaNCC, SanPhamKho) values (18, N'ÁO SƠ MI NAM DÀI TAY TRẮNG SMT0001', N'ESAO001', N'so_mi_nam_0001.jpg', 300000, 0.2, N'Áo sơ mi cổ cao trắng sang trọng quý phái', N'ESHOP', NULL)
into HangHoa (MaHH, TenHH, MaLoai, Hinh, DonGia, GiamGia, MoTa, MaNCC, SanPhamKho) values (19, N'ÁO SƠ MI NAM DÀI TAY SỌC ĐEN TRẮNG SMT0004', N'ESAO001', N'ao_so_mi_0004.jpg', 320000, 0.2, N'Áo sơ mi sọc đen trắng sang trọng quý phái', N'ESHOP', NULL)
into HangHoa (MaHH, TenHH, MaLoai, Hinh, DonGia, GiamGia, MoTa, MaNCC, SanPhamKho) values (20, N'ÁO SƠ MI NAM DÀI TAY ĐỎ SỌC SMT0006', N'ESAO001', N'ao_so_mi_0006.jpg', 300000, 0.2, N'Áo sơ mi cổ cao đỏ sọc sang trọng quý phái', N'ESHOP', NULL)
into HangHoa (MaHH, TenHH, MaLoai, Hinh, DonGia, GiamGia, MoTa, MaNCC, SanPhamKho) values (21, N'ÁO SƠ MI NAM DÀI TAY XÁM SỌC ĐEN SMT0018', N'ESAO001', N'ao_so_mi_0018.jpg', 300000, 0.2, N'Áo sơ mi cổ cao xám đen sọc sang trọng quý phái', N'ESHOP', NULL)
into HangHoa (MaHH, TenHH, MaLoai, Hinh, DonGia, GiamGia, MoTa, MaNCC, SanPhamKho) values (22, N'ÁO SƠ MI NAM DÀI TAY XANH SỌC ĐEN SMT0026', N'ESAO001', N'ao_so_mi_0026.jpg', 300000, 0.2, N'Áo sơ mi cổ cao xanh sọc sang trọng quý phái', N'ESHOP', NULL)
into HangHoa (MaHH, TenHH, MaLoai, Hinh, DonGia, GiamGia, MoTa, MaNCC, SanPhamKho) values (23, N'ÁO SƠ MI NAM NGẮN TAY SMT0001', N'ESAO007', N'ao_so_mi_0001.jpg', 300000, 0.2, N'Áo sơ mi cổ cao đỏ sọc sang trọng quý phái', N'ESHOP', NULL)
into HangHoa (MaHH, TenHH, MaLoai, Hinh, DonGia, GiamGia, MoTa, MaNCC, SanPhamKho) values (24, N'ÁO SƠ MI NAM NGẮN TAY HỌA TIẾT SMT0065', N'ESAO007', N'ao_so_mi_tay_ngan_0065.jpg', 300000, 0.2, N'Áo sơ mi ngắn xanh sang trọng quý phái', N'ESHOP', NULL)
into HangHoa (MaHH, TenHH, MaLoai, Hinh, DonGia, GiamGia, MoTa, MaNCC, SanPhamKho) values (25, N'ÁO SƠ MI NAM NGẮN TAY SMT0069', N'ESAO007', N'ao_so_mi_tay_ngan_0069.jpg', 300000, 0.2, N'Áo sơ mi ngắn xanh sang trọng quý phái', N'ESHOP', NULL)
into HangHoa (MaHH, TenHH, MaLoai, Hinh, DonGia, GiamGia, MoTa, MaNCC, SanPhamKho) values (26, N'ÁO THUN NAM NGẮN TAY SMT0005', N'ESAO011', N'ao_thun_nam_5.jpg', 110000, 0.2, N'Áo thun ngắn sang trọng quý phái', N'ESHOP', NULL)
into HangHoa (MaHH, TenHH, MaLoai, Hinh, DonGia, GiamGia, MoTa, MaNCC, SanPhamKho) values (27, N'ÁO THUN NAM NGẮN TAY SMT0001', N'ESAO011', N'ao_thun_nam_01.jpg', 110000, 0.2, N'Áo thun ngắn sang trọng quý phái', N'ESHOP', NULL)
into HangHoa (MaHH, TenHH, MaLoai, Hinh, DonGia, GiamGia, MoTa, MaNCC, SanPhamKho) values (28, N'ÁO THUN NAM NGẮN TAY SMT0010', N'ESAO011', N'ao_thun_nam_1.jpg', 110000, 0.2, N'Áo thun ngắn sang trọng quý phái', N'ESHOP', NULL)
into HangHoa (MaHH, TenHH, MaLoai, Hinh, DonGia, GiamGia, MoTa, MaNCC, SanPhamKho) values (29, N'ÁO THUN NAM NGẮN TAY SMT0041', N'ESAO011', N'ao_thun_nam_41.jpg', 110000, 0.2, N'Áo thun ngắn sang trọng quý phái', N'ESHOP', NULL)
into HangHoa (MaHH, TenHH, MaLoai, Hinh, DonGia, GiamGia, MoTa, MaNCC, SanPhamKho) values (30, N'ÁO THUN NAM NGẮN TAY SMT0073', N'ESAO011', N'ao_thun_nam_73.jpg', 110000, 0.2, N'Áo thun ngắn sang trọng quý phái', N'ESHOP', NULL)
SELECT * FROM dual;
--SET IDENTITY_INSERT HangHoa OFF
--SET IDENTITY_INSERT HoaDon ON 
--TO_TIMESTAMP ('1975-01-01 00:00:00.000','YYYY-MM-DD HH24:MI:SS.FF3')
INSERT ALL
into HoaDon (MaHD, MaKH, NgayDat, NgayGiao, HoTen, DiaChi, SDT_nguoinhan, GhiChu, PhiVanChuyen, MaTrangThai, MaNV, TongTienHang, MaVoucher, TongThucThu) values (3, 5, TO_TIMESTAMP ('2018-11-30 17:53:28.673','YYYY-MM-DD HH24:MI:SS.FF3') , NULL, N'Nguyễn Thanh Sang', N'Chánh Mỹ, Bình Dương', N'0971890712', N'Giao hàng đến văn phòng khu phố', 35000, 1, NULL, NULL, NULL, NULL)
into HoaDon (MaHD, MaKH, NgayDat, NgayGiao, HoTen, DiaChi, SDT_nguoinhan, GhiChu, PhiVanChuyen, MaTrangThai, MaNV, TongTienHang, MaVoucher, TongThucThu) values (4, 4, TO_TIMESTAMP ('2018-11-30 19:20:53.203','YYYY-MM-DD HH24:MI:SS.FF3') , NULL, N'Nguyễn Thành Long', N'Chánh Mỹ, Bình Dương', N'0971890712', N'Giao hàng đến văn phòng khu phố', 35000, 1, NULL, NULL, NULL, NULL)
into HoaDon (MaHD, MaKH, NgayDat, NgayGiao, HoTen, DiaChi, SDT_nguoinhan, GhiChu, PhiVanChuyen, MaTrangThai, MaNV, TongTienHang, MaVoucher, TongThucThu) values (5, 4, TO_TIMESTAMP ('2018-12-01 21:08:24.610','YYYY-MM-DD HH24:MI:SS.FF3') , NULL, N'Nguyễn Thanh Sang', N'Chánh Mỹ, Bình Dương', N'0971890712', N'Giao hàng đến văn phòng khu phố', 35000, 1, NULL, NULL, NULL, NULL)
into HoaDon (MaHD, MaKH, NgayDat, NgayGiao, HoTen, DiaChi, SDT_nguoinhan, GhiChu, PhiVanChuyen, MaTrangThai, MaNV, TongTienHang, MaVoucher, TongThucThu) values (6, 4, TO_TIMESTAMP ('2018-12-01 21:37:24.947','YYYY-MM-DD HH24:MI:SS.FF3') , NULL, N'Nguyễn Thành Long', N'Chánh Mỹ, Bình Dương', N'0971890712', N'Giao hàng đến văn phòng khu phố', 35000, 1, NULL, NULL, NULL, NULL)
into HoaDon (MaHD, MaKH, NgayDat, NgayGiao, HoTen, DiaChi, SDT_nguoinhan, GhiChu, PhiVanChuyen, MaTrangThai, MaNV, TongTienHang, MaVoucher, TongThucThu) values (7, 6, TO_TIMESTAMP ('2018-12-01 21:40:56.943','YYYY-MM-DD HH24:MI:SS.FF3') , NULL, N'Nguyễn Thành Long', N'Chánh Mỹ, Bình Dương', N'0971890712', N'Giao hàng đến văn phòng khu phố', 35000, 1, NULL, NULL, NULL, NULL)
into HoaDon (MaHD, MaKH, NgayDat, NgayGiao, HoTen, DiaChi, SDT_nguoinhan, GhiChu, PhiVanChuyen, MaTrangThai, MaNV, TongTienHang, MaVoucher, TongThucThu) values (8, 4, TO_TIMESTAMP ('2018-12-01 21:45:14.087','YYYY-MM-DD HH24:MI:SS.FF3') , NULL, N'Nguyễn Thanh Sang', N'Chánh Mỹ, Bình Dương', N'0971890712', N'Giao hàng đến văn phòng khu phố', 35000, 1, NULL, NULL, NULL, NULL)
into HoaDon (MaHD, MaKH, NgayDat, NgayGiao, HoTen, DiaChi, SDT_nguoinhan, GhiChu, PhiVanChuyen, MaTrangThai, MaNV, TongTienHang, MaVoucher, TongThucThu) values (10, 4, TO_TIMESTAMP ('2018-12-01 22:07:14.300','YYYY-MM-DD HH24:MI:SS.FF3') , NULL, N'Nguyễn Thanh Sang', N'Chánh Mỹ, Bình Dương', N'0971890712', N'Giao hàng đến văn phòng khu phố', 35000, 0, NULL, NULL, NULL, NULL)
into HoaDon (MaHD, MaKH, NgayDat, NgayGiao, HoTen, DiaChi, SDT_nguoinhan, GhiChu, PhiVanChuyen, MaTrangThai, MaNV, TongTienHang, MaVoucher, TongThucThu) values (11, 4, TO_TIMESTAMP ('2018-12-01 22:10:41.587','YYYY-MM-DD HH24:MI:SS.FF3') , NULL, N'Nguyễn Thành Long', N'Chánh Mỹ, Bình Dương', N'0971890712', N'Giao hàng đến văn phòng khu phố', 35000, 0, NULL, NULL, NULL, NULL)
into HoaDon (MaHD, MaKH, NgayDat, NgayGiao, HoTen, DiaChi, SDT_nguoinhan, GhiChu, PhiVanChuyen, MaTrangThai, MaNV, TongTienHang, MaVoucher, TongThucThu) values (19, 4, TO_TIMESTAMP ('2018-12-04 11:34:00.213','YYYY-MM-DD HH24:MI:SS.FF3') , NULL, N'Nguyễn Thành Long', N'Chánh Mỹ, Bình Dương', N'0971890712', N'Giao hàng đến văn phòng khu phố', 35000, 0, NULL, NULL, NULL, NULL)
into HoaDon (MaHD, MaKH, NgayDat, NgayGiao, HoTen, DiaChi, SDT_nguoinhan, GhiChu, PhiVanChuyen, MaTrangThai, MaNV, TongTienHang, MaVoucher, TongThucThu) values (20, 4, TO_TIMESTAMP ('2018-12-20 13:50:15.093','YYYY-MM-DD HH24:MI:SS.FF3') , NULL, N'Nguyễn Thanh Sang', N'Chánh Mỹ, Bình Dương', N'0971890712', N'Giao hàng đến văn phòng khu phố', 35000, 0, NULL, 1248000, N'12dasjAdsB', 1158200)
into HoaDon (MaHD, MaKH, NgayDat, NgayGiao, HoTen, DiaChi, SDT_nguoinhan, GhiChu, PhiVanChuyen, MaTrangThai, MaNV, TongTienHang, MaVoucher, TongThucThu) values (22, 11, TO_TIMESTAMP ('2018-12-20 21:57:30.273','YYYY-MM-DD HH24:MI:SS.FF3') , NULL, N'Đỗ Phúc Hậu', N'280 ADV', N'0904877306', NULL, 35000, 0, NULL, 297500, NULL, 332500)
SELECT * FROM dual;
--SET IDENTITY_INSERT HoaDon OFF
--SET IDENTITY_INSERT HoiDap ON 
--TO_TIMESTAMP ('1975-01-01','YYYY-MM-DD')
INSERT ALL
into HoiDap (MaHD, MaKH, MaNV, CauHoi, TraLoi, NgayDua, TrangThaiTL) values (3, 6, NULL, N'Cửa hàng phục vụ tốt', N'Cảm ơn bạn đả ủng hộ shop', TO_TIMESTAMP ('2018-12-06','YYYY-MM-DD') , 1)
into HoiDap (MaHD, MaKH, MaNV, CauHoi, TraLoi, NgayDua, TrangThaiTL) values (4, 6, NULL, N'Ok', N'Cảm ơn bạn', TO_TIMESTAMP ('2018-12-06','YYYY-MM-DD') , 1)
into HoiDap (MaHD, MaKH, MaNV, CauHoi, TraLoi, NgayDua, TrangThaiTL) values (5, 6, NULL, N'Shop phục vụ tận tình', N'Cảm ơn bạn đã ủng hộ shop', TO_TIMESTAMP ('2018-12-06','YYYY-MM-DD') , 1)
into HoiDap (MaHD, MaKH, MaNV, CauHoi, TraLoi, NgayDua, TrangThaiTL) values (6, 6, NULL, N'Nhân Viên lịch sự', NULL, TO_TIMESTAMP ('2018-12-06','YYYY-MM-DD') , 0)
into HoiDap (MaHD, MaKH, MaNV, CauHoi, TraLoi, NgayDua, TrangThaiTL) values (7, 6, NULL, N'Dịch vụ khách hàng ưu đãi tốt', NULL, TO_TIMESTAMP ('2018-12-06','YYYY-MM-DD') , 0)
into HoiDap (MaHD, MaKH, MaNV, CauHoi, TraLoi, NgayDua, TrangThaiTL) values (8, 4, NULL, N'Rất thích ESHOP .', N'Cảm ơn bạn đả ủng hộ ESHOP', TO_TIMESTAMP ('2018-12-06','YYYY-MM-DD') , 1)
into HoiDap (MaHD, MaKH, MaNV, CauHoi, TraLoi, NgayDua, TrangThaiTL) values (9, 4, NULL, N'Shop làm ăn chán', N'ESHOP xl vì những bất biện', TO_TIMESTAMP ('2018-12-06','YYYY-MM-DD') , 1)
SELECT * FROM dual;
--SET IDENTITY_INSERT HoiDap OFF
--SET IDENTITY_INSERT KhachHang ON 

INSERT ALL
into KhachHang (MaKH, MatKhau, HoTen, DiaChi, DienThoai, Email, Hinh, LoaiKH, TaiKhoan, GioiTinh, NgaySinh, TrangThaiHD) values (4, N'c4ca4238a0b923820dcc509a6f75849b', N'Nguyễn Thanh Sang', N'Bình Dương', N'0971890712', N'sanglun2254@gmail.com', N'34441.png', 1, N'sangnt2', N'Nam', NULL, 1)
into KhachHang (MaKH, MatKhau, HoTen, DiaChi, DienThoai, Email, Hinh, LoaiKH, TaiKhoan, GioiTinh, NgaySinh, TrangThaiHD) values (5, N'c4ca4238a0b923820dcc509a6f75849b', N'Minh Cao', N'TPHCM', N'0971890712', N'minhcd@gmail.com', N'backg.jpg', 1, N'minhcd', N'Nam', NULL, 1)
into KhachHang (MaKH, MatKhau, HoTen, DiaChi, DienThoai, Email, Hinh, LoaiKH, TaiKhoan, GioiTinh, NgaySinh, TrangThaiHD) values (6, N'c4ca4238a0b923820dcc509a6f75849b', N'Nguyễn Thanh Sang', N'Bình Dương', N'0971890712', N'sanglun2254_1@gmail.com', N'long.jpg', 1, N'sangnt', N'Nam', NULL, 1)
into KhachHang (MaKH, MatKhau, HoTen, DiaChi, DienThoai, Email, Hinh, LoaiKH, TaiKhoan, GioiTinh, NgaySinh, TrangThaiHD) values (10, N'', N'anonymouse', N'Không có', N'', N'pinkwater98@gmail.com', N'anonymouse.jpg', 0, N'shanm', N'Nam', NULL, 1)
into KhachHang (MaKH, MatKhau, HoTen, DiaChi, DienThoai, Email, Hinh, LoaiKH, TaiKhoan, GioiTinh, NgaySinh, TrangThaiHD) values (11, NULL, N'Đỗ Phúc Hậu', N'280 ADV', N'0904877306', N'wanriky2998@gmail.com', NULL, 0, N'haudp', N'Nam', NULL, 1)
SELECT * FROM dual;
--SET IDENTITY_INSERT KhachHang OFF
INSERT ALL
into Loai (MaLoai, GioiTinh, TenLoai) values (N'ESAO001', 0, N'ÁO SƠ MI TAY DÀI')
into Loai (MaLoai, GioiTinh, TenLoai) values (N'ESAO006', 1, N'ÁO SƠ MI TAY DÀI')
into Loai (MaLoai, GioiTinh, TenLoai) values (N'ESAO007', 0, N'ÁO SƠ MI NGẮN TAY')
into Loai (MaLoai, GioiTinh, TenLoai) values (N'ESAO008', 1, N'ÁO SƠ MI NGẮN TAY')
into Loai (MaLoai, GioiTinh, TenLoai) values (N'ESAO009', 0, N'ÁO THUN DÀI TAY')
into Loai (MaLoai, GioiTinh, TenLoai) values (N'ESAO010', 1, N'ÁO THUN DÀI TAY')
into Loai (MaLoai, GioiTinh, TenLoai) values (N'ESAO011', 0, N'ÁO THUN NGẮN TAY')
into Loai (MaLoai, GioiTinh, TenLoai) values (N'ESAO012', 1, N'ÁO THUN NGẮN TAY')
into Loai (MaLoai, GioiTinh, TenLoai) values (N'ESAO013', 0, N'ÁO THUN BA LỖ')
into Loai (MaLoai, GioiTinh, TenLoai) values (N'ESAO014', 1, N'ÁO THUN BA LỖ')
into LoaiTinTuc (LoaiTT, TenTT) values (N'TT_KM', N'Khuyến mãi')
into LoaiTinTuc (LoaiTT, TenTT) values (N'TT_QC', N'Quảng cáo')
into LoaiTinTuc (LoaiTT, TenTT) values (N'TT_REV', N'Review sản phẩm')
into NhaCungCap (MaNCC, TenCongTy, Email, DienThoai, DiaChi, MoTa, Hinh) values (N'ESHOP', N'ESHOP', N'eshop@gmail.com', N'1654651326', N'TPHCM', N'Công ty thương mại', N'kenta.jpg')
into NhaCungCap (MaNCC, TenCongTy, Email, DienThoai, DiaChi, MoTa, Hinh) values (N'KENTA', N'KENTA', N'kenta@gmail.com', N'653256565', N'TPHCM', N'Cửa hàng thời trang', N'kenta.jpg')
into NhaCungCap (MaNCC, TenCongTy, Email, DienThoai, DiaChi, MoTa, Hinh) values (N'SENDO', N'SENDO', N'sendo@gmail.com', N'2356562323', N'TPHCM', N'Công ty thương mại điện tử', N'sendo.jpg')
into NhaCungCap (MaNCC, TenCongTy, Email, DienThoai, DiaChi, MoTa, Hinh) values (N'YAME', N'YAME', N'yame@gmail.com', N'32565365323', N'BÌNH DƯƠNG', N'Cửa hàng may mặc thời trang ', N'yame.jpg')
SELECT * FROM dual;
--SET IDENTITY_INSERT NhanVien ON 

INSERT into NhanVien (MaNV, HoTen, Email, MatKhau, MaPQ, TrangThaiHD) values (1, N'Admin', N'nv1@gmail.com', N'c4ca4238a0b923820dcc509a6f75849b', 1, 1);
-- SET IDENTITY_INSERT NhanVien OFF
--SET IDENTITY_INSERT PhanQuyen ON 

INSERT into PhanQuyen (MaPQ, Them, Sua, Xoa, Xem) values  (1, 1, 1, 1, 1);
--SET IDENTITY_INSERT PhanQuyen OFF
--SET IDENTITY_INSERT PhieuNhapHang ON 
--TO_TIMESTAMP ('1975-01-01 00:00:00.000','YYYY-MM-DD HH24:MI:SS.FF3')
INSERT ALL
into PhieuNhapHang (MaPN, NgayNhap, TongTien) values (13, TO_TIMESTAMP ('2018-12-18 01:12:59.063','YYYY-MM-DD HH24:MI:SS.FF3') , 15000000)
into PhieuNhapHang (MaPN, NgayNhap, TongTien) values (14, TO_TIMESTAMP ('2018-12-18 01:16:40.443','YYYY-MM-DD HH24:MI:SS.FF3') , 53250000)
into PhieuNhapHang (MaPN, NgayNhap, TongTien) values (15, TO_TIMESTAMP ('2018-12-20 08:30:07.050','YYYY-MM-DD HH24:MI:SS.FF3') , 19250000)
into PhieuNhapHang (MaPN, NgayNhap, TongTien) values (16, TO_TIMESTAMP ('2018-12-20 08:32:45.633','YYYY-MM-DD HH24:MI:SS.FF3') , 12000000)
SELECT * FROM dual;
--SET IDENTITY_INSERT PhieuNhapHang OFF
--SET IDENTITY_INSERT SanPham_Kho ON 

INSERT ALL
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (1, 7, N'S', 66)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (2, 7, N'M', 86)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (3, 7, N'L', 105)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (4, 11, N'S', 2)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (5, 11, N'M', 3)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (6, 11, N'L', 0)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (7, 17, N'S', 100)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (8, 17, N'M', 100)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (9, 17, N'L', 100)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (10, 18, N'S', 110)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (11, 18, N'M', 160)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (12, 18, N'L', 120)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (13, 19, N'S', 100)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (14, 19, N'M', 97)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (15, 19, N'L', 100)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (16, 20, N'S', 110)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (17, 20, N'M', 111)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (18, 20, N'L', 120)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (19, 21, N'S', 100)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (20, 21, N'M', 100)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (21, 21, N'L', 100)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (22, 22, N'S', 100)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (23, 22, N'M', 100)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (24, 22, N'L', 100)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (25, 23, N'S', 100)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (26, 23, N'M', 100)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (27, 23, N'L', 100)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (28, 24, N'S', 100)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (29, 24, N'M', 100)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (30, 24, N'L', 100)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (31, 25, N'S', 100)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (32, 25, N'M', 100)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (33, 25, N'L', 100)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (34, 26, N'S', 100)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (35, 26, N'M', 100)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (36, 26, N'L', 100)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (37, 27, N'S', 100)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (38, 27, N'M', 100)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (39, 27, N'L', 100)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (40, 28, N'S', 100)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (41, 28, N'M', 100)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (42, 28, N'L', 100)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (43, 29, N'S', 100)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (44, 29, N'M', 100)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (45, 29, N'L', 100)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (46, 30, N'S', 100)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (47, 30, N'M', 100)
into SanPham_Kho (MaSP_Kho, MaHh, KichCo, SoLuong) values (48, 30, N'L', 100)
SELECT * FROM dual;
--SET IDENTITY_INSERT SanPham_Kho OFF
--TO_TIMESTAMP ('1975-01-01 00:00:00.000','YYYY-MM-DD HH24:MI:SS.FF3')
INSERT ALL
into TrangThai (MaTrangThai, TenTrangThai) values (0, N'Chờ xử lý')
into TrangThai (MaTrangThai, TenTrangThai) values (1, N'Đã xử lý')
into Voucher (MaVC, NoiDung, NgayTao, NgayBatDau, NgayHetHan, GiamGia, TongTienDK, TrangThai) values (N'12dasjAdsB', N'Giảm giá Noel', TO_TIMESTAMP ('2018-12-19 00:00:00.000','YYYY-MM-DD HH24:MI:SS.FF3') , TO_TIMESTAMP ('2018-12-20 00:00:00.000','YYYY-MM-DD HH24:MI:SS.FF3') , TO_TIMESTAMP ('2018-12-24 00:00:00.000','YYYY-MM-DD HH24:MI:SS.FF3') , 0.1, 500000, 1)
into Voucher (MaVC, NoiDung, NgayTao, NgayBatDau, NgayHetHan, GiamGia, TongTienDK, TrangThai) values (N'g4oesHY8JY', N'Hè sôi động', TO_TIMESTAMP ('2018-12-20 07:56:07.983','YYYY-MM-DD HH24:MI:SS.FF3') , TO_TIMESTAMP ('2019-03-15 01:00:00.000','YYYY-MM-DD HH24:MI:SS.FF3') , TO_TIMESTAMP ('2019-03-20 23:59:00.000','YYYY-MM-DD HH24:MI:SS.FF3') , 0.1, 250000, 1)
into Voucher (MaVC, NoiDung, NgayTao, NgayBatDau, NgayHetHan, GiamGia, TongTienDK, TrangThai) values (N'WYyGAhzxBI', N'Tết nguyên đán', TO_TIMESTAMP ('2018-12-20 07:30:56.913','YYYY-MM-DD HH24:MI:SS.FF3'), TO_TIMESTAMP ('2019-01-15 00:00:00.000','YYYY-MM-DD HH24:MI:SS.FF3') , TO_TIMESTAMP ('2019-02-05 00:00:00.000','YYYY-MM-DD HH24:MI:SS.FF3') , 0.15, 1000000, 0)
SELECT * FROM dual;
--SET IDENTITY_INSERT YeuThich ON 
--TO_TIMESTAMP ('1975-01-01 00:00:00.000','YYYY-MM-DD HH24:MI:SS.FF3')
INSERT ALL
into YeuThich (MaYT, MaHH, MaKH, NgayChon, DiemDanhGia, MaBL) values (6, 7, 6, TO_TIMESTAMP ('2018-12-03 13:26:05.043','YYYY-MM-DD HH24:MI:SS.FF3') , 5, 13)
into YeuThich (MaYT, MaHH, MaKH, NgayChon, DiemDanhGia, MaBL) values (7, 7, 6, TO_TIMESTAMP ('2018-12-03 13:27:05.713','YYYY-MM-DD HH24:MI:SS.FF3') , 3, 14)
into YeuThich (MaYT, MaHH, MaKH, NgayChon, DiemDanhGia, MaBL) values (8, 7, 5, TO_TIMESTAMP ('2018-12-03 13:54:30.573','YYYY-MM-DD HH24:MI:SS.FF3') , 3, 15)
SELECT * FROM dual;
--SET IDENTITY_INSERT YeuThich OFF

ALTER TABLE BinhLuanSP   ADD  CONSTRAINT FK_BinhLuanSP_HangHoa FOREIGN KEY(MaHh)
REFERENCES HangHoa (MaHH);
--ALTER TABLE BinhLuanSP CHECK CONSTRAINT FK_BinhLuanSP_HangHoa;
ALTER TABLE BinhLuanSP   ADD  CONSTRAINT FK_BinhLuanSP_KhachHang FOREIGN KEY(MaKH)
REFERENCES KhachHang (MaKH);
--ALTER TABLE BinhLuanSP CHECK CONSTRAINT FK_BinhLuanSP_KhachHang;
ALTER TABLE ChiTietHD   ADD  CONSTRAINT FK__ChiTietHD__MaHD__25869641 FOREIGN KEY(MaHD)
REFERENCES HoaDon (MaHD);
--ALTER TABLE ChiTietHD CHECK CONSTRAINT FK__ChiTietHD__MaHD__25869641;
ALTER TABLE ChiTietHD   ADD  CONSTRAINT FK__ChiTietHD__MaHH__267ABA7A FOREIGN KEY(MaHH)
REFERENCES HangHoa (MaHH);
--ALTER TABLE ChiTietHD CHECK CONSTRAINT FK__ChiTietHD__MaHH__267ABA7A;
ALTER TABLE ChiTietPhieuNhap   ADD  CONSTRAINT FK_ChiTietPhieuNhap_HangHoa FOREIGN KEY(MaHH)
REFERENCES HangHoa (MaHH);
--ALTER TABLE ChiTietPhieuNhap CHECK CONSTRAINT FK_ChiTietPhieuNhap_HangHoa;
ALTER TABLE ChiTietPhieuNhap   ADD  CONSTRAINT FK_ChiTietPhieuNhap_PhieuNhapHang FOREIGN KEY(MaPN)
REFERENCES PhieuNhapHang (MaPN);
--ALTER TABLE ChiTietPhieuNhap CHECK CONSTRAINT FK_ChiTietPhieuNhap_PhieuNhapHang;
ALTER TABLE HangHoa   ADD  CONSTRAINT FK__HangHoa__MaNCC__15502E78 FOREIGN KEY(MaNCC)
REFERENCES NhaCungCap (MaNCC);
--ALTER TABLE HangHoa CHECK CONSTRAINT FK__HangHoa__MaNCC__15502E78;
ALTER TABLE HangHoa   ADD  CONSTRAINT FK_HangHoa_Loai FOREIGN KEY(MaLoai)
REFERENCES Loai (MaLoai);
--ALTER TABLE HangHoa MODIFY TenHH varchar2(100) NOT NULL;
--ALTER TABLE HangHoa CHECK CONSTRAINT FK_HangHoa_Loai;
ALTER TABLE HoaDon   ADD  CONSTRAINT FK__HoaDon__MaTrangT__1ED998B2 FOREIGN KEY(MaTrangThai)
REFERENCES TrangThai (MaTrangThai);
--ALTER TABLE HoaDon CHECK CONSTRAINT FK__HoaDon__MaTrangT__1ED998B2;
ALTER TABLE HoaDon   ADD  CONSTRAINT FK_HoaDon_KhachHang FOREIGN KEY(MaKH)
REFERENCES KhachHang (MaKH);
--ALTER TABLE HoaDon CHECK CONSTRAINT FK_HoaDon_KhachHang;
ALTER TABLE HoiDap   ADD  CONSTRAINT FK_HoiDap_KhachHang FOREIGN KEY(MaKH)
REFERENCES KhachHang (MaKH);
--ALTER TABLE KhachHang MODIFY HoTen varchar2(100) NOT NULL;
--ALTER TABLE HoiDap CHECK CONSTRAINT FK_HoiDap_KhachHang;
ALTER TABLE HoiDap   ADD  CONSTRAINT FK_HoiDap_NhanVien FOREIGN KEY(MaNV)
REFERENCES NhanVien (MaNV);
--ALTER TABLE HoiDap CHECK CONSTRAINT FK_HoiDap_NhanVien;
ALTER TABLE NhanVien   ADD  CONSTRAINT FK__NhanVien__MaPQ__1BFD2C07 FOREIGN KEY(MaPQ)
REFERENCES PhanQuyen (MaPQ);

--ALTER TABLE NhanVien MODIFY HoTen varchar2(100) NOT NULL;
--ALTER TABLE NhanVien CHECK CONSTRAINT FK__NhanVien__MaPQ__1BFD2C07;
ALTER TABLE SanPham_Kho   ADD  CONSTRAINT FK_SanPham_Kho_HangHoa FOREIGN KEY(MaHh)
REFERENCES HangHoa (MaHH);
--ALTER TABLE SanPham_Kho CHECK CONSTRAINT FK_SanPham_Kho_HangHoa;
ALTER TABLE TinTuc   ADD  CONSTRAINT FK_TinTuc_LoaiTinTuc FOREIGN KEY(LoaiTT)
REFERENCES LoaiTinTuc (LoaiTT);
--ALTER TABLE TinTuc CHECK CONSTRAINT FK_TinTuc_LoaiTinTuc;
--ALTER TABLE TinTuc MODIFY TieuDe varchar2(100) NOT NULL;
ALTER TABLE TinTuc   ADD  CONSTRAINT FK_TinTuc_NhanVien FOREIGN KEY(MaNV)
REFERENCES NhanVien (MaNV);
--ALTER TABLE TinTuc CHECK CONSTRAINT FK_TinTuc_NhanVien;
ALTER TABLE YeuThich   ADD  CONSTRAINT FK_YeuThich_HangHoa FOREIGN KEY(MaHH)
REFERENCES HangHoa (MaHH);
--ALTER TABLE YeuThich CHECK CONSTRAINT FK_YeuThich_HangHoa;
ALTER TABLE YeuThich   ADD  CONSTRAINT FK_YeuThich_KhachHang FOREIGN KEY(MaKH)
REFERENCES KhachHang (MaKH);
--ALTER TABLE YeuThich CHECK CONSTRAINT FK_YeuThich_KhachHang;
