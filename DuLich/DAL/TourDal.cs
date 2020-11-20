using DuLich.BUS;
using DuLich.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;

namespace DuLich.DAL
{
    class TourDal
    {
        static DuLichContext context = DuLichContext.GetInstance();


        public static List<Tour> GetAll()
        {
            return context.Touris.ToList();
        }
        public static Task AddOrUpdate(Tour tour)
        {
            var result = context.Touris.SingleOrDefault(b => b.Id == tour.Id);
            if (result != null)
            {
                result.ChiTietTours = tour.ChiTietTours;
                result.Doans = tour.Doans;
                result.Gias = tour.Gias;
                result.Loai = tour.Loai;
                result.Name = tour.Name;
                return context.SaveChangesAsync();
            }
            else
            {
                context.Touris.Add(tour);
                return context.SaveChangesAsync();
            }
        }
        public static Task Delete(Tour touris)
        {
            var result = context.Touris.SingleOrDefault(b => b.Id == touris.Id);
            if (result != null)
            {
                context.Touris.Remove(touris);
            }
            return context.SaveChangesAsync();
        }
        public static List<Doan> GetListDoanByTourId(int id)
        {
            return context.Doans.Where(c => c.Touris.Id == id).ToList();
        }

    

        public static List<DiaDiem> GetListDiaDiemByTour(Tour tour)
        {
            List<DiaDiem> danhSachDiaDiemCuaTor = new List<DiaDiem>();
            if (tour.ChiTietTours == null)
                return danhSachDiaDiemCuaTor;
            foreach (ChiTietTour chiTietTour in tour.ChiTietTours.OrderBy(c => c.ThuTu).ToList())
            {
                DiaDiem diaDiem = context.DiaDiem.Where(c => c.MaDienDiem == chiTietTour.diaDiem.MaDienDiem).First();
                if (!danhSachDiaDiemCuaTor.Contains(diaDiem))
                    danhSachDiaDiemCuaTor.Add(diaDiem);
            }
            return danhSachDiaDiemCuaTor;
        }

        public static void DeleteAllChiTietByTour(Tour tour)
        {
            if (tour.ChiTietTours != null)
            {
                context.ChiTietTour.RemoveRange(tour.ChiTietTours);
            }
        }

        public static Task UpdateListDiaDiemTour(List<ChiTietTour> danhSachChiTietTour)
        {
            foreach(ChiTietTour chiTietTour in danhSachChiTietTour)
            {
                context.ChiTietTour.AddOrUpdate(chiTietTour);
            }
            return context.SaveChangesAsync();
        }

        public static List<Tour> GetListTourHasPrice()
        {
            return GetAll().Where(c => c.Gias!=null && c.Gias.Count >0).ToList();
        }

       
    }
}
