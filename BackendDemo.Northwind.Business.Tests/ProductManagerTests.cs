using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BackendDemo.Northwind.Business.Concrete.Managers;
using BackendDemo.Northwind.DataAccess.Abstract;
using BackendDemo.Northwind.Entities.Concrete;
using FluentValidation;
using Moq;

namespace BackendDemo.Northwind.Business.Tests
{
    [TestClass]
    public class ProductManagerTests
    {
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void Product_validation_check()
        {
            Mock<IProductDal> mock = new Mock<IProductDal>();
            ProductManager productManager = new ProductManager(mock.Object);
            productManager.Add(new Product());
        }

        
    }
}
