using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEDC.WebApi.Workshop.Notes.ServiceModels.UserModels;
using SEDC.WebApi.Workshop.Notes.Services.Interfaces;

namespace SEDC.WebApi.Workshop.Notes.Controllers
{
    [ApiController]
    [Route("api/v1/controller")]
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userServce)
        {
            _userService = userServce;
        }

        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public ActionResult RegisterUser([FromBody]RegisterUser request)
        {
            try
            {
                _userService.Register(request);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public ActionResult UserLoginDto([FromBody] LoginModel request)
        {
            try
            {
                var user = _userService.Login(request);
                return Ok(user);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
