using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DuLich.BUS
{
    public class ChiTietTour
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaChiTietTour { get; set; }
        public virtual DiaDiem diaDiem { get; set; }
        public virtual Tour touris { get; set; }
        public int ThuTu { get; set; }
    }
}
