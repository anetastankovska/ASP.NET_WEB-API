using SEDC.WebApi.MovieManager.DataModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.WebApi.MovieManager.DataAccess
{
    public interface IRepository<T>
    {
        public IEnumerable<T> GetAll();
        public T GetById(int id);
        public int Insert(T entity);
        public int Update(T entity);
        public int Delete(T entity);
        public IEnumerable<T> FilterBy(Func<T, bool> filter);
    }
}
