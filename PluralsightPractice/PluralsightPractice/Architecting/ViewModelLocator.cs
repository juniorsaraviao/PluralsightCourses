using PluralsightPractice.Architecting.ViewModel;
using PluralsightPractice.Common;
using PluralsightPractice.Dependency;

namespace PluralsightPractice.Architecting
{
   public static class ViewModelLocator
   {
      private static ILocator Locator = Bootstrap.GetLocator();

      static ViewModelLocator()
      {
         Locator.Register<AboutViewModel>();
      }

      public static AboutViewModel AboutViewModel => Locator.GetInstance<AboutViewModel>();
   }
}
