using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PluralsightPractice.NativeFeatures
{
   [XamlCompilation(XamlCompilationOptions.Compile)]
   public partial class AboutPage : ContentPage
   {
      public AboutPage()
      {
         InitializeComponent();
      }

      protected override void OnAppearing()
      {
         base.OnAppearing();
         MessagingCenter.Subscribe<AboutViewModel>(this, "HideKeyboard", (sender) =>
         {
            Device.BeginInvokeOnMainThread(() =>
            {
               App.ServiceProvider.GetService<IKeyboardHelper>()?.HideKeyboard();

               App.ServiceProvider.GetService<IToastMessage>()?.OpenToast("Goodbye keyboard!");
            });
         });
      }
   }
}