using System;
using Xamarin.Forms;

namespace PluralsightPractice.Architecting
{
   public class HybridWebView : WebView
   {
      Action<string> action;

      public static readonly BindableProperty UriProperty = BindableProperty.Create(nameof(Uri), typeof(string), typeof(HybridWebView), default(string));

      public string Uri
      {
         get => (string)GetValue(UriProperty);
         set => SetValue(UriProperty, value);
      }

      public void RegisterAction(Action<string> callback)
      {
         action = callback;
      }

      public void CleanUp()
      {
         action = null;
      }

      public void InvokeAction(string data)
      {
         if (action == null || data == null)
         {
            return;
         }
         action.Invoke(data);
      }
   }
}
