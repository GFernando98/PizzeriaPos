using AutoMapper;
using Project.Pos.Pizzeria.WebApi.Common;
using Project.Pos.Pizzeria.WebApi.DTO;
using Project.Pos.Pizzeria.WebApi.Entities;
using Project.Pos.Pizzeria.WebApi.Repository;

namespace Project.Pos.Pizzeria.WebApi.Domain;

public class DireccionesDomain
{
    readonly DireccionesRepository _direccionesRepository;
    readonly IMapper _mapper;
    public DireccionesDomain(DireccionesRepository direccionesRepository, IMapper mapper)
    {
        this._mapper = mapper;
        this._direccionesRepository = direccionesRepository;
    }

    public async Task<StatusDomain> CreateAddress(DireccionesView entity)
    {
        var getAddress = await _direccionesRepository.GetAddressById(entity.Id);
        if (getAddress != null) return StatusDomain.AddressExist;
        var mapAddress = _mapper.Map<Direcciones>(entity);
        var insert = await _direccionesRepository.InsertAddress(mapAddress);
        return insert == 0 ? StatusDomain.AddressCreateError : StatusDomain.AddressCreate;
    }

    public async Task<StatusDomain> UpdateAddress(DireccionesView entity)
    {
        var getAddress = await _direccionesRepository.GetAddressById(entity.Id);
        if (getAddress == null) return StatusDomain.AddressNotExist;
        var mapAddress = _mapper.Map<Direcciones>(entity);
        var update = await _direccionesRepository.UpdateAddress(mapAddress);
        return update == 0 ? StatusDomain.AddressUpdateError : StatusDomain.AddressUpdate;
    }

    public async Task<StatusDomain> DeleteAddress(DireccionesView entity)
    {
        var getAddress = await _direccionesRepository.GetAddressById(entity.Id);
        if (getAddress == null) return StatusDomain.AddressNotExist;       
        var delete = await _direccionesRepository.DeleteAddress(getAddress);
        return delete == 0 ? StatusDomain.CustomerDeleteError : StatusDomain.CustomerDelete;
    }
}
