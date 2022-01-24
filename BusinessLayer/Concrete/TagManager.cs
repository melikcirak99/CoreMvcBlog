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
    public class TagManager : Manager<Tag>, ITagService
    {
        public TagManager(IRepositoryDal<Tag> dal) : base(dal)
        {
        }
    }
}
