
using HelwanUniversity.Core.Helpers;


namespace HelwanUniversity.Core.Contracts.Repositories;
public interface IBaseRepository<T> where T : class
{
    Response<List<T>> GetAll();
    Response<T> GetById(int id);
    Response<T> Insert(T item);
    Response<T> Edit(T item);
    Response<T> Delete(int id);
}