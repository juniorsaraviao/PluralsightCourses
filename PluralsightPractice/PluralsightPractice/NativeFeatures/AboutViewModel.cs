using PluralsightPractice.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PluralsightPractice.NativeFeatures
{
   public class AboutViewModel : BaseViewModel
   {
      public string AppName => AppInfo.Name;
      public string AppVersion => AppInfo.VersionString;
      public ICommand OpenWebCommand { get; }

      public AboutViewModel()
      {
         OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://www.pluralsight.com/paths/building-cross-platform-apps-with-xamarin-forms"));
      }
   }
}
