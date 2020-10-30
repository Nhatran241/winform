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
    class LoaiDal
    {
        private DuLichContext context = DuLichContext.GetInstance();
        private static LoaiDal instance;
       
        public static LoaiDal GetInstance()
        {
            if (instance == null)
                instance = new LoaiDal();
            return instance;
        }


        public List<Loai> GetAll()
        {
            return context.Loai.ToList();
        }
    }
}
