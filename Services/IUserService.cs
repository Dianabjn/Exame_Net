using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eval_proy.DTO;
using Eval_proy.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Eval_proy.Services
{
    public interface IUserService
    {
        //The user will create, get, update and delete a user 
        Task<List<User>> CreateUser(User newUser);
        Task<User> GetUser(Guid id);
        Task UpdateUser(User user);
        Task DeleteUser(Guid id);
    }
}