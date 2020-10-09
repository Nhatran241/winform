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
        public Doan()
        {
            this.Khaches = new HashSet<Khach>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DoanId { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }

        public Touris Touris { get; set; }
        public ICollection<Khach> Khaches { get; set; }
    }
}
