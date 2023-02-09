using Microsoft.AspNetCore.Mvc;
using simple_crud_net_6.Data;
using simple_crud_net_6.Models;

namespace simple.crud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository repository;

        public UserController(IUserRepository repository)
        {
            this.repository = repository;
        }
        [HttpPost]
        public IActionResult create([FromForm] User user)
        {
            repository.create(user);
            return Ok(user);
        }

        [HttpGet]
        public IActionResult getAll()
        {
            var users = repository.getAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            var user = repository.getUserById(id);
            if (user == null)
            {
                return BadRequest("User Not Found");
            }
            return Ok(user);
        }
        [HttpPut("{id}")]
        public IActionResult update(int id, [FromForm] User user)
        {
            var data = repository.getUserById(id);
            if (user == null)
            {
                return BadRequest("User Not Found");
            }
            if (data != null)
            {
                data.firstName = user.firstName;
                data.lastName = user.lastName;
                data.email = user.email;
                data.username = user.username;
            }
            repository.update(user);
            return Ok("Success Update Data");
        }

        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            repository.delete(id);
            return Ok("Deleted");
        }
    }
}