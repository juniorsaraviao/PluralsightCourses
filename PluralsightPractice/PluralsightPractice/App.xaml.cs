using PluralsightPractice.Architecting;
using PluralsightPractice.Localization.Views;
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

         //ChangeCulture("es-ES");

         //MainPage = new NavigationPage(new PicturePage());
         //ViewModelLocator.Register<Architecting.ViewModel.AboutViewModel>();
         MainPage = new MainPage();
      }

      public static void Register<TInterface, TImplementation>()
         where TImplementation : class, TInterface
         where TInterface : class => ViewModelLocator.Register<TInterface, TImplementation>();

      private void ChangeCulture(string locale)
      {
         System.Threading.Thread.CurrentThread.CurrentCulture =
             new System.Globalization.CultureInfo(locale);

         System.Threading.Thread.CurrentThread.CurrentUICulture =
             System.Threading.Thread.CurrentThread.CurrentCulture;
      }

      protected async override void OnStart()
      {
         //await ((CurView)MainPage).RefreshData();
      }

      protected override void OnSleep()
      {
      }

      protected override void OnResume()
      {
      }
   }
}
