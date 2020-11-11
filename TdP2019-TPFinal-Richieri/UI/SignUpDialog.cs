using System;
namespace TdP2019TPFinalRichieri
{
    using TdP2019TPFinalRichieri.UI;

    public partial class SignUpDialog : Gtk.Dialog
    {
        private TriviaApp _triviaApp; 

        public SignUpDialog(TriviaApp pTrivia)
        {
            this._triviaApp = pTrivia;
            this.Build();
        }

        protected void OnBtnConfirmClicked(object sender, EventArgs e)
        {
            var response = _triviaApp.SignUp(this.entUsername.Text, this.entPassword.Text, this.entConfirmPassword.Text);
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

    }
}
