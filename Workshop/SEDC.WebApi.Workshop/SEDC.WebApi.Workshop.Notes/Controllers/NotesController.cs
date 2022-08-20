﻿using Microsoft.AspNetCore.Mvc;
using SEDC.WebApi.Workshop.Notes.ServiceModels.NotesModels;
using SEDC.WebApi.Workshop.Notes.Services.Interfaces;

namespace SEDC.WebApi.Workshop.Notes.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;
        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet("user/{userId}")]
        public ActionResult<NoteDto> GetNotes(int userId)
        {
            try
            {
                var notes = _noteService.GetUserNotes(userId);
                return Ok(notes);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/user/{userId}")]
        public ActionResult<NoteDto> Get(int id, int userId)
        {
            try
            {
                var note = _noteService.GetNote(id, userId);
                return Ok(note);
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }
    }
}