using SEDC.WebApi.Workshop.Notes.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.WebApi.Workshop.Notes.DataAccess.Repositories
{
    public class UserFERepository : IRepository<User>
    {
        private readonly NotesDbContext _context;

        public UserFERepository(NotesDbContext context)
        {
            _context = context;
        }
        public int Delete(User entity)
        {
            _context.Users.Remove(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public IEnumerable<User> FilterBy(Func<User, bool> filter)
        {
            return _context.Users.Where(filter);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(User entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public int Update(User entity)
        {
            _context.Users.Update(entity);
            //_context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return entity.Id;
        }
    }
}
