using Project.Pos.Pizzeria.WebApi.Common;
using Project.Pos.Pizzeria.WebApi.Domain;
using Project.Pos.Pizzeria.WebApi.DTO;
using System.Net;

namespace Project.Pos.Pizzeria.WebApi.Command
{
    public class PedidosDetalleCommand
    {
        readonly PedidosDetallesDomain _pedidosDetallesDomain;
        readonly StatusDomainMessage _domainMessage;
        public PedidosDetalleCommand(PedidosDetallesDomain pedidosDetallesDomain, StatusDomainMessage domainMessage)
        {
            this._domainMessage = domainMessage;
            this._pedidosDetallesDomain = pedidosDetallesDomain;
        }

        public async Task<Response<bool>> CreateOrderDetail(PedidosDetalleView entity)
        {
            var response = new Response<bool>();
            try
            {
                var insert = await _pedidosDetallesDomain.CreateOrderDetail(entity);
                if (insert != StatusDomain.OrderDetailCreate)
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

        public async Task<Response<bool>> UpdateOrderDetail(PedidosDetalleView entity)
        {
            var response = new Response<bool>();
            try
            {
                var insert = await _pedidosDetallesDomain.UpdateOrderDetail(entity);
                if (insert != StatusDomain.OrderDetailUpdate)
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

        public async Task<Response<bool>> DeleteOrderDetail(PedidosDetalleView entity)
        {
            var response = new Response<bool>();
            try
            {
                var insert = await _pedidosDetallesDomain.DeleteOrderDetail(entity);
                if (insert != StatusDomain.OrderDetailDelete)
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
