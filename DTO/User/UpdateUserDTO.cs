using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Eval_proy.Entities;

namespace Eval_proy.DTO
{
    public record UpdateUserDTO
    {
        [Required]
        public string Name {get; init;}
        [Required]
        public UsTyClass Class {get; init;}
        [Required]
        public string Email {get; init;}
        [Required]
        public string Phone {get; init;}
    }
}