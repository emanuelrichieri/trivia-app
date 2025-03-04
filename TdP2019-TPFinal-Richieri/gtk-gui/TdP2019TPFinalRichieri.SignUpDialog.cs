
// This file has been generated by the GUI designer. Do not modify.
namespace TdP2019TPFinalRichieri
{
	public partial class SignUpDialog
	{
		private global::Gtk.VBox vboxSignUp;

		private global::Gtk.Image imgHeader;

		private global::Gtk.Frame frameSignUp;

		private global::Gtk.Alignment algSignUp;

		private global::Gtk.VBox vbox2;

		private global::Gtk.HBox hboxUsername;

		private global::Gtk.Label lblUsername;

		private global::Gtk.Entry entUsername;

		private global::Gtk.HBox hboxPassword;

		private global::Gtk.Label lblPassword;

		private global::Gtk.Entry entPassword;

		private global::Gtk.HBox hboxConfirmPassword;

		private global::Gtk.Label lblConfirmPassword;

		private global::Gtk.Entry entConfirmPassword;

		private global::Gtk.Label lblSignUp;

		private global::Gtk.Button buttonCancel;

		private global::Gtk.Button btnConfirm;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget TdP2019TPFinalRichieri.SignUpDialog
			this.Name = "TdP2019TPFinalRichieri.SignUpDialog";
			this.Title = global::Mono.Unix.Catalog.GetString("TriviaApp - SignUp");
			this.Icon = global::Stetic.IconLoader.LoadIcon(this, "stock_person", global::Gtk.IconSize.Menu);
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.Modal = true;
			this.Resizable = false;
			this.AllowGrow = false;
			this.DefaultWidth = 640;
			this.DefaultHeight = 480;
			// Internal child TdP2019TPFinalRichieri.SignUpDialog.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.vboxSignUp = new global::Gtk.VBox();
			this.vboxSignUp.Name = "vboxSignUp";
			this.vboxSignUp.Spacing = 6;
			// Container child vboxSignUp.Gtk.Box+BoxChild
			this.imgHeader = new global::Gtk.Image();
			this.imgHeader.Name = "imgHeader";
			this.imgHeader.Pixbuf = global::Gdk.Pixbuf.LoadFromResource("TdP2019TPFinalRichieri.UI.Resources.Header.png");
			this.vboxSignUp.Add(this.imgHeader);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vboxSignUp[this.imgHeader]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vboxSignUp.Gtk.Box+BoxChild
			this.frameSignUp = new global::Gtk.Frame();
			this.frameSignUp.Name = "frameSignUp";
			this.frameSignUp.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frameSignUp.Gtk.Container+ContainerChild
			this.algSignUp = new global::Gtk.Alignment(0F, 0F, 1F, 1F);
			this.algSignUp.HeightRequest = 200;
			this.algSignUp.Name = "algSignUp";
			this.algSignUp.LeftPadding = ((uint)(12));
			// Container child algSignUp.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hboxUsername = new global::Gtk.HBox();
			this.hboxUsername.Name = "hboxUsername";
			this.hboxUsername.Spacing = 6;
			// Container child hboxUsername.Gtk.Box+BoxChild
			this.lblUsername = new global::Gtk.Label();
			this.lblUsername.WidthRequest = 150;
			this.lblUsername.Name = "lblUsername";
			this.lblUsername.LabelProp = global::Mono.Unix.Catalog.GetString("Username");
			this.lblUsername.Justify = ((global::Gtk.Justification)(1));
			this.hboxUsername.Add(this.lblUsername);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hboxUsername[this.lblUsername]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child hboxUsername.Gtk.Box+BoxChild
			this.entUsername = new global::Gtk.Entry();
			this.entUsername.CanFocus = true;
			this.entUsername.Name = "entUsername";
			this.entUsername.IsEditable = true;
			this.entUsername.InvisibleChar = '•';
			this.hboxUsername.Add(this.entUsername);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hboxUsername[this.entUsername]));
			w4.Position = 1;
			this.vbox2.Add(this.hboxUsername);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hboxUsername]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hboxPassword = new global::Gtk.HBox();
			this.hboxPassword.Name = "hboxPassword";
			this.hboxPassword.Spacing = 6;
			// Container child hboxPassword.Gtk.Box+BoxChild
			this.lblPassword = new global::Gtk.Label();
			this.lblPassword.WidthRequest = 150;
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.LabelProp = global::Mono.Unix.Catalog.GetString("Password");
			this.lblPassword.Justify = ((global::Gtk.Justification)(1));
			this.hboxPassword.Add(this.lblPassword);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hboxPassword[this.lblPassword]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			// Container child hboxPassword.Gtk.Box+BoxChild
			this.entPassword = new global::Gtk.Entry();
			this.entPassword.CanFocus = true;
			this.entPassword.Name = "entPassword";
			this.entPassword.IsEditable = true;
			this.entPassword.InvisibleChar = '•';
			this.hboxPassword.Add(this.entPassword);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hboxPassword[this.entPassword]));
			w7.Position = 1;
			this.vbox2.Add(this.hboxPassword);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hboxPassword]));
			w8.Position = 1;
			w8.Expand = false;
			w8.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hboxConfirmPassword = new global::Gtk.HBox();
			this.hboxConfirmPassword.Name = "hboxConfirmPassword";
			this.hboxConfirmPassword.Spacing = 6;
			// Container child hboxConfirmPassword.Gtk.Box+BoxChild
			this.lblConfirmPassword = new global::Gtk.Label();
			this.lblConfirmPassword.WidthRequest = 150;
			this.lblConfirmPassword.Name = "lblConfirmPassword";
			this.lblConfirmPassword.LabelProp = global::Mono.Unix.Catalog.GetString("Confirm Password");
			this.lblConfirmPassword.Justify = ((global::Gtk.Justification)(1));
			this.hboxConfirmPassword.Add(this.lblConfirmPassword);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hboxConfirmPassword[this.lblConfirmPassword]));
			w9.Position = 0;
			w9.Expand = false;
			w9.Fill = false;
			// Container child hboxConfirmPassword.Gtk.Box+BoxChild
			this.entConfirmPassword = new global::Gtk.Entry();
			this.entConfirmPassword.CanFocus = true;
			this.entConfirmPassword.Name = "entConfirmPassword";
			this.entConfirmPassword.IsEditable = true;
			this.entConfirmPassword.InvisibleChar = '•';
			this.hboxConfirmPassword.Add(this.entConfirmPassword);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hboxConfirmPassword[this.entConfirmPassword]));
			w10.Position = 1;
			this.vbox2.Add(this.hboxConfirmPassword);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hboxConfirmPassword]));
			w11.Position = 2;
			w11.Expand = false;
			w11.Fill = false;
			this.algSignUp.Add(this.vbox2);
			this.frameSignUp.Add(this.algSignUp);
			this.lblSignUp = new global::Gtk.Label();
			this.lblSignUp.Name = "lblSignUp";
			this.lblSignUp.LabelProp = global::Mono.Unix.Catalog.GetString("<b>Sign Up</b>");
			this.lblSignUp.UseMarkup = true;
			this.frameSignUp.LabelWidget = this.lblSignUp;
			this.vboxSignUp.Add(this.frameSignUp);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vboxSignUp[this.frameSignUp]));
			w14.Position = 1;
			w1.Add(this.vboxSignUp);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(w1[this.vboxSignUp]));
			w15.Position = 0;
			w15.Expand = false;
			w15.Fill = false;
			// Internal child TdP2019TPFinalRichieri.SignUpDialog.ActionArea
			global::Gtk.HButtonBox w16 = this.ActionArea;
			w16.Name = "dialog1_ActionArea";
			w16.Spacing = 10;
			w16.BorderWidth = ((uint)(5));
			w16.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonCancel = new global::Gtk.Button();
			this.buttonCancel.CanDefault = true;
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseStock = true;
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = "gtk-cancel";
			this.AddActionWidget(this.buttonCancel, -6);
			global::Gtk.ButtonBox.ButtonBoxChild w17 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w16[this.buttonCancel]));
			w17.Expand = false;
			w17.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.btnConfirm = new global::Gtk.Button();
			this.btnConfirm.CanDefault = true;
			this.btnConfirm.CanFocus = true;
			this.btnConfirm.Name = "btnConfirm";
			this.btnConfirm.UseUnderline = true;
			this.btnConfirm.Label = global::Mono.Unix.Catalog.GetString("Confirm");
			global::Gtk.Image w18 = new global::Gtk.Image();
			w18.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-apply", global::Gtk.IconSize.Menu);
			this.btnConfirm.Image = w18;
			this.AddActionWidget(this.btnConfirm, -5);
			global::Gtk.ButtonBox.ButtonBoxChild w19 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w16[this.btnConfirm]));
			w19.Position = 1;
			w19.Expand = false;
			w19.Fill = false;
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Show();
			this.btnConfirm.Clicked += new global::System.EventHandler(this.OnBtnConfirmClicked);
		}
	}
}
