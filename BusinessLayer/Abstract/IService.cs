using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IService<T> where T : class
    {
        T GetBL(int id);
        T GetBL(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetAllBL();
        IEnumerable<T> GetAllBL(Expression<Func<T, bool>> filter);
        void InsertBL(T p);
        void UpdateBL(T p);
        void DeleteBL(T p);
    }
}
