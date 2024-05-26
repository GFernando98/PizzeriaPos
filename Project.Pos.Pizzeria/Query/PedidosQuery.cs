using PosPizzeria.Framework.GenericRepository.GenericRepository;
using Project.Pos.Pizzeria.WebApi.DTO;
using Project.Pos.Pizzeria.WebApi.Entities;
using System.Net;

namespace Project.Pos.Pizzeria.WebApi.Query;

public class PedidosQuery
{
    readonly IRepository<SqlServerRepository> _query;
    public PedidosQuery(IRepository<SqlServerRepository> query)
    {
        this._query = query;
    }

    public async Task<Response<List<PedidosView>>> GetOrders()
    {
        var response = new Response<List<PedidosView>>();
        try
        {
            var getOrders = await _query.FindAll<PedidosView>();
            if (getOrders.Count == 0)
            {
                response.StatusCode = (int)HttpStatusCode.NoContent;
                response.Entity = null;
                response.Message = "No hay pedidos disponibles";
                return response;
            }

            response.StatusCode = 200;
            response.Entity = getOrders;
            response.Message = "OK";
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

    public async Task<Response<List<PedidosView>>> GetOrdersByCustomer(int customerId)
    {
        var response = new Response<List<PedidosView>>();
        try
        {
            var getOrders = await _query.FindAll<PedidosView>(("ClienteId", customerId));
            if (getOrders.Count == 0)
            {
                response.StatusCode = (int)HttpStatusCode.NoContent;
                response.Entity = null;
                response.Message = "No hay pedidos disponibles";
                return response;
            }

            response.StatusCode = 200;
            response.Entity = getOrders;
            response.Message = "OK";
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
