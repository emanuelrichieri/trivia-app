using System;
using System.Collections.Generic;
using AutoMapper;
namespace TdP2019TPFinalRichieri.Mapper
{
    using Profiles;

    public class TriviaMapperFactory : IMapperFactory
    {

        public TriviaMapperFactory()
        {
            IEnumerable<Profile> profiles = new List<Profile>
            {
                new AnswerProfile(),
                new AnswerResultProfile(),
                new CategoryProfile(),
                new LevelProfile(),
                new QuestionProfile(),
                new QuestionsSetProfile(),
                new SessionProfile(),
                new SessionResultProfile(),
                new UserProfile()
            };
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfiles(profiles);
            });

            this.Mapper = config.CreateMapper();
        }


        public IMapper GetMapper()
        {
            TriviaMapperFactory triviaMapper = new TriviaMapperFactory();
            return triviaMapper.Mapper;
        }

        private IMapper Mapper { get; set; }
    }

}
