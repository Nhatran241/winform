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
    public class ChiTietTour
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaChiTietTour { get; set; }
        public DiaDiem diaDiem { get; set; }
        public Tour touris { get; set; }
        public int ThuTu { get; set; }

        public void AddOrUpdate()
        {
            ChiTietTourDal.GetInstance().AddOrUpdate(this);
        }
        public void Delete()
        {
            ChiTietTourDal.GetInstance().Delete(this);
        }
    }
}
