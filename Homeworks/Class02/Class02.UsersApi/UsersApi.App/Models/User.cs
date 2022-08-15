using UsersApi.App.Models.Interfaces;

namespace UsersApi.App.Models
{
    public class User : IUser
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
    }
}
