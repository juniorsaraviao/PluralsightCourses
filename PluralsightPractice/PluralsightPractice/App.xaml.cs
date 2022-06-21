using PluralsightPractice.AbsoluteAndRelative;
using PluralsightPractice.Architecting;
using PluralsightPractice.NativeFeatures;
using PluralsightPractice.Navigation;
using System;
using Xamarin.Forms;

namespace PluralsightPractice
{
   public partial class App : Application
   {
      public static IServiceProvider ServiceProvider { get; set; }

      public App()
      {
         InitializeComponent();

         //MainPage = new NavigationPage(new PicturePage());
         //ViewModelLocator.Register<Architecting.ViewModel.AboutViewModel>();
         MainPage = new ArchFlyoutPage();
      }

      public static void Register<TInterface, TImplementation>()
         where TImplementation : class, TInterface
         where TInterface : class => ViewModelLocator.Register<TInterface, TImplementation>();

      protected override void OnStart()
      {
      }

      protected override void OnSleep()
      {
      }

      protected override void OnResume()
      {
      }
   }
}
