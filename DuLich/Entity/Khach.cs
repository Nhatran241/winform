using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuLich.Entity
{
    public class Khach
    {
        public Khach()
        {
            this.Doans = new HashSet<Doan>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KhachId { get; set; }
        public String Ten { get; set; }
        public String DiaChi { get; set; }
        public String SoDienThoai { get; set; }

        public String SoCmnd { get; set; }
        public ICollection<Doan> Doans { get; set; }
    }
}
