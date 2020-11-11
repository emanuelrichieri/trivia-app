using System;
using TdP2019TPFinalRichieri.DTO;
using TdP2019TPFinalRichieri.UI;

namespace TdP2019TPFinalRichieri
{
    public partial class LogInDialog : Gtk.Dialog
    {
        private TriviaApp _triviaApp;


        public LogInDialog(TriviaApp pTriviaApp) {
            this._triviaApp = pTriviaApp;
            this.Build();
        }


        /// <summary>
        /// Event triggered when user clicks on LogIn button.
        /// Makes the login for the entered Username and Password
        /// </summary>
        protected void OnClickLogIn(object sender, EventArgs e)
        {
            var response = _triviaApp.Login(this.entUsername.Text, this.entPassword.Text);
            if (response.Success)
            {
                this.Hide();
                new MainWindow(_triviaApp).Show();
            }
            else
            {
                ModalMessage.Error(this, response.Message);
            }
        }

        protected void OnClickBtnSignUp(object sender, EventArgs e)
        {
            using (SignUpDialog signUpDialog = new SignUpDialog(_triviaApp))
            {
                signUpDialog.Show();
            }
        }
    }
}
