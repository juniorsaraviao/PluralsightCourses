using PluralsightPractice.Common;
using System.Threading.Tasks;

namespace PluralsightPractice.Services
{
   public class CustomerService
   {
      public async Task<Customer> GetCustomerById(string customerId)
      {
         return new Customer 
         {
            FirstName = customerId
         };
      }

      // Implement other service methods
   }
}
