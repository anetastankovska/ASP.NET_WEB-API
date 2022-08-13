using Microsoft.AspNetCore.Mvc;

namespace SEDC.WEBApi.Class02.App.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FirstController : ControllerBase
    {
        private List<string> _names = new List<string>
        {
            "Trajan",
            "Vlatko",
            "Aneta",
            "Stefan"
        };

        [HttpGet]
        public int GetRandomInteger()
        {
            return 1;
        }

        [HttpGet("name/{id}")]
        public ActionResult GetName(int id)
        {
            try
            {
                var name = _names[id];
                return Ok(name);
            }
            catch (Exception)
            {
                return NotFound();
            };
        }
    }
}
