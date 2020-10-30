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
        private DuLichContext context = DuLichContext.GetInstance();
        private static LoaiChiPhiDal instance;
       
        public static LoaiChiPhiDal GetInstance()
        {
            if (instance == null)
                instance = new LoaiChiPhiDal();
            return instance;
        }

        public List<LoaiChiPhi> GetAll()
        {
            return context.LoaiChiPhis.ToList();
        }
     
    }
}
