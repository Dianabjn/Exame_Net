using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Eval_proy.DTO;
using Eval_proy.Entities;
using Eval_proy.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/*172298042*/

namespace Eval_proy.Services
{
    public class ItemService : IItemService
    {
        private static List<Item> items = new()
        {
            new Item { ItemId = Guid.NewGuid(), Name = "Potion", Description = "strong potion", Quantity = 1},
            new Item { ItemId = Guid.NewGuid(), Name = "Iron Sword", Description = "weak iron sword", Quantity = 2},
            new Item { ItemId = Guid.NewGuid(), Name = "Bronze Shield", Description = "best bronze shield", Quantity = 3}
        };

        private readonly DataContext _context;
        public ItemService (DataContext context)
        {
            _context = context;
        }

        public async Task AddItem(Item item)
        {
            items.Add(item);
            await Task.CompletedTask;
            /*
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return (await _context.Items.ToListAsync());*/
        }

        public async Task DeleteItem(Guid id)
        {
            var index = items.FindIndex(existItem => existItem.ItemId == id);
            items.RemoveAt(index);
            await Task.CompletedTask;
        }

        public async Task<Item> GetItemById(Guid id)
        {
            var item = items.Where(item => item.ItemId == id).SingleOrDefault();
            return await Task.FromResult(item);
        }

        public async Task<List<Item>> GetItemByUser(Guid id)
        {
            /*var item = new <List<ItemDTO>>();
            item.Data = await items.Where(item => item.UserId.UserId == id).SingleOrDefault();
            return item;*/
            throw new NotImplementedException();
        }

        public async Task<List<Item>> GetItems()
        {       
            return  await Task.FromResult(items);
        }

        public async Task UpdateItem(Item item)
        {
            var index = items.FindIndex(existItem => existItem.ItemId == item.ItemId);
            items[index] = item;
            await Task.CompletedTask;
        }
    }
}