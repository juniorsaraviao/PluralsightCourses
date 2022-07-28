using Android.Widget;
using PluralsightPractice.Droid;
using PluralsightPractice.Effects;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(AttachedShadowEffect), nameof(AttachedShadowEffect))]
namespace PluralsightPractice.Droid
{
   public class AttachedShadowEffect : PlatformEffect
   {
      TextView control;
      Android.Graphics.Color color;
      float radius, distanceX, distanceY;

      protected override void OnAttached()
      {
         try
         {
            control = Control as TextView;
            UpdateRadius();
            UpdateColor();
            UpdateOffset();
            UpdateControl();
         }
         catch (Exception ex)
         {
            Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
         }
      }

      protected override void OnDetached()
      {
      }

      void UpdateControl()
      {
         if (control != null)
         {
            control.SetShadowLayer(radius, distanceX, distanceY, color);
         }
      }

      void UpdateRadius()
      {
         radius = (float)ShadowEffectParameters.GetRadius(Element);
      }

      void UpdateColor()
      {
         color = ShadowEffectParameters.GetColor(Element).ToAndroid();
      }

      void UpdateOffset()
      {
         distanceX = (float)ShadowEffectParameters.GetDistanceX(Element);
         distanceY = (float)ShadowEffectParameters.GetDistanceY(Element);
      }

      protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
      {
         base.OnElementPropertyChanged(args);
         if (args.PropertyName == ShadowEffectParameters.RadiusProperty.PropertyName)
         {
            UpdateRadius();
            UpdateControl();
         }
         else if (args.PropertyName == ShadowEffectParameters.ColorProperty.PropertyName)
         {
            UpdateColor();
            UpdateControl();
         }
         else if (args.PropertyName == ShadowEffectParameters.DistanceXProperty.PropertyName ||
                  args.PropertyName == ShadowEffectParameters.DistanceYProperty.PropertyName)
         {
            UpdateOffset();
            UpdateControl();
         }
      }
   }
}