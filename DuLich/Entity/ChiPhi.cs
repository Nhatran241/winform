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
    public class ChiPhi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public virtual Doan Doan { get; set; }
        public virtual LoaiChiPhi LoaiChiPhi { get; set; }
        public long giaTri { get; set; }
        public string ghiChu { get; set; }
    }
}
