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
        public virtual ICollection<ChiTietTour> ChiTietTours { get; set; }
        public override string ToString()
        {
            return TenDiaDiem;
        }
        public Task AddOrUpdate()
        {
            return DiaDiemDal.AddOrUpdate(this);
        }
        public Task Delete()
        {
            return DiaDiemDal.Delete(this);
        }
        public DiaDiem GetDiaDiemByName(String name)
        {
            return DiaDiemDal.GetDiaDiemByName(name);
        }

        public List<Tour> GetListTour()
        {
            List<Tour> listTour = new List<Tour>();
            foreach (ChiTietTour chiTietTour in ChiTietTours)
            {
                listTour.Add(chiTietTour.touris);
            }
            return listTour;
        }
    }
}
