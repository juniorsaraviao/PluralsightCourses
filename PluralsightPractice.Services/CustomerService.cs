using PluralsightPractice.Common;
using System.Threading.Tasks;

namespace PluralsightPractice.Services
{
   public class CustomerService : ICustomerService
   {
      private readonly IPlatformPrinter _platformPrinter;

      public CustomerService(IPlatformPrinter platformPrinter)
      {
         _platformPrinter = platformPrinter;
      }

      public async Task<Customer> GetCustomerById(string customerId)
      {
         return new Customer
         {
            FirstName = _platformPrinter.GetPlatformString()
         };
      }

      // Implement other service methods
   }
}
