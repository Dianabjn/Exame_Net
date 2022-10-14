using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eval_proy.Entities;

namespace Eval_proy.Services
{
    public interface IItemService
    {
        //you can add, update, get, getAll, getByUser and delete an item(s
        Task AddItem(Item item);
        Task UpdateItem(Item item);
        Task<Item> GetItemById(Guid id);
        Task<IEnumerable<Item>> GetItems();
        Task<Item> GetItemByUser(User user);
        Task DeleteItem(Guid id);
    }
}