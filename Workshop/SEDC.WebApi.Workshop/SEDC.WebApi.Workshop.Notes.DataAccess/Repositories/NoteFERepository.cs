using SEDC.WebApi.Workshop.Notes.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.WebApi.Workshop.Notes.DataAccess.Repositories
{
    public class NoteFERepository : IRepository<Note>
    {
        private readonly NotesDbContext _context;

        public NoteFERepository(NotesDbContext context)
        {
            _context = context;
        }

        public int Delete(Note entity)
        {
            _context.Notes.Remove(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public IEnumerable<Note> FilterBy(Func<Note, bool> filter)
        {
            return _context.Notes.Where(filter);
        }

        public IEnumerable<Note> GetAll()
        {
            return _context.Notes;
        }

        public Note GetById(int id)
        {
            return _context.Notes.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Note entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public int Update(Note entity)
        {
            _context.Notes.Update(entity);
            //_context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return entity.Id;
        }
    }
}
