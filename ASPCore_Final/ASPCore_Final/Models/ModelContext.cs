using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ASPCore_Final.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chitiethd> Chitiethd { get; set; }
        public virtual DbSet<Hanghoa> Hanghoa { get; set; }
        public virtual DbSet<Hoadon> Hoadon { get; set; }
        public virtual DbSet<Khachhang> Khachhang { get; set; }
        public virtual DbSet<Loai> Loai { get; set; }
        public virtual DbSet<Nhacungcap> Nhacungcap { get; set; }
        public virtual DbSet<Nhanvien> Nhanvien { get; set; }
        public virtual DbSet<Phanquyen> Phanquyen { get; set; }
        public virtual DbSet<Sanphamkho> Sanphamkho { get; set; }
        public virtual DbSet<Trangthai> Trangthai { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseOracle("User Id=nva;Password=123456;Data Source=localhost:1521/db12c;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "NVA");

            modelBuilder.Entity<Chitiethd>(entity =>
            {
                entity.HasKey(e => e.Mact);

                entity.ToTable("CHITIETHD");

                entity.HasIndex(e => e.Mact)
                    .HasName("PK_CTHD")
                    .IsUnique();

                entity.Property(e => e.Mact).HasColumnName("MACT");

                entity.Property(e => e.Dongia)
                    .HasColumnName("DONGIA")
                    .HasColumnType("NUMBER(10,1)");

                entity.Property(e => e.Giamgia)
                    .HasColumnName("GIAMGIA")
                    .HasColumnType("NUMBER(10,1)");

                entity.Property(e => e.Kichco)
                    .HasColumnName("KICHCO")
                    .HasColumnType("VARCHAR2(5)");

                entity.Property(e => e.Mahd).HasColumnName("MAHD");

                entity.Property(e => e.Mahh).HasColumnName("MAHH");

                entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

                entity.HasOne(d => d.MahdNavigation)
                    .WithMany(p => p.Chitiethd)
                    .HasForeignKey(d => d.Mahd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CTHD_HD");

                entity.HasOne(d => d.MahhNavigation)
                    .WithMany(p => p.Chitiethd)
                    .HasForeignKey(d => d.Mahh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CTHD_HH");
            });

            modelBuilder.Entity<Hanghoa>(entity =>
            {
                entity.HasKey(e => e.Mahh);

                entity.ToTable("HANGHOA");

                entity.HasIndex(e => e.Mahh)
                    .HasName("PK_HH")
                    .IsUnique();

                entity.Property(e => e.Mahh).HasColumnName("MAHH");

                entity.Property(e => e.Dongia)
                    .HasColumnName("DONGIA")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Giamgia)
                    .HasColumnName("GIAMGIA")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Hinh)
                    .HasColumnName("HINH")
                    .HasMaxLength(60);

                entity.Property(e => e.Maloai)
                    .IsRequired()
                    .HasColumnName("MALOAI")
                    .HasColumnType("VARCHAR2(10)");

                entity.Property(e => e.Mancc)
                    .IsRequired()
                    .HasColumnName("MANCC")
                    .HasColumnType("VARCHAR2(10)");

                entity.Property(e => e.Mota)
                    .HasColumnName("MOTA")
                    .HasMaxLength(1000);

                entity.Property(e => e.Tenhh)
                    .IsRequired()
                    .HasColumnName("TENHH")
                    .HasMaxLength(60);

                entity.HasOne(d => d.MaloaiNavigation)
                    .WithMany(p => p.Hanghoa)
                    .HasForeignKey(d => d.Maloai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HH_LOAI");

                entity.HasOne(d => d.ManccNavigation)
                    .WithMany(p => p.Hanghoa)
                    .HasForeignKey(d => d.Mancc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HH_NCC");
            });

            modelBuilder.Entity<Hoadon>(entity =>
            {
                entity.HasKey(e => e.Mahd);

                entity.ToTable("HOADON");

                entity.HasIndex(e => e.Mahd)
                    .HasName("PK_HD")
                    .IsUnique();

                entity.Property(e => e.Mahd).HasColumnName("MAHD");

                entity.Property(e => e.Diachi)
                    .IsRequired()
                    .HasColumnName("DIACHI")
                    .HasMaxLength(60);

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasMaxLength(50);

                entity.Property(e => e.Hoten)
                    .HasColumnName("HOTEN")
                    .HasMaxLength(50);

                entity.Property(e => e.Makh).HasColumnName("MAKH");

                entity.Property(e => e.Manv).HasColumnName("MANV");

                entity.Property(e => e.Matrangthai).HasColumnName("MATRANGTHAI");

                entity.Property(e => e.Ngaydat)
                    .HasColumnName("NGAYDAT")
                    .HasColumnType("DATE");

                entity.Property(e => e.Ngaygiao)
                    .HasColumnName("NGAYGIAO")
                    .HasColumnType("DATE");

                entity.Property(e => e.Phivanchuyen)
                    .HasColumnName("PHIVANCHUYEN")
                    .HasColumnType("NUMBER(9)");

                entity.Property(e => e.SdtNguoinhan)
                    .HasColumnName("SDT_NGUOINHAN")
                    .HasColumnType("VARCHAR2(20)");

                entity.Property(e => e.Tongthucthu)
                    .HasColumnName("TONGTHUCTHU")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Tongtienhang)
                    .HasColumnName("TONGTIENHANG")
                    .HasColumnType("FLOAT");

                entity.HasOne(d => d.MakhNavigation)
                    .WithMany(p => p.Hoadon)
                    .HasForeignKey(d => d.Makh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HD_KH");

                entity.HasOne(d => d.MatrangthaiNavigation)
                    .WithMany(p => p.Hoadon)
                    .HasForeignKey(d => d.Matrangthai)
                    .HasConstraintName("FK_HD_TT");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.Makh);

                entity.ToTable("KHACHHANG");

                entity.HasIndex(e => e.Makh)
                    .HasName("PK_KH")
                    .IsUnique();

                entity.Property(e => e.Makh).HasColumnName("MAKH");

                entity.Property(e => e.Diachi)
                    .HasColumnName("DIACHI")
                    .HasMaxLength(60);

                entity.Property(e => e.Dienthoai)
                    .HasColumnName("DIENTHOAI")
                    .HasColumnType("VARCHAR2(24)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasColumnType("VARCHAR2(50)");

                entity.Property(e => e.Gioitinh)
                    .HasColumnName("GIOITINH")
                    .HasMaxLength(50);

                entity.Property(e => e.Hinh)
                    .HasColumnName("HINH")
                    .HasColumnType("VARCHAR2(50)");

                entity.Property(e => e.Hoten)
                    .IsRequired()
                    .HasColumnName("HOTEN")
                    .HasMaxLength(50);

                entity.Property(e => e.Matkhau)
                    .IsRequired()
                    .HasColumnName("MATKHAU")
                    .HasColumnType("VARCHAR2(50)");

                entity.Property(e => e.Ngaysinh)
                    .HasColumnName("NGAYSINH")
                    .HasColumnType("DATE");

                entity.Property(e => e.Taikhoan)
                    .HasColumnName("TAIKHOAN")
                    .HasColumnType("VARCHAR2(30)");

                entity.Property(e => e.Trangthaihd).HasColumnName("TRANGTHAIHD");
            });

            modelBuilder.Entity<Loai>(entity =>
            {
                entity.HasKey(e => e.Maloai);

                entity.ToTable("LOAI");

                entity.HasIndex(e => e.Maloai)
                    .HasName("PK_LOAI")
                    .IsUnique();

                entity.Property(e => e.Maloai)
                    .HasColumnName("MALOAI")
                    .HasColumnType("VARCHAR2(10)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Gioitinh).HasColumnName("GIOITINH");

                entity.Property(e => e.Tenloai)
                    .IsRequired()
                    .HasColumnName("TENLOAI")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Nhacungcap>(entity =>
            {
                entity.HasKey(e => e.Mancc);

                entity.ToTable("NHACUNGCAP");

                entity.HasIndex(e => e.Mancc)
                    .HasName("PK_NCC")
                    .IsUnique();

                entity.Property(e => e.Mancc)
                    .HasColumnName("MANCC")
                    .HasColumnType("VARCHAR2(10)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Diachi)
                    .IsRequired()
                    .HasColumnName("DIACHI")
                    .HasMaxLength(60);

                entity.Property(e => e.Dienthoai)
                    .IsRequired()
                    .HasColumnName("DIENTHOAI")
                    .HasColumnType("VARCHAR2(24)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasColumnType("VARCHAR2(50)");

                entity.Property(e => e.Tencongty)
                    .IsRequired()
                    .HasColumnName("TENCONGTY")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.Manv);

                entity.ToTable("NHANVIEN");

                entity.HasIndex(e => e.Manv)
                    .HasName("PK_NV")
                    .IsUnique();

                entity.Property(e => e.Manv).HasColumnName("MANV");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasColumnType("VARCHAR2(50)");

                entity.Property(e => e.Hoten)
                    .IsRequired()
                    .HasColumnName("HOTEN")
                    .HasMaxLength(50);

                entity.Property(e => e.Mapq).HasColumnName("MAPQ");

                entity.Property(e => e.Matkhau)
                    .IsRequired()
                    .HasColumnName("MATKHAU")
                    .HasColumnType("VARCHAR2(50)");

                entity.Property(e => e.Trangthaihd).HasColumnName("TRANGTHAIHD");

                entity.HasOne(d => d.MapqNavigation)
                    .WithMany(p => p.Nhanvien)
                    .HasForeignKey(d => d.Mapq)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NV_PQ");
            });

            modelBuilder.Entity<Phanquyen>(entity =>
            {
                entity.HasKey(e => e.Mapq);

                entity.ToTable("PHANQUYEN");

                entity.HasIndex(e => e.Mapq)
                    .HasName("PK_PQ")
                    .IsUnique();

                entity.Property(e => e.Mapq).HasColumnName("MAPQ");

                entity.Property(e => e.Sua).HasColumnName("SUA");

                entity.Property(e => e.Them).HasColumnName("THEM");

                entity.Property(e => e.Xem).HasColumnName("XEM");

                entity.Property(e => e.Xoa).HasColumnName("XOA");
            });

            modelBuilder.Entity<Sanphamkho>(entity =>
            {
                entity.HasKey(e => e.MaspKho);

                entity.ToTable("SANPHAMKHO");

                entity.HasIndex(e => e.MaspKho)
                    .HasName("PK_MASP_KHO")
                    .IsUnique();

                entity.Property(e => e.MaspKho).HasColumnName("MASP_KHO");

                entity.Property(e => e.Kichco)
                    .HasColumnName("KICHCO")
                    .HasColumnType("VARCHAR2(10)");

                entity.Property(e => e.Mahh).HasColumnName("MAHH");

                entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

                entity.HasOne(d => d.MahhNavigation)
                    .WithMany(p => p.Sanphamkho)
                    .HasForeignKey(d => d.Mahh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SPK_HH");
            });

            modelBuilder.Entity<Trangthai>(entity =>
            {
                entity.HasKey(e => e.Matrangthai);

                entity.ToTable("TRANGTHAI");

                entity.HasIndex(e => e.Matrangthai)
                    .HasName("PK_TT")
                    .IsUnique();

                entity.Property(e => e.Matrangthai)
                    .HasColumnName("MATRANGTHAI")
                    .ValueGeneratedNever();

                entity.Property(e => e.Tentrangthai)
                    .IsRequired()
                    .HasColumnName("TENTRANGTHAI")
                    .HasMaxLength(30);
            });

            modelBuilder.HasSequence("ISEQ$$_78261");

            modelBuilder.HasSequence("ISEQ$$_78264");

            modelBuilder.HasSequence("ISEQ$$_78266");

            modelBuilder.HasSequence("ISEQ$$_78274");

            modelBuilder.HasSequence("ISEQ$$_78279");

            modelBuilder.HasSequence("ISEQ$$_78282");

            modelBuilder.HasSequence("ISEQ$$_78285");

            modelBuilder.HasSequence("ISEQ$$_78288");

            modelBuilder.HasSequence("ISEQ$$_78291");

            modelBuilder.HasSequence("ISEQ$$_78294");

            modelBuilder.HasSequence("ISEQ$$_78301");

            modelBuilder.HasSequence("ISEQ$$_78304");

            modelBuilder.HasSequence("ISEQ$$_78307");

            modelBuilder.HasSequence("ISEQ$$_78310");

            modelBuilder.HasSequence("ISEQ$$_78315");

            modelBuilder.HasSequence("ISEQ$$_78318");

            modelBuilder.HasSequence("ISEQ$$_78330");

            modelBuilder.HasSequence("ISEQ$$_78333");

            modelBuilder.HasSequence("ISEQ$$_78336");

            modelBuilder.HasSequence("ISEQ$$_78339");

            modelBuilder.HasSequence("ISEQ$$_78344");

            modelBuilder.HasSequence("ISEQ$$_78347");

            modelBuilder.HasSequence("ISEQ$$_78355");

            modelBuilder.HasSequence("ISEQ$$_78362");

            modelBuilder.HasSequence("ISEQ$$_78365");

            modelBuilder.HasSequence("ISEQ$$_78368");

            modelBuilder.HasSequence("ISEQ$$_78371");

            modelBuilder.HasSequence("ISEQ$$_78376");

            modelBuilder.HasSequence("ISEQ$$_78379");

            modelBuilder.HasSequence("ISEQ$$_78399");

            modelBuilder.HasSequence("ISEQ$$_78402");

            modelBuilder.HasSequence("ISEQ$$_78405");

            modelBuilder.HasSequence("ISEQ$$_78408");

            modelBuilder.HasSequence("ISEQ$$_78413");

            modelBuilder.HasSequence("ISEQ$$_78416");

            modelBuilder.HasSequence("ISEQ$$_78475");

            modelBuilder.HasSequence("ISEQ$$_78478");

            modelBuilder.HasSequence("ISEQ$$_78481");

            modelBuilder.HasSequence("ISEQ$$_78484");

            modelBuilder.HasSequence("ISEQ$$_78489");

            modelBuilder.HasSequence("ISEQ$$_78492");

            modelBuilder.HasSequence("ISEQ$$_79245");
        }
    }
}
