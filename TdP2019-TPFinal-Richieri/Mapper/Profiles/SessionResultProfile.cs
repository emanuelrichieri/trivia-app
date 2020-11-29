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
                .ForMember(destination => destination.Score,
                    map => map.MapFrom(source => source.Score))
                .ForMember(destination => destination.Time,
                    map => map.MapFrom(source => source.GetTime()))
                .ForMember(destination => destination.Date,
                    map => map.MapFrom(source => source.Date));
        }
    }
}
