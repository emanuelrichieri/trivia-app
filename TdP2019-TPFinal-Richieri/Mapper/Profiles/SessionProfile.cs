using System;
using AutoMapper;
namespace TdP2019TPFinalRichieri.Mapper.Profiles
{
    using Entities;
    using DTO;

    public class SessionProfile : Profile
    {
        public SessionProfile()
        {
            CreateMap<Session, SessionDTO>()
                .ForMember(destination => destination.Username,
                    map => map.MapFrom(source => source.User == null ? "" : source.User.Username))
                .ForMember(destination => destination.Category, 
                    map => map.MapFrom(source => source.Category == null ? "" : source.Category.Name))
                .ForMember(dest => dest.Level,
                    map => map.MapFrom(source => source.Level == null ? "" : source.Level.Name))
                .ForMember(dest => dest.QuestionsSet,
                    map => map.MapFrom(source => source.GetQuestionsSet() == null ? "" : source.GetQuestionsSet().Name));
        }
    }
}
