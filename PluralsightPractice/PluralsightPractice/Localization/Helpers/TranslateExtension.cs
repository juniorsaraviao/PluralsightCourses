using PluralsightPractice.Localization.Resources;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PluralsightPractice.Localization.Helpers
{
   [ContentProperty("Text")]
   public class TranslateExtension : IMarkupExtension
   {
      public string Text { get; set; }

      public object ProvideValue(IServiceProvider serviceProvider)
      {
         if (Text == null)
            return null;

         return AppResource.ResourceManager.GetString(Text, AppResource.Culture);
      }
   }
}
