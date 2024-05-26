using PosPizzeria.Framework.GenericRepository.GenericRepository;
using Project.Pos.Pizzeria.WebApi.DTO;
using Project.Pos.Pizzeria.WebApi.Entities;
using System.Net;

namespace Project.Pos.Pizzeria.WebApi.Query
{
    public class ClientesQuery
    {
        readonly IRepository<SqlServerRepository> _query;
        public ClientesQuery(IRepository<SqlServerRepository> query)
        {
            this._query = query;
        }

        public async Task<Response<List<Clientes>>> GetCustomers() 
        {
            var response = new Response<List<Clientes>>();
            try
            {
                var getClientes = await _query.FindAll<Clientes>();
                if (getClientes.Count == 0) 
                {
                    response.StatusCode = (int)HttpStatusCode.NoContent;
                    response.Entity = null;
                    response.Message = "No hay clientes disponibles";
                    return response;
                }

                response.StatusCode = 200;
                response.Entity = getClientes;
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
}
