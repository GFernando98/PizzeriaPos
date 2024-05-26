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

    public async Task<int> InserOrderDetail(PedidosDetalle entity)
    {
        var insert = await _repository.Insert(entity);
        return insert;
    }

    public async Task<int> UpdateOrderDetail(PedidosDetalle entity)
    {
        var update = await _repository.Update(entity, entity.Id);
        return update;
    }

    public async Task<int> DeleteOrderDetail(PedidosDetalle entity)
    {
        var delete = await _repository.Delete<PedidosDetalle>(entity.Id);
        return delete;
    }

    public async Task<PedidosDetalle> GetOrderDetailById(int id)
    {
        var getOrderDetail = await _repository.Find<PedidosDetalle>(("Id", id));
        return getOrderDetail;
    }


    public async Task<List<PedidosDetalle>> GetOrderDetailByOrder(int OrderId)
    {
        var getOrderDetail = await _repository.FindAll<PedidosDetalle>(("PedidoId", OrderId));
        return getOrderDetail;
    }


}
