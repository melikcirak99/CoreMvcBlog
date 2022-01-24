using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class Manager<T> : IService<T> where T : class
    {
        IRepositoryDal<T> _dal;
        public Manager(IRepositoryDal<T> dal)
        {
            _dal = dal;
        }
        public void DeleteBL(T p)
        {
            _dal.Delete(p);
        }

        public IEnumerable<T> GetAllBL()
        {
            return _dal.GetAll();
        }

        public IEnumerable<T> GetAllBL(Expression<Func<T, bool>> filter)
        {
            return _dal.GetAll(filter);
        }

        public T GetBL(int id)
        {
            return _dal.Get(id);
        }

        public T GetBL(Expression<Func<T, bool>> filter)
        {
            return _dal.Get(filter);
        }

        public void InsertBL(T p)
        {
            _dal.Insert(p);
        }

        public void UpdateBL(T p)
        {
            _dal.Update(p);
        }
    }
}
