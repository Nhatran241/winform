using DuLich.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuLich.BUS
{
    public partial class NhanVien
    {
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
