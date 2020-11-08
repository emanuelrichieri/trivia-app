using System;
namespace TdP2019TPFinalRichieri.Services.QuestionsSetImporter
{
    public interface IQuestionsSetImporterFactory
    {
        IQuestionsSetImporter GetImporter(string pQuestionsSetName);
    }
}
