using Microsoft.AspNetCore.Mvc;
using SEDC.WEBApi.Class02.App.Models;

namespace SEDC.WEBApi.Class02.App.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly List<User> _users = new List<User>()
        {
            new User
            {
                Id = 1,
                Name = "Trajan",
                Age = 33,
                Gender = "m"
            },
            new User
            {
                Id = 2,
                Name = "Vlatko",
                Age = 29,
                Gender = "m"
            },
            new User
            {
                Id = 3,
                Name = "Stefan",
                Age = 27,
                Gender = "m"
            },
            new User
            {
                Id = 4,
                Name = "Aneta",
                Age = 18,
                Gender = "f"
            },

        };

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            if (id < 1)
            {
                return BadRequest(id);
            }
            var user = _users.FirstOrDefault(x => x.Id == id);
            if(user == null)
            {
                return NotFound($"The user does not exists");
            }
            return Ok(user);
        }
        [HttpGet("name/{name}/age/{age}")]
        public ActionResult<IEnumerable<User>> GetUsersByNameAndAge(string name, int age)
        {
            var users = _users.Where(x => x.Name.
                Equals(name, StringComparison.InvariantCultureIgnoreCase))
                .Where(x => x.Age == age);
            return Ok(users);
        }
        //this route is the same as above - it identifies them as string/int
        //[HttpGet("{gender}/age/{age}")]
        [HttpGet("gender/{gender}/age/{age}")]
        public ActionResult<IEnumerable<User>> GetUsersByGenderAndAge(string gender, int age)
        {
            var users = _users.Where(x => x.Gender == gender).Where(x => x.Age < age);
            return Ok(users);
        }
    }
}
