﻿using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService : IService<Category>
    {
        void SetInActive(int categoryId);
        void SetActive(int categoryId);
    }
    
}
