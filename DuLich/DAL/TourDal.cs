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

        public List<Doan> GetListDoanByTour(Tour tour)
        {
            if(tour.Doans != null)
                return tour.Doans.ToList();
            return new List<Doan>();
        }
        public List<Doan> GetListDoanByTourId(int id)
        {
            return context.Doans.Where(c => c.Touris.Id == id).ToList();
        }

        public List<Khach> GetListKhachByTour(Tour tour)
        {
            List<Khach> khachTrongTour = new List<Khach>();
            if (tour.Doans != null)
            {
                foreach (Doan doan1 in tour.Doans.ToList())
                {
                    if (doan1.DoanKhachs != null)
                        khachTrongTour.AddRange(context.Khaches.ToList().Where(c => doan1.DoanKhachs.Select(d => d.Khach.KhachId).ToList().Contains(c.KhachId)).ToList());
                }
            }
            return khachTrongTour.Distinct().ToList();
        }

        public List<Tour> GetListTourHasPrice()
        {
            return GetAll().Where(c => c.Gias!=null && c.Gias.Count >0).ToList();
        }
    }
}
