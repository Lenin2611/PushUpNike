using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() // Remember adding : Profile in the class
        { // 2611
            CreateMap<Ciudad, CiudadDto>().ReverseMap();
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Departamento, DepartamentoDto>().ReverseMap();
            CreateMap<Direccion, DireccionDto>().ReverseMap();
            CreateMap<FormaPago, FormaPagoDto>().ReverseMap();
            CreateMap<Orden, OrdenDto>().ReverseMap();
            CreateMap<OrdenPedido, OrdenPedidoDto>().ReverseMap();
            CreateMap<Pago, PagoDto>().ReverseMap();
            CreateMap<Pais, PaisDto>().ReverseMap();
            CreateMap<Pedido, PedidoDto>().ReverseMap();
            CreateMap<Producto, ProductoDto>().ReverseMap();
            CreateMap<TipoProducto, TipoProductoDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<UserRegisterDto, UserDto>().ReverseMap();
        }
    }
}