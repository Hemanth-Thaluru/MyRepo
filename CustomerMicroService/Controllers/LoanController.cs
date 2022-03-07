using CustomerMicroService.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace CustomerMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {

        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(LoanController));
        private CustomeContext _context;
        public LoanController(CustomeContext context)
        {
            _context = context;
        }

        [HttpGet("{customerId}")]
        [Route("getCustomerLoan/{customerId}")]
        public async Task<IActionResult> getCustomerLoan(int customerId)
        {
            if (customerId == 0)
            {
                return NotFound();
            }

            var li= _context.Loans.ToList();
            List<Loan> lo= li.FindAll(a => a.CustomerId == customerId);
            var mn = JsonConvert.SerializeObject(lo);
            _log4net.Info("Loan history returned for Account Id: " + customerId);
            return Ok(mn);
        }

        [HttpGet]
        [Route("getAllLoan")]
        public async Task<IActionResult> getAllLoan()
        {
            List<Loan> lo = _context.Loans.ToList();
            var mn = JsonConvert.SerializeObject(lo);
            _log4net.Info("Loan history returned for all accounts " );
            return Ok(lo);
        }

    }
}
