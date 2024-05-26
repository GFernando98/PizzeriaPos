using Project.Pos.Pizzeria.WebApi.Common;
using Project.Pos.Pizzeria.WebApi.Domain;
using Project.Pos.Pizzeria.WebApi.DTO;
using Project.Pos.Pizzeria.WebApi.Entities;
using System.Net;

namespace Project.Pos.Pizzeria.WebApi.Command;

public class ProductosCommand
{
    readonly ProductosDomain _productosDomain;
    readonly StatusDomainMessage _domainMessage;
    public ProductosCommand(ProductosDomain productosDomain, StatusDomainMessage domainMessage)
    {
        this._domainMessage = domainMessage;
        this._productosDomain = productosDomain;
    }

    public async Task<Response<bool>> CreateProduct(Productos entity)
    {
        var response = new Response<bool>();
        try
        {
            var insert = await _productosDomain.CreateProduct(entity);
            if (insert != StatusDomain.ProductCreate)
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

    public async Task<Response<bool>> UpdateProduct(Productos entity)
    {
        var response = new Response<bool>();
        try
        {
            var insert = await _productosDomain.UpdateProduct(entity);
            if (insert != StatusDomain.ProductUpdate)
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

    public async Task<Response<bool>> DeleteProduct(Productos entity)
    {
        var response = new Response<bool>();
        try
        {
            var insert = await _productosDomain.DeleteProduct(entity);
            if (insert != StatusDomain.ProductDelete)
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
