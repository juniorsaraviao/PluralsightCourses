using Xamarin.Forms;

namespace PluralsightPractice.Effects
{
   public delegate void TouchActionEventHandler(object sender, TouchActionEventArgs args);

   public class TouchEffect : RoutingEffect
   {
      public event TouchActionEventHandler TouchAction;
      public TouchEffect() : base($"Pluralsight.{nameof(TouchEffect)}")
      {
      }

      public bool Capture { get; set; }
      public void OnTouchAction(Element element, TouchActionEventArgs eventArgs)
      {
         TouchAction?.Invoke(element, eventArgs);
      }
   }
}
