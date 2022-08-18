﻿using SEDC.WebApi.Workshop.Notes.Common.MappingHelpers;
using SEDC.WebApi.Workshop.Notes.DataAccess;
using SEDC.WebApi.Workshop.Notes.DataModels.Models;
using SEDC.WebApi.Workshop.Notes.ServiceModels.Enums;
using SEDC.WebApi.Workshop.Notes.ServiceModels.NotesModels;
using SEDC.WebApi.Workshop.Notes.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.WebApi.Workshop.Notes.Services
{
    public class NoteService : INoteService
    {
        private readonly IRepository<Note> _noteRepository;

        public NoteService(IRepository<Note> noteRepository)
        {
           _noteRepository = noteRepository;
        }
        public NoteDto GetNote(int id, int userId)
        {
            var note = _noteRepository
                .FilterBy(x => x.Id == id && x.UserId == userId)
                .FirstOrDefault();

            if(note == null)
            {
                throw new Exception("Note not found");
            }

            return note.Map();
        }

        public IEnumerable<NoteDto> GetUserNotes(int userId)
        {
            return _noteRepository
                .FilterBy(x => x.UserId == userId)
                .Select(note => note.Map());
        }
    }
}
