namespace PosPizzeria.Framework.GenericRepository.GenericRepository;

public class SQLServer<T>
{
    private readonly IRepository<SqlServerRepository> _repository;

    public SQLServer(IRepository<SqlServerRepository> repository)
    {
        _repository = repository;
    }

    public async Task Create(T entity) => await _repository.Insert(entity);
    public async Task Update(T enitity, int id) => await _repository.Update(enitity, id);
    public async Task FindAll() => await _repository.FindAll<T>();
    public async Task Find() => await _repository.Find<T>();
    public async Task<List<T>> FindAll(params (string, object)[] parameters) => await _repository.FindAll<T>(parameters);
    public async Task<T> Find(params (string, object)[] parameters) => await _repository.Find<T>(parameters);
    public async Task Delete(int id) => await _repository.Delete<T>(id);
}
