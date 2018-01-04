using AutoMapper;
using Foodinio.Core.Domain;
using Foodinio.Infrastructure.DTO;

namespace Foodinio.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
        => new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<User, UserDTO>();
            cfg.CreateMap<Address, AddressDTO>();
        })
        .CreateMapper();
    }
}