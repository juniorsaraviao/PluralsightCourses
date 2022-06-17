using PluralsightPractice.Common;
using System.Threading.Tasks;

namespace PluralsightPractice.Common
{
   public interface ICustomerService
   {
      Task<Customer> GetCustomerById(string customerId);
   }
}