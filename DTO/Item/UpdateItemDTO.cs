using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Eval_proy.Entities;

namespace Eval_proy.DTO
{
    public record UpdateItemDTO
    {
        [Required]
        public string Name {get; init;}
        [Required]
        public string Description {get; init;}
        [Required]
        public int Quantity {get; init;}
    }
}