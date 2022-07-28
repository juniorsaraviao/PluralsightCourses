using PluralsightPractice.Droid;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(ShadowEffect), nameof(ShadowEffect))]
namespace PluralsightPractice.Droid
{
   public class ShadowEffect : PlatformEffect
   {
      protected override void OnAttached()
      {
         try
         {
            var control = Control as Android.Widget.TextView;
            var effect = (Effects.ShadowEffect)Element.Effects.FirstOrDefault(e => e is Effects.ShadowEffect);
            if (effect != null)
            {
               float radius = effect.Radius;
               float distanceX = effect.DistanceX;
               float distanceY = effect.DistanceY;
               Android.Graphics.Color color = effect.Color.ToAndroid();
               control.SetShadowLayer(radius, distanceX, distanceY, color);
            }
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
         }
      }

      protected override void OnDetached()
      {
      }
   }
}