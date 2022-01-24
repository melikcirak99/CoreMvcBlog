using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CommentManager : Manager<Comment>, ICommentService
    {
        ICommentDal dal;
        public CommentManager(ICommentDal _dal) : base(_dal)
        {
            dal = _dal;
        }

        public void AddToTrash(int commentId)
        {
            dal.AddToTrash(commentId);
        }

        public void OutOfTrash(int commentId)
        {
            dal.OutOfTrash(commentId);
        }
    }
}
