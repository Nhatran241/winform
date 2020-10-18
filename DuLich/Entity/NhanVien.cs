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
    public class NhanVien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaNhanVien { get; set; }
        public String TenNhanVien { get; set; }
        public String DiaChi { get; set; }
        public String SoDienThoai { get; set; }
        public String SoCmnd { get; set; }
        public ICollection<PhanCong> PhanCongs { get; set; }
        public override string ToString()
        {
            return TenNhanVien;
        }
    }
}
