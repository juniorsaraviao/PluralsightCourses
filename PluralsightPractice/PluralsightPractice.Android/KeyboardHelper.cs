using Android.Views.InputMethods;
using Plugin.CurrentActivity;
using PluralsightPractice.Droid;
using PluralsightPractice.NativeFeatures;
using Xamarin.Forms;

[assembly: Dependency(typeof(KeyboardHelper))]
namespace PluralsightPractice.Droid
{
   public class KeyboardHelper : IKeyboardHelper
   {
      public void HideKeyboard()
      {
         var inputMethodManager = InputMethodManager.FromContext(CrossCurrentActivity.Current.AppContext);

         if (inputMethodManager != null)
         {
            inputMethodManager.HideSoftInputFromWindow(CrossCurrentActivity.Current.Activity.Window.DecorView.WindowToken,
               HideSoftInputFlags.None);
         }
      }
   }
}