using PluralsightPractice.Common;
using System;
using TinyIoC;

namespace PluralsightPractice.Dependency
{   
   public class Locator : ILocator
   {
      private TinyIoCContainer _container;

      public Locator(TinyIoCContainer container)
      {
         _container = container;
      }

      public T GetInstance<T>() where T : class
      {
         return _container.Resolve<T>();
      }

      public void Register<T>() where T : class
      {
         _container.Register<T>();
      }

      public void Register<T>(T instance) where T : class
      {
         _container.Register<T>(instance);
      }

      public void Register<TInterface, TImplementation>()
         where TImplementation : class, TInterface
         where TInterface : class
      {
         _container.Register<TInterface, TImplementation>();
      }
   }
}
