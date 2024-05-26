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
            entity.Total = ((entity.Cantidad * entity.PrecioUnitario) * (entity.Impuesto / 100));
            await UpdateTotalOrder(entity.PedidoId);
            var mapOrderDetail = _mapper.Map<PedidoDetalle>(entity);
            var insert = await _pedidosDetalleRepository.InserOrderDetail(mapOrderDetail);
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

            entity.Total = ((entity.Cantidad * entity.PrecioUnitario) * (entity.Impuesto / 100));
            await UpdateTotalOrder(entity.PedidoId);
            var mapOrderDetail = _mapper.Map<PedidoDetalle>(entity);

            var update = await _pedidosDetalleRepository.UpdateOrderDetail(mapOrderDetail);
            return update == 0 ? StatusDomain.OrderDetailUpdateError : StatusDomain.OrderDetailUpdate;
        }

        public async Task<StatusDomain> DeleteCustomer(PedidosDetalleView entity)
        {
            var getCustomer = await _clientesRepository.GetCustomersById(entity);
            if (getCustomer == null) return StatusDomain.UserNotExist;

            var delete = await _clientesRepository.DeleteCustomers(getCustomer);
            return delete == 0 ? StatusDomain.CustomerDeleteError : StatusDomain.CustomerDelete;
        }
    }
}
