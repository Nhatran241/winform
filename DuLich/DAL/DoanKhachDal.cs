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
    class DoanKhachDal
    {
        private DuLichContext context = DuLichContext.GetInstance();
        private static DoanKhachDal instance;
       
        public static DoanKhachDal GetInstance()
        {
            if (instance == null)
                instance = new DoanKhachDal();
            return instance;
        }

        public List<DoanKhach> GetAll()
        {
            return context.DoanKhachs.ToList();
        }
        public void AddOrUpdate(DoanKhach doanKhach)
        {
            context.DoanKhachs.AddOrUpdate(doanKhach);
        }
        public void Delete(DoanKhach doanKhach)
        {
            context.DoanKhachs.Remove(doanKhach);
        }
     
        public Task Save()
        {
            return context.SaveChangesAsync();
        }

        public void RemoveRange(List<DoanKhach> lists)
        {
            context.DoanKhachs.RemoveRange(lists);
        }
    }
}
