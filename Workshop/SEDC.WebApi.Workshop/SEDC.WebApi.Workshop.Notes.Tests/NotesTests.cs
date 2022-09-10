using SEDC.WebApi.Workshop.Notes.DataAccess;
using SEDC.WebApi.Workshop.Notes.DataModels.Models;
using SEDC.WebApi.Workshop.Notes.ServiceModels.NotesModels;
using SEDC.WebApi.Workshop.Notes.Services;

namespace SEDC.WebApi.Workshop.Notes.Tests
{
    [TestClass]
    public class NotesTests
    {
        private Mock<IRepository<Note>> _noteRepository;
        private Mock<IRepository<User>> _userRepository;

        public NotesTests()
        {
            _noteRepository = new Mock<IRepository<Note>>();
            _userRepository = new Mock<IRepository<User>>();
        }

        [TestMethod]
        public void GetUserNotes_GetValidResponse()
        {
            // Arange
            var notes = new List<Note>
            {
                new Note
                {
                    Id = 1,
                    Color = "green",
                    Tag = 2,
                    Text = "Unit testing",
                    UserId = 1
                }
            };
            var userId = 1;

            _noteRepository.Setup(x => x.FilterBy(It.IsAny<Func<Note, bool>>()))
                .Returns(notes);

            var service = new NoteService(_noteRepository.Object, _userRepository.Object);

            // Act
            var notesDtos = service.GetUserNotes(userId);

            // Assert
            Assert.AreEqual(notes.Count, notesDtos.Count());
        }

        [TestMethod]
        public void GetUserNotes_GetInvalidResponse()
        {
            var notes = new List<Note>
            {
                new Note
                {
                    Id = 1,
                    Color = "green",
                    Tag = 2,
                    Text = "Unit testing",
                    UserId = 1
                }
            };
            var userId = 2;

            _noteRepository.Setup(x => x.FilterBy(It.IsAny<Func<Note, bool>>()))
                .Returns(notes);

            var service = new NoteService(_noteRepository.Object, _userRepository.Object);
            var result = service.GetUserNotes(userId);

            // Act
            // Assert
            Assert.AreNotEqual(notes.Count, result.Count());
            Assert.IsTrue(!result.Any());
        }

        [TestMethod]
        public void AddNote_GetValidResponse()
        {
            // Arange
            var notes = new List<Note>
            {
                new Note
                {
                    Id = 1,
                    Color = "green",
                    Tag = 2,
                    Text = "Unit testing",
                    UserId = 1
                }
            };
            var userId = 1;

            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    FirstName = "Aneta",
                    LastName = "Stankovska",
                    NoteList = new List<Note>
                    {

                    }
                }
            };

            _noteRepository.Setup(x => x.FilterBy(It.IsAny<Func<Note, bool>>()))
                .Returns(notes);

            _userRepository.Setup(x => x.GetById(userId)).Returns(users.FirstOrDefault());

            _userRepository.Setup(x => x.FilterBy(It.IsAny<Func<User, bool>>()));

            var service = new NoteService(_noteRepository.Object, _userRepository.Object);

            var newNote = new CreateNote
            {
                Text = "New text",
                Color = "red",
                Tag = 1,
            };

            service.AddNote(newNote, userId);

            // Act
            var notesDtos = service.GetUserNotes(userId);

            // Assert
            Assert.IsTrue(notesDtos.Count() == notes.Count);
        }

        [TestMethod]
        public void AddNote_GetInvalidResponse()
        {

        }

        [TestMethod]
        public void DeleteNote_GetInValidResponse()
        {

        }

        [TestMethod]
        public void DeleteNote_GetValidResponse()
        {
            // Arange
            var notes = new List<Note>
            {
                new Note
                {
                    Id = 1,
                    Color = "green",
                    Tag = 2,
                    Text = "Unit testing",
                    UserId = 1
                }
            };
            var id = 1;
            var userId = 1;

            _noteRepository.Setup(x => x.FilterBy(It.IsAny<Func<Note, bool>>()))
                .Returns(notes);

            var service = new NoteService(_noteRepository.Object, _userRepository.Object);


            service.DeleteNote(id, userId);

            // Act
            var notesDtos = service.GetUserNotes(userId);

            // Assert
            Assert.IsTrue(notesDtos.Count() > notes.Count);
        }

    }
}
