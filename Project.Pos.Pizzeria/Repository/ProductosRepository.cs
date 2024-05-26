using PosPizzeria.Framework.GenericRepository.GenericRepository;
using Project.Pos.Pizzeria.WebApi.Entities;

namespace Project.Pos.Pizzeria.WebApi.Repository;

public class ProductosRepository
{
    readonly IRepository<SqlServerRepository> _repository;
    public ProductosRepository(IRepository<SqlServerRepository> repository)
    {
        this._repository = repository;
    }

    public async Task<int> InsertProduct(Productos entity)
    {
        var insert = await _repository.Insert(entity);
        return insert;
    }

    public async Task<int> UpdateProduct(Productos entity)
    {
        var update = await _repository.Update(entity, entity.Id);
        return update;
    }

    public async Task<int> DeleteProduct(Productos entity)
    {
        var delete = await _repository.Delete<Productos>(entity.Id);
        return delete;
    }

    public async Task<Productos> GetProductByCode(Productos entity)
    {
        var getProduct = await _repository.Find<Productos>(("Codigo", entity.Codigo));
        return getProduct;
    }

    public async Task<List<Productos>> GetProductAll()
    {
        var getProducts = await _repository.FindAll<Productos>();
        return getProducts;
    }
}
