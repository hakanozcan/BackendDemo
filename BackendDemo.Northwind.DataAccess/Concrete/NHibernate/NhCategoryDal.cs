using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendDemo.Core.DataAccess.NHibernate;
using BackendDemo.Northwind.DataAccess.Abstract;
using BackendDemo.Northwind.Entities.Concrete;

namespace BackendDemo.Northwind.DataAccess.Concrete.NHibernate
{
    public class NhCategoryDal:NhEntityRepositoryBase<Category>,ICategoryDal
    {
        public NhCategoryDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {

        }
    }
}
