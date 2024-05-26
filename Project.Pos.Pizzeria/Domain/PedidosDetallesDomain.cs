using AutoMapper;
using Project.Pos.Pizzeria.WebApi.Common;
using Project.Pos.Pizzeria.WebApi.DTO;
using Project.Pos.Pizzeria.WebApi.Entities;
using Project.Pos.Pizzeria.WebApi.Repository;

namespace Project.Pos.Pizzeria.WebApi.Domain
{
    public class PedidosDetallesDomain
    {
        readonly PedidosDetalleRepository _pedidosDetalleRepository;
        readonly IMapper _mapper;
        readonly PedidosRepository _pedidosRepository;
        public PedidosDetallesDomain(PedidosDetalleRepository pedidosDetalleRepository, IMapper mapper, PedidosRepository pedidosRepository)
        {
            this._pedidosRepository = pedidosRepository;
            this._mapper = mapper;
            this._pedidosDetalleRepository = pedidosDetalleRepository;
        }


        public async Task<StatusDomain> CreateOrderDetail(PedidosDetalleView entity)
        {
            var getOrderDetail = await _pedidosDetalleRepository.GetOrderDetailById(entity.Id);
            if (getOrderDetail != null) return StatusDomain.OrderDetailExist;
            entity.Total = ((entity.Cantidad * entity.PrecioUnitario) * (entity.Impuesto / 100) + (entity.Cantidad * entity.PrecioUnitario));            
            var mapOrderDetail = _mapper.Map<PedidosDetalle>(entity);
            var insert = await _pedidosDetalleRepository.InserOrderDetail(mapOrderDetail);
            await UpdateTotalOrder(entity.PedidoId);
            return insert == 0 ? StatusDomain.OrderDetailCreateError : StatusDomain.OrderDetailCreate;
        }

        public async Task UpdateTotalOrder(int orderId) 
        {
            var getOrdersDetail = await _pedidosDetalleRepository.GetOrderDetailByOrder(orderId);
            if(getOrdersDetail.Count > 0)
            {
                var getOrder = await _pedidosRepository.GetOrderById(orderId);
                getOrder.TotalPedido = getOrdersDetail.Sum(x => x.Total);
                await _pedidosRepository.UpdateOrder(getOrder);
            }
        }

        public async Task<StatusDomain> UpdateOrderDetail(PedidosDetalleView entity)
        {
            var getOrderDetail = await _pedidosDetalleRepository.GetOrderDetailByOrder(entity.Id);
            if (getOrderDetail == null) return StatusDomain.OrderDetailNotExist;

            entity.Total = ((entity.Cantidad * entity.PrecioUnitario) * (entity.Impuesto / 100) + (entity.Cantidad * entity.PrecioUnitario));
            var mapOrderDetail = _mapper.Map<PedidosDetalle>(entity);

            var update = await _pedidosDetalleRepository.UpdateOrderDetail(mapOrderDetail);
            await UpdateTotalOrder(entity.PedidoId);
            return update == 0 ? StatusDomain.OrderDetailUpdateError : StatusDomain.OrderDetailUpdate;
        }

        public async Task<StatusDomain> DeleteOrderDetail(PedidosDetalleView entity)
        {
            var getOrderDetail = await _pedidosDetalleRepository.GetOrderDetailByOrder(entity.Id);
            if (getOrderDetail == null) return StatusDomain.OrderDetailNotExist;
            var mapOrderDetail = _mapper.Map<PedidosDetalle>(entity);
            var delete = await _pedidosDetalleRepository.DeleteOrderDetail(mapOrderDetail);
            await UpdateTotalOrder(entity.PedidoId);
            return delete == 0 ? StatusDomain.OrderDetailDeleteError : StatusDomain.OrderDetailDelete;
        }
    }
}
