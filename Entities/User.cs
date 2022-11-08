using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eval_proy.Entities
{
    public record User
    {
        //User need
        //{UserId, Name, UserType(Enum), Email, Phone}

        public Guid UserId {get; set;}
        public string Name {get; set;} = string.Empty;
        public UsTyClass Class {get; set;} = UsTyClass.General;
        public string Email {get; set;} = string.Empty;
        public string Phone {get; set;} = string.Empty;
        //public List<Item>? Items {get; set;}
    }
}