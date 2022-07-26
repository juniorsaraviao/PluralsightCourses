using PluralsightPractice.Controls;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PluralsightPractice
{
   public partial class MainPage : ContentPage
   {
      public MainPage()
      {
         InitializeComponent();
         Device.BeginInvokeOnMainThread(async () =>
         {
            var status = await Permissions.RequestAsync<Permissions.Camera>();
         });
      }

      private async void Button_Clicked(object sender, System.EventArgs e)
      {
         await Navigation.PushAsync(new CameraPage());
      }
   }
}
