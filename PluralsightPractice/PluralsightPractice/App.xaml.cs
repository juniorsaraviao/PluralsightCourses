﻿using PluralsightPractice.AbsoluteAndRelative;
using PluralsightPractice.Navigation;
using Xamarin.Forms;

namespace PluralsightPractice
{
   public partial class App : Application
   {
      public App()
      {
         InitializeComponent();

         MainPage = new NavigationPage(new ModalLandingPage());
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
