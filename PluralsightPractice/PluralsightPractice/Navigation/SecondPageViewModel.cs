namespace PluralsightPractice.Navigation
{
   public class SecondPageViewModel : BaseViewModel
   {
      private string _text = "Welcome to Xamarin Forms!";

      public string Text
      {
         get => _text;
         set => SetProperty(ref _text, value);
      }

   }
}
