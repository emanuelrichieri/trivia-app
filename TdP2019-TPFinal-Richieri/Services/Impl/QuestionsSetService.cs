using System;
using System.Linq;
using System.Collections.Generic;

namespace TdP2019TPFinalRichieri.Services
{
    using AutoMapper;
    using Mapper;
    using DTO;
    using Entities;
    using DAL;
    using QuestionsSetImporter;
    using QuestionsSetImporter.Factory;
    using TdP2019TPFinalRichieri.Exceptions;

    public class QuestionsSetService : IQuestionsSetService
    {
        private IUnitOfWorkFactory _unitOfWorkFactory;
        private IQuestionsSetImporterFactory _questionsSetImporterFactory;
        private IMapper _mapper;

        public QuestionsSetService(IUnitOfWorkFactory pUnitOfWorkFactory,
                                   IMapperFactory pMapperFactory,
                                   IQuestionsSetImporterFactory pQuestionsSetImporterFactory)
        {
            this._unitOfWorkFactory = pUnitOfWorkFactory;
            this._mapper = pMapperFactory.GetMapper();
            this._questionsSetImporterFactory = pQuestionsSetImporterFactory;
        }


        /// <summary>
        /// Gets all Questions Sets available.
        /// </summary>
        /// <returns>Questions set list.</returns>
        public ResponseDTO<IEnumerable<QuestionsSetDTO>> GetQuestionsSets()
        {
            using (IUnitOfWork bUoW = _unitOfWorkFactory.GetUnitOfWork())
            {
                var questionsSets = _mapper.Map<IEnumerable<QuestionsSetDTO>>(bUoW.QuestionsSetRepository.GetAll().ToList());
                if (!questionsSets.Any())
                {
                    throw new NoContentException("There are no questions sets in the database");
                }
                return ResponseDTO<IEnumerable<QuestionsSetDTO>>.Ok(questionsSets);
            }
        }


        public ResponseDTO<object> UpdateQuestionsSetData(string pQuestionsSetName)
        {
            using (IUnitOfWork bUoW = _unitOfWorkFactory.GetUnitOfWork())
            {
                IQuestionsSetImporter questionsSetImporter = _questionsSetImporterFactory.GetImporter(pQuestionsSetName);
                questionsSetImporter.UpdateData();
                return ResponseDTO.Ok("Data updated successfully.");
            }
        }


        /// <summary>
        /// Save the specified pQuestionsSet into database.
        /// </summary>
        /// <param name="pQuestionsSet">Questions set.</param>
        public ResponseDTO<object> Save(QuestionsSet pQuestionsSet)
        {
            if (pQuestionsSet == null)
            {
                throw new NullReferenceException("Questions Set cannot be null");
            }
            using (IUnitOfWork bUoW = _unitOfWorkFactory.GetUnitOfWork())
            {
                QuestionsSet entity = bUoW.QuestionsSetRepository.Get(pQuestionsSet.Id);
                if (entity == null)
                {
                    throw new NotFoundException($"No questions set found with id {pQuestionsSet.Id}");
                }
                entity.ExpectedAnswerTime = pQuestionsSet.ExpectedAnswerTime;
                bUoW.Complete();
            }
            return ResponseDTO.Ok("Questions Set successfully saved.");
        }
    }
}
