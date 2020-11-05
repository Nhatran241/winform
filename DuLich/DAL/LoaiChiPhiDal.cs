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
    class LoaiChiPhiDal
    {
        static DuLichContext context = DuLichContext.GetInstance();

        public static List<LoaiChiPhi> GetAll()
        {
            return context.LoaiChiPhis.ToList();
        }
     
    }
}
