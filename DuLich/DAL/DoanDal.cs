using DuLich.Entity;
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
        private DuLichContext context = DuLichContext.GetInstance();
        private static DoanDal instance;
       
        public static DoanDal GetInstance()
        {
            if (instance == null)
                instance = new DoanDal();
            return instance;
        }


        public List<Doan> GetAll()
        {
            return context.Doans.ToList();
        }
        public void AddOrUpdate(Doan doan)
        {
            context.Doans.AddOrUpdate(doan);
        }
        public void Delete(Doan doan)
        {
            context.Doans.Remove(doan);
        }
        public Task Save()
        {
            return context.SaveChangesAsync();
        }
    }
}
