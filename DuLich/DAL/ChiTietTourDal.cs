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
    class ChiTietTourDal
    {
        private DuLichContext context = DuLichContext.GetInstance();
        private static ChiTietTourDal instance;
       
        public static ChiTietTourDal GetInstance()
        {
            if (instance == null)
                instance = new ChiTietTourDal();
            return instance;
        }


        public List<ChiTietTour> GetAll()
        {
            return context.ChiTietTour.ToList();
        }
        public void AddOrUpdate(ChiTietTour newChiTietTour)
        {
            context.ChiTietTour.AddOrUpdate(newChiTietTour);
        }
        public void Delete(ChiTietTour chiTietTour)
        {
            context.ChiTietTour.Remove(chiTietTour);
        }
        public Task Save()
        {
            return context.SaveChangesAsync();
        }

        public void DeleteRange(List<ChiTietTour> lists)
        {
            context.ChiTietTour.RemoveRange(lists);
        }
    }
}
