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
            if(entity != null)
            {
                InMemoryDb.Movies.Add(entity);
                return InMemoryDb.Movies.Count - count;
            }
            else
            {
                throw new Exception("The movie could not be added");
            };
        }

        public int Update(Movie entity)
        {
            var movie = InMemoryDb.Movies.FirstOrDefault(x => x.Id == entity.Id);
            movie.Title = entity.Title;
            movie.Year = entity.Year;
            movie.Description = entity.Description;
            movie.Genre = entity.Genre;
            movie.User = entity.User;
            movie.UserId = entity.UserId;
            
            return InMemoryDb.Movies.Count;
        }

        public int Delete(int id)
        {
            var count = InMemoryDb.Movies.Count;
            var movie = GetById(id);
            if(movie != null)
            {
                InMemoryDb.Movies.Remove(movie);
            }
            else
            {
                throw new Exception("No movie with such id found!");
            }
            return InMemoryDb.Movies.Count - count;
        }
    }
}
