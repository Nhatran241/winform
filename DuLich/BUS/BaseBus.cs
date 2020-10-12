using DuLich.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuLich.BUS
{
    abstract class BaseBus<T>
    {
        protected DuLichContext context = DuLichContext.getInstance();
        public Task SaveChanges()
        {
            return context.SaveChangesAsync();
        }

        public abstract void AddOrUpdate(T entity);

        public abstract void RemoveRange(List<T> listEntity);
        public abstract List<T> GetAll();
        public abstract T Get(int id);
        public abstract void Remove(T entity);

    }
}
