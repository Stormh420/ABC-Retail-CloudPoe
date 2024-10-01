using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ABC_Retail_CloudPoe.Controllers
{
    public class CustomerController : Controller
    {
        // Static list to store customer profiles in memory
        private static List<CustomerProfile> customerProfiles = new List<CustomerProfile>();
        private static int currentId = 1;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(CustomerProfile customer)
        {
            // Auto-generate ID and add customer to the list
            customer.Id = currentId++;
            customerProfiles.Add(customer);
            return RedirectToAction("ViewAllCustomerProfiles");
        }

        public IActionResult ViewAllCustomerProfiles()
        {
            return View(customerProfiles);
        }

        public IActionResult ViewCustomer(int id)
        {
            var customer = customerProfiles.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        public IActionResult UpdateCustomer(CustomerProfile updatedCustomer)
        {
            var customer = customerProfiles.FirstOrDefault(c => c.Id == updatedCustomer.Id);
            if (customer != null)
            {
                customer.Name = updatedCustomer.Name;
                customer.Email = updatedCustomer.Email;
            }
            return RedirectToAction("ViewAllCustomerProfiles");
        }

        public IActionResult DeleteCustomer(int id)
        {
            var customer = customerProfiles.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                customerProfiles.Remove(customer);
            }
            return RedirectToAction("ViewAllCustomerProfiles");
        }
    }
}

