using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Profile.API.Demo.Models;

namespace Profile.API.Demo.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ILogger<CustomerService> _logger;
        private readonly IHostingEnvironment _hostingEnvironment;

        public CustomerService(ILogger<CustomerService> logger, IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        private Task<List<CustomerData>> LoadData()
        {
            string fileLocation = _hostingEnvironment.ContentRootPath + "\\Data\\customerData.json";
            return Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<CustomerData>>(File.ReadAllText(fileLocation), new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            }));
        }

        /// <summary>
        /// Get all customers from repository.
        /// </summary>
        /// <returns></returns>
        public async Task<List<CustomerData>> GetAllCustomers()
        {
            return await LoadData();
        }

        /// <summary>
        /// Get customer by Id.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<CustomerData> GetCustomer(long customerId)
        {
            var customerList = await LoadData();
            return customerList.FirstOrDefault(data => data.CustomerId == customerId);
        }
    }
}
