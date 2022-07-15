using Android.Content;
using PluralsightPractice.Controls;
using PluralsightPractice.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer))]
namespace PluralsightPractice.Droid
{
   public class MyEntryRenderer : EntryRenderer
   {
      public MyEntryRenderer(Context context) : base(context)
      {         
      }

      protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
      {
         base.OnElementChanged(e);

         if (Control != null)
         {
            Control.Text = "This is from the custom renderer";
         }
      }
   }
}