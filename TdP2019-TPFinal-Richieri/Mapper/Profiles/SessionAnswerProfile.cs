using System;
using AutoMapper;

namespace TdP2019TPFinalRichieri.Mapper.Profiles
{
    using Entities;
    using DTO;

    public class SessionAnswerProfile : Profile
    {
        public SessionAnswerProfile()
        {
            CreateMap<SessionAnswer, SessionAnswerDTO>()
                .ForMember(dest => dest.Answers,
                    map => map.MapFrom(source => source.Answers)
                )
                .ForMember(dest => dest.Question,
                    map => map.MapFrom(source => source.Question)
                )
                .ForMember(dest => dest.AnswerTime,
                    map => map.MapFrom(source => source.AnswerTime)
                )
            .ReverseMap();
        }
    }
}
