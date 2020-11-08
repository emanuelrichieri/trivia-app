using System;
namespace TdP2019TPFinalRichieri.Mapper.Profiles
{
    using AutoMapper;
    using Entities;
    using DTO;

    public class AnswerProfile : Profile
    {
        public AnswerProfile()
        {
            CreateMap<Answer, AnswerDTO>()
                .ForMember(destination => destination.Answer,
                    map => map.MapFrom(source => source.Description)
                )
            .ReverseMap()
                .ForMember(destination => destination.Description,
                    map => map.MapFrom(source => source.Answer))
                ;
        }
    }
}
