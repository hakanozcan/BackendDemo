using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendDemo.Core.Aspects.CacheAspects;
using BackendDemo.Core.CrossCuttingConcerns.Validation.FluentValidation;
using BackendDemo.Northwind.Business.Abstract;
using BackendDemo.Northwind.Business.ValidationRules.FluentValidation;
using BackendDemo.Northwind.DataAccess.Abstract;
using BackendDemo.Northwind.Entities.Concrete;
using BackendDemo.Core.Aspects.Postsharp;
using BackendDemo.Core.Aspects.Postsharp.LogAspects;
using BackendDemo.Core.Aspects.Postsharp.TransactionAspects;
using BackendDemo.Core.Aspects.Postsharp.ValidationAspects;
using BackendDemo.Core.CrossCuttingConcerns.Caching.Microsoft;
using BackendDemo.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;

namespace BackendDemo.Northwind.Business.Concrete.Managers
{
    public class ProductManager:IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        [CacheAspect(typeof(MemoryCacheManager),120)]
        [LogAspect(typeof(DatabaseLogger))]
        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Add(Product product)
        {
           
            return _productDal.Add(product);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }

        [TransactionScopeAspect]
        public void TransactionalOperation(Product product1, Product product2)
        {
            
            _productDal.Add(product1);
            _productDal.Update(product2);
        }
    }
}
