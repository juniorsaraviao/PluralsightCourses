using Android.Content;
using PluralsightPractice.Architecting;
using PluralsightPractice.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(HybridWebView), typeof(HybridWebViewRenderer))]
namespace PluralsightPractice.Droid
{
   public class HybridWebViewRenderer : WebViewRenderer
   {
      public HybridWebViewRenderer(Context context) : base(context)
      {
      }
   }
}