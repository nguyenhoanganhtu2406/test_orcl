/*
DROP TABLE ChiTietHD;
DROP TABLE HoaDon;
DROP TABLE TrangThai;
DROP TABLE NhanVien;
DROP TABLE PhanQuyen;
DROP TABLE KhachHang;
DROP TABLE HangHoa;
DROP TABLE NhaCungCap;
DROP TABLE Loai;
*/

CREATE TABLE Loai(
  MaLoai VARCHAR2(10) NOT NULL,
  GioiTinh NUMBER(1) NOT NULL,
  TenLoai NVARCHAR2(30) NOT NULL,
  CONSTRAINT pk_loai PRIMARY KEY (MaLoai)
);


CREATE TABLE NhaCungCap(
  MaNCC VARCHAR2(10) NOT NULL,
  TenCongTy NVARCHAR2(50) NOT NULL,
  Email VARCHAR2(50) NOT NULL,
  DienThoai VARCHAR2(24) NOT NULL,
  DiaChi NVARCHAR2(60) NOT NULL,
  CONSTRAINT pk_ncc PRIMARY KEY (MaNCC)
);


CREATE TABLE HangHoa (
  MaHH NUMBER(10) GENERATED BY DEFAULT ON NULL AS IDENTITY,
  TenHH NVARCHAR2(60) NOT NULL,
  MaLoai VARCHAR2(10) NOT NULL,
  Hinh NVARCHAR2(60),
  DonGia FLOAT NOT NULL,
  GiamGia FLOAT NOT NULL,
  MoTa NVARCHAR2(1000),
  MaNCC VARCHAR2(10) NOT NULL,
  CONSTRAINT pk_hh PRIMARY KEY (MaHH),
  CONSTRAINT fk_hh_loai FOREIGN KEY (MaLoai) REFERENCES Loai(MaLoai),
  CONSTRAINT fk_hh_ncc FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC)
);


CREATE TABLE KhachHang (
  MaKH NUMBER(10) GENERATED BY DEFAULT ON NULL AS IDENTITY,
  MatKhau VARCHAR2(50) NOT NULL,
  HoTen NVARCHAR2(50) NOT NULL,
  DiaChi NVARCHAR2(60),
  DienThoai VARCHAR2(24),
  Email VARCHAR2(50) NOT NULL,
  Hinh VARCHAR2(50),
  TaiKhoan VARCHAR2(30),
  GioiTinh NVARCHAR2(50),
  NgaySinh DATE,
  TrangThaiHD NUMBER(1),
  CONSTRAINT pk_kh PRIMARY KEY (MaKH)
);

CREATE TABLE PhanQuyen(
  MaPQ NUMBER(10) GENERATED BY DEFAULT ON NULL AS IDENTITY,
  Them NUMBER(1) NOT NULL,
  Sua NUMBER(1) NOT NULL,
  Xoa NUMBER(1) NOT NULL,
  Xem NUMBER(1) NOT NULL,
  CONSTRAINT pk_pq PRIMARY KEY (MaPQ)
);


CREATE TABLE NhanVien (
  MaNV NUMBER(10) GENERATED BY DEFAULT ON NULL AS IDENTITY,
  HoTen NVARCHAR2(50) NOT NULL,
  Email VARCHAR2(50) NOT NULL,
  MatKhau VARCHAR2(50) NOT NULL,
  MaPQ NUMBER(10) NOT NULL,
  TrangThaiHD NUMBER(1),
  CONSTRAINT pk_nv PRIMARY KEY (MaNV),
  CONSTRAINT fk_nv_pq FOREIGN KEY (MaPQ) REFERENCES PhanQuyen(MaPQ)
);


CREATE TABLE TrangThai(
  MaTrangThai NUMBER(10) NOT NULL,
  TenTrangThai NVARCHAR2(30) NOT NULL,
  CONSTRAINT pk_tt PRIMARY KEY (MaTrangThai)
);


CREATE TABLE HoaDon (
  MaHD NUMBER(10) GENERATED BY DEFAULT ON NULL AS IDENTITY,
  MaKH NUMBER(10) NOT NULL,
  NgayDat DATE NOT NULL,
  NgayGiao DATE,
  HoTen NVARCHAR2(50),
  DiaChi NVARCHAR2(60) NOT NULL,
  SDT_nguoinhan VARCHAR2(20),
  GhiChu NVARCHAR2(50),
  PhiVanChuyen NUMBER(9) NOT NULL,
  MaTrangThai NUMBER(10),
  MaNV NUMBER(10),
  TongTienHang FLOAT,
  TongThucThu FLOAT,
  CONSTRAINT pk_hd PRIMARY KEY (MaHD),
  CONSTRAINT fk_hd_kh FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
  CONSTRAINT fk_hd_tt FOREIGN KEY (MaTrangThai) REFERENCES TrangThai(MaTrangThai)
);


CREATE TABLE ChiTietHD(
  MaCT NUMBER(10) GENERATED BY DEFAULT ON NULL AS IDENTITY,
  MaHD NUMBER(10) NOT NULL,
  MaHH NUMBER(10) NOT NULL,
  DonGia NUMBER(10,1) NOT NULL,
  GiamGia NUMBER(10,1) NULL,
  SoLuong NUMBER(10) NOT NULL,
  KichCo VARCHAR2(5),
  CONSTRAINT pk_cthd PRIMARY KEY (MaCT),
  CONSTRAINT fk_cthd_hd FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD),
  CONSTRAINT fk_cthd_hh FOREIGN KEY (MaHH) REFERENCES HangHoa(MaHH)
);

insert all
into PhanQuyen (MaPQ, Them, Sua, Xoa, Xem) values  (1, 1, 1, 1, 1)

into NhanVien (MaNV, HoTen, Email, MatKhau, MaPQ, TrangThaiHD) values (1, N'Admin', N'nv1@gmail.com', N'c4ca4238a0b923820dcc509a6f75849b', 1, 1)

into KhachHang (MaKH, MatKhau, HoTen, DiaChi, DienThoai, Email, Hinh, TaiKhoan, GioiTinh, NgaySinh, TrangThaiHD) values (4, N'c4ca4238a0b923820dcc509a6f75849b', N'Nguyễn Thanh Sang', N'Bình Dương', N'0971890712', N'sanglun2254@gmail.com', N'34441.png', N'sangnt2', N'Nam', NULL, 1)
into KhachHang (MaKH, MatKhau, HoTen, DiaChi, DienThoai, Email, Hinh, TaiKhoan, GioiTinh, NgaySinh, TrangThaiHD) values (5, N'c4ca4238a0b923820dcc509a6f75849b', N'Minh Cao', N'TPHCM', N'0971890712', N'minhcd@gmail.com', N'backg.jpg', N'minhcd', N'Nam', NULL, 1)
into KhachHang (MaKH, MatKhau, HoTen, DiaChi, DienThoai, Email, Hinh, TaiKhoan, GioiTinh, NgaySinh, TrangThaiHD) values (6, N'c4ca4238a0b923820dcc509a6f75849b', N'Nguyễn Thanh Sang', N'Bình Dương', N'0971890712', N'sanglun2254_1@gmail.com', N'long.jpg', N'sangnt', N'Nam', NULL, 1)
into KhachHang (MaKH, MatKhau, HoTen, DiaChi, DienThoai, Email, Hinh, TaiKhoan, GioiTinh, NgaySinh, TrangThaiHD) values (10, N'c4ca4238a0b923820dcc509a6f75849b', N'anonymouse', N'Không có', N'', N'pinkwater98@gmail.com', N'anonymouse.jpg', N'shanm', N'Nam', NULL, 1)
into KhachHang (MaKH, MatKhau, HoTen, DiaChi, DienThoai, Email, Hinh, TaiKhoan, GioiTinh, NgaySinh, TrangThaiHD) values (11, N'c4ca4238a0b923820dcc509a6f75849b', N'Đỗ Phúc Hậu', N'280 ADV', N'0904877306', N'wanriky2998@gmail.com', NULL, N'haudp', N'Nam', NULL, 1)

into NhaCungCap (MaNCC, TenCongTy, Email, DienThoai, DiaChi) values (N'ESHOP', N'ESHOP', N'eshop@gmail.com', N'1654651326', N'TPHCM')
into NhaCungCap (MaNCC, TenCongTy, Email, DienThoai, DiaChi) values (N'KENTA', N'KENTA', N'kenta@gmail.com', N'653256565', N'TPHCM')
into NhaCungCap (MaNCC, TenCongTy, Email, DienThoai, DiaChi) values (N'SENDO', N'SENDO', N'sendo@gmail.com', N'2356562323', N'TPHCM')
into NhaCungCap (MaNCC, TenCongTy, Email, DienThoai, DiaChi) values (N'YAME', N'YAME', N'yame@gmail.com', N'32565365323', N'BÌNH DƯƠNG')

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

into HangHoa (MaHH, TenHH, MaLoai, Hinh, DonGia, GiamGia, MoTa, MaNCC) values (7, N'ÁO SƠ MI NAM DÀI TAY TRẮNG SMT16', N'ESAO001', N'so_mi_nam_16.jpg', 350000, 0.15, N'Sơ mi tay dài trắng phong cách tinh sảo', N'ESHOP')
into HangHoa (MaHH, TenHH, MaLoai, Hinh, DonGia, GiamGia, MoTa, MaNCC) values (11, N'ÁO SƠ MI NAM DÀI TAY TRẮNG SMT12', N'ESAO001', N'so_mi_nam_012.jpg', 280000, 0.12, N'Sơ mi body hoa văn họa tiết tinh sảo', N'ESHOP')
into HangHoa (MaHH, TenHH, MaLoai, Hinh, DonGia, GiamGia, MoTa, MaNCC) values (17, N'ÁO SƠ MI NAM DÀI TAY TRẮNG SMT12', N'ESAO001', N'so_mi_nam_01.jpg', 280000, 0, N'Sơ mi tay dài nam trắng phong cách', N'ESHOP')
into HangHoa (MaHH, TenHH, MaLoai, Hinh, DonGia, GiamGia, MoTa, MaNCC) values (18, N'ÁO SƠ MI NAM DÀI TAY TRẮNG SMT0001', N'ESAO001', N'so_mi_nam_0001.jpg', 300000, 0.2, N'Áo sơ mi cổ cao trắng sang trọng quý phái', N'ESHOP')
into HangHoa (MaHH, TenHH, MaLoai, Hinh, DonGia, GiamGia, MoTa, MaNCC) values (19, N'ÁO SƠ MI NAM DÀI TAY SỌC ĐEN TRẮNG SMT0004', N'ESAO001', N'ao_so_mi_0004.jpg', 320000, 0.2, N'Áo sơ mi sọc đen trắng sang trọng quý phái', N'ESHOP')
into HangHoa (MaHH, TenHH, MaLoai, Hinh, DonGia, GiamGia, MoTa, MaNCC) values (20, N'ÁO SƠ MI NAM DÀI TAY ĐỎ SỌC SMT0006', N'ESAO001', N'ao_so_mi_0006.jpg', 300000, 0.2, N'Áo sơ mi cổ cao đỏ sọc sang trọng quý phái', N'ESHOP')
into HangHoa (MaHH, TenHH, MaLoai, Hinh, DonGia, GiamGia, MoTa, MaNCC) values (21, N'ÁO SƠ MI NAM DÀI TAY XÁM SỌC ĐEN SMT0018', N'ESAO001', N'ao_so_mi_0018.jpg', 300000, 0.2, N'Áo sơ mi cổ cao xám đen sọc sang trọng quý phái', N'ESHOP')
into HangHoa (MaHH, TenHH, MaLoai, Hinh, DonGia, GiamGia, MoTa, MaNCC) values (22, N'ÁO SƠ MI NAM DÀI TAY XANH SỌC ĐEN SMT0026', N'ESAO001', N'ao_so_mi_0026.jpg', 300000, 0.2, N'Áo sơ mi cổ cao xanh sọc sang trọng quý phái', N'ESHOP')
into HangHoa (MaHH, TenHH, MaLoai, Hinh, DonGia, GiamGia, MoTa, MaNCC) values (23, N'ÁO SƠ MI NAM NGẮN TAY SMT0001', N'ESAO007', N'ao_so_mi_0001.jpg', 300000, 0.2, N'Áo sơ mi cổ cao đỏ sọc sang trọng quý phái', N'ESHOP')
into HangHoa (MaHH, TenHH, MaLoai, Hinh, DonGia, GiamGia, MoTa, MaNCC) values (24, N'ÁO SƠ MI NAM NGẮN TAY HỌA TIẾT SMT0065', N'ESAO007', N'ao_so_mi_tay_ngan_0065.jpg', 300000, 0.2, N'Áo sơ mi ngắn xanh sang trọng quý phái', N'ESHOP')
into HangHoa (MaHH, TenHH, MaLoai, Hinh, DonGia, GiamGia, MoTa, MaNCC) values (25, N'ÁO SƠ MI NAM NGẮN TAY SMT0069', N'ESAO007', N'ao_so_mi_tay_ngan_0069.jpg', 300000, 0.2, N'Áo sơ mi ngắn xanh sang trọng quý phái', N'ESHOP')
into HangHoa (MaHH, TenHH, MaLoai, Hinh, DonGia, GiamGia, MoTa, MaNCC) values (26, N'ÁO THUN NAM NGẮN TAY SMT0005', N'ESAO011', N'ao_thun_nam_5.jpg', 110000, 0.2, N'Áo thun ngắn sang trọng quý phái', N'ESHOP')
into HangHoa (MaHH, TenHH, MaLoai, Hinh, DonGia, GiamGia, MoTa, MaNCC) values (27, N'ÁO THUN NAM NGẮN TAY SMT0001', N'ESAO011', N'ao_thun_nam_01.jpg', 110000, 0.2, N'Áo thun ngắn sang trọng quý phái', N'ESHOP')
into HangHoa (MaHH, TenHH, MaLoai, Hinh, DonGia, GiamGia, MoTa, MaNCC) values (28, N'ÁO THUN NAM NGẮN TAY SMT0010', N'ESAO011', N'ao_thun_nam_1.jpg', 110000, 0.2, N'Áo thun ngắn sang trọng quý phái', N'ESHOP')
into HangHoa (MaHH, TenHH, MaLoai, Hinh, DonGia, GiamGia, MoTa, MaNCC) values (29, N'ÁO THUN NAM NGẮN TAY SMT0041', N'ESAO011', N'ao_thun_nam_41.jpg', 110000, 0.2, N'Áo thun ngắn sang trọng quý phái', N'ESHOP')
into HangHoa (MaHH, TenHH, MaLoai, Hinh, DonGia, GiamGia, MoTa, MaNCC) values (30, N'ÁO THUN NAM NGẮN TAY SMT0073', N'ESAO011', N'ao_thun_nam_73.jpg', 110000, 0.2, N'Áo thun ngắn sang trọng quý phái', N'ESHOP')

into TrangThai (MaTrangThai, TenTrangThai) values (0, N'Chờ xử lý')
into TrangThai (MaTrangThai, TenTrangThai) values (1, N'Đã xử lý')

into HoaDon (MaHD, MaKH, NgayDat, NgayGiao, HoTen, DiaChi, SDT_nguoinhan, GhiChu, PhiVanChuyen, MaTrangThai, MaNV, TongTienHang, TongThucThu) values (3, 5, TO_TIMESTAMP ('2018-11-30 17:53:28.673','YYYY-MM-DD HH24:MI:SS.FF3') , NULL, N'Nguyễn Thanh Sang', N'Chánh Mỹ, Bình Dương', N'0971890712', N'Giao hàng đến văn phòng khu phố', 35000, 1, NULL, NULL, NULL)
into HoaDon (MaHD, MaKH, NgayDat, NgayGiao, HoTen, DiaChi, SDT_nguoinhan, GhiChu, PhiVanChuyen, MaTrangThai, MaNV, TongTienHang, TongThucThu) values (4, 4, TO_TIMESTAMP ('2018-11-30 19:20:53.203','YYYY-MM-DD HH24:MI:SS.FF3') , NULL, N'Nguyễn Thành Long', N'Chánh Mỹ, Bình Dương', N'0971890712', N'Giao hàng đến văn phòng khu phố', 35000, 1, NULL, NULL, NULL)
into HoaDon (MaHD, MaKH, NgayDat, NgayGiao, HoTen, DiaChi, SDT_nguoinhan, GhiChu, PhiVanChuyen, MaTrangThai, MaNV, TongTienHang, TongThucThu) values (5, 4, TO_TIMESTAMP ('2018-12-01 21:08:24.610','YYYY-MM-DD HH24:MI:SS.FF3') , NULL, N'Nguyễn Thanh Sang', N'Chánh Mỹ, Bình Dương', N'0971890712', N'Giao hàng đến văn phòng khu phố', 35000, 1, NULL, NULL, NULL)
into HoaDon (MaHD, MaKH, NgayDat, NgayGiao, HoTen, DiaChi, SDT_nguoinhan, GhiChu, PhiVanChuyen, MaTrangThai, MaNV, TongTienHang, TongThucThu) values (6, 4, TO_TIMESTAMP ('2018-12-01 21:37:24.947','YYYY-MM-DD HH24:MI:SS.FF3') , NULL, N'Nguyễn Thành Long', N'Chánh Mỹ, Bình Dương', N'0971890712', N'Giao hàng đến văn phòng khu phố', 35000, 1, NULL, NULL, NULL)
into HoaDon (MaHD, MaKH, NgayDat, NgayGiao, HoTen, DiaChi, SDT_nguoinhan, GhiChu, PhiVanChuyen, MaTrangThai, MaNV, TongTienHang, TongThucThu) values (7, 6, TO_TIMESTAMP ('2018-12-01 21:40:56.943','YYYY-MM-DD HH24:MI:SS.FF3') , NULL, N'Nguyễn Thành Long', N'Chánh Mỹ, Bình Dương', N'0971890712', N'Giao hàng đến văn phòng khu phố', 35000, 1, NULL, NULL, NULL)
into HoaDon (MaHD, MaKH, NgayDat, NgayGiao, HoTen, DiaChi, SDT_nguoinhan, GhiChu, PhiVanChuyen, MaTrangThai, MaNV, TongTienHang, TongThucThu) values (8, 4, TO_TIMESTAMP ('2018-12-01 21:45:14.087','YYYY-MM-DD HH24:MI:SS.FF3') , NULL, N'Nguyễn Thanh Sang', N'Chánh Mỹ, Bình Dương', N'0971890712', N'Giao hàng đến văn phòng khu phố', 35000, 1, NULL, NULL, NULL)
into HoaDon (MaHD, MaKH, NgayDat, NgayGiao, HoTen, DiaChi, SDT_nguoinhan, GhiChu, PhiVanChuyen, MaTrangThai, MaNV, TongTienHang, TongThucThu) values (10, 4, TO_TIMESTAMP ('2018-12-01 22:07:14.300','YYYY-MM-DD HH24:MI:SS.FF3') , NULL, N'Nguyễn Thanh Sang', N'Chánh Mỹ, Bình Dương', N'0971890712', N'Giao hàng đến văn phòng khu phố', 35000, 0, NULL, NULL, NULL)
into HoaDon (MaHD, MaKH, NgayDat, NgayGiao, HoTen, DiaChi, SDT_nguoinhan, GhiChu, PhiVanChuyen, MaTrangThai, MaNV, TongTienHang, TongThucThu) values (11, 4, TO_TIMESTAMP ('2018-12-01 22:10:41.587','YYYY-MM-DD HH24:MI:SS.FF3') , NULL, N'Nguyễn Thành Long', N'Chánh Mỹ, Bình Dương', N'0971890712', N'Giao hàng đến văn phòng khu phố', 35000, 0, NULL, NULL, NULL)
into HoaDon (MaHD, MaKH, NgayDat, NgayGiao, HoTen, DiaChi, SDT_nguoinhan, GhiChu, PhiVanChuyen, MaTrangThai, MaNV, TongTienHang, TongThucThu) values (19, 4, TO_TIMESTAMP ('2018-12-04 11:34:00.213','YYYY-MM-DD HH24:MI:SS.FF3') , NULL, N'Nguyễn Thành Long', N'Chánh Mỹ, Bình Dương', N'0971890712', N'Giao hàng đến văn phòng khu phố', 35000, 0, NULL, NULL, NULL)
into HoaDon (MaHD, MaKH, NgayDat, NgayGiao, HoTen, DiaChi, SDT_nguoinhan, GhiChu, PhiVanChuyen, MaTrangThai, MaNV, TongTienHang, TongThucThu) values (20, 4, TO_TIMESTAMP ('2018-12-20 13:50:15.093','YYYY-MM-DD HH24:MI:SS.FF3') , NULL, N'Nguyễn Thanh Sang', N'Chánh Mỹ, Bình Dương', N'0971890712', N'Giao hàng đến văn phòng khu phố', 35000, 0, NULL, 1248000, 1158200)
into HoaDon (MaHD, MaKH, NgayDat, NgayGiao, HoTen, DiaChi, SDT_nguoinhan, GhiChu, PhiVanChuyen, MaTrangThai, MaNV, TongTienHang, TongThucThu) values (22, 11, TO_TIMESTAMP ('2018-12-20 21:57:30.273','YYYY-MM-DD HH24:MI:SS.FF3') , NULL, N'Đỗ Phúc Hậu', N'280 ADV', N'0904877306', NULL, 35000, 0, NULL, 297500, 332500)

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