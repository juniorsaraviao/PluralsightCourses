﻿using PluralsightPractice.NativeFeatures;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PluralsightPractice.Architecting
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
         MessagingCenter.Subscribe<ViewModel.AboutViewModel>(this, "HideKeyboard", (sender) =>
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