using DuLich.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuLich.DAL
{
    class KhachDal
    {
        private DuLichContext context = new DuLichContext();
        private static KhachDal instance;
       
        public static KhachDal GetInstance()
        {
            if (instance == null)
                instance = new KhachDal();
            return instance;
        }


        public List<Khach> GetAll()
        {
            return context.Khaches.ToList();
        }
        public void AddOrUpdate(Khach newKhach)
        {
            context.Khaches.AddOrUpdate(newKhach);
        }
        public void Delete(Khach khach)
        {
            context.Khaches.Remove(khach);
        }
        public Task Save()
        {
            return context.SaveChangesAsync();
        }
    }
}
