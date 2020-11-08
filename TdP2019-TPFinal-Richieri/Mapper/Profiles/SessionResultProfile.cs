using System;
namespace TdP2019TPFinalRichieri.Mapper.Profiles
{
    using AutoMapper;
    using Entities;
    using DTO;

    public class SessionResultProfile : Profile
    {
        public SessionResultProfile()
        {
            CreateMap<Session, SessionResultDTO>()
                .ForMember(destination => destination.Username,
                    map => map.MapFrom(source => source.User == null ? "" : source.User.Username)
                )
                .ForMember(destination => destination.Session,
                    map => map.MapFrom(source => source));
        }
    }
}
