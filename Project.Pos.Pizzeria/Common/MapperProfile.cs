using AutoMapper;
using Project.Pos.Pizzeria.WebApi.DTO;
using Project.Pos.Pizzeria.WebApi.Entities;

namespace Project.Pos.Pizzeria.WebApi.Common;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<DireccionesView, Direcciones>().ReverseMap();
        CreateMap<PedidosView, Pedidos>().ReverseMap();
        CreateMap<PedidosDetalleView, PedidoDetalle>().ReverseMap();
    }
}
