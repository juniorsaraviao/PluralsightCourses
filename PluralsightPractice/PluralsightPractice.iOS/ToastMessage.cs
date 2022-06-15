using CoreFoundation;
using PluralsightPractice.NativeFeatures;
using UIKit;

namespace PluralsightPractice.iOS
{
   public class ToastMessage : IToastMessage
   {
      public void OpenToast(string text)
      {
         var rvc = UIApplication.SharedApplication.KeyWindow.RootViewController;

         var alertController = UIAlertController.Create(string.Empty, text, UIAlertControllerStyle.Alert);
         alertController.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));

         rvc.PresentViewController(alertController, true, () =>
         {
            var delayTime = new DispatchTime(DispatchTime.Now, 3_000_000_000);
            DispatchQueue.MainQueue.DispatchAfter(delayTime, () =>
            {
               alertController.DismissViewController(true, null);
            });
         });
      }
   }
}