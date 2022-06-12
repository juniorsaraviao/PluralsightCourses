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

      public PictureViewModel()
      {
         Title = "Pictures";

         PickPhotoCommand = new Command(async () => await PickPhoto());
         ShareCommand = new Command(async () => await SharePhoto(), () => _enableShareButton);
         SettingsCommand = new Command(() => AppInfo.ShowSettingsUI());
      }

      async Task PickPhoto()
      {
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
