using PosPizzeria.Framework.GenericRepository.GenericRepository;
using Project.Pos.Pizzeria.WebApi.Entities;

namespace Project.Pos.Pizzeria.WebApi.Repository;

public class DireccionesRepository
{
    readonly IRepository<SqlServerRepository> _repository;
    public DireccionesRepository(IRepository<SqlServerRepository> repository)
    {
        this._repository = repository;
    }

    public async Task<int> InsertAddress(Direcciones entity)
    {
        var insert = await _repository.Insert(entity);
        return insert;
    }

    public async Task<int> UpdateAddress(Direcciones entity)
    {
        var update = await _repository.Update(entity, entity.Id);
        return update;
    }

    public async Task<int> DeleteAddress(Direcciones entity)
    {
        var delete = await _repository.Delete<Direcciones>(entity.Id);
        return delete;
    }

    public async Task<Direcciones> GetAddressById(int id)
    {
        var geAddress = await _repository.Find<Direcciones>(("Id", id));
        return geAddress;
    }

}
