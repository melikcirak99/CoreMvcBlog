using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface ICommentDal : IRepositoryDal<Comment>
    {
        void AddToTrash(int commentId);
        void OutOfTrash(int commentId);
    }
}
