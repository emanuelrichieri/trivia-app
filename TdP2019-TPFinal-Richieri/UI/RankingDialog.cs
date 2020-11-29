using System;
using Gtk;
using TdP2019TPFinalRichieri.UI;

namespace TdP2019TPFinalRichieri
{
    public partial class RankingDialog : Dialog
    {
        protected TriviaApp _triviaApp;

        public RankingDialog(TriviaApp pTriviaApp)
        {
            this.Build();
            this._triviaApp = pTriviaApp;
            this.BuildTree();
            this.LoadData();
        }

        protected void OnBtnCloseClicked(object sender, EventArgs e)
        {
            this.Hide();
        }

        protected void BuildTree()
        {
            var userColumn = new TreeViewColumn();
            userColumn.Title = "User";

            var scoreColumn = new TreeViewColumn();
            scoreColumn.Title = "Score";

            var timeColumn = new TreeViewColumn();
            timeColumn.Title = "Time";

            var dateColumn = new TreeViewColumn();
            dateColumn.Title = "Date";

            this.treeviewRanking.AppendColumn(userColumn);
            this.treeviewRanking.AppendColumn(scoreColumn);
            this.treeviewRanking.AppendColumn(timeColumn);
            this.treeviewRanking.AppendColumn(dateColumn);

            var usernameCell = new CellRendererText();
            var scoreCell = new CellRendererText();
            var timeCell = new CellRendererText();
            var dateCell = new CellRendererText();

            userColumn.PackStart(usernameCell, true);
            userColumn.AddAttribute(usernameCell, "text", 0);

            scoreColumn.PackStart(scoreCell, true);
            scoreColumn.AddAttribute(scoreCell, "text", 1);

            timeColumn.PackStart(timeCell, true);
            timeColumn.AddAttribute(timeCell, "text", 2);

            dateColumn.PackStart(dateCell, true);
            dateColumn.AddAttribute(dateCell, "text", 3);
        }

        protected void LoadData()
        {
            var response = _triviaApp.ShowRanking();
            if (response.Success)
            {
                var rankingListStore = new ListStore(typeof(string), typeof(string), typeof(string), typeof(string));
                var ranking = response.Data;
                foreach (var sessionResult in ranking)
                {
                    rankingListStore.AppendValues(sessionResult.Username, sessionResult.Score.ToString(), sessionResult.Time.ToString(), sessionResult.Date.ToString());

                }
                this.treeviewRanking.Model = rankingListStore;
            }
            else
            {
                ModalMessage.Error(this, response.Message);
            }
        }
    }
}
