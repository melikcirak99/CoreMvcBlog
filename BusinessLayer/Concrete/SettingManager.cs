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
    public class SettingManager : Manager<Setting>, ISettingService
    {
        ISettingDal dal;
        public SettingManager(ISettingDal _dal) : base(_dal)
        {
            dal = _dal;
        }

    }
}
