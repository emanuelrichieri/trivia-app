
// This file has been generated by the GUI designer. Do not modify.
namespace TdP2019TPFinalRichieri
{
	public partial class LogIn
	{
		private global::Gtk.VBox vbox5;

		private global::Gtk.Image imgHeader;

		private global::Gtk.HSeparator hseparator1;

		private global::Gtk.HBox hbox2;

		private global::Gtk.Button btnSignUp;

		private global::Gtk.Button btnLogIn;

		private global::Gtk.Table table7;

		private global::Gtk.Entry inp;

		private global::Gtk.Label lblPassword;

		private global::Gtk.Label lblUsername;

		private global::Gtk.Entry txtUsername;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget TdP2019TPFinalRichieri.LogIn
			this.Name = "TdP2019TPFinalRichieri.LogIn";
			this.Title = global::Mono.Unix.Catalog.GetString("LogIn");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child TdP2019TPFinalRichieri.LogIn.Gtk.Container+ContainerChild
			this.vbox5 = new global::Gtk.VBox();
			this.vbox5.Name = "vbox5";
			this.vbox5.Spacing = 6;
			// Container child vbox5.Gtk.Box+BoxChild
			this.imgHeader = new global::Gtk.Image();
			this.imgHeader.Name = "imgHeader";
			this.imgHeader.Pixbuf = global::Gdk.Pixbuf.LoadFromResource("TdP2019TPFinalRichieri.UI.Resources.Header.png");
			this.vbox5.Add(this.imgHeader);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.imgHeader]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this.hseparator1 = new global::Gtk.HSeparator();
			this.hseparator1.Name = "hseparator1";
			this.vbox5.Add(this.hseparator1);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.hseparator1]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.btnSignUp = new global::Gtk.Button();
			this.btnSignUp.CanFocus = true;
			this.btnSignUp.Name = "btnSignUp";
			this.btnSignUp.UseUnderline = true;
			this.btnSignUp.Label = global::Mono.Unix.Catalog.GetString("Sign Up");
			this.hbox2.Add(this.btnSignUp);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.btnSignUp]));
			w3.Position = 0;
			// Container child hbox2.Gtk.Box+BoxChild
			this.btnLogIn = new global::Gtk.Button();
			this.btnLogIn.CanFocus = true;
			this.btnLogIn.Name = "btnLogIn";
			this.btnLogIn.UseUnderline = true;
			this.btnLogIn.Label = global::Mono.Unix.Catalog.GetString("Log In");
			this.hbox2.Add(this.btnLogIn);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.btnLogIn]));
			w4.Position = 1;
			this.vbox5.Add(this.hbox2);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.hbox2]));
			w5.PackType = ((global::Gtk.PackType)(1));
			w5.Position = 2;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this.table7 = new global::Gtk.Table(((uint)(2)), ((uint)(3)), false);
			this.table7.Name = "table7";
			this.table7.RowSpacing = ((uint)(6));
			this.table7.ColumnSpacing = ((uint)(6));
			// Container child table7.Gtk.Table+TableChild
			this.inp = new global::Gtk.Entry();
			this.inp.CanFocus = true;
			this.inp.Name = "inp";
			this.inp.IsEditable = true;
			this.inp.InvisibleChar = '•';
			this.table7.Add(this.inp);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table7[this.inp]));
			w6.TopAttach = ((uint)(1));
			w6.BottomAttach = ((uint)(2));
			w6.LeftAttach = ((uint)(1));
			w6.RightAttach = ((uint)(2));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table7.Gtk.Table+TableChild
			this.lblPassword = new global::Gtk.Label();
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.LabelProp = global::Mono.Unix.Catalog.GetString("Password");
			this.table7.Add(this.lblPassword);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table7[this.lblPassword]));
			w7.TopAttach = ((uint)(1));
			w7.BottomAttach = ((uint)(2));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table7.Gtk.Table+TableChild
			this.lblUsername = new global::Gtk.Label();
			this.lblUsername.Name = "lblUsername";
			this.lblUsername.LabelProp = global::Mono.Unix.Catalog.GetString("Username");
			this.lblUsername.Justify = ((global::Gtk.Justification)(1));
			this.table7.Add(this.lblUsername);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table7[this.lblUsername]));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table7.Gtk.Table+TableChild
			this.txtUsername = new global::Gtk.Entry();
			this.txtUsername.CanFocus = true;
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.IsEditable = true;
			this.txtUsername.InvisibleChar = '•';
			this.table7.Add(this.txtUsername);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.table7[this.txtUsername]));
			w9.LeftAttach = ((uint)(1));
			w9.RightAttach = ((uint)(2));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox5.Add(this.table7);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.table7]));
			w10.PackType = ((global::Gtk.PackType)(1));
			w10.Position = 3;
			w10.Expand = false;
			w10.Fill = false;
			this.Add(this.vbox5);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 689;
			this.DefaultHeight = 300;
			this.Show();
		}
	}
}
