using DuLich.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuLich.BUS
{
    class GiaBus : BaseBus<Gia>
    {
        public override void AddOrUpdate(Gia entity)
        {
            context.Gia.AddOrUpdate(entity);
        }

        public override Gia Get(int id)
        {
            return context.Gia.Where(c => c.MaGia == id).FirstOrDefault();
        }

        public override List<Gia> GetAll()
        {
            return context.Gia.ToList();
        }

        public override void Remove(Gia entity)
        {
            context.Gia.Remove(entity);
        }

        public override void RemoveRange(List<Gia> listEntity)
        {
            context.Gia.RemoveRange(listEntity);
        }

    
    }
}
