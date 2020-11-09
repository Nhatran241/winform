using DuLich.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuLich.BUS
{
    public partial class Tour
    {
        public Task AddOrUpdate()
        {
            return TourDal.AddOrUpdate(this);
        }
        public Task Delete()
        {
            return TourDal.Delete(this);
        }
        public List<Doan> GetListDoanOfTour()
        {
            if (Doans == null)
                return new List<Doan>();
            return Doans.ToList();
        }

        public List<Khach> GetListKhachOfTour()
        {
            List<Khach> khachTrongTour = new List<Khach>();
            if (Doans != null)
            {
                foreach (Doan doan in Doans)
                {
                    if (doan.DoanKhachs != null)
                    {
                        foreach(DoanKhach doanKhach in doan.DoanKhachs)
                        {
                            khachTrongTour.Add(doanKhach.Khach);
                        }
                    }
                }
            }
            return khachTrongTour.Distinct().ToList();
        }
        public List<Khach> GetListKhachOfTourByTime(DateTime from,DateTime to)
        {
            List<Khach> khachTrongTour = new List<Khach>();
            if (Doans != null)
            {
                foreach (Doan doan in Doans.Where(c=>c.ThoiGianBatDau>=from && c.ThoiGianKetThuc<=to))
                {
                    if (doan.DoanKhachs != null)
                    {
                        foreach (DoanKhach doanKhach in doan.DoanKhachs)
                        {
                            khachTrongTour.Add(doanKhach.Khach);
                        }
                    }
                }
            }
            return khachTrongTour.Distinct().ToList();
        }

        public List<DiaDiem> GetListDiaDiemOfTour()
        {
            return TourDal.GetListDiaDiemByTour(this);
        }

        public List<Gia> GetListGiaOfTour()
        {
            if (Gias == null)
                return new List<Gia>();
            return Gias.ToList();
        }

        public void DeleteAllChiTietTour()
        {
            TourDal.DeleteAllChiTietByTour(this);
        }

        public double TongDoanhThuTourByTime(DateTime from, DateTime to)
        {
            return GetListDoanOfTourByTime(from,to).Where(c=>c.GiaApDung != null).Sum(c => c.GiaApDung.GiaTri*c.DoanKhachs.Count());
        }

        public Task UpdateListDiaDiemTour(List<DiaDiem> danhSachDiaDiemTrongDoanUpdate)
        {
            List<ChiTietTour> danhSachChiTietTour = new List<ChiTietTour>();
            for (int i = 0; i < danhSachDiaDiemTrongDoanUpdate.Count(); i++)
            {
                ChiTietTour chiTietTour = new ChiTietTour();
                chiTietTour.diaDiem = danhSachDiaDiemTrongDoanUpdate.ToArray()[i];
                chiTietTour.touris = this;
                chiTietTour.ThuTu = i + 1;
                danhSachChiTietTour.Add(chiTietTour);
            }
            return TourDal.UpdateListDiaDiemTour(danhSachChiTietTour);
        }

        public List<Doan> GetListDoanOfTourByTime(DateTime from, DateTime to)
        {
            return GetListDoanOfTour().Where(c => c.ThoiGianBatDau >= from && c.ThoiGianKetThuc <= to).ToList();
        }
    }
}
