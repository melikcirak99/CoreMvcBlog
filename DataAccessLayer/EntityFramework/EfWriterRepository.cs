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
    public class EfWriterRepository : GenericRepository<Writer>, IWriterDal
    {
        public override IEnumerable<Writer> GetAll()
        {
            return dbset.Include(x => x.Posts);
        }

        public override IEnumerable<Writer> GetAll(Expression<Func<Writer, bool>> filter)
        {
            return dbset.Where(filter).Include(x => x.Posts);
        }

        public void SetInActive(int writerId)
        {
            Get(writerId).IsActive = false;
            db.SaveChanges();
        }
    }
}
