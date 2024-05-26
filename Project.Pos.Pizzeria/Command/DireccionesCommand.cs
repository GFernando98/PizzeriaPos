using Project.Pos.Pizzeria.WebApi.Common;
using Project.Pos.Pizzeria.WebApi.Domain;
using Project.Pos.Pizzeria.WebApi.DTO;
using Project.Pos.Pizzeria.WebApi.Entities;
using System.Net;

namespace Project.Pos.Pizzeria.WebApi.Command;

public class DireccionesCommand
{
    readonly DireccionesDomain _direccionesDomain;
    readonly StatusDomainMessage _domainMessage;
    public DireccionesCommand(DireccionesDomain direccionesDomain, StatusDomainMessage domainMessage)
    {
        this._domainMessage = domainMessage;
        this._direccionesDomain = direccionesDomain;
    }

    public async Task<Response<bool>> CreateAddress(DireccionesView entity)
    {
        var response = new Response<bool>();
        try
        {
            var insert = await _direccionesDomain.CreateAddress(entity);
            if (insert != StatusDomain.AddressCreate)
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

    public async Task<Response<bool>> UpdateAddress(DireccionesView entity)
    {
        var response = new Response<bool>();
        try
        {
            var insert = await _direccionesDomain.UpdateAddress(entity);
            if (insert != StatusDomain.AddressUpdate)
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

    public async Task<Response<bool>> DeleteAddress(DireccionesView entity)
    {
        var response = new Response<bool>();
        try
        {
            var insert = await _direccionesDomain.DeleteAddress(entity);
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
