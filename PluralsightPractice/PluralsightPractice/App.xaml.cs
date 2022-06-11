using PluralsightPractice.AbsoluteAndRelative;
using Xamarin.Forms;

namespace PluralsightPractice
{
   public partial class App : Application
   {
      public App()
      {
         InitializeComponent();

         MainPage = new RelativeLayoutPage();
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
