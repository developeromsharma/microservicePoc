using Microsoft.AspNetCore.Mvc;
using UserService.Domain.Entities;
using UserService.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        //[HttpPost]
        //public async Task<ActionResult> Create(User user)
        //{
        //    await _repository.AddAsync(user);
        //    return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult> Update(int id, User updatedUser)
        //{
        //    if (id != updatedUser.Id) return BadRequest();

        //    var user = await _repository.GetByIdAsync(id);
        //    if (user == null) return NotFound();

        //    user.Username = updatedUser.Username;
           
        //    await _repository.UpdateAsync(user);
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    var user = await _repository.GetByIdAsync(id);
        //    if (user == null) return NotFound();

        //    await _repository.DeleteAsync(id);
        //    return NoContent();
        //}
    }
}
