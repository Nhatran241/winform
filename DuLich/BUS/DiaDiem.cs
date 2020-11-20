using DuLich.DAL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DuLich.BUS
{
    public partial class DiaDiem
    {
        public void Map(DiaDiem diaDiem)
        {
            ChiTietTours = diaDiem.ChiTietTours;
            MaDienDiem = diaDiem.MaDienDiem;
            TenDiaDiem = diaDiem.TenDiaDiem;
        }
        public Task AddOrUpdate()
        {
            return DiaDiemDal.AddOrUpdate(this);
        }
        public Task Delete()
        {
            return DiaDiemDal.Delete(this);
        }
        public DiaDiem GetDiaDiemByName(String name)
        {
            return DiaDiemDal.GetDiaDiemByName(name);
        }

        public List<Tour> GetListTour()
        {
            List<Tour> listTour = new List<Tour>();
            foreach (ChiTietTour chiTietTour in ChiTietTours)
            {
                listTour.Add(chiTietTour.touris);
            }
            return listTour;
        }
    }
}
