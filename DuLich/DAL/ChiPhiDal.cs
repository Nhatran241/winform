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
    class ChiPhiDal
    {
        private DuLichContext context = DuLichContext.GetInstance();
        private static ChiPhiDal instance;
       
        public static ChiPhiDal GetInstance()
        {
            if (instance == null)
                instance = new ChiPhiDal();
            return instance;
        }

        public List<ChiPhi> GetAll()
        {
            return context.ChiPhis.ToList();
        }
        public void AddOrUpdate(ChiPhi newChiPhi)
        {
            context.ChiPhis.AddOrUpdate(newChiPhi);
        }
        public void Delete(ChiPhi chiPhi)
        {
            context.ChiPhis.Remove(chiPhi);
        }
        public void DeleteAll(List<ChiPhi> danhSachChiPhi)
        {
            context.ChiPhis.RemoveRange(danhSachChiPhi);
        }
        public Task Save()
        {
            return context.SaveChangesAsync();
        }
    }
}
