using PluralsightPractice.Droid;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("Pluralsight")]
[assembly: ExportEffect(typeof(FocusEffect), nameof(FocusEffect))]
namespace PluralsightPractice.Droid
{
   public class FocusEffect : PlatformEffect
   {
      Android.Graphics.Color originalColor = new Android.Graphics.Color(0, 0, 0, 0);
      Android.Graphics.Color backgroundColor;
      protected override void OnAttached()
      {
         try
         {
            backgroundColor = Color.LightGreen.ToAndroid();
            Control.SetBackgroundColor(backgroundColor);
         }
         catch (Exception ex)
         {
            Debug.WriteLine($"Cannot set property on attached control. Error: {ex.Message}");
         }
      }

      protected override void OnDetached()
      {
         throw new NotImplementedException();
      }

      protected override void OnElementPropertyChanged(System.ComponentModel.PropertyChangedEventArgs args)
      {
         base.OnElementPropertyChanged(args);
         try
         {
            if (args.PropertyName == "IsFocused")
            {
               if (((Android.Graphics.Drawables.ColorDrawable)Control.Background).Color == backgroundColor)
               {
                  Control.SetBackgroundColor(originalColor);
               }
               else
               {
                  Control.SetBackgroundColor(backgroundColor);
               }
            }
         }
         catch (Exception ex)
         {
            Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
         }
      }
   }
}