using Microsoft.AspNetCore.Mvc;
using UsersApi.App.DataAccess;
using UsersApi.App.DataAccess.Interfaces;
using UsersApi.App.Models.Interfaces;

namespace UsersApi.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        public List<IUser> Users { get; set; } = DataRepository.Users;        

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<IUser>> GetAllUsers()
        {
            return Ok(Users);
        }

        [HttpGet("id/{id}")]
        public ActionResult<IUser> GetUserById(int? id)
        {
            var user = Users.FirstOrDefault(x => x.Id == id);
            if(user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("firstname/{firstName}")]
        public ActionResult<IEnumerable<IUser>> GetUserByFirstName(string? firstName)
        {
            var users = Users.Where(x => x.FirstName == firstName).ToList();
            if(users.Count == 0)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpPost("addUser")]
        public ActionResult AddUser()
        {

        }

    }
}
