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
        static DuLichContext context = DuLichContext.GetInstance();


        public static List<Loai> GetAll()
        {
            return context.Loai.ToList();
        }
    }
}
