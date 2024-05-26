using PosPizzeria.Framework.GenericRepository.GenericRepository;
using Project.Pos.Pizzeria.WebApi.Entities;

namespace Project.Pos.Pizzeria.WebApi.Repository;
public class PedidosRepository
{
    readonly IRepository<SqlServerRepository> _repository;
    public PedidosRepository(IRepository<SqlServerRepository> repository)
    {
        this._repository = repository;
    }

    public async Task<int> InsertOrder(Pedidos entity)
    {
        var insert = await _repository.Insert(entity);
        return insert;
    }

    public async Task<int> UpdateOrder(Pedidos entity)
    {
        var update = await _repository.Update(entity, entity.Id);
        return update;
    }

    public async Task<int> DeleteOrder(Pedidos entity)
    {
        var delete = await _repository.Delete<Pedidos>(entity.Id);
        return delete;
    }

    public async Task<Pedidos> GetOrderById(int id)
    {
        var getOrder = await _repository.Find<Pedidos>(("Id", id));
        return getOrder;
    }

    public async Task<Pedidos> GetOrdersByCorrelative(string correlativo)
    {
        var getOrder = await _repository.Find<Pedidos>(("Correlativo", correlativo));
        return getOrder;
    }

    public async Task<List<Pedidos>> GetOrdersAll()
    {
        var getOrders = await _repository.FindAll<Pedidos>();
        return getOrders;
    }

    public async Task<List<PedidoDetalle>> GetOrderDetail(int pedidoId)
    {
        var getOrdeDetails = await _repository.FindAll<PedidoDetalle>();
        return getOrdeDetails;
    }
}
