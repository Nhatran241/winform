using DuLich.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuLich.DAL
{
    class TourDal
    {
        private DuLichContext context =  DuLichContext.GetInstance();
        private static TourDal instance;
       
        public static TourDal GetTourDal()
        {
            if (instance == null)
                instance = new TourDal();
            return instance;
        }


        public List<Tour> GetAll()
        {
            return context.Touris.ToList();
        }
        public void AddOrUpdate(Tour newTour)
        {
            context.Touris.AddOrUpdate(newTour);
        }
        public void Delete(Tour touris)
        {
            context.Touris.Remove(touris);
        }
        public Task Save()
        {
            return context.SaveChangesAsync();
        }
    }
}
