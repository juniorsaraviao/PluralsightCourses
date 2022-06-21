using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PluralsightPractice.Architecting
{
   [XamlCompilation(XamlCompilationOptions.Compile)]
   public partial class ShowWebPage : ContentPage
   {
      public ShowWebPage()
      {
         InitializeComponent();

         hybridWebView.RegisterAction(data => DisplayAlert("Alert", $"Hello {data}", "Ok"));
      }
   }
}