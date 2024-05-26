using Project.Pos.Pizzeria.WebApi.Common;
using Project.Pos.Pizzeria.WebApi.Domain;
using Project.Pos.Pizzeria.WebApi.DTO;
using Project.Pos.Pizzeria.WebApi.Entities;
using System.Net;

namespace Project.Pos.Pizzeria.WebApi.Command;

public class PedidosCommand
{
    readonly PedidosDomain _pedidosDomain;
    readonly StatusDomainMessage _domainMessage;
    public PedidosCommand(PedidosDomain pedidosDomain, StatusDomainMessage domainMessage)
    {
        this._domainMessage = domainMessage;
        this._pedidosDomain = pedidosDomain;
    }


    public async Task<Response<bool>> CreateOrders(PedidosView entity)
    {
        var response = new Response<bool>();
        try
        {
            var insert = await _pedidosDomain.CreateOrders(entity);
            if (insert != StatusDomain.OrderCreate)
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

    public async Task<Response<bool>> UpdateOrders(PedidosView entity)
    {
        var response = new Response<bool>();
        try
        {
            var insert = await _pedidosDomain.UpdateOrders(entity);
            if (insert != StatusDomain.OrderUpdate)
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

    public async Task<Response<bool>> DeleteOrder(PedidosView entity)
    {
        var response = new Response<bool>();
        try
        {
            var insert = await _pedidosDomain.DeleteOrder(entity);
            if (insert != StatusDomain.OrderDelete)
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
