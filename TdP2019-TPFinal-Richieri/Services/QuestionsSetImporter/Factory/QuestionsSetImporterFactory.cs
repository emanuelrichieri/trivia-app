using System;
using System.Collections.Generic;
using TdP2019TPFinalRichieri.DAL;

namespace TdP2019TPFinalRichieri.Services.QuestionsSetImporter
{
    using Importers;

    public class QuestionsSetImporterFactory : IQuestionsSetImporterFactory
    {
        private IDictionary<string, IQuestionsSetImporter> _questionsSetImporters = new Dictionary<string, IQuestionsSetImporter>();

        public QuestionsSetImporterFactory(IUnitOfWorkFactory pUnitOfWorkFactory,
                                        IHttpService pHttpService)
        {

            // Initialize importers

            this._questionsSetImporters.Add(QuestionsSetsName.OpenTriviaDB.ToUpper(),
                                            new OpenTriviaDBSetImporter(pUnitOfWorkFactory,
                                                                        pHttpService));
        }

        /// <summary>
        /// Get importer by questions set name.
        /// </summary>
        /// <returns>The importer.</returns>
        /// <param name="pQuestionsSetName">Questions set name.</param>
        public IQuestionsSetImporter GetImporter(string pQuestionsSetName)
        {
            if (_questionsSetImporters.TryGetValue(pQuestionsSetName.ToUpper(), out IQuestionsSetImporter questionsSetImporter))
            {
                return questionsSetImporter;
            }
            throw new NotImplementedException("There is no importer defined for the given QuestionsSet.");
        }
    }
}
