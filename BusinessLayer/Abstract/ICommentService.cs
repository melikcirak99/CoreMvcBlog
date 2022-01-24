using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ICommentService : IService<Comment>
    {
        void AddToTrash(int commentId);
        void OutOfTrash(int commentId);
    }
}
