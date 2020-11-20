using DuLich.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DuLich.BUS
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

        public void Map(ChiPhi chiphi)
        {
            LoaiChiPhi = chiphi.LoaiChiPhi;
            Doan =chiphi.Doan;
            ghiChu =chiphi.ghiChu;
            giaTri = chiphi.giaTri;
            id =chiphi.id;
        }

    }
}
