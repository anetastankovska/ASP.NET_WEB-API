using SEDC.WebApi.Workshop.Notes.ServiceModels.NotesModels;

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
