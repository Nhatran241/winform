using DuLich.Entity;
using DuLich.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuLich.DAL
{
    class DoanDal
    {
        static DuLichContext context = DuLichContext.GetInstance();

        public static List<Doan> GetAll()
        {
            return context.Doans.ToList();
        }
        public static Task AddOrUpdate(Doan doan)
        {
            context.Doans.AddOrUpdate(doan);
            return context.SaveChangesAsync();
        }
        public static Task Delete(Doan doan)
        {
            context.Doans.Remove(doan);
            return context.SaveChangesAsync();
        }

        public static void DeleteAllKhach(Doan doan)
        {
            if (doan.DoanKhachs != null)
                context.DoanKhachs.RemoveRange(doan.DoanKhachs);
        }

        public static Task UpdateListDoanKhach(List<DoanKhach> danhSachDoanKhach)
        {
            foreach(DoanKhach doanKhach in danhSachDoanKhach)
            {
                context.DoanKhachs.AddOrUpdate(doanKhach);
            }
            return context.SaveChangesAsync();
        }

        public static Task DeleteChiPhi(ChiPhi chiPhi)
        {
            context.ChiPhis.Remove(chiPhi);
            return context.SaveChangesAsync();
        }

        public static Task AddOrUpdateChiPhi(ChiPhi chiPhi)
        {
            context.ChiPhis.AddOrUpdate(chiPhi);
            return context.SaveChangesAsync();
        }

        public static Task DeletePhanCong(PhanCong phanCong)
        {
            context.PhanCongs.Remove(phanCong);
            return context.SaveChangesAsync();
        }

        public static Task AddOrUpdatePhanCong(PhanCong phanCong)
        {
            context.PhanCongs.AddOrUpdate(phanCong);
            return context.SaveChangesAsync();
        }
    }
}
