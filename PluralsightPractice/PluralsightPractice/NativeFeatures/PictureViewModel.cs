using PluralsightPractice.Navigation;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PluralsightPractice.NativeFeatures
{
   public class PictureViewModel : BaseViewModel
   {
      public Command PickPhotoCommand { get; set; }
      public Command ShareCommand { get; set; }
      public Command SettingsCommand { get; set; }

      private bool _enableShareButton = false;

      private string _buttonLabel = "Pick picture";
      public string ButtonLabel
      {
         get => _buttonLabel;
         set => SetProperty(ref _buttonLabel, value);
      }

      private ImageSource _imageData;
      public ImageSource ImageData
      {
         get => _imageData;
         set => SetProperty(ref _imageData, value);
      }

      private bool _showFixSettings;
      public bool ShowFixSettings
      {
         get => _showFixSettings;
         set => SetProperty(ref _showFixSettings, value);
      }

      private string _title;
      public string Title
      {
         get => _title;
         set => SetProperty(ref _title, value);
      }

      private double _boxOpacity;
      public double BoxOpacity
      {
         get => _boxOpacity;
         set => SetProperty(ref _boxOpacity, value);
      }

      private bool KeepGoing = true;

      public PictureViewModel()
      {
         Title = "Pictures";

         int i = 0;
         Device.StartTimer(new TimeSpan(0, 0, 1), () =>
         {
            if (i > 100)
            {
               KeepGoing = false;
            }

            Device.BeginInvokeOnMainThread(() =>
            {
               BoxOpacity = i / 100.0;
            });
            i += 5;

            return KeepGoing;
         });

         PickPhotoCommand = new Command(async () => await PickPhoto());
         ShareCommand = new Command(async () => await SharePhoto(), () => _enableShareButton);
         SettingsCommand = new Command(() => AppInfo.ShowSettingsUI());
      }

      public void StopFade()
      {
         if (KeepGoing)
         {
            KeepGoing = false;
            BoxOpacity = 1.0;
         }
      }

      async Task PickPhoto()
      {
         StopFade();
         var status = await Permissions.CheckStatusAsync<Permissions.Photos>();

         if (status == PermissionStatus.Unknown)
         {
            status = await Permissions.RequestAsync<Permissions.Photos>();
         }

         if (status == PermissionStatus.Denied)
         {
            ShowFixSettings = true;
            await App.Current.MainPage.DisplayAlert(Title, "Photo Pick Denied - fix in settings", "Ok");
         }
         else
         {
            ShowFixSettings = false;
         }
      }

      Task SharePhoto()
      {
         throw new NotImplementedException();
      }
   }
}
