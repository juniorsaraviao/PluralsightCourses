using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PluralsightPractice.Navigation
{
   [XamlCompilation(XamlCompilationOptions.Compile)]
   public partial class SecondPage : ContentPage
   {
      public SecondPage()
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
         await Navigation.PopModalAsync(ToggleAnimation());
      }
   }
}