using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetCoreCrud.Context;
using AspNetCoreCrud.Models;
using AspNetCoreCrud.Services;

namespace AspNetCoreCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IQueryable<User>> GetUsers()
        {
            return await this._userRepository.GetAllUsers();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = this._userRepository.GetUser(id);
            if(user == null) { return NotFound(); }
            return Ok(user);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            var userEdited = this._userRepository.EditUser(id, user);

            if(userEdited == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromBody]User user)
        { 
            var newUser = this._userRepository.AddUser(user);
            if(newUser == null)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(User user)
        {
            
            return Ok(user);
        }

        private bool UserExists(int id)
        {
            var user = this._userRepository.UserExist(id);
            if(user == null){ return false; }

            return true;
        }
    }
}
