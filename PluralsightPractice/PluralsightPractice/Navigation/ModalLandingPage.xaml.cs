using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PluralsightPractice.Navigation
{
   [XamlCompilation(XamlCompilationOptions.Compile)]
   public partial class ModalLandingPage : ContentPage
   {
      public ModalLandingPage()
      {
         InitializeComponent();
      }

      private async void Button_Clicked(object sender, EventArgs e)
      {
         await Navigation.PushModalAsync(new NavigationPage(new LandingPage()));
      }
   }
}