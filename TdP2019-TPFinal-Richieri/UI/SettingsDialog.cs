using System;
using TdP2019TPFinalRichieri.DTO;
using TdP2019TPFinalRichieri.UI;

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
                ModalMessage.Info(this, Gtk.ButtonsType.Ok, response.Message);
            }
            else
            {
                ModalMessage.Error(this, response.Message);
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
                ModalMessage.Info(this, Gtk.ButtonsType.Ok, response.Message);
                this.Hide();
            }
            else
            {
                ModalMessage.Error(this, response.Message);
            }
        }

        protected void OnEntExpectedAnswerTimeChanged(object sender, EventArgs e)
        {
            if (entExpectedAnswerTime.Text.Length == 0)
            {
                return;
            }
            bool parseIntSuccess = int.TryParse(this.entExpectedAnswerTime.Text, out int expectedAnswerTimeValue);
            if (!parseIntSuccess)
            {
                this.entExpectedAnswerTime.Text = this._triviaApp.SelectedQuestionsSet.ExpectedAnswerTime.ToString();
                ModalMessage.Error(this, "Invalid number");
            }
        }
    }
}
