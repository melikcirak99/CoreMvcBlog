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
    public class EfCommentRepository : GenericRepository<Comment>, ICommentDal
    {
        

        public override IEnumerable<Comment> GetAll()
        {
            return dbset.Include(x => x.Post).Include(x => x.User);
        }

        public override IEnumerable<Comment> GetAll(Expression<Func<Comment, bool>> filter)
        {
            return dbset.Where(filter).Include(x => x.Post).Include(x => x.User);
        }
        public void AddToTrash(int commentId)
        {
            Comment comment = Get(commentId);
            comment.IsApproved = false;
            db.SaveChanges();
        }

        public void OutOfTrash(int commentId)
        {
            Comment comment = Get(commentId);
            comment.IsApproved = true;
            db.SaveChanges();
        }
    }
}
