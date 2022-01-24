using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BusinessLayer.Concrete
{
    public class WriterManager : Manager<Writer>, IWriterService
    {
        IWriterDal dal;
        public WriterManager(IWriterDal _dal) : base(_dal)
        {
            dal = _dal;
        }

        public void SetInActive(int writerId)
        {
            dal.SetInActive(writerId);
        }
    }
}
