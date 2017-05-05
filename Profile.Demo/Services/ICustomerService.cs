using System.Collections.Generic;
using System.Threading.Tasks;
using Profile.API.Demo.Models;

namespace Profile.API.Demo.Services
{
    public interface ICustomerService
    {
        /// <summary>
        /// Get all customers from repository.
        /// </summary>
        /// <returns></returns>
        Task<List<CustomerData>> GetAllCustomers();

        /// <summary>
        /// Get customer by Id.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<CustomerData> GetCustomer(long customerId);
    }
}