using UsersApi.App.DataAccess.Interfaces;
using UsersApi.App.Models;
using UsersApi.App.Models.Interfaces;

namespace UsersApi.App.DataAccess
{
    public static class DataRepository 
    {
        public static List<IUser> Users { get; set; } = new List<IUser>() 
        { 
            new User
            {
                Id = 1,
                FirstName = "Aneta",
                LastName = "Stankovska",
                Age = 31,
            },
            new User
            {
                Id = 2,
                FirstName = "Trajan",
                LastName = "Stevkovski",
                Age = 34,
            },
            new User
            {
                Id = 3,
                FirstName = "Bob",
                LastName = "Bobsky",
                Age = 26,
            },
            new User
            {
                Id = 4,
                FirstName = "Pink",
                LastName = "Panther",
                Age = 12,
            },
            new User
            {
                Id = 5,
                FirstName = "Jill",
                LastName = "Wayne",
                Age = 22,
            },
            new User
            {
                Id = 6,
                FirstName = "Pink",
                LastName = "Pinky",
                Age = 18,
            }
        };

    }
}
