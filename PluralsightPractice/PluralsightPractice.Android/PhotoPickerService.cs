using Android.Content;
using PluralsightPractice.Droid;
using PluralsightPractice.NativeFeatures;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhotoPickerService))]
namespace PluralsightPractice.Droid
{
   public class PhotoPickerService : IPhotoPickerService
   {
      public Task<SharedPhoto> GetImageStreamAsync()
      {
         var intent = new Intent();
         intent.SetType("image/*");
         intent.SetAction(Intent.ActionGetContent);

         MainActivity.Instance.StartActivityForResult(
            Intent.CreateChooser(intent, "Select Photo"),
            MainActivity.PickImageId);

         MainActivity.Instance.PickImageTaskCompletionSource = new TaskCompletionSource<SharedPhoto>();

         return MainActivity.Instance.PickImageTaskCompletionSource.Task;
      }
   }
}