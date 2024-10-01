using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ABC_Retail_CloudPoe.Models;

namespace ABC_Retail_CloudPoe.Controllers
{
    public class ProductController : Controller
    {
        // Temporary in-memory product list to store data during the application's runtime
        private static List<Product> products = new List<Product>();

        public IActionResult Index()
        {
            return View();
        }

        // Main navigation view for products
        public IActionResult ProductMainNav()
        {
            return View("~/Views/Product/ProductMainNav.cshtml");
        }

        // Display the add product form
        public IActionResult AddProducts()
        {
            return View();
        }

        // Handle the submission of the add product form
        [HttpPost]
        public IActionResult AddProducts(Product model)
        {
            if (ModelState.IsValid)
            {
                // Generate an ID for the new product
                model.Id = products.Count > 0 ? products.Max(p => p.Id) + 1 : 1;
                products.Add(model);
                return RedirectToAction("ViewAllProducts");
            }
            return View(model);
        }

        // Display all products
        public IActionResult ViewAllProducts()
        {
            return View(products);
        }

        // View details for a single product
        public IActionResult ViewProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // Handle editing of a product in the same view as single product view
        [HttpPost]
        public IActionResult EditProduct(Product model)
        {
            var product = products.FirstOrDefault(p => p.Id == model.Id);
            if (product == null)
            {
                return NotFound();
            }
            product.Name = model.Name;
            product.Price = model.Price;
            product.ImageUrl = model.ImageUrl;
            return RedirectToAction("ViewAllProducts");
        }

        // Delete a product
        public IActionResult DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                products.Remove(product);
            }
            return RedirectToAction("ViewAllProducts");
        }
    }

   
}

