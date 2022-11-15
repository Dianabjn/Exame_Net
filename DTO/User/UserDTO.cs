using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Eval_proy.Entities;

namespace Eval_proy.DTO
{
    public record UserDTO
    {
        
        public Guid UserId {get; init;}
        public string Name {get; init;}
        public UsTyClass Class {get; init;}
        public string Email {get; init;}
        public string Phone {get; init;}
        
    }
}