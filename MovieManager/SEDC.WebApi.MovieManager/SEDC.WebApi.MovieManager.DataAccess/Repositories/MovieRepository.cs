using SEDC.WebApi.MovieManager.DataModels.Models;

namespace SEDC.WebApi.MovieManager.DataAccess.Repositories
{
    public class MovieRepository : IRepository<Movie>
    {
        public IEnumerable<Movie> GetAll()
        {
            return InMemoryDb.Movies;
        }

        public Movie GetById(int id)
        {
            return InMemoryDb.Movies.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Movie> FilterBy(Func<Movie, bool> filter)
        {
            return InMemoryDb.Movies.Where(filter);
        }

        public int Insert(Movie entity)
        {
            var count = InMemoryDb.Movies.Count;
            InMemoryDb.Movies.Add(entity);
            return InMemoryDb.Movies.Count - count;
        }

        public int Update(Movie entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(Movie entity)
        {
            var count = InMemoryDb.Movies.Count;
            InMemoryDb.Movies.Remove(entity);
            return InMemoryDb.Movies.Count - count;
        }
    }
}
