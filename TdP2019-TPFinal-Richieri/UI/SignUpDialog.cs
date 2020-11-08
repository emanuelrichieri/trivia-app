using System;
namespace TdP2019TPFinalRichieri
{
    using DTO;

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
            ResponseDTO<object> response = _triviaApp.SignUp(this.entUsername.Text, this.entPassword.Text, this.entConfirmPassword.Text);
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

    }
}
