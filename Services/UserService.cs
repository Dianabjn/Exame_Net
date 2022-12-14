using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eval_proy.Data;
using Eval_proy.DTO;
using Eval_proy.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eval_proy.Services
{
    public class UserService : IUserService
    {
        private static List<User> users = new()
        {
            new User { UserId = Guid.NewGuid(), Name = "Diana Barrientos", Email = "dbarrientos@example.com", Phone = "1234567890"},
            new User { UserId = Guid.NewGuid(), Name = "Karina Ruiz", Email = "kruiz@example.com", Phone = "0987654321"},
            new User { UserId = Guid.NewGuid(), Name = "Karla Contreras", Email = "KContreras@example.com", Phone = "1122334455"}
        };

        private readonly DataContext _context;
        public UserService (DataContext context)
        {
            _context = context;
        }

        public async Task<List<User>> CreateUser(User newUser)
        {
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return (await _context.Users.ToListAsync());

            //await Task.CompletedTask;   
        }

        public async Task DeleteUser(Guid id)
        {
            var index = users.FindIndex(existUser => existUser.UserId == id);
            users.RemoveAt(index);
            await Task.CompletedTask;
        }

        public async Task<User> GetUser(Guid id)
        {
            var user = users.Where(user => user.UserId == id).SingleOrDefault();
            return await Task.FromResult(user);
        }

        public async Task UpdateUser(User user)
        {
            var index = users.FindIndex(existUser => existUser.UserId == user.UserId);
            users[index] = user;
            await Task.CompletedTask;
        }
    }
}