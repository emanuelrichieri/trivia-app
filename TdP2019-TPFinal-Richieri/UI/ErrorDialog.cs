using System;
namespace TdP2019TPFinalRichieri
{
    public partial class ErrorDialog : Gtk.Dialog
    {
        public ErrorDialog(string pMessage)
        {
            this.Build();
            this.txtMessage.Buffer.Text = pMessage;
        }

        protected void OnClickBtnClose(object sender, EventArgs e) => this.Hide();
    }
}
