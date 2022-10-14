using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eval_proy.DTO;
using Eval_proy.Entities;

namespace Eval_proy
{
    public static class Extensions
    {
        public static UserDTO AsDTO(this User user)
        {
            return new UserDTO
            {
                UserId = user.UserId,
                Name = user.Name,
                Class = user.Class,
                Email = user.Email,
                Phone = user.Phone
            };
        }
    }
}