using PluralsightPractice.AbsoluteAndRelative;
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

         MainPage = new NavigationPage(new PicturePage());
      }

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
