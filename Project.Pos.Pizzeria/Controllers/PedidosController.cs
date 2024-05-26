using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Pos.Pizzeria.WebApi.Command;
using Project.Pos.Pizzeria.WebApi.DTO;
using Project.Pos.Pizzeria.WebApi.Entities;
using Project.Pos.Pizzeria.WebApi.Query;

namespace Project.Pos.Pizzeria.WebApi.Controllers
{
    [Route("pizzeria/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        readonly PedidosQuery _pedidosQuery;
        readonly PedidosCommand _pedidosCommand;
        public PedidosController(PedidosQuery pedidosQuery, PedidosCommand pedidosCommand)
        {
            this._pedidosCommand = pedidosCommand;
            this._pedidosQuery = pedidosQuery;
        }

        [HttpGet("get-orders")]
        public async Task<Response<List<PedidosView>>> GetOrders()
            => await _pedidosQuery.GetOrders();

        [HttpGet("get-orders-by-customer")]
        public async Task<Response<List<PedidosView>>> GetOrdersByCustomer([FromQuery] int customerId)
            => await _pedidosQuery.GetOrdersByCustomer(customerId);

        [HttpPost("create-order")]
        public async Task<Response<bool>> CreateOrders(PedidosView entity)
            => await _pedidosCommand.CreateOrders(entity);

        [HttpPut("update-order")]
        public async Task<Response<bool>> UpdateOrders(PedidosView entity)
            => await _pedidosCommand.UpdateOrders(entity);

        [HttpDelete("delete-order")]
        public async Task<Response<bool>> DeleteOrder(PedidosView entity)
            => await _pedidosCommand.DeleteOrder(entity);
    }
}
