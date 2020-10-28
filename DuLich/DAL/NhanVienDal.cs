using DuLich.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuLich.DAL
{
    class NhanVienDal
    {
        private DuLichContext context = new DuLichContext();
        private static NhanVienDal instance;
       
        public static NhanVienDal GetInstance()
        {
            if (instance == null)
                instance = new NhanVienDal();
            return instance;
        }


        public List<NhanVien> GetAll()
        {
            return context.NhanViens.ToList();
        }
        public void AddOrUpdate(NhanVien newNhanVien)
        {
            context.NhanViens.AddOrUpdate(newNhanVien);
        }
        public void Delete(NhanVien nhanVien)
        {
            context.NhanViens.Remove(nhanVien);
        }
        public Task Save()
        {
            return context.SaveChangesAsync();
        }
    }
}
