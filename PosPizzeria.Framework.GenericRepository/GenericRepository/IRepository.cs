namespace PosPizzeria.Framework.GenericRepository.GenericRepository;



public interface IRepository<Y> where Y : class
{
    Task<T> Find<T>();
    Task<T> Find<T>(IDictionary<string, object> parameters);
    Task<T> Find<T>(params (string, object)[] parameters);
    Task<T> Find<T>(params (string, object, RepositoryEnum)[] parameters);
    Task<T> FindBetween<T>(string column, (string, object) init, (string, object) end);
    Task<List<T>> FindAll<T>();
    Task<List<T>> FindAll<T>(IDictionary<string, object> parameters);
    Task<List<T>> FindAll<T>(params (string, object)[] parameters);
    Task<List<T>> FindAll<T>(params (string, object, RepositoryEnum)[] parameters);
    Task<List<T>> FindAllBetween<T>(string column, (string, object) init, (string, object) end);
    Task<List<T>> FindAllIn<T>((string, object[]) inside);
    Task<int> Insert<T>(T entity);
    Task<int> Update<T>(T entity, int id);
    Task<T> StoreProcedure<T>(string sp, params (string, object)[] parameters);
    Task<List<T>> StoreProcedureList<T>(string sp, params (string, object)[] parameters);
    Task<int> Delete<T>(int id);
}
