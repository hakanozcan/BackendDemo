﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendDemo.Northwind.Business.ValidationRules.FluentValidation;
using BackendDemo.Northwind.Entities.Concrete;
using FluentValidation;
using Ninject.Modules;

namespace BackendDemo.Northwind.Business.DependencyResolvers.Ninject
{
    public class ValidationModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<Product>>().To<ProductValidator>().InSingletonScope();
        }
    }
}
