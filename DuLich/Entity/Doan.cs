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
    public class Doan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Name { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
        public Touris Touris { get; set; }
        public ICollection<DoanKhach> DoanKhachs { get; set; }
        public ICollection<PhanCong> PhanCongs { get; set; }
        public ICollection<ChiPhi> ChiPhis { get; set; }
    }
}
