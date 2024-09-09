using Microsoft.AspNetCore.Mvc;
using AppwithRoles.Data;
using InventoryManagementSystem.Models;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
      
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("RegisterProduct")]
        public async Task<IActionResult> RegisterProduct([FromBody] ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    ProductId = model.ProductId,
                    ProductName = model.ProductName,
                    Price = model.Price,
                    EntryDate = model.EntryDate,
                    StockQuantity = model.StockQuantity
                };

                _context.Products.Add(product);
                await _context.SaveChangesAsync(); // Save to the database

                return Ok(new { message = "Product registered successfully!" });
            }

            return BadRequest(new { message = "Invalid product data!" });
        }
         
    }

    // Data Transfer Model (Optional)
    public class ProductModel
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public DateTime EntryDate { get; set; }
        public int StockQuantity { get; set; }
    }
}
