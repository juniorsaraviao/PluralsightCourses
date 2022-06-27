using PluralsightPractice.Navigation;
using System.Threading;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PluralsightPractice.NativeFeatures
{
   public class AboutViewModel : BaseViewModel
   {
      public string AppName => AppInfo.Name;
      public string AppVersion => AppInfo.VersionString;
      
      public string Platform
      {
         get
         {
            switch (Device.RuntimePlatform)
            {
               case Device.iOS:
                  if (Device.Idiom == TargetIdiom.Tablet)
                  {
                     return "iPad";
                  }
                  else
                  {
                     return "iPhone";
                  }
               default:
                  return Device.RuntimePlatform;
            }
         }
      }

      public ICommand OpenWebCommand { get; }

      public AboutViewModel()
      {
         OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://www.pluralsight.com/paths/building-cross-platform-apps-with-xamarin-forms"));
      }

      private string _countDownLabel = "Countdown not triggered";
      public string CountDownLabel
      {
         get => _countDownLabel;
         set => SetProperty(ref _countDownLabel, value);
      }

      private string _countDownText = "";
      public string CountDownText
      {
         get => _countDownText;
         set
         {
            if (SetProperty(ref _countDownText, value))
            {
               CountDownLabel = "Countdown triggered";
               ResetTimer();
            }
         }
      }

      private Timer _timer;

      void ResetTimer()
      {
         if (_timer == null)
         {
            _timer = new Timer(new TimerCallback(TextTimer), null, 2000, Timeout.Infinite);
         }
         else
         {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
            _timer.Change(2000, Timeout.Infinite);
         }
      }

      void TextTimer(object state)
      {
         CountDownLabel = "CountDown complete";
         MessagingCenter.Send<AboutViewModel>(this, "HideKeyboard");
         _timer.Change(Timeout.Infinite, Timeout.Infinite);
      }
   }
}
