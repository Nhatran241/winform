using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DuLich.BUS
{
    public partial class Doan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Name { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
        public virtual Gia GiaApDung { get; set; }
        public virtual Tour Touris { get; set; }
        public virtual ICollection<DoanKhach> DoanKhachs { get; set; }
        public virtual ICollection<PhanCong> PhanCongs { get; set; }
        public virtual ICollection<ChiPhi> ChiPhis { get; set; }
    }
}
