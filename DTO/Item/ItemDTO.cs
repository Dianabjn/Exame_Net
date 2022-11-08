using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eval_proy.Entities;

namespace Eval_proy.DTO
{
    public record ItemDTO
    {
        public Guid ItemId {get; init;}
        public string Name {get; init;}
        public string Description {get; init;}
        public int Quantity {get; init;}
        //public User? UserId {get; init;}
    }
}