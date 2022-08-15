using UsersApi.App.Models;
using UsersApi.App.Models.Interfaces;

namespace UsersApi.App.DataAccess.Interfaces
{
    public interface IDataRepository
    {
        public List<IUser> Users { get; set; }
    }
}
