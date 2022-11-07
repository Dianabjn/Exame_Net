using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eval_proy.DTO;
using Eval_proy.Entities;
using Eval_proy.Services;
using Microsoft.AspNetCore.Mvc;

namespace Eval_proy.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {

        private readonly IItemService _serviceItem;

        public ItemsController(IItemService serviceItem)
        {
            _serviceItem = serviceItem;
        }

        [HttpPost]
        public async Task<ActionResult<ItemDTO>> CreateItem(CreateItemDTO itemDTO)
        {
            Item item = new()
            {
                ItemId = Guid.NewGuid(),
                Name = itemDTO.Name,
                Description = itemDTO.Description,
                Quantity = itemDTO.Quantity,
                
            };
            await _serviceItem.AddItem(item);

            return CreatedAtAction(nameof(GetItemById), new{id = item.ItemId}, item.IAsDTO());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDTO>> GetItemById(Guid id)
        {
            var item = await _serviceItem.GetItemById(id);
            if(item == null)
            {
                return NotFound();
            }
            return item.IAsDTO();
        }

        [HttpGet]
        public async Task<IEnumerable<ItemDTO>> GetItems()
        {
            var items = (await _serviceItem.GetItems())
                            .Select(item => item.IAsDTO());
            return items;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItem(Guid id, UpdateItemDTO itemDTO)
        {
            var existItem = await _serviceItem.GetItemById(id);

            if(existItem is null)
            {
                return NotFound();
            }
            
            Item updatedItem = existItem with{
                Name = itemDTO.Name,
                Description = itemDTO.Description,
                Quantity = itemDTO.Quantity
            };

            await _serviceItem.UpdateItem(updatedItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(Guid id)
        {
            var existItem = await _serviceItem.GetItemById(id);

            if(existItem is null)
            {
                return NotFound();
            }

            await _serviceItem.DeleteItem(id);

            return NoContent();
        }

    }
}