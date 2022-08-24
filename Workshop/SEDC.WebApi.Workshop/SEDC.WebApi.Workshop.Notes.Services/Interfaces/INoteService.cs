using SEDC.WebApi.Workshop.Notes.ServiceModels.NotesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.WebApi.Workshop.Notes.Services.Interfaces
{
    public interface INoteService
    {
        IEnumerable<NoteDto> GetUserNotes(int userId);
        NoteDto GetNote(int id, int userId);
        NoteDto GetNote(int id, int userId, string name);
        string AddNote(CreateNote note);
        void DeleteNote(int id, int userId);
    }
}
