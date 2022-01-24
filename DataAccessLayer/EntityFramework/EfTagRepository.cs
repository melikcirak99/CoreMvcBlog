using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EfTagRepository : GenericRepository<Tag>, ITagDal
    {
    }
}
