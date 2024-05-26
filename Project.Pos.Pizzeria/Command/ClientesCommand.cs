using Project.Pos.Pizzeria.WebApi.Common;
using Project.Pos.Pizzeria.WebApi.Domain;
using Project.Pos.Pizzeria.WebApi.DTO;
using Project.Pos.Pizzeria.WebApi.Entities;
using Project.Pos.Pizzeria.WebApi.Repository;
using System.Net;

namespace Project.Pos.Pizzeria.WebApi.Command
{
    public class ClientesCommand
    {
        
        readonly StatusDomainMessage _domainMessage;
        readonly ClientesDomain _clientesDomain;

        public ClientesCommand(ClientesDomain clientesDomain, StatusDomainMessage domainMessage)
        {
            this._clientesDomain = clientesDomain;
            this._domainMessage = domainMessage;
            
        }

        public async Task<Response<bool>> CreateCustomer(Clientes entity)
        {
            var response = new Response<bool>();
            try
            {
                var insert = await _clientesDomain.CreateCustomer(entity);
                if (insert != StatusDomain.CustomerCreate)
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

        public async Task<Response<bool>> UpdateCustomer(Clientes entity)
        {
            var response = new Response<bool>();
            try
            {
                var insert = await _clientesDomain.UpdateCustomer(entity);
                if (insert != StatusDomain.CustomerUpdate)
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

        public async Task<Response<bool>> DeleteCustomer(Clientes entity)
        {
            var response = new Response<bool>();
            try
            {
                var insert = await _clientesDomain.DeleteCustomer(entity);
                if (insert != StatusDomain.CustomerDelete)
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
