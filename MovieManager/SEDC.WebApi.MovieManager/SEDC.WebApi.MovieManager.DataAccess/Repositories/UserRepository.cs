using SEDC.WebApi.MovieManager.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.WebApi.MovieManager.DataAccess.Repositories
{
    public class UserRepository : IRepository<User>
    {
        public IEnumerable<User> GetAll()
        {
            return InMemoryDb.Users;
        }

        public User GetById(int id)
        {
            return InMemoryDb.Users.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(User entity)
        {
            var count = InMemoryDb.Users.Count;
            InMemoryDb.Users.Add(entity);
            return InMemoryDb.Users.Count - count;
        }

        public int Update(User entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(User entity)
        {
            var count = InMemoryDb.Users.Count;
            InMemoryDb.Users.Remove(entity);
            return InMemoryDb.Users.Count - count;
        }

        public IEnumerable<User> FilterBy(Func<User, bool> filter)
        {
            return InMemoryDb.Users.Where(filter);
        }
    }
}
