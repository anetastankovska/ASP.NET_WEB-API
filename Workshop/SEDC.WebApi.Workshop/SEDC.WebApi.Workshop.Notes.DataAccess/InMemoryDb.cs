using SEDC.WebApi.Workshop.Notes.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.WebApi.Workshop.Notes.DataAccess
{
    public static class InMemoryDb
    {
        public static List<User> Users { get; set; } = new List<User>
        {
            new User
            {
                Id = 1,
                FirstName = "Aneta",
                LastName = "Stankovska",
                NoteList = new List<Note>(),
                Password = "12345",
                Username = "astankovska"
            },
            new User
            {
                Id = 2,
                FirstName = "Bob",
                LastName = "Bobsky",
                NoteList = new List<Note>(),
                Password = "54321",
                Username = "bbobsky"
            }
        };

        public static List<Note> Notes { get; set; } = new List<Note>
        {
            new Note
            {
                Id = 1,
                Color = "Orange",
                Tag = 1,
                User = new User()
                {
                    Id = 1,
                    FirstName = "Aneta",
                    LastName = "Stankovska",
                    NoteList = new List<Note>(),
                    Password = "12345",
                    Username = "astankovska"
                },
                UserId = 1
            },

            new Note
            {
                Id = 2,
                Color = "Green",
                Tag = 2,
                User = new User()
                {
                    Id = 1,
                    FirstName = "Aneta",
                    LastName = "Stankovska",
                    NoteList = new List<Note>(),
                    Password = "12345",
                    Username = "astankovska"
                },
                UserId = 1
            }
        };
    }
}
