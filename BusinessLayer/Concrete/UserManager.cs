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
    public class UserManager : Manager<User>, IUserService
    {
        IUserDal dal;
        public UserManager(IUserDal _dal) : base(_dal)
        {
            dal = _dal;
        }

    }
}
