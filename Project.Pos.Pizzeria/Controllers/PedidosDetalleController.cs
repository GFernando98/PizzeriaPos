using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Pos.Pizzeria.WebApi.DTO;
using Project.Pos.Pizzeria.WebApi.Query;

namespace Project.Pos.Pizzeria.WebApi.Controllers;

[Route("pizzeria/[controller]")]
[ApiController]
public class PedidosDetalleController : ControllerBase
{
    readonly PedidosDetailQuery _pedidosDetailQuery;
    public PedidosDetalleController(PedidosDetailQuery pedidosDetailQuery)
    {
        this._pedidosDetailQuery = pedidosDetailQuery;
    }

    [HttpGet("get-orders-by-customer")]
    public async Task<Response<List<PedidosDetalleView>>> GetOrdersDetailsByOrder([FromQuery] int orderId)
        => await _pedidosDetailQuery.GetOrdersDetailsByOrder(orderId);


}
