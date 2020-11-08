using System.Collections.Generic;
using System.Linq;
namespace TdP2019TPFinalRichieri.Mapper.Profiles
{
    using AutoMapper;
    using Entities;
    using DTO;

    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<Question, QuestionDTO>()
                .ForMember(dest => dest.Question,
                           map => map.MapFrom(src => src.Description))
            .ReverseMap()
                .ForMember(dest => dest.Description,
                           map => map.MapFrom(src => src.Question))
                .ForMember(dest => dest.Multiple, 
                           map => map.MapFrom(src => src.IsMultiple))
                .ForMember(dest => dest.Answers,
                           map => map.MapFrom(src => src.CorrectAnswers.Concat(src.IncorrectAnswers)));
        }
    }
}
