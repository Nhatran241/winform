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
    class PhanCongDal
    {
        private DuLichContext context = DuLichContext.GetInstance();
        private static PhanCongDal instance;
       
        public static PhanCongDal GetInstance()
        {
            if (instance == null)
                instance = new PhanCongDal();
            return instance;
        }

        public List<PhanCong> GetAll()
        {
            return context.PhanCongs.ToList();
        }
        public void AddOrUpdate(PhanCong phanCong)
        {
            context.PhanCongs.AddOrUpdate(phanCong);
        }
        public void Delete(PhanCong phanCong)
        {
            context.PhanCongs.Remove(phanCong);
        }
     
        public Task Save()
        {
            return context.SaveChangesAsync();
        }
    }
}
