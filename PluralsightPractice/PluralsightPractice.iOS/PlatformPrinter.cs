using PluralsightPractice.Common;
using PluralsightPractice.iOS;
using Xamarin.Forms;

//[assembly: Dependency(typeof(PlatformPrinter))]
namespace PluralsightPractice.iOS
{
   public class PlatformPrinter : IPlatformPrinter
   {
      public string GetPlatformString()
      {
         return "iOS";
      }
   }
}