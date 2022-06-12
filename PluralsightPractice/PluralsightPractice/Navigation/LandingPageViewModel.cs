namespace PluralsightPractice.Navigation
{
   public class LandingPageViewModel : BaseViewModel
   {
      private string _text;

      public string Text
      {
         get => _text;
         set => SetProperty(ref _text, value);
      }
   }
}
