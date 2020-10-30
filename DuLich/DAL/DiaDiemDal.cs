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
    class DiaDiemDal
    {
        private DuLichContext context = DuLichContext.GetInstance();
        private static DiaDiemDal instance;
       
        public static DiaDiemDal GetInstance()
        {
            if (instance == null)
                instance = new DiaDiemDal();
            return instance;
        }

        public List<DiaDiem> GetAll()
        {
            return context.DiaDiem.ToList();
        }
        public void AddOrUpdate(DiaDiem diaDiem)
        {
            context.DiaDiem.AddOrUpdate(diaDiem);
        }
        public void Delete(DiaDiem diaDiem)
        {
            context.DiaDiem.Remove(diaDiem);
        }
     
        public Task Save()
        {
            return context.SaveChangesAsync();
        }
    }
}
