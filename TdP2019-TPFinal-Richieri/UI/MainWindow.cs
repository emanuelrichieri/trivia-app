using System;
using System.Collections.Generic;
using System.Linq;

namespace TdP2019TPFinalRichieri
{
    using DTO;
    using Gtk;
    using TdP2019TPFinalRichieri.UI;

    public partial class MainWindow : Gtk.Window
    {
        private TriviaApp _triviaApp;

        private IEnumerable<QuestionsSetDTO> _questionsSets = new List<QuestionsSetDTO>();

        private const int DEFAULT_QUESTIONS_SET_IDX = 0;

        public MainWindow(TriviaApp pTriviaApp) : base(Gtk.WindowType.Toplevel)
        {
            this._triviaApp = pTriviaApp;
            if (_triviaApp.LoggedUser == null)
            {
                this.Hide();
                ModalMessage.Error(this, "Permission denied");
            }
            this.Build();
            this.lblUsername.Text = _triviaApp.LoggedUser.Username;
            this.btnSettings.Visible = _triviaApp.LoggedUser.IsAdmin;
            this.LoadQuestionsSets();
        }

        /// <summary>
        /// Load questions sets into cbbQuestionsSets
        /// </summary>
        protected void LoadQuestionsSets()
        {

            var response = _triviaApp.GetQuestionsSets();
            if (response.Success)
            {
                _questionsSets = response.Data;

                ListStore store = new ListStore(typeof(string));
                this.cbbQuestionsSets.Model = store;

                foreach (var questionsSet in _questionsSets)
                {
                    this.cbbQuestionsSets.AppendText(questionsSet.Name);
                }
                if (_questionsSets.Any())
                {
                    cbbQuestionsSets.Active = DEFAULT_QUESTIONS_SET_IDX;
                    _triviaApp.SelectedQuestionsSet = _questionsSets.ElementAt(DEFAULT_QUESTIONS_SET_IDX);
                }
            }
            else
            {
                ModalMessage.Error(this, response.Message);
            }
        }

        protected void OnBtnStartNewSessionClicked(object sender, EventArgs e)
        {
            new NewSessionDialog(_triviaApp).Show();
        }

        protected void OnBtnShowRankingClicked(object sender, EventArgs e)
        {
        }

        protected void OnBtnLogoutClicked(object sender, EventArgs e)
        {
            _triviaApp.Logout();
            this.Hide();
            new LogInDialog(_triviaApp).Show();
        }

        protected void OnCbbQuestionsSetsChanged(object sender, EventArgs e)
        {
            int selectedIdx = ((ComboBox)sender).Active;
            _triviaApp.SelectedQuestionsSet = _questionsSets.ElementAt(selectedIdx);
        }

        protected void OnBtnSettingsClicked(object sender, EventArgs e)
        {
            new SettingsDialog(this._triviaApp).Show();
        }
    }
}
