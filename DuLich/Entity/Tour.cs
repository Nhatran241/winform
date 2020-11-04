using DuLich.DAL;
using DuLich.Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuLich.Entity
{
    public class Tour
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Name { get; set; }
        public virtual Loai Loai { get; set; }
        public virtual ICollection<Gia> Gias { get; set; }
        public virtual ICollection<Doan> Doans { get; set; }
        public virtual ICollection<ChiTietTour> ChiTietTours { get; set; }
        public override string ToString()
        {
            return Name;
        }

        public void AddOrUpdate()
        {
            TourDal.GetTourDal().AddOrUpdate(this);
        }
        public void Delete()
        {
            TourDal.GetTourDal().Delete(this);
        }
        public List<Doan> GetListDoanOfTour()
        {
            return TourDal.GetTourDal().GetListDoanByTour(this);
        }

        public List<Khach> GetListKhachOfTour()
        {
            return TourDal.GetTourDal().GetListKhachByTour(this);
        }
    }
}
