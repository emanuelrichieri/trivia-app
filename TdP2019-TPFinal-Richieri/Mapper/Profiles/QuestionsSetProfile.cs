using System;
namespace TdP2019TPFinalRichieri.Mapper.Profiles
{
    using AutoMapper;
    using DTO;
    using Entities;

    public class QuestionsSetProfile : Profile
    {
        public QuestionsSetProfile()
        {
            CreateMap<QuestionsSet, QuestionsSetDTO>()
                .ReverseMap();
        }
    }
}
