using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eval_proy.Entities;

namespace Eval_proy.DTO
{
    public record ItemDTO
    {
        public Guid ItemId {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public int Quantity {get; set;}
        public User? UserId {get; set;}
    }
}