using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace TdP2019TPFinalRichieri.Services.QuestionsSetImporter.Importers
{
    using DAL;
    using Entities;

    /// <summary>
    /// Response codes from OpenTdb API
    /// </summary>
    public enum OpenTdbResponseCode
    {
        Success = 0,
        NoResults = 1,
        InvalidParameter = 2,
        TokenNotFound = 3,
        TokenEmpty = 4
    }

    /// <summary>
    /// Open trivia DB Set importer.
    /// API Documentation <see cref="https://opentdb.com/api_config.php"/>
    /// </summary>
    public class OpenTriviaDBSetImporter : IQuestionsSetImporter
    {
        private readonly string API_URL;  
        // API given limit 
        private readonly int MAX_QUESTIONS_PER_CALL;

        private IUnitOfWorkFactory _unitOfWorkFactory; 
        private IHttpService _httpService;

        public OpenTriviaDBSetImporter(IUnitOfWorkFactory pUnitOfWorkFactory,
                                       IHttpService pHttpService)
        {
            // Default API URL value https://opentdb.com/
            this.API_URL = ConfigurationManager.AppSettings["OpenTriviaDBAPIUrl"] ?? "https://opentdb.com/";

            // Default value 50 
            this.MAX_QUESTIONS_PER_CALL = int.Parse(ConfigurationManager.AppSettings["OpenTriviaDBMaxQuestionsPerCall"] ?? "50");

            this._unitOfWorkFactory = pUnitOfWorkFactory;
            this._httpService = pHttpService;
        }



        /// <summary>
        /// Get all categories from the API.
        /// </summary>
        /// <returns>The categories.</returns>
        private IList<Category> GetCategories()
        {
            dynamic jsonResponse = _httpService.GetResponse($"{API_URL}/api_category.php");
            if (jsonResponse == null)
            {
                throw new Exception("Failed to fetch categories.");
            }
            IList<Category> categories = new List<Category>();

            // Map each item from the jsonResponse to a Category entity object.
            foreach (var jsonCategoryItem in jsonResponse.trivia_categories)
            {
                categories.Add(new Category
                {
                    Id = (int) jsonCategoryItem.id,
                    Name = jsonCategoryItem.name.ToString()
                });
            }
            return categories;
        }


        /// <summary>
        /// Get <see cref="MAX_QUESTIONS_PER_CALL"/> from the API for the given category.
        /// </summary>
        /// <returns>Questions list.</returns>
        /// <param name="pCategoryId">Category identifier.</param>
        /// <param name="pQuantity">Questions queantity</param>
        private IList<Question> GetQuestions(int pCategoryId, int pQuantity)
        {
            dynamic jsonResponse = _httpService.GetResponse($"{API_URL}/api.php?amount={pQuantity}&category={pCategoryId}");
            if (jsonResponse == null)
            {
                throw new Exception("Failed to fetch questions.");
            }

            // If response code is success
            if (jsonResponse.response_code == OpenTdbResponseCode.Success)
            {
                IList<Question> questions = new List<Question>();

                foreach(var jsonQuestionItem in jsonResponse.results)
                {
                    Question question = new Question {
                        Description = WebUtility.HtmlDecode(jsonQuestionItem.question.ToString()),
                        Multiple = string.Equals(jsonQuestionItem.type.ToString(), "multiple", StringComparison.OrdinalIgnoreCase),
                        Level = new Level
                        {
                            Name = jsonQuestionItem.difficulty.ToString().ToUpper()
                        }
                    };

                    // Set as id its hashcode for question identity 
                    question.Id = question.GetHashCode();

                    // Set correct answer
                    Answer correctAnswer = new Answer
                    {
                        Description = WebUtility.HtmlDecode(jsonQuestionItem.correct_answer.ToString()),
                        IsCorrect = true
                    };
                    question.Answers.Add(correctAnswer);

                    // Map incorrect answers
                    foreach(var incorrectAnswer in jsonQuestionItem.incorrect_answers)
                    {
                        question.Answers.Add(
                           new Answer
                           {
                               Description = WebUtility.HtmlDecode(incorrectAnswer.ToString()),
                               IsCorrect = false
                           }
                        );
                    }

                    questions.Add(question);
                }

                return questions;
            }
            // If response code is not Success
            throw new Exception("Failed to fetch questions. " +
                $" Response Code = {jsonResponse.response_code} " +
                    $"({((OpenTdbResponseCode) jsonResponse.response_code).ToString()})");

        }

        private int GetCategoryQuestionCount(int pCategoryId)
        {
            dynamic jsonResponse = _httpService.GetResponse($"{API_URL}/api_count.php?category={pCategoryId}");
            if (jsonResponse == null)
            {
                throw new Exception("Failed to fetch category question count.");
            }
            return (int) jsonResponse.category_question_count.total_question_count;
        }

        /// <summary>
        /// Update OpenTriviaDB Questions Set data.
        /// First, fetches all categories available.
        /// For each category imported, it checks if that category exists or not.
        /// If it does not exist, then it is saved.
        /// Also gets <see cref="MAX_QUESTIONS_PER_CALL"/> questions for the 
        /// imported category, and if any question does not exist for the categroy,
        /// it is saved too. (All questions are saved for new categories)
        /// </summary>
        public void UpdateData()
        {
            using (IUnitOfWork bUoW = _unitOfWorkFactory.GetUnitOfWork())
            {
                QuestionsSet questionsSet = bUoW.QuestionsSetRepository
                                                .Get(bQuestionsSet => string.Equals(bQuestionsSet.Name,
                                                                        QuestionsSetsName.OpenTriviaDB,
                                                                        StringComparison.OrdinalIgnoreCase));
                if (questionsSet == null)
                {
                    throw new Exception("Failed to get Open Trivia DB Questions Set entity.");
                }

                foreach (Category category in GetCategories())
                {
                    int categoryQuestionCount = GetCategoryQuestionCount(category.Id);

                    // Get minimum number of questions between categoryQuestionCount and MAX_QUESTIONS_PER_CALL
                    // because a request with a greater number than category question count returns 
                    // a no result response
                    IList<Question> importedQuestions = GetQuestions(category.Id, Math.Min(categoryQuestionCount, MAX_QUESTIONS_PER_CALL));

                    // Set correspondent Level for each importedQuestion
                    foreach (Question importedQuestion in importedQuestions)
                    {
                        importedQuestion.Level = questionsSet.Levels.ToList()
                                                    .Find(bLevel => string.Equals(bLevel.Name, importedQuestion.Level.Name, StringComparison.OrdinalIgnoreCase));
                    }

                    // Check if the category already exists in OpenTriviaDB Questions Set
                    Category existingCategory = questionsSet.Categories.ToList().Find(bCategory => bCategory.Id == category.Id);

                    // If not exists any category with that id, then save the imported category
                    // with all imported questions.
                    if (existingCategory == null)
                    {
                        category.Questions = importedQuestions;
                        questionsSet.Categories.Add(category);
                    }
                    else
                    {
                        // Only save questions which are not already saved for OpenTriviaDB Questions Set
                        foreach (Question importedQuestion in importedQuestions)
                        {
                            Question existingQuestion = existingCategory.Questions.ToList().Find(bQuestion => Equals(bQuestion.Id, importedQuestion.Id));
                            if (existingQuestion == null)
                            {
                                existingCategory.Questions.Add(importedQuestion);
                            }
                        }
                    }
                }
                bUoW.Complete();
            }
        }
    }
}
