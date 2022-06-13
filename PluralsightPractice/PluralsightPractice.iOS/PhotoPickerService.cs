using Foundation;
using PluralsightPractice.iOS;
using PluralsightPractice.NativeFeatures;
using System;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhotoPickerService))]
namespace PluralsightPractice.iOS
{
   public class PhotoPickerService : IPhotoPickerService
   {
      TaskCompletionSource<SharedPhoto> taskCompletionSource;
      UIImagePickerController imagePicker;

      public Task<SharedPhoto> GetImageStreamAsync()
      {
         imagePicker = new UIImagePickerController
         {
            SourceType = UIImagePickerControllerSourceType.PhotoLibrary,
            MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary)
         };
         imagePicker.FinishedPickingMedia += ImagePicker_FinishedPickingMedia;
         imagePicker.Canceled += ImagePicker_Canceled;

         UIWindow window = UIApplication.SharedApplication.KeyWindow;
         var viewController = window.RootViewController;
         viewController.PresentModalViewController(imagePicker, true);

         taskCompletionSource = new TaskCompletionSource<SharedPhoto>();

         return taskCompletionSource.Task;
      }

      private void ImagePicker_Canceled(object sender, EventArgs e)
      {
         throw new NotImplementedException();
      }

      private void ImagePicker_FinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs e)
      {
         var image = e.EditedImage ?? e.OriginalImage;

         if (image != null)
         {
            NSData data;

            if (e.ReferenceUrl.PathExtension.ToUpper().Equals("PNG"))
            {
               data = image.AsPNG();
            }
            else
            {
               data = image.AsJPEG(1);
            }

            var sharedPhoto = new SharedPhoto
            {
               ImageName = e.ReferenceUrl.ToString(),
               ImageData = data.AsStream()
            };

            UnregisterEventHandlers();

            taskCompletionSource.SetResult(sharedPhoto);
         }
         else
         {
            UnregisterEventHandlers();
            taskCompletionSource.SetResult(null);
         }
         imagePicker.DismissModalViewController(true);
      }

      void UnregisterEventHandlers()
      {
         imagePicker.FinishedPickingMedia -= ImagePicker_FinishedPickingMedia;
         imagePicker.Canceled -= ImagePicker_Canceled;
      }
   }
}