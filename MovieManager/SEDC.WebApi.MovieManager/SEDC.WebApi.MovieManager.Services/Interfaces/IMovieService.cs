using SEDC.WebApi.MovieManager.DataModels.Enums;
using SEDC.WebApi.MovieManager.ServiceModels.MovieModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.WebApi.MovieManager.Services.Interfaces
{
    public interface IMovieService
    {
        public IEnumerable<MovieDto> GetAll();
        public MovieDto GetById(int id);
        public void Insert(CreateMovieDto entity);
        public void Update(UpdateMovieDto entity);
        public void Delete(int id);
        public IEnumerable<MovieDto> FilterBy(Func<MovieDto, bool> filter);
        public IEnumerable<MovieDto> GetByUser(int userId);
    }
}
