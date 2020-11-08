using System;
namespace TdP2019TPFinalRichieri.Mapper.Profiles
{
    using AutoMapper;
    using Entities;
    using DTO;
    using System.Linq;

    public class AnswerResultProfile : Profile
    {
        public AnswerResultProfile()
        {
            CreateMap<SessionAnswer, AnswerResultDTO>()
                .ForMember(destination => destination.CorrectAnswers,
                    map => map.MapFrom(source => source.Question == null ? Enumerable.Empty<Answer>() : source.Question.GetCorrectAnswers())
                )
                .ForMember(destination => destination.UserAnswers,
                    map => map.MapFrom(source => source.Answers)
                );
        }
    }
}
