using Microsoft.AspNetCore.Mvc;
using ABC_Retail_CloudPoe.Models;
using System.Collections.Generic;
using System.Linq;

namespace ABC_Retail_CloudPoe.Controllers
{
    public class OrderController : Controller
    {
        private static List<Order> orders = new List<Order>(); // Store orders temporarily
        private static int orderIdCounter = 1; // Counter for generating Order IDs

        // List of products (for demonstration)
        private static List<Product> products = new List<Product>(); // Add some products for selection

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OrderMainNav()
        {
            return View();
        }

        // Display form to add an order
        public IActionResult AddOrder()
        {
            ViewBag.Customers = GetCustomerProfiles(); // Assuming you have a method to get customer profiles
            ViewBag.Products = products; // Load products for selection
            return View();
        }

        // Handle submission of the AddOrder form
        [HttpPost]
        public IActionResult AddOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                order.Id = orderIdCounter++; // Generate a new order ID
                order.TotalAmount = CalculateTotal(order.ProductIds);
                orders.Add(order); // Save the order
                return RedirectToAction("PaymentMethod", new { orderId = order.Id }); // Redirect to payment method selection
            }
            return View(order);
        }

        // Display payment method selection
        public IActionResult PaymentMethod(int orderId)
        {
            var order = orders.FirstOrDefault(o => o.Id == orderId);
            if (order == null) return NotFound();
            return View(order);
        }

        // Save payment method and redirect to OrderMainNav
        [HttpPost]
        public IActionResult SavePaymentMethod(int orderId, string paymentMethod)
        {
            var order = orders.FirstOrDefault(o => o.Id == orderId);
            if (order == null) return NotFound();
            order.PaymentMethod = paymentMethod; // Save the payment method
            return RedirectToAction("OrderMainNav");
        }

        // View all orders
        public IActionResult ViewAllOrders()
        {
            return View(orders);
        }

        // View details of a single order
        public IActionResult ViewOrder(int id)
        {
            var order = orders.FirstOrDefault(o => o.Id == id);
            if (order == null) return NotFound();
            return View(order);
        }

        // Handle editing of an order
        [HttpPost]
        public IActionResult EditOrder(Order model)
        {
            var order = orders.FirstOrDefault(o => o.Id == model.Id);
            if (order == null) return NotFound();
            order.CustomerId = model.CustomerId; // Assuming you want to update the customer as well
            order.ProductIds = model.ProductIds; // Update the selected product IDs
            order.TotalAmount = CalculateTotal(model.ProductIds); // Recalculate total amount
            return RedirectToAction("ViewAllOrders");
        }

        // Delete an order
        public IActionResult DeleteOrder(int id)
        {
            var order = orders.FirstOrDefault(o => o.Id == id);
            if (order != null)
            {
                orders.Remove(order);
            }
            return RedirectToAction("ViewAllOrders");
        }

        // Method to calculate total based on selected product IDs
        private decimal CalculateTotal(List<int> productIds)
        {
            return products.Where(p => productIds.Contains(p.Id)).Sum(p => p.Price);
        }

        // Simulated method to get customer profiles (replace with actual data retrieval logic)
        private List<string> GetCustomerProfiles()
        {
            return new List<string> { "Customer 1", "Customer 2", "Customer 3" }; // Example customer names
        }
    }
}

