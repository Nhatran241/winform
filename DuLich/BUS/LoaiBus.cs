using DuLich.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuLich.BUS
{
    class LoaiBus:BaseBus<Loai>
    {
        public override void AddOrUpdate(Loai entity)
        {
            context.Loai.AddOrUpdate(entity);
        }

        public override void RemoveRange(List<Loai> listEntity)
        {
            context.Loai.RemoveRange(listEntity);
        }

        public override List<Loai> GetAll()
        {
            return context.Loai.ToList();
        }

        public override Loai Get(int id)
        {
            return context.Loai.Where(c => c.Id == id).FirstOrDefault();
        }

        public override void Remove(Loai entity)
        {
            context.Loai.Remove(entity);
        }
    }
}