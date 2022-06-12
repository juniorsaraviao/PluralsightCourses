using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PluralsightPractice.Navigation
{
   public class BaseViewModel : INotifyPropertyChanged
   {
      public event PropertyChangedEventHandler PropertyChanged;

      void OnPropertyChanged([CallerMemberName] string property = null)
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
      }

      protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
      {
         if (object.Equals(storage, value))
            return false;

         storage = value;
         OnPropertyChanged(propertyName);
         return true;
      }
   }
}
