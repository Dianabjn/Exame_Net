using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eval_proy.Entities
{
    public record Item
    {
        //Item {ItemId, Name, Description, Quantity, UserId(The user that this item belongs to)}
        public Guid ItemId {get; set;}
        public string Name {get; set;} = string.Empty;
        public string Description {get; set;} = string.Empty;
        public int Quantity {get; set;} = 0;
        public List<User>? Users {get; set;}
    }
}

//20221108-0336
//1 a 5 