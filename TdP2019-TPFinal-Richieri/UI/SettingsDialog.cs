using System;
using TdP2019TPFinalRichieri.DTO;

namespace TdP2019TPFinalRichieri
{
    public partial class SettingsDialog : Gtk.Dialog
    {
        private TriviaApp _triviaApp;

        private QuestionsSetDTO _selectedQuestionsSetBackUp;

        public SettingsDialog(TriviaApp pTriviaApp)
        {
            this.Build();
            this._triviaApp = pTriviaApp;

            _selectedQuestionsSetBackUp = this._triviaApp.SelectedQuestionsSet;
            this.lblQuestionSetName.Text = this._triviaApp.SelectedQuestionsSet.Name;
            this.entExpectedAnswerTime.Text = this._triviaApp.SelectedQuestionsSet.ExpectedAnswerTime.ToString();
        }

        protected void OnBtnUpdateDataClicked(object sender, EventArgs e)
        {
            this.lblLoading.Visible = true;
            var response = this._triviaApp.UpdateQuestionsSetData();
            if (response.Success)
            {
                this.lblLoading.Visible = false;
                new SuccessDialog(response.Message).Show();
            }
            else
            {
                new ErrorDialog(response.Message).Show();
            }
        }

        protected void OnBtnBackClicked(object sender, EventArgs e)
        {
            this.GoBack();
        }

        protected void GoBack()
        {
            this._triviaApp.SelectedQuestionsSet = _selectedQuestionsSetBackUp;
            this.Hide();
        }

        protected void OnBtnSaveClicked(object sender, EventArgs e)
        {
            int oldExpectedAnswerTime = this._triviaApp.SelectedQuestionsSet.ExpectedAnswerTime;
            this._triviaApp.SelectedQuestionsSet.ExpectedAnswerTime = int.Parse(this.entExpectedAnswerTime.Text);
            var response = this._triviaApp.SaveQuestionsSet();
            if (response.Success)
            {
                new SuccessDialog(response.Message).Show();
                this.Hide();
            }
            else
            {
                new ErrorDialog(response.Message).Show();
            }
        }

        protected void OnEntExpectedAnswerTimeChanged(object sender, EventArgs e)
        {
            bool parseIntSuccess = int.TryParse(this.entExpectedAnswerTime.Text, out int expectedAnswerTimeValue);
            if (!parseIntSuccess)
            {
                this.entExpectedAnswerTime.Text = this._triviaApp.SelectedQuestionsSet.ExpectedAnswerTime.ToString();
                new ErrorDialog("Invalid number").Show();
            }
        }
    }
}
