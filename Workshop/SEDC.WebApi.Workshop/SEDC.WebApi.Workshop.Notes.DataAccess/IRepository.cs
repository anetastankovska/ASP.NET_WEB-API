using SEDC.WebApi.Workshop.Notes.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.WebApi.Workshop.Notes.DataAccess
{
    public interface IRepository<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        int Insert(T entity);
        int Update(T entity);
        int Delete(T entity);
        IEnumerable<T> FilterBy(Func<T, bool> filter);
        
    }
}
