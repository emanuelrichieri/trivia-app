using System;
using System.Collections.Generic;
using System.Linq;
using Gtk;
using TdP2019TPFinalRichieri.UI;

namespace TdP2019TPFinalRichieri
{
    public partial class NewSessionDialog : Gtk.Dialog
    {
        private TriviaApp _triviaApp;

        private IList<int> _possiblesQuestionsNumber = Enumerable.Range(10, 90).ToList();

        public NewSessionDialog(TriviaApp pTriviaApp)
        {
            this._triviaApp = pTriviaApp;
            this.Build();
            this.InitializeData();
        }

        protected void InitializeData()
        {
            this.cbbCategories.Model = new ListStore(typeof(string));
            this.cbbLevels.Model = new ListStore(typeof(string));
            this.cbbQuestionsNumber.Model = new ListStore(typeof(string));

            foreach(var category in _triviaApp.SelectedQuestionsSet.Categories)
            {
                this.cbbCategories.AppendText(category.Name);
            }

            foreach(var level in _triviaApp.SelectedQuestionsSet.Levels)
            {
                this.cbbLevels.AppendText(level.Name);
            }

            foreach(int questionsNumber in _possiblesQuestionsNumber)
            {
                this.cbbQuestionsNumber.AppendText(questionsNumber.ToString());
            }
        }

        protected void OnBtnCancelClicked(object sender, EventArgs e)
        {
            this.Hide();
        }

        protected void OnButtonOkClicked(object sender, EventArgs e)
        {
            var category = _triviaApp.SelectedQuestionsSet.Categories.ElementAt(cbbCategories.Active);
            var level = _triviaApp.SelectedQuestionsSet.Levels.ElementAt(cbbLevels.Active);
            var questionsNumber = _possiblesQuestionsNumber.ElementAt(cbbQuestionsNumber.Active);

            var response = _triviaApp.StartNewSession(category, level, questionsNumber);
            if (response.Success)
            {
                var session = response.Data;
            }
            else
            {
                ModalMessage.Error(this, response.Message);
            }

        }
    }
}
