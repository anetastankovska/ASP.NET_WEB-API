using SEDC.WebApi.MovieManager.DataModels;
using SEDC.WebApi.MovieManager.DataModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.WebApi.MovieManager.DataAccess.GenericRepository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public int Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FilterBy(Func<T, bool> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public int Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
