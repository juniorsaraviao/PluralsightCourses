using PluralsightPractice.Common;
using PluralsightPractice.Droid;
using Xamarin.Forms;

//[assembly: Dependency(typeof(PlatformPrinter))]
namespace PluralsightPractice.Droid
{
   public class PlatformPrinter : IPlatformPrinter
   {
      public string GetPlatformString()
      {
         return "Android";
      }
   }
}