using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Plugin.CurrentActivity;
using System.Threading.Tasks;
using PluralsightPractice.NativeFeatures;
using Android.Content;
using Microsoft.Extensions.DependencyInjection;

namespace PluralsightPractice.Droid
{
   [Activity(Label = "PluralsightPractice", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static readonly int PickImageId = 1000;
        public TaskCompletionSource<SharedPhoto> PickImageTaskCompletionSource { get; set; }
        internal static MainActivity Instance { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Instance = this;

            CrossCurrentActivity.Current.Init(this, savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            Startup.Init(ConfigureServices);
            
            LoadApplication(new App());
        }

        void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IToastMessage, ToastMessage>();
            services.AddTransient<IKeyboardHelper, KeyboardHelper>();
            services.AddTransient<IPhotoPickerService, PhotoPickerService>();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
           base.OnActivityResult(requestCode, resultCode, data);

           if (requestCode == PickImageId)
           {
              if ((resultCode == Result.Ok) && data != null)
              {
                 var sharedPhoto = new SharedPhoto
                 {
                    ImageName = data.Data.ToString(),
                    ImageData = ContentResolver.OpenInputStream(data.Data)
                 };
               
                 PickImageTaskCompletionSource.SetResult(sharedPhoto);
              }
              else
              {
                 PickImageTaskCompletionSource.SetResult(null);
              }            
           }
        }
    }
}