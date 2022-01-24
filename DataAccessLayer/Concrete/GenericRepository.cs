using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataAccessLayer.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
    public class GenericRepository<T> : IRepositoryDal<T> where T : class
    {
        protected Context db;
        protected DbSet<T> dbset;
        public GenericRepository()
        {
            db = new Context();
            dbset = db.Set<T>();
        }
        public void Delete(T p)
        {
            dbset.Remove(p);
            db.SaveChanges();
        }

        public virtual T Get(int id)
        {
            return dbset.Find(id);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return dbset.Where(filter).FirstOrDefault();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return dbset.Where(filter).ToList();
        }

        public void Insert(T p)
        {
            dbset.Add(p);
            db.SaveChanges();
        }

        public void Update(T p)
        {
            dbset.Update(p);
            db.SaveChanges();
        }
    }
}
