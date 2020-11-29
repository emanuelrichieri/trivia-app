using System;
using Gtk;
namespace TdP2019TPFinalRichieri
{
    public partial class RankingDialog : Dialog
    {
        protected TriviaApp _triviaApp;

        public RankingDialog()
        {
            this.Build();
        }

        protected void OnBtnCloseClicked(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
