using AccountMicroservice.Model;
using CustomerMicroService.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace Retail_Bank_UI.Controllers
{

    public class AdminController : Controller
    {

        public async Task<IActionResult> Index()
        {
            Client client = new Client();
            List<Account> accounts = new List<Account>();
            try
            {
                var result = await client.APIClient().GetAsync("/gateway/Account/getAllAccounts");
                if (result.IsSuccessStatusCode)
                {
                    var account = result.Content.ReadAsStringAsync().Result;
                    accounts = JsonConvert.DeserializeObject<List<Account>>(account);
                }
                return View(accounts);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }

        public async Task<IActionResult> AllLoans()
        {
            Client client = new Client();
            List<Loan> accounts = new List<Loan>();
            try
            {
                var result = await client.APIClient().GetAsync("http://localhost:5004/api/Loan/getAllLoan");
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadAsStringAsync().Result;
                    var allLoans = JsonConvert.DeserializeObject<List<Loan>>(data);
                    return View(allLoans);
                }
                return View();
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }

            return View();
        }
    }

}
