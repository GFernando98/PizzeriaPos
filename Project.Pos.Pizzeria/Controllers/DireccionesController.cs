using Microsoft.AspNetCore.Mvc;
using Project.Pos.Pizzeria.WebApi.Command;
using Project.Pos.Pizzeria.WebApi.DTO;
using Project.Pos.Pizzeria.WebApi.Entities;
using Project.Pos.Pizzeria.WebApi.Query;

namespace Project.Pos.Pizzeria.WebApi.Controllers
{
    [Route("pizzeria/[controller]")]
    [ApiController]
    public class DireccionesController : ControllerBase
    {
        readonly DireccionesQuery _direccionesQuery;
        readonly DireccionesCommand _direccionesCommand;
        public DireccionesController(DireccionesQuery direccionesQuery, DireccionesCommand direccionesCommand)
        {
            this._direccionesCommand = direccionesCommand;
            this._direccionesQuery = direccionesQuery;
        }

        [HttpGet("get-address")]
        public async Task<Response<List<DireccionesView>>> GetCustomers()
            => await _direccionesQuery.GetAddress();

        [HttpGet("get-address-by-customer")]
        public async Task<Response<List<DireccionesView>>> GetAddressByCustomer([FromQuery] int clienteId)
            => await _direccionesQuery.GetAddressByCustomer(clienteId);


        [HttpPost("create-address")]
        public async Task<Response<bool>> CreateAddress(DireccionesView entity)
            => await _direccionesCommand.CreateAddress(entity);

        [HttpPut("update-address")]
        public async Task<Response<bool>> UpdateAddress(DireccionesView entity)
            => await _direccionesCommand.UpdateAddress(entity);

        [HttpDelete("delete-address")]
        public async Task<Response<bool>> DeleteAddress(DireccionesView entity)
            => await _direccionesCommand.DeleteAddress(entity);
    }
}
