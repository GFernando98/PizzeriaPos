using PosPizzeria.Framework.GenericRepository.GenericRepository;
using Project.Pos.Pizzeria.WebApi.DTO;
using Project.Pos.Pizzeria.WebApi.Entities;
using System.Net;

namespace Project.Pos.Pizzeria.WebApi.Query;

public class ProductosQuery
{
    readonly IRepository<SqlServerRepository> _query;
    public ProductosQuery(IRepository<SqlServerRepository> query)
    {
        this._query = query;
    }

    public async Task<Response<List<Productos>>> GetProducts()
    {
        var response = new Response<List<Productos>>();
        try
        {
            var getProducts = await _query.FindAll<Productos>();
            if (getProducts.Count == 0)
            {
                response.StatusCode = (int)HttpStatusCode.NoContent;
                response.Entity = null;
                response.Message = "No hay productos disponibles";
                return response;
            }

            response.StatusCode = 200;
            response.Entity = getProducts;
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
