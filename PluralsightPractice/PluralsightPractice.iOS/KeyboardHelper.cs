using PluralsightPractice.iOS;
using PluralsightPractice.NativeFeatures;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(KeyboardHelper))]
namespace PluralsightPractice.iOS
{
   public class KeyboardHelper : IKeyboardHelper
   {
      public void HideKeyboard()
      {
         UIApplication.SharedApplication.KeyWindow.EndEditing(true);
      }
   }
}