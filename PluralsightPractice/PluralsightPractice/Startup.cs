using Microsoft.Extensions.DependencyInjection;
using System;

namespace PluralsightPractice
{
   public static class Startup
   {
      public static void Init(Action<IServiceCollection> nativeConfigurationServices)
      {
         var services = new ServiceCollection();

         nativeConfigurationServices(services);

         App.ServiceProvider = services.BuildServiceProvider();
      }
   }
}
