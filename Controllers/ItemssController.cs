using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eval_proy.Data;
using Eval_proy.DTO;
using Eval_proy.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eval_proy.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly DataContext _context;
        public ItemsController (DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> CreateItem(CreateItemDTO itemDTO)
        {
            var user = await _context.Users.FindAsync(itemDTO.UsId);

            if(user == null)
            {
                return BadRequest("User not found");
            }

            Item item = new()
            {
                ItemId = Guid.NewGuid(),
                Name = itemDTO.Name,
                Description = itemDTO.Description,
                Quantity = itemDTO.Quantity
            };
            _context.Items.Add(item);
            user.Items.Add(item);
            await _context.SaveChangesAsync();
            return Ok(); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDTO>> GetItem(Guid id)
        {
            var item = await _context.Items.FindAsync(id);
            if(item == null)
            {
                return BadRequest("Item not found");
            }
            return Ok(item);
        }
        
        [HttpGet]
        public async Task<ActionResult<List<ItemDTO>>> GetItems()
        {
            return Ok(await _context.Items.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItem(Guid id, UpdateItemDTO itemDTO)
        {
            var existItem = await _context.Items.FindAsync(id);

            if(existItem is null)
            {
                return NotFound();
            }

            existItem.Name = itemDTO.Name;
            existItem.Description = itemDTO.Description;
            existItem.Quantity = itemDTO.Quantity;

            await _context.SaveChangesAsync();
            return Ok(); 
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(Guid id)
        {
            var existItem = await _context.Items.FindAsync(id);

            if(existItem is null)
            {
                return NotFound();
            }

            _context.Items.Remove(existItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}