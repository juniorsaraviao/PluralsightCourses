using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralsightPractice.Architecting
{
   public class ArchFlyoutPageFlyoutMenuItem
   {
      public ArchFlyoutPageFlyoutMenuItem()
      {
         TargetType = typeof(ArchFlyoutPageFlyoutMenuItem);
      }
      public int Id { get; set; }
      public string Title { get; set; }

      public Type TargetType { get; set; }
   }
}