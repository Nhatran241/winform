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
    public class Gia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaGia { get; set; }
        public long GiaTri { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
        public Tour touris { get; set; }
        public override string ToString()
        {
            return GiaTri.ToString();
        }
        public void AddOrUpdate()
        {
            GiaDal.GetInstance().AddOrUpdate(this);
        }
        public void Delete()
        {
            GiaDal.GetInstance().Delete(this);
        }
    }
}
