using Microsoft.AspNetCore.Mvc;
using SEDC.WebApi.Class03.NotesApp.Models;

namespace SEDC.WebApi.Class03.NotesApp.Controllers
{


    [ApiController]
    [Route("api/v1/[controller]")]
    public class NotesController : ControllerBase
    {

        private readonly List<Note> _notes = new List<Note>()
        {
            new Note
            {
                Id = 1,
                Text = "Buy milk",
                Color = "Green",
                UserId = 1,
            },
            new Note
            {
                Id = 2,
                Text = "Walk dog",
                Color = "Orange",
                UserId= 1,
            },
            new Note
            {
                Id = 3,
                Text = "Clean floor",
                Color = "Orange",
                UserId = 1
            },
            new Note
            {
                Id = 4,
                Text = "Complete homework",
                Color = "Red",
                UserId = 1,
            }
        };


        [HttpGet]
        [Route("{id}")]
        public ActionResult<Note> GetById(int? id)
        {
            var note = _notes.FirstOrDefault(x => x.Id == id);
            if (note is null)
            {
                return NotFound("Note doesn't exist");
            }
            return Ok(note);
        }

        //[HttpGet]
        //ActionResult<IEnumerable<Note>> GetList()
        //{
        //    return Ok(_notes);
        //}

        [HttpGet]
        public ActionResult<IEnumerable<Note>> GetList([FromQuery] string? orderBy)
        {
            var a = Request;
            var b = Response;
            IEnumerable<Note> notes = _notes;
            switch (orderBy)
            {
                case "Text":
                    notes = notes.OrderBy(x => x.Text).ToList();
                    break;
                case "Color":
                    notes = notes.OrderBy(x => x.Color).ToList();
                    break;
            }
            return Ok(notes);
        }

        [HttpGet("user/{userId}/notes")]
        public ActionResult<IEnumerable<Note>> GetNotesForUser([FromRoute] int? userId, [FromQuery]SearchNotesInput input)
        {
            if (!ModelState.IsValid)
            {
                var test = "Test";
            }
            var notes = _notes.Where(x => x.UserId == userId);
            if (!string.IsNullOrWhiteSpace(input.Color))
            {
                notes = notes.Where(x => x.Color == input.Color);
            }
            switch (input.OrderBy)
            {
                case "Text":
                    notes = notes.OrderBy(x => x.Text);
                    break;
                case "Color":
                    notes = notes.OrderBy(x => x.Color);
                    break;
            }
            return Ok(notes);
        }

        [HttpGet("user/{userId}/notesForUser")]
        public ActionResult<IEnumerable<Note>> GetNotesForLoggedUser([FromRoute] int? userId, [FromHeader] int? authenticatedUser)
        {
            if(authenticatedUser is null)
            {
                return Unauthorized();
            }
            if(authenticatedUser != userId)
            {
                return StatusCode(403, "You cannot access notes for this user");
            }
            return Ok(_notes.Where(x => x.UserId == userId));
        }

    }
}
