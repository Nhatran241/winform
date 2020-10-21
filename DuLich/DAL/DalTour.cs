using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using BUS;
using DuLich.Entity;

namespace DAL
{
    public class DalTour
    {
        internal static List<TourBus> GetAll()
        {
            List<TourBus> result = new List<TourBus>();

            DuLichContext db = DuLichContext.GetInstance();
            foreach (Touris dd in db.Touris)
            {
                TourBus tourBus = new TourBus(dd.Id, dd.Name,new LoaiTourBus(dd.Loai.Id,dd.Loai.TenLoai));
                result.Add(tourBus);
            }

            return result;
        }

        internal static void Update(TourBus tourBus)
        {
            DuLichContext db = DuLichContext.GetInstance();
            Touris tour = db.Touris.Where(d => d.Id == tourBus.MaTour).FirstOrDefault();
            tour.Id = tourBus.MaTour;
            tour.Name = tourBus.TenTour;
            tour.Loai = db.Loai.Where(d => d.Id == tourBus.LoaiTour.MaLoai).FirstOrDefault();

            try
            {
                db.SaveChanges();
            }
            catch (Exception /* dex */)
            {
            }

        }
    }
}
