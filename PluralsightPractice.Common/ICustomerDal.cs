using PluralsightPractice.Common;
using System.Threading.Tasks;

namespace PluralsightPractice.Common
{
   public interface ICustomerDal
   {
      Task<Customer> GetCustomerById(string customerId);
   }
}