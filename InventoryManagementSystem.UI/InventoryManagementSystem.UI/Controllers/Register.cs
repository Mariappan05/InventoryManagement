using Microsoft.AspNetCore.Mvc;
using InventoryManagementSystem.Models;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Controllers
{
    [Route("[controller]/[action]")]
    public class RegisterController : Controller
    {
        // This action method will return the Product/Index view
        public IActionResult Index()
        {
            return View();
        }
    }
}
