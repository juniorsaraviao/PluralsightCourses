using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PluralsightPractice.NativeFeatures
{
   [XamlCompilation(XamlCompilationOptions.Compile)]
   public partial class PicturePage : ContentPage
   {
      NetworkAccess LatNetworkAccess = NetworkAccess.Unknown;

      public PicturePage()
      {
         InitializeComponent();

         Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
      }

      private async void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
      {
         var access = e.NetworkAccess;

         if (access != LatNetworkAccess)
         {
            LatNetworkAccess = access;

            if (access == NetworkAccess.Internet)
            {
               await App.Current.MainPage.DisplayAlert("Network access", "Internet access available", "Ok");
            }
            else
            {
               await App.Current.MainPage.DisplayAlert("Network access", "Internet access unavailable", "Ok");
            }
         }
      }

      private async void Button_Clicked(object sender, EventArgs e)
      {
         await Navigation.PushAsync(new AboutPage());
      }
   }
}