using Microsoft.AspNetCore.Mvc;
using InventoryManagementSystem.Models;
using AppwithRoles.Data;
using System.Linq;

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : Controller
    {
        private readonly AppDbContext _context;

        public StockController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetStockItems")]
        public IActionResult GetStockItems()
        {
            var stockItems = _context.StockItems.ToList();
            return Ok(stockItems);
        }

        [HttpPost("SaveStock")]
        public IActionResult SaveStock([FromBody] StockItem stockItem)
        {
            if (ModelState.IsValid)
            {
                if (stockItem.Id == 0)
                {
                    _context.StockItems.Add(stockItem);
                }
                else
                {
                    var existingItem = _context.StockItems.Find(stockItem.Id);
                    if (existingItem == null)
                    {
                        return NotFound("Item not found.");
                    }

                    existingItem.ItemName = stockItem.ItemName;
                    existingItem.Category = stockItem.Category;
                    existingItem.Quantity = stockItem.Quantity;
                    existingItem.Price = stockItem.Price;

                    _context.StockItems.Update(existingItem);
                }
                _context.SaveChanges();
                return Ok(stockItem);
            }
            return BadRequest("Invalid data.");
        }

        [HttpPost("AddStockItem")]
        public IActionResult AddStockItem([FromBody] StockItem newItem)
        {
            if (ModelState.IsValid)
            {
                _context.StockItems.Add(newItem);
                _context.SaveChanges();
                return Ok(newItem);
            }
            return BadRequest("Invalid data.");
        }

        [HttpPut("EditStockItem/{id}")]
        public IActionResult EditStockItem(int id, [FromBody] StockItem updatedItem)
        {
            var existingItem = _context.StockItems.Find(id);
            if (existingItem == null)
            {
                return NotFound("Item not found.");
            }

            if (ModelState.IsValid)
            {
                existingItem.ItemName = updatedItem.ItemName;
                existingItem.Category = updatedItem.Category;
                existingItem.Quantity = updatedItem.Quantity;
                existingItem.Price = updatedItem.Price;

                _context.SaveChanges();
                return Ok(existingItem);
            }
            return BadRequest("Invalid data.");
        }

        [HttpDelete("DeleteStockItem/{id}")]
        public IActionResult DeleteStockItem(int id)
        {
            var item = _context.StockItems.Find(id);
            if (item == null)
            {
                return NotFound("Item not found.");
            }

            _context.StockItems.Remove(item);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
