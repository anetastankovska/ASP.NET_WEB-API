using SEDC.WebApi.MovieManager.DataModels;

namespace SEDC.WebApi.MovieManager.DataAccess
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        int Insert(T entity);
        int Update(T entity);
        int Delete(int id);
        IEnumerable<T> FilterBy(Func<T, bool> filter);
    }
}
