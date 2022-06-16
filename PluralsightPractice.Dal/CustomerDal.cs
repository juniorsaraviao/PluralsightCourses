using PluralsightPractice.Common;
using System.Threading.Tasks;

namespace PluralsightPractice.Dal
{
   // DAL = Data Access Layer
   public class CustomerDal
   {
      public async Task<Customer> GetCustomerById(string customerId)
      {
         return new Customer();
      }

      // Implement CRUD
   }
}
