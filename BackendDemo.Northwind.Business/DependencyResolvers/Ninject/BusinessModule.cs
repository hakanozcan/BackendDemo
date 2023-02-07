using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendDemo.Core.DataAccess;
using BackendDemo.Core.DataAccess.EntityFramework;
using BackendDemo.Core.DataAccess.NHibernate;
using BackendDemo.Northwind.Business.Abstract;
using BackendDemo.Northwind.Business.Concrete.Managers;
using BackendDemo.Northwind.DataAccess.Abstract;
using BackendDemo.Northwind.DataAccess.Concrete.EntityFramework;
using BackendDemo.Northwind.DataAccess.Concrete.NHibernate.Helpers;
using Ninject.Modules;

namespace BackendDemo.Northwind.Business.DependencyResolvers.Ninject
{
    public class BusinessModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>();

            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));
            Bind<DbContext>().To<NorthwindContext>();
            Bind<NHibernateHelper>().To<SqlServerHelper>();
        }
    }
}
