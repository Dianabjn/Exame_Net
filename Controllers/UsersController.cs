using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eval_proy.DTO;
using Eval_proy.Entities;
using Eval_proy.Services;
using Microsoft.AspNetCore.Mvc;

namespace Eval_proy.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUser(CreateUserDTO userDTO)
        {
            User user = new()
            {
                UserId = Guid.NewGuid(),
                Name = userDTO.Name,
                Class = userDTO.Class,
                Email = userDTO.Email,
                Phone = userDTO.Phone
            };
            await _service.CreateUser(user);

            return CreatedAtAction(nameof(GetUser), new{id = user.UserId}, user.AsDTO());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(Guid id)
        {
            var user = await _service.GetUser(id);
            if(user == null)
            {
                return NotFound();
            }
            return user.AsDTO();
        }

        

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(Guid id, UpdateUserDTO userDTO)
        {
            var existUser = await _service.GetUser(id);

            if(existUser is null)
            {
                return NotFound();
            }
            
            User updatedUser = existUser with{
                Name = userDTO.Name,
                Class = userDTO.Class,
                Email = userDTO.Email,
                Phone = userDTO.Phone
            };

            await _service.UpdateUser(updatedUser);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            var existUser = await _service.GetUser(id);

            if(existUser is null)
            {
                return NotFound();
            }

            await _service.DeleteUser(id);

            return NoContent();
        }

    }
}