using DuLich.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuLich.BUS
{
    class DoanBus : BaseBus<Doan>
    {
        public override void AddOrUpdate(Doan entity)
        {
            context.Doans.Add(entity);
        }

        public override Doan Get(int id)
        {
            return context.Doans.Where(c => c.Id == id).FirstOrDefault();
        }

        public override List<Doan> GetAll()
        {
            return context.Doans.ToList();
        }

        public override void Remove(Doan entity)
        {
            context.Doans.Remove(entity);
        }

        public override void RemoveRange(List<Doan> listEntity)
        {
            context.Doans.RemoveRange(listEntity);
        }


    }
}
