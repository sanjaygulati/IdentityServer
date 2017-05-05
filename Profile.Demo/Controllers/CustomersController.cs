using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Profile.API.Demo.Models;
using Profile.API.Demo.Services;

namespace Profile.API.Demo.Controllers
{
    /// <summary>
    /// Provides capability to get customer profile.
    /// </summary>
    [Route("[controller]")]
    [Authorize]
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomersController> _logger;
        private readonly IHostingEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomersController" /> class.
        /// </summary>
        /// <param name="customerService"></param>
        /// <param name="logger"></param>
        /// <param name="environment"></param>
        public CustomersController(ICustomerService customerService,ILogger<CustomersController> logger, IHostingEnvironment environment)
        {
            _customerService = customerService;
            _logger = logger;
            _environment = environment;
        }

        /// <summary>
        /// Retrieves all customers.
        /// </summary>
        [HttpGet, Route("")]
        [ProducesResponseType(typeof(IQueryable<CustomerData>), 200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var customers = await _customerService.GetAllCustomers();

                return Ok(customers);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(0, ex, $"Error when executing {0}", nameof(Get), _environment);
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Retrieve customer by customer id.
        /// </summary>
        [HttpGet, Route("id")]
        [ProducesResponseType(typeof(CustomerData), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        
        public async Task<IActionResult> Get(long id)
        {
            if (id <= 0)
            {
                return BadRequest("invalid customer Id");
            }

            try
            {
                var customers = await _customerService.GetCustomer(id);

                return Ok(customers);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(0, ex, $"Error when executing {0}", nameof(Get), _environment);
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
