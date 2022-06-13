using System.IO;
using System.Threading.Tasks;

namespace PluralsightPractice.NativeFeatures
{
   public interface IPhotoPickerService
   {
      Task<SharedPhoto> GetImageStreamAsync();
   }

   public class SharedPhoto
   {
      public string ImageName { get; set; }
      public Stream ImageData { get; set; }
   }
}
