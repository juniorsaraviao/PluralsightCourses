using PluralsightPractice.Common;
using PluralsightPractice.Dal;
using PluralsightPractice.Services;
using System;
using System.Collections.Generic;
using System.Text;
using TinyIoC;

namespace PluralsightPractice.Dependency
{
   public static class Bootstrap
   {
      internal static TinyIoCContainer GetContainer()
      {
         var container = new TinyIoCContainer();
         container.Register<ICustomerDal, CustomerDal>();
         container.Register<ICustomerService, CustomerService>();
         return container;
      }

      public static ILocator GetLocator()
      {
         return new Locator(Bootstrap.GetContainer());
      }
   }
}
