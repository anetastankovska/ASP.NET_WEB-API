using SEDC.WebApi.Workshop.Notes.DataAccess;
using SEDC.WebApi.Workshop.Notes.DataModels.Models;
using SEDC.WebApi.Workshop.Notes.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.WebApi.Workshop.Notes.Tests
{
    [TestClass]
    public class NotesTests
    {
        private Mock<IRepository<Note>> _noteRepository;
        private Mock<IRepository<User>> _userRepository;

        public NotesTests(Mock<IRepository<Note>> noteRepository, Mock<IRepository<User>> userRepository)
        {
            _noteRepository = noteRepository;
            _userRepository = userRepository;
        }

        [TestMethod]
        public void GetUserNotes_GetValidResponse()
        {
            var notes = new List<Note>
            {
                new Note
                {
                    Id = 1,
                    Color = "Green",
                    Tag = 2,
                    Text = "Unit testing",
                    UserId = 1
                }
            };
            var userId = 1;

            _noteRepository.Setup(x => x.FilterBy(It.IsAny < Func < Note, bool>>()))
                .Returns(notes);

            var service = new NoteService(_noteRepository.Object, _userRepository.Object);

            //Act
            var notesDtos = service.GetUserNotes(userId);

            //Assert
            Assert.AreEqual(notes.Count, notesDtos.Count());
        }
    }
}
