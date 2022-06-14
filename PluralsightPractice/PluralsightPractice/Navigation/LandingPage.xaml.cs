using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PluralsightPractice.Navigation
{
   [XamlCompilation(XamlCompilationOptions.Compile)]
   public partial class LandingPage : ContentPage
   {
      public LandingPage()
      {
         InitializeComponent();
      }

      private static bool _showAnimation = true;

      private static bool ToggleAnimation()
      {
         _showAnimation = !_showAnimation;
         return _showAnimation;
      }

      private async void Button_Clicked(object sender, EventArgs e)
      {
         var viewModel = this.BindingContext as LandingPageViewModel;

         if (viewModel == null)
         {
            return;
         }

         var secondPage = new SecondPage();
         ((SecondPageViewModel)secondPage.BindingContext).Text = viewModel.Text;

         await Navigation.PushAsync(secondPage, ToggleAnimation());
      }
   }
}