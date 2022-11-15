using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eval_proy.DTO;
using Eval_proy.Entities;
using Microsoft.AspNetCore.Mvc;
using Eval_proy.Data;
using Microsoft.EntityFrameworkCore;
using Eval_proy.DTO.User;

namespace Eval_proy.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController (DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<UserDTO>>> CreateUser(CreateUserDTO userDTO)
        {
            User user = new()
            {
                UserId = Guid.NewGuid(),
                Name = userDTO.Name,
                Class = userDTO.Class,
                Email = userDTO.Email,
                Phone = userDTO.Phone
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(await _context.Users.ToListAsync()); 
        }

        [HttpPost]
        public async Task<ActionResult<List<UserDTO>>> AddUserItem(AddUserItemDTO userItemDTO)
        {
            var user = await _context.Users.FindAsync(userItemDTO.UserId);
            if(user == null)
            {
                return BadRequest("User not found");
            }
            var item = await _context.Items.FindAsync(userItemDTO.ItemId);
            if(item == null)
            {
                return BadRequest("Item not found");
            }

            user.Items.Add(item);
            await _context.SaveChangesAsync();
            return Ok(await _context.Users.ToListAsync()); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if(user == null)
            {
                return BadRequest("User not found");
            }
            return Ok(user);
        }

         [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetUsers()
        {
            return Ok(await _context.Users.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(Guid id, UpdateUserDTO userDTO)
        {
            var existUser = await _context.Users.FindAsync(id);

            if(existUser is null)
            {
                return NotFound();
            }
            
            existUser.Name = userDTO.Name;
            existUser.Class = userDTO.Class;
            existUser.Email = userDTO.Email;
            existUser.Phone = userDTO.Phone;

            await _context.SaveChangesAsync();
            return Ok(); 
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            var existUser = await _context.Users.FindAsync(id);

            if(existUser is null)
            {
                return NotFound();
            }

            _context.Users.Remove(existUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}