using DuLich.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuLich.Entity
{
    public class DuLichContext : DbContext
    {
        private static DuLichContext instance;
        public static DuLichContext GetInstance()
        {
            if (instance == null)
                instance = new DuLichContext();
            return instance;
        }
        public DuLichContext() : base("dulichdb")
        {
            try
            {
                if (DiaDiem.ToList().Count == 0)
                {
                    new List<DiaDiem>
            {
                new DiaDiem { TenDiaDiem ="Hà Nội"},
                new DiaDiem { TenDiaDiem ="Lạng Sơn" },
                new DiaDiem { TenDiaDiem ="Cao Bằng" },
                new DiaDiem { TenDiaDiem ="Nha Trang" },
                new DiaDiem { TenDiaDiem ="Mũi Né" },
                new DiaDiem { TenDiaDiem ="Phú Quốc" },
                new DiaDiem { TenDiaDiem ="Nghệ An" },
                new DiaDiem { TenDiaDiem ="Hội An" },
                new DiaDiem { TenDiaDiem ="Huế" },
                new DiaDiem {TenDiaDiem="Tp Hồ Chí Minh" },
                new DiaDiem {TenDiaDiem="Vũng Tàu" }
            }.ForEach(x => DiaDiem.Add(x));
                    SaveChanges();
                }
                if (Loai.ToList().Count == 0)
                {
                    new List<Loai>
            {
                new Loai { TenLoai= "Tour cao cấp"},
                new Loai { TenLoai= "Tour bình dân"},
                new Loai { TenLoai= "Tour truyền thống"}
            }.ForEach(x => Loai.Add(x));
                    SaveChanges();
                }
                if (NhanViens.ToList().Count == 0)
                {
                    new List<NhanVien>{
                        new NhanVien { TenNhanVien= "Nhật",DiaChi="35/2b khu phố 5 nhà bè",SoCmnd="025711770",SoDienThoai="0909228923"},
                        new NhanVien { TenNhanVien= "Nam",DiaChi="35/2b khu phố 5 nhà bè",SoCmnd="025711770",SoDienThoai="0909228923"},
                        new NhanVien { TenNhanVien= "Phat",DiaChi="35/2b khu phố 5 nhà bè",SoCmnd="025711770",SoDienThoai="0909228923"},
                        new NhanVien { TenNhanVien= "Kha",DiaChi="35/2b khu phố 5 nhà bè",SoCmnd="025711770",SoDienThoai="0909228923"}
                    }.ForEach(x => NhanViens.Add(x));
                    SaveChanges();
                }
                if (LoaiChiPhis.ToList().Count == 0)
                {
                    new List<LoaiChiPhi>
            {
                new LoaiChiPhi { name= "Ăn Uống"},
                new LoaiChiPhi { name= "Khách Sạn "},
                new LoaiChiPhi { name= "Phương Tiện"}
            }.ForEach(x => LoaiChiPhis.Add(x));
                    SaveChanges();
                }
               
        }
            catch(Exception e) { }
        }
        public DbSet<Touris> Touris { get; set; }
        public DbSet<Gia> Gia { get; set; }
        public DbSet<Loai> Loai { get; set; }
        public DbSet<DiaDiem> DiaDiem { get; set; }
        public DbSet<ChiTietTour> ChiTietTour { get; set; }
        public DbSet<Doan> Doans { get; set; }
        public DbSet<DoanKhach> DoanKhachs { get; set; }
        public DbSet<Khach> Khaches { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<PhanCong> PhanCongs { get; set; }
        public DbSet<ChiPhi> ChiPhis { get; set; }
        public DbSet<LoaiChiPhi> LoaiChiPhis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // XÓa tour xóa giá luôn
            modelBuilder.Entity<Touris>()
                        .HasMany<Gia>(g => g.Gias)
                        .WithRequired(s => s.touris)
                        .WillCascadeOnDelete();
            modelBuilder.Entity<Touris>()
                      .HasMany<Doan>(g => g.Doans)
                      .WithRequired(s => s.Touris)
                      .WillCascadeOnDelete();
            // Xóa luôn chi tiết
            modelBuilder.Entity<Touris>()
                        .HasMany<ChiTietTour>(g => g.ChiTietTours)
                        .WithRequired(s => s.touris)
                        .WillCascadeOnDelete();

            // Xóa đoàn xóa luôn những phân công liên quan
            modelBuilder.Entity<Doan>()
                       .HasMany<PhanCong>(g => g.PhanCongs)
                       .WithRequired(s => s.Doan)
                       .WillCascadeOnDelete();

            // Xóa đoàn xóa luôn những chi phí liên quan
            modelBuilder.Entity<Doan>()
                       .HasMany<ChiPhi>(g => g.ChiPhis)
                       .WithRequired(s => s.Doan)
                       .WillCascadeOnDelete();

            // xóa đoàn thì xóa những đoàn khách liên quan nhưng ko xóa đoàn
            modelBuilder.Entity<Doan>()
                       .HasMany<DoanKhach>(g => g.DoanKhachs)
                       .WithRequired(s => s.Doan)
                       .WillCascadeOnDelete();
            
            modelBuilder.Entity<Khach>()
                      .HasMany<DoanKhach>(g => g.DoanKhachs)
                      .WithRequired(s => s.Khach)
                      .WillCascadeOnDelete();



            // configures one-to-many relationship {Touris} - [Gia]
            //modelBuilder.Entity<Gia>()
            //  .HasRequired<Touris>(s => s.touris)
            // .WithMany(g => g.Gias)
            //  .HasForeignKey<int>(s => s.TourisId);

            // configures one-to-many relationship {Touris} - [ChiTietTour]
            //modelBuilder.Entity<ChiTietTour>()
            //   .HasRequired<Touris>(s => s.touris)
            //    .WithMany(g => g.ChiTietTours)
            //  .HasForeignKey<int>(s => s.TourisId);
        }
    }
}
