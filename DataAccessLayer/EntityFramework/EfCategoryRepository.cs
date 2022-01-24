using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfCategoryRepository : GenericRepository<Category>, ICategoryDal
    {
        public override IEnumerable<Category> GetAll()
        {
            return dbset.Include(x => x.Posts).ToList();
        }
        public override IEnumerable<Category> GetAll(Expression<Func<Category, bool>> filter)
        {
            return dbset.Where(filter).Include(x => x.Posts).ToList();
        }

        public void SetInActive(int categoryId)
        {
            Category category = Get(categoryId);
            category.IsActive = false;
            db.SaveChanges();
        }
        public void SetActive(int categoryId)
        {
            Category category = Get(categoryId);
            category.IsActive = true;
            db.SaveChanges();
        }
    }
}
