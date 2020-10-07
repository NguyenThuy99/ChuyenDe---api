using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DoAn5Demo.Models
{
    public partial class doan5Context : DbContext
    {
        //public doan5Context()
        //{
        //}

        public doan5Context(DbContextOptions<doan5Context> options)
            : base(options)
        {
        }

        public virtual DbSet<ChuDe> ChuDe { get; set; }
        public virtual DbSet<LoaiChuDe> LoaiChuDe { get; set; }
        public virtual DbSet<LoaiQuangCao> LoaiQuangCao { get; set; }
        public virtual DbSet<LoaiTin> LoaiTin { get; set; }
        public virtual DbSet<QuangCao> QuangCao { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoan { get; set; }
        public virtual DbSet<ThucDon> ThucDon { get; set; }
        public virtual DbSet<TinTuc> TinTuc { get; set; }
        public virtual DbSet<Tkb> Tkb { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-3QI0JMS\\SQLEXPRESS;Database=doan5;Integrated Security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChuDe>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Idcd).HasColumnName("idcd");

                entity.Property(e => e.Ngaydang)
                    .HasColumnName("ngaydang")
                    .HasColumnType("datetime");

                entity.Property(e => e.Noidung).HasColumnName("noidung");

                entity.Property(e => e.Tieude).HasColumnName("tieude");

                entity.HasOne(d => d.IdcdNavigation)
                    .WithMany(p => p.ChuDe)
                    .HasForeignKey(d => d.Idcd)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ChuDe_LoaiChuDe");
            });

            modelBuilder.Entity<LoaiChuDe>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Tenchude).HasColumnName("tenchude");
            });

            modelBuilder.Entity<LoaiQuangCao>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Tenquangcao).HasColumnName("tenquangcao");
            });

            modelBuilder.Entity<LoaiTin>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Tenloai).HasColumnName("tenloai");
            });

            modelBuilder.Entity<QuangCao>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Idqc).HasColumnName("idqc");

                entity.Property(e => e.Tieude).HasColumnName("tieude");

                entity.Property(e => e.Video)
                    .HasColumnName("video")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdqcNavigation)
                    .WithMany(p => p.QuangCao)
                    .HasForeignKey(d => d.Idqc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_QuangCao_LoaiQuangCao");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.Phanquyen)
                    .HasColumnName("phanquyen")
                    .HasMaxLength(50);

                entity.Property(e => e.Usename)
                    .HasColumnName("usename")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ThucDon>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Hinhanh)
                    .HasColumnName("hinhanh")
                    .HasMaxLength(50);

                entity.Property(e => e.Teude)
                    .HasColumnName("teude")
                    .HasMaxLength(50);

                entity.Property(e => e.Thoigian)
                    .HasColumnName("thoigian")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TinTuc>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Hinhanh)
                    .HasColumnName("hinhanh")
                    .HasMaxLength(50);

                entity.Property(e => e.Idloai).HasColumnName("idloai");

                entity.Property(e => e.Mota).HasColumnName("mota");

                entity.Property(e => e.Ngaydang)
                    .HasColumnName("ngaydang")
                    .HasColumnType("datetime");

                entity.Property(e => e.Noidung).HasColumnName("noidung");

                entity.Property(e => e.Tieude).HasColumnName("tieude");

                entity.HasOne(d => d.IdloaiNavigation)
                    .WithMany(p => p.TinTuc)
                    .HasForeignKey(d => d.Idloai)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TinTuc_LoaiTin");
            });

            modelBuilder.Entity<Tkb>(entity =>
            {
                entity.ToTable("TKB");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Hinhanh)
                    .HasColumnName("hinhanh")
                    .HasMaxLength(50);

                entity.Property(e => e.Ten)
                    .HasColumnName("ten")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
