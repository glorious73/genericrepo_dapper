namespace Infrastructure.GenericRepository;

public interface IGenericRepository<T>
{
    Task<T> GetById(int id);
    Task<IEnumerable<T>> GetAll();
    Task<int> CountAll();
    Task<int> Add(T entity);
    Task<int> Update(T entity);
    Task<int> Delete(T entity);
}