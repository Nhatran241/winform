using DuLich.DAL;
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
    public class Khach
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KhachId { get; set; }
        public String Ten { get; set; }
        public String DiaChi { get; set; }
        public String SoDienThoai { get; set; }
        public String SoCmnd { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public ICollection<DoanKhach> DoanKhachs { get; set; }
        public override string ToString()
        {
            return Ten;
        }

        public void AddOrUpdate()
        {
            KhachDal.GetInstance().AddOrUpdate(this);
        }
        public void Delete()
        {
            KhachDal.GetInstance().Delete(this);
        }
    }
}
