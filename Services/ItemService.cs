using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eval_proy.Entities;

namespace Eval_proy.Services
{
    public class ItemService : IItemService
    {
        public Task AddItem(Item item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetItemById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetItemByUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Item>> GetItems()
        {
            throw new NotImplementedException();
        }

        public Task UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}