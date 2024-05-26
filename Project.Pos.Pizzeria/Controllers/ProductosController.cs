using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Pos.Pizzeria.WebApi.Command;
using Project.Pos.Pizzeria.WebApi.DTO;
using Project.Pos.Pizzeria.WebApi.Entities;
using Project.Pos.Pizzeria.WebApi.Query;

namespace Project.Pos.Pizzeria.WebApi.Controllers
{
    [Route("pizzeria/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        readonly ProductosQuery _productosQuery;
        readonly ProductosCommand _productosCommand;
        public ProductosController(ProductosQuery productosQuery, ProductosCommand productosCommand)
        {
            this._productosCommand = productosCommand;
            this._productosQuery = productosQuery;
        }

        [HttpGet("get-products")]
        public async Task<Response<List<Productos>>> GetProducts()
            => await _productosQuery.GetProducts();


        [HttpPost("create-product")]
        public async Task<Response<bool>> CreateProduct(Productos entity)
            => await _productosCommand.CreateProduct(entity);

        [HttpPut("update-product")]
        public async Task<Response<bool>> UpdateProduct(Productos entity)
            => await _productosCommand.UpdateProduct(entity);

        [HttpDelete("delete-product")]
        public async Task<Response<bool>> DeleteProduct(Productos entity)
            => await _productosCommand.DeleteProduct(entity);
    }
}
