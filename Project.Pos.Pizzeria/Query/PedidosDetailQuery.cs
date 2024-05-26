using PosPizzeria.Framework.GenericRepository.GenericRepository;
using Project.Pos.Pizzeria.WebApi.DTO;
using System.Net;

namespace Project.Pos.Pizzeria.WebApi.Query;

public class PedidosDetailQuery
{
    readonly IRepository<SqlServerRepository> _query;
    public PedidosDetailQuery(IRepository<SqlServerRepository> query)
    {
        this._query = query;
    }

    public async Task<Response<List<PedidosDetalleView>>> GetOrdersDetailsByOrder(int orderId)
    {
        var response = new Response<List<PedidosDetalleView>>();
        try
        {
            var getOrdersDetail = await _query.FindAll<PedidosDetalleView>(("PedidoId", orderId));
            if (getOrdersDetail.Count == 0)
            {
                response.StatusCode = (int)HttpStatusCode.NoContent;
                response.Entity = null;
                response.Message = "No hay detalle disponibles";
                return response;
            }

            response.StatusCode = 200;
            response.Entity = getOrdersDetail;
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
