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
    public class CategoryManager : Manager<Category>, ICategoryService
    {
        ICategoryDal dal;
        public CategoryManager(ICategoryDal _dal) : base(_dal)
        {
        }

        public void SetInActive(int categoryId)
        {
            dal.SetInActive(categoryId);
        }
        public void SetActive(int categoryId)
        {
            dal.SetActive(categoryId);
        }
    }
}
