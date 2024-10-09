using AutoMapper;
using ProjPedidos.Application.Common.Models.Pedido;
using ProjPedidos.Application.Common.Models.User;

namespace ProjPedidos.Application.Common.Mappings;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<Pedido, PedidoDTO>().ReverseMap();
        CreateMap<ItensPedido, ItensPedidoDTO>().ReverseMap();

        CreateMap<User, UserSignInRequest>().ReverseMap();
        CreateMap<User, UserSignInResponse>().ReverseMap();
        CreateMap<User, UserSignUpRequest>().ReverseMap();
        CreateMap<User, UserSignUpResponse>().ReverseMap();
        CreateMap<User, UserProfileResponse>().ReverseMap();
    }
}
