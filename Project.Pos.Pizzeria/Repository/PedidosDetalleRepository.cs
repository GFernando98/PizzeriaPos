using PosPizzeria.Framework.GenericRepository.GenericRepository;
using Project.Pos.Pizzeria.WebApi.Entities;

namespace Project.Pos.Pizzeria.WebApi.Repository;

public class PedidosDetalleRepository
{
    readonly IRepository<SqlServerRepository> _repository;
    public PedidosDetalleRepository(IRepository<SqlServerRepository> repository)
    {
        this._repository = repository;
    }

    public async Task<int> InserOrderDetail(PedidoDetalle entity)
    {
        var insert = await _repository.Insert(entity);
        return insert;
    }

    public async Task<int> UpdateOrderDetail(PedidoDetalle entity)
    {
        var update = await _repository.Update(entity, entity.Id);
        return update;
    }

    public async Task<int> DeleteOrderDetail(PedidoDetalle entity)
    {
        var delete = await _repository.Delete<PedidoDetalle>(entity.Id);
        return delete;
    }

    public async Task<PedidoDetalle> GetOrderDetailById(int id)
    {
        var getOrderDetail = await _repository.Find<PedidoDetalle>(("Id", id));
        return getOrderDetail;
    }


    public async Task<List<PedidoDetalle>> GetOrderDetailByOrder(int OrderId)
    {
        var getOrderDetail = await _repository.FindAll<PedidoDetalle>(("PedidoId", OrderId));
        return getOrderDetail;
    }


}
