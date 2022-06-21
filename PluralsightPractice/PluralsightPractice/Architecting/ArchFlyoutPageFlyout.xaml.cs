using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PluralsightPractice.Architecting
{
   [XamlCompilation(XamlCompilationOptions.Compile)]
   public partial class ArchFlyoutPageFlyout : ContentPage
   {
      public ListView ListView;

      public ArchFlyoutPageFlyout()
      {
         InitializeComponent();

         BindingContext = new ArchFlyoutPageFlyoutViewModel();
         ListView = MenuItemsListView;
      }

      class ArchFlyoutPageFlyoutViewModel : INotifyPropertyChanged
      {
         public ObservableCollection<ArchFlyoutPageFlyoutMenuItem> MenuItems { get; set; }

         public ArchFlyoutPageFlyoutViewModel()
         {
            MenuItems = new ObservableCollection<ArchFlyoutPageFlyoutMenuItem>(new[]
            {
                    new ArchFlyoutPageFlyoutMenuItem { Id = 0, Title = "Page 1", TargetType = typeof(ShowWebPage) },
                    new ArchFlyoutPageFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new ArchFlyoutPageFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new ArchFlyoutPageFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new ArchFlyoutPageFlyoutMenuItem { Id = 4, Title = "Page 5" },
                });
         }

         #region INotifyPropertyChanged Implementation
         public event PropertyChangedEventHandler PropertyChanged;
         void OnPropertyChanged([CallerMemberName] string propertyName = "")
         {
            if (PropertyChanged == null)
               return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
         }
         #endregion
      }
   }
}