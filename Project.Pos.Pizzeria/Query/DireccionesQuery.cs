using PosPizzeria.Framework.GenericRepository.GenericRepository;
using Project.Pos.Pizzeria.WebApi.DTO;
using Project.Pos.Pizzeria.WebApi.Entities;
using System.Net;

namespace Project.Pos.Pizzeria.WebApi.Query;

public class DireccionesQuery
{
    readonly IRepository<SqlServerRepository> _query;
    public DireccionesQuery(IRepository<SqlServerRepository> query)
    {
        this._query = query;
    }

    public async Task<Response<List<DireccionesView>>> GetAddress()
    {
        var response = new Response<List<DireccionesView>>();
        try
        {
            var getAddress = await _query.FindAll<DireccionesView>();
            if (getAddress.Count == 0)
            {
                response.StatusCode = (int)HttpStatusCode.NoContent;
                response.Entity = null;
                response.Message = "No hay direcciones disponibles";
                return response;
            }

            response.StatusCode = 200;
            response.Entity = getAddress;
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

    public async Task<Response<List<DireccionesView>>> GetAddressByCustomer(int clienteId)
    {
        var response = new Response<List<DireccionesView>>();
        try
        {
            var getAddress = await _query.FindAll<DireccionesView>(("ClienteId", clienteId));
            if (getAddress.Count == 0)
            {
                response.StatusCode = (int)HttpStatusCode.NoContent;
                response.Entity = null;
                response.Message = "No hay direcciones disponibles";
                return response;
            }

            response.StatusCode = 200;
            response.Entity = getAddress;
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
