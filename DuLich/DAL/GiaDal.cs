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
    class GiaDal
    {
        private DuLichContext context = DuLichContext.GetInstance();
        private static GiaDal instance;
       
        public static GiaDal GetInstance()
        {
            if (instance == null)
                instance = new GiaDal();
            return instance;
        }


        public List<Gia> GetAll()
        {
            return context.Gia.ToList();
        }
        public void AddOrUpdate(Gia gia)
        {
            context.Gia.AddOrUpdate(gia);
        }
        public void Delete(Gia gia)
        {
            context.Gia.Remove(gia);
        }
        public Task Save()
        {
            return context.SaveChangesAsync();
        }
    }
}
