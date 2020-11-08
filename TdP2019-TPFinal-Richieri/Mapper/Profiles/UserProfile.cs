using System;
namespace TdP2019TPFinalRichieri.Mapper.Profiles
{
    using AutoMapper;
    using Entities;
    using DTO;

    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(destination => destination.Rol,
                    map => map.MapFrom(source => source.Rol.ToString())
                )
                .ForMember(destination => destination.IsAdmin,
                    map => map.MapFrom(source => UserRol.Administrator.Equals(source.Rol))
                );
        }
    }
}
