using DuLich.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuLich.BUS
{
    class ChiTietTourBus : BaseBus<ChiTietTour>
    {
        public override void AddOrUpdate(ChiTietTour entity)
        {
            context.ChiTietTour.AddOrUpdate(entity);
        }

        public override ChiTietTour Get(int id)
        {
            return context.ChiTietTour.Where(c => c.MaChiTietTour == id).FirstOrDefault();
        }

        public override List<ChiTietTour> GetAll()
        {
            return context.ChiTietTour.ToList();
        }
        public List<ChiTietTour> GetAll(DiaDiem diaDiem)
        {
            return context.ChiTietTour.Where(c => c.diaDiem.MaDienDiem == diaDiem.MaDienDiem).ToList();
        }

        public override void Remove(ChiTietTour entity)
        {
            context.ChiTietTour.Remove(entity);
        }

        public override void RemoveRange(List<ChiTietTour> listEntity)
        {
            context.ChiTietTour.RemoveRange(listEntity);
        }
    }
}
