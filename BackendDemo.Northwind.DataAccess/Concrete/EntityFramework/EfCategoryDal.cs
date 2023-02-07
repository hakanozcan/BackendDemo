﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendDemo.Core.DataAccess.EntityFramework;
using BackendDemo.Northwind.DataAccess.Abstract;
using BackendDemo.Northwind.Entities.Concrete;

namespace BackendDemo.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal:EfEntityRepositoryBase<Category,NorthwindContext>,ICategoryDal
    {

    }
}
