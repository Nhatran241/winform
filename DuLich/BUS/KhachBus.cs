using DuLich.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuLich.BUS
{
    class KhachBus : BaseBus<Khach>
    {
        public override void AddOrUpdate(Khach entity)
        {
            context.Khaches.AddOrUpdate(entity);
        }

        public override Khach Get(int id)
        {
            return context.Khaches.Where(c => c.KhachId == id).FirstOrDefault();
        }

        public override List<Khach> GetAll()
        {
            return context.Khaches.ToList();
        }

        public override void Remove(Khach entity)
        {
            context.Khaches.Remove(entity);
        }

        public override void RemoveRange(List<Khach> listEntity)
        {
            context.Khaches.RemoveRange(listEntity);
        }

    }
}
