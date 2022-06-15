using Android.App;
using Android.Widget;
using PluralsightPractice.NativeFeatures;

namespace PluralsightPractice.Droid
{
   public class ToastMessage : IToastMessage
   {
      public void OpenToast(string text)
      {
         Toast.MakeText(Application.Context, text, ToastLength.Long).Show();
      }
   }
}