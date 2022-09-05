using SEDC.WebApi.Workshop.Notes.Common.MappingHelpers;
using SEDC.WebApi.Workshop.Notes.DataAccess;
using SEDC.WebApi.Workshop.Notes.DataModels.Models;
using SEDC.WebApi.Workshop.Notes.ServiceModels.NotesModels;
using SEDC.WebApi.Workshop.Notes.Services.Interfaces;

namespace SEDC.WebApi.Workshop.Notes.Services
{
    public class NoteService : INoteService
    {
        private readonly IRepository<Note> _noteRepository;
        private readonly IRepository<User> _userRepository;

        public NoteService(IRepository<Note> noteRepository, IRepository<User> userRepository)
        {
           _noteRepository = noteRepository;
            _userRepository = userRepository;
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

        public NoteDto GetNote(int id, int userId, string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NoteDto> GetUserNotes(int userId)
        {
            return _noteRepository
                .FilterBy(x => x.UserId == userId)
                .Select(note => note.Map());
        }

        public string AddNote(CreateNote note, int userId)
        {
            var user = _userRepository.GetById(userId);
            if(user == null)
            {
                throw new Exception("User not found");
            }
            var newNote = new Note
            {
                Text = note.Text,
                UserId = userId,
                Color = note.Color,
                Tag = note.Tag
            };

            _noteRepository.Insert(newNote);
            var url = $"http://localhost:5070/swagger/index.html{newNote.Id}/user/{newNote.UserId}";
            return url;
        }

        public void DeleteNote(int id, int userId)
        {
            var note = _noteRepository.FilterBy(x => x.Id == id && x.UserId == userId)
                .FirstOrDefault();
            if(note == null)
            {
                throw new Exception("Note not found");
            }
            _noteRepository.Delete(note);
        }
    }
}
