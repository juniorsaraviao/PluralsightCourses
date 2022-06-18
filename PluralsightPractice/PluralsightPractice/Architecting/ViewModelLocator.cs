using PluralsightPractice.Architecting.ViewModel;
using PluralsightPractice.Common;
using PluralsightPractice.Dependency;
using Xamarin.Forms;

namespace PluralsightPractice.Architecting
{
   public static class ViewModelLocator
   {
      private static ILocator Locator = Bootstrap.GetLocator();

      static ViewModelLocator()
      {
         Locator.Register<AboutViewModel>();
         //Locator.Register<IPlatformPrinter>(DependencyService.Get<IPlatformPrinter>());
      }

      public static void Register<T>() where T : class => Locator.Register<T>();

      public static void Register<TInterface, TImplementation>()
         where TImplementation : class, TInterface
         where TInterface : class => Locator.Register<TInterface, TImplementation>();

      public static AboutViewModel AboutViewModel => Locator.GetInstance<AboutViewModel>();
   }
}
