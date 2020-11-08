using System;

namespace TdP2019TPFinalRichieri.Services.QuestionsSetImporter.Factory
{
    public interface IQuestionsSetImporterFactory
    {
        IQuestionsSetImporter GetImporter(string pQuestionsSetName);
    }
}
