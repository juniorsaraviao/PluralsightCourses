using PluralsightPractice.Common;
using PluralsightPractice.Services;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PluralsightPractice.Architecting.ViewModel
{
   public class AboutViewModel : BaseViewModel
   {
      private ICustomerService _customerService;
      public string AppName => AppInfo.Name;
      public string AppVersion => AppInfo.VersionString;

      private string _title;
      public string Title
      {
         get => _title;
         set => SetProperty(ref _title, value);
      }

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

      public AboutViewModel(ICustomerService customerService)
      {
         //OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://www.pluralsight.com/paths/building-cross-platform-apps-with-xamarin-forms"));
         _customerService = customerService;
         OpenWebCommand = new Command(async () => await GetCustomer());
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

      private async Task GetCustomer()
      {
         var newTitle = await _customerService.GetCustomerById("user");
         Title = newTitle.FirstName;
      }
   }
}
