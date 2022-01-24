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
    public class EfUserRepository : GenericRepository<User>, IUserDal
    {
        public override IEnumerable<User> GetAll()
        {
            return dbset.Include(x => x.Comments);
        }
        public override IEnumerable<User> GetAll(Expression<Func<User, bool>> filter)
        {
            return dbset.Where(filter).Include(x => x.Comments);
        }
    }
}
