using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Pos.Pizzeria.WebApi.Command;
using Project.Pos.Pizzeria.WebApi.DTO;
using Project.Pos.Pizzeria.WebApi.Query;

namespace Project.Pos.Pizzeria.WebApi.Controllers;

[Route("pizzeria/[controller]")]
[ApiController]
public class PedidosDetalleController : ControllerBase
{
    readonly PedidosDetailQuery _pedidosDetailQuery;
    readonly PedidosDetalleCommand _pedidosDetalleCommand;
    public PedidosDetalleController(PedidosDetailQuery pedidosDetailQuery, PedidosDetalleCommand pedidosDetalleCommand)
    {
        this._pedidosDetalleCommand = pedidosDetalleCommand;
        this._pedidosDetailQuery = pedidosDetailQuery;
    }

    [HttpGet("get-orders-by-customer")]
    public async Task<Response<List<PedidosDetalleView>>> GetOrdersDetailsByOrder([FromQuery] int orderId)
        => await _pedidosDetailQuery.GetOrdersDetailsByOrder(orderId);

    [HttpPost("create-order-detail")]
    public async Task<Response<bool>> CreateOrderDetail(PedidosDetalleView entity)
    => await _pedidosDetalleCommand.CreateOrderDetail(entity);

    [HttpPut("update-order-detail")]
    public async Task<Response<bool>> UpdateOrderDetail(PedidosDetalleView entity)
        => await _pedidosDetalleCommand.UpdateOrderDetail(entity);

    [HttpDelete("delete-order-detail")]
    public async Task<Response<bool>> DeleteOrderDetail(PedidosDetalleView entity)
        => await _pedidosDetalleCommand.DeleteOrderDetail(entity);
}
