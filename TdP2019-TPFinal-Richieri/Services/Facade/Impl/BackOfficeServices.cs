using System;
namespace TdP2019TPFinalRichieri.Services.Facade
{
    using Mapper;
    using AutoMapper;
    using DTO;
    using Util;
    using Services;
    using Entities;

    public class BackOfficeServices : IBackOfficeServices
    {
        private readonly IMapper _mapper;
        private readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
       
        private IQuestionsSetService _questionsSetService;


        public BackOfficeServices(IMapperFactory pMapperFactory,
                                  IQuestionsSetService pQuestionsSetService)
        {
            this._mapper = pMapperFactory.GetMapper();
            this._questionsSetService = pQuestionsSetService;
        }

        /// <summary>
        /// Updates the questions set data.
        /// </summary>
        /// <returns>The questions set data.</returns>
        /// <param name="pQuestionsSetName">Questions set name.</param>
        public ResponseDTO<object> UpdateQuestionsSetData(string pQuestionsSetName)
        {
            try
            {
                return _questionsSetService.UpdateQuestionsSetData(pQuestionsSetName);
            } 
            catch (Exception ex)
            {
                _logger.Error(ex, "Failed to update Questions Set data.");
                return ResponseDTO.InternalError(ErrorMessageHelper.FailedOperation("updating questions set data"));
            }
        }


        /// <summary>
        /// Save the specified pQuestionsSet.
        /// </summary>
        /// <param name="pQuestionsSet">Questions set DTO.</param>
        public ResponseDTO<object> Save(QuestionsSetDTO pQuestionsSet)
        {
            try
            {
                QuestionsSet modifiedQuestionsSet = _mapper.Map<QuestionsSet>(pQuestionsSet);
                return _questionsSetService.Save(modifiedQuestionsSet);
            } 
            catch (Exception ex)
            {
                _logger.Error(ex, "Failed to save QuestionsSet.");
                return ResponseDTO.InternalError(ErrorMessageHelper.FailedOperation("saving questions set"));
            }
        }
    }
}
