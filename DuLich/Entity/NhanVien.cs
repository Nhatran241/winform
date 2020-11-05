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
    public class NhanVien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaNhanVien { get; set; }
        public String TenNhanVien { get; set; }
        public String DiaChi { get; set; }
        public String SoDienThoai { get; set; }
        public String SoCmnd { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public virtual ICollection<PhanCong> PhanCongs { get; set; }
        public override string ToString()
        {
            return TenNhanVien;
        }

        public Task AddOrUpdate()
        {
            return NhanVienDal.AddOrUpdate(this);
        }
        public Task Delete()
        {
            return NhanVienDal.Delete(this);
        }

        public List<Doan> GetListDoanPhanCong()
        {
            List<Doan> listDoanPhanCong = new List<Doan>();
            if (PhanCongs == null)
                return listDoanPhanCong;
            foreach(PhanCong phanCong in PhanCongs)
            {
                listDoanPhanCong.Add(phanCong.Doan);
            }
            return listDoanPhanCong.Distinct().ToList();
        }

        public List<Doan> GetListDoanPhanCongByTime(DateTime from, DateTime to)
        {
            return GetListDoanPhanCong().Where(c => c.ThoiGianBatDau >= from && c.ThoiGianKetThuc <= to).ToList();
        }
    }
}
