using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Pos.Pizzeria.WebApi.Command;
using Project.Pos.Pizzeria.WebApi.DTO;
using Project.Pos.Pizzeria.WebApi.Entities;

namespace Project.Pos.Pizzeria.WebApi.Controllers
{
    [Route("pizzeria/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        readonly UsuariosCommand _usuariosCommand;
        public UsuariosController(UsuariosCommand usuariosCommand)
        {
            this._usuariosCommand = usuariosCommand;
        }

        [HttpPost("create-user")]
        public async Task<Response<bool>> CreateUser(Usuarios entity)
            => await _usuariosCommand.CreateUser(entity);

        [HttpPut("update-user")]
        public async Task<Response<bool>> UpdateUser(Usuarios entity)
            => await _usuariosCommand.UpdateUser(entity);

    }
}
