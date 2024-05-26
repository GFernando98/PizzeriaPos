using Project.Pos.Pizzeria.WebApi.Domain;
using Project.Pos.Pizzeria.WebApi.DTO;
using Project.Pos.Pizzeria.WebApi.Entities;
using Project.Pos.Pizzeria.WebApi.Common;
using System.Net;

namespace Project.Pos.Pizzeria.WebApi.Command
{
    public class UsuariosCommand
    {
        readonly UsuariosDomain _usuariosDomain;
        readonly StatusDomainMessage _domainMessage;
        public UsuariosCommand(UsuariosDomain usuariosDomain, StatusDomainMessage domainMessage)
        {
            this._domainMessage = domainMessage;
            this._usuariosDomain = usuariosDomain;
        }

        public async Task<Response<bool>> CreateUser(Usuarios entity)
        {
            var response = new Response<bool>();
            try
            {
                var insert = await _usuariosDomain.CreateUser(entity);
                if (insert != StatusDomain.UserCreate)
                {
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.Entity = false;
                    response.Message = _domainMessage.GetMessage(insert);                
                    return response;
                }

                response.StatusCode = 200;
                response.Entity = true;
                response.Message = _domainMessage.GetMessage(insert);
                return response;
            }
            catch (Exception e)
            {
                response.StatusCode = 500;
                response.Error = e.Message;
                response.Message = "Error";
                return response;
            }
        }

        public async Task<Response<bool>> UpdateUser(Usuarios entity)
        {
            var response = new Response<bool>();
            try
            {
                var insert = await _usuariosDomain.UpdateUser(entity);
                if (insert != StatusDomain.UserUpdate)
                {
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.Entity = false;
                    response.Message = _domainMessage.GetMessage(insert);
                    return response;
                }

                response.StatusCode = 200;
                response.Entity = true;
                response.Message = _domainMessage.GetMessage(insert);
                return response;
            }
            catch (Exception e)
            {
                response.StatusCode = 500;
                response.Error = e.Message;
                response.Message = "Error";
                return response;
            }
        }

    }
}
