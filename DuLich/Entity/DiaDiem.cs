using DuLich.DAL;
using DuLich.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuLich.Model.Entity
{
    public class DiaDiem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaDienDiem { get; set; }
        public String TenDiaDiem { get; set; }
        public ICollection<ChiTietTour> Touris { get; set; }
        public override string ToString()
        {
            return TenDiaDiem;
        }
        public void AddOrUpdate()
        {
            DiaDiemDal.GetInstance().AddOrUpdate(this);
        }
        public void Delete()
        {
            DiaDiemDal.GetInstance().Delete(this);
        }
    }
}
