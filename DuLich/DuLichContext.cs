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
        public DuLichContext() : base("dulichdb")
        {
            if(DiaDiem.ToList().Count == 0)
            {
                new List<DiaDiem>
            {
                new DiaDiem { TenDiaDiem ="Hà Nội" },
                new DiaDiem {TenDiaDiem="Tp Hồ Chí Minh" }
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

        }
        public DbSet<Touris> Touris { get; set; }
        public DbSet<Gia> Gia { get; set; }
        public DbSet<Loai> Loai { get; set; }
        public DbSet<DiaDiem> DiaDiem { get; set; }
        public DbSet<ChiTietTour> ChiTietTour { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<Gia>()
                .HasRequired<Touris>(s => s.touris)
                .WithMany(g => g.Gias)
                .HasForeignKey<int>(s => s.TourisId);
        }
    }
}
