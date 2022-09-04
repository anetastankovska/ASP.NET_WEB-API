using SEDC.WebApi.MovieManager.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.WebApi.MovieManager.DataAccess.Repositories
{
    public class MovieEFRepository : IRepository<Movie>
    {
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> FilterBy(Func<Movie, bool> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetAll()
        {
            throw new NotImplementedException();
        }

        public Movie GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Movie entity)
        {
            throw new NotImplementedException();
        }

        public int Update(Movie entity)
        {
            throw new NotImplementedException();
        }
    }
}
