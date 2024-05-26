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
    public class ClientesController : ControllerBase
    {
        readonly ClientesQuery _clientesQuery;
        readonly ClientesCommand _clientesCommand;
        public ClientesController(ClientesQuery clientesQuery, ClientesCommand clientesCommand)
        {
            this._clientesCommand = clientesCommand;
            this._clientesQuery = clientesQuery;
        }

        [HttpGet("get-customer")]
        public async Task<Response<List<Clientes>>> GetCustomers()
            => await _clientesQuery.GetCustomers();

        [HttpPost("create-customer")]
        public async Task<Response<bool>> CreateCustomer(Clientes entity)
            => await _clientesCommand.CreateCustomer(entity);

        [HttpPut("update-customer")]
        public async Task<Response<bool>> UpdateCustomer(Clientes entity)
            => await _clientesCommand.UpdateCustomer(entity);

        [HttpDelete("delete-customer")]
        public async Task<Response<bool>> DeleteCustomer(Clientes entity)
            => await _clientesCommand.DeleteCustomer(entity);
    }
}
