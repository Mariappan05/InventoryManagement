using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Collections.Generic;
using InventoryManagementSystem.Models;

namespace Inventory_Management_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("Product")]
        public IActionResult Product()
        {
            return View();
        }
        [HttpGet("Stock")]
        public IActionResult Stock()
        {
            return View();
        }
        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Rolemanagement()
        {
            return View();
        }

    }
}
