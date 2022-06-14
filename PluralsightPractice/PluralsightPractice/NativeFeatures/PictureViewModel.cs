using PluralsightPractice.Navigation;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PluralsightPractice.NativeFeatures
{
   public class PictureViewModel : BaseViewModel
   {
      private static readonly byte[] PnhHeader = new byte[] { 137, 80, 78, 71, 13, 10, 26, 10 };
      private byte[] cachedImage = null;
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

            var sharedPhoto = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();

            if (sharedPhoto != null)
            {
               BoxOpacity = 0;

               var stream = new MemoryStream();
               sharedPhoto.ImageData.CopyTo(stream);
               cachedImage = stream.ToArray();

               ImageData = ImageSource.FromStream(() => new MemoryStream(cachedImage));

               ButtonLabel = "Pick another picture";
               _enableShareButton = true;
               ShareCommand.ChangeCanExecute();
            }
         }
      }

      bool IsPng()
      {
         bool result;
         int i = 0;
         do
         {
            result = cachedImage[i] == PnhHeader[i];
         } while (result && ++i < 8);

         return result;
      }

      async Task SharePhoto()
      {
         var fn = IsPng() ? "attachment.png" : "attachment.jpg";
         var shareFileName = Path.Combine(FileSystem.CacheDirectory, fn);

         File.WriteAllBytes(shareFileName, cachedImage);

         await Share.RequestAsync(new ShareFileRequest
         {
            Title = "Shared from me",
            File = new ShareFile(shareFileName),
            PresentationSourceBounds = DeviceInfo.Platform == DevicePlatform.iOS && DeviceInfo.Idiom == DeviceIdiom.Tablet
               ? new System.Drawing.Rectangle(0, 20, 0, 0)
               : System.Drawing.Rectangle.Empty
         });
      }
   }
}
