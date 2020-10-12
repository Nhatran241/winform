using DuLich.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuLich.BUS
{
    class DiaDiemBus : BaseBus<DiaDiem>
    {
        public override void AddOrUpdate(DiaDiem entity)
        {
            context.DiaDiem.AddOrUpdate(entity);
        }

        public override DiaDiem Get(int id)
        {
            return context.DiaDiem.Where(c => c.MaDienDiem == id).FirstOrDefault();
        }

        public override List<DiaDiem> GetAll()
        {
            return context.DiaDiem.ToList();
        }

        public override void Remove(DiaDiem entity)
        {
            context.DiaDiem.Remove(entity);
        }

        public override void RemoveRange(List<DiaDiem> listEntity)
        {
            context.DiaDiem.RemoveRange(listEntity);
        }
    }
}
