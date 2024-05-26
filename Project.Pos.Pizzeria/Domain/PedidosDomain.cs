using AutoMapper;
using Project.Pos.Pizzeria.WebApi.Common;
using Project.Pos.Pizzeria.WebApi.DTO;
using Project.Pos.Pizzeria.WebApi.Entities;
using Project.Pos.Pizzeria.WebApi.Repository;

namespace Project.Pos.Pizzeria.WebApi.Domain;

public class PedidosDomain
{
    readonly PedidosRepository _pedidosRepository;
    readonly IMapper _mapper;
    public PedidosDomain(PedidosRepository pedidosRepository, IMapper mapper)
    {
        this._mapper = mapper;
        this._pedidosRepository = pedidosRepository;
    }

    public async Task<StatusDomain> CreateOrders(PedidosView entity)
    {
        var getOrder = await _pedidosRepository.GetOrdersByCorrelative(entity.Correlativo);
        if (getOrder != null) return StatusDomain.OrderExist;
        var mapOrder = _mapper.Map<Pedidos>(entity);
        mapOrder.Correlativo = await LastCorrelativeOrder();
        var insert = await _pedidosRepository.InsertOrder(mapOrder);
        return insert == 0 ? StatusDomain.OrderCreateError : StatusDomain.OrderCreate;
    }


    public async Task<string> LastCorrelativeOrder()
    {
        var getAllOrders = await _pedidosRepository.GetOrdersAll();
        if (getAllOrders.Count() > 0)
        {
            string lastCode = getAllOrders.OrderByDescending(x => x.Correlativo).FirstOrDefault().Correlativo;
            int nextCode = int.Parse(lastCode.Substring(1)) + 1;
            string nextCodeFormatted = nextCode.ToString().PadLeft(3, '0');
            return "000-" + nextCodeFormatted;
        }
        else
        {
            return "000-001";
        }
    }

    public async Task<StatusDomain> UpdateOrders(PedidosView entity)
    {
        var getOrder = await _pedidosRepository.GetOrdersByCorrelative(entity.Correlativo);
        if (getOrder == null) return StatusDomain.OrderNotExist;
        var mapOrder = _mapper.Map<Pedidos>(entity);
        mapOrder.Correlativo = getOrder.Correlativo;
        var update = await _pedidosRepository.UpdateOrder(mapOrder);
        return update == 0 ? StatusDomain.OrderUpdateError : StatusDomain.OrderUpdate;
    }

    public async Task<StatusDomain> DeleteOrder(PedidosView entity)
    {
        var getOrder = await _pedidosRepository.GetOrdersByCorrelative(entity.Correlativo);
        if (getOrder == null) return StatusDomain.OrderNotExist;
        var validateDetail = await ValidateDetail(getOrder.Id);
        if (validateDetail != StatusDomain.Ok) return validateDetail;
        var delete = await _pedidosRepository.DeleteOrder(getOrder);
        return delete == 0 ? StatusDomain.OrderDeleteError : StatusDomain.OrderDeleteError;
    }

    public async Task<StatusDomain> ValidateDetail(int orderId)
    {
        var getOrderDetails = await _pedidosRepository.GetOrderDetail(orderId);
        if (getOrderDetails.Count > 0) return StatusDomain.OrderDetailValidate;
        return StatusDomain.Ok;
    }
}
