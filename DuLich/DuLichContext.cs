using DuLich.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuLich.Entity
{
    public class DuLichContext:DbContext
    {
        public DuLichContext():base("dulichdb")
        {

        }
        public DbSet<Touris> Touris { get; set; }
        public DbSet<Gia> Gia { get; set; }
        public DbSet<Loai> Loai { get; set; }
        public DbSet<DiaDiem> DiaDiem { get; set; }
        public DbSet<ChiTietTour> ChiTietTour { get; set; }

    }
}
