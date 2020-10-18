using DuLich.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuLich.BUS
{
    class TourBus : BaseBus<Touris>
    {
        public override void AddOrUpdate(Touris entity)
        {
            context.Touris.AddOrUpdate(entity);
        }

        public override Touris Get(int id)
        {
            return context.Touris.Where(c => c.Id == id).FirstOrDefault();
        }

        public override List<Touris> GetAll()
        {
            return context.Touris.ToList();
        }

        public override void Remove(Touris entity)
        {
            context.Touris.Remove(entity);
        }

        public override void RemoveRange(List<Touris> listEntity)
        {
            context.Touris.RemoveRange(listEntity);
        }
    }
}
