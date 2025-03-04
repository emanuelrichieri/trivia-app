
// This file has been generated by the GUI designer. Do not modify.
namespace TdP2019TPFinalRichieri
{
	public partial class MainWindow
	{
		private global::Gtk.VBox vbox2;

		private global::Gtk.Image imgHeader;

		private global::Gtk.HBox hbox3;

		private global::Gtk.Label lblUsername;

		private global::Gtk.Button btnLogout;

		private global::Gtk.HBox hbox1;

		private global::Gtk.ComboBox cbbQuestionsSets;

		private global::Gtk.HBox hbox2;

		private global::Gtk.Button btnStartNewSession;

		private global::Gtk.HBox hbox5;

		private global::Gtk.Button btnShowRanking;

		private global::Gtk.HBox hbox4;

		private global::Gtk.Button btnSettings;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget TdP2019TPFinalRichieri.MainWindow
			this.Name = "TdP2019TPFinalRichieri.MainWindow";
			this.Title = global::Mono.Unix.Catalog.GetString("MainWindow");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.AllowGrow = false;
			// Container child TdP2019TPFinalRichieri.MainWindow.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.imgHeader = new global::Gtk.Image();
			this.imgHeader.Name = "imgHeader";
			this.imgHeader.Pixbuf = global::Gdk.Pixbuf.LoadFromResource("TdP2019TPFinalRichieri.UI.Resources.Header.png");
			this.vbox2.Add(this.imgHeader);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.imgHeader]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.lblUsername = new global::Gtk.Label();
			this.lblUsername.WidthRequest = 100;
			this.lblUsername.Name = "lblUsername";
			this.lblUsername.LabelProp = global::Mono.Unix.Catalog.GetString("Username");
			this.lblUsername.Justify = ((global::Gtk.Justification)(1));
			this.hbox3.Add(this.lblUsername);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.lblUsername]));
			w2.Position = 2;
			w2.Expand = false;
			w2.Fill = false;
			w2.Padding = ((uint)(10));
			// Container child hbox3.Gtk.Box+BoxChild
			this.btnLogout = new global::Gtk.Button();
			this.btnLogout.WidthRequest = 100;
			this.btnLogout.CanFocus = true;
			this.btnLogout.Name = "btnLogout";
			this.btnLogout.UseUnderline = true;
			this.btnLogout.Label = global::Mono.Unix.Catalog.GetString("Log Out");
			global::Gtk.Image w3 = new global::Gtk.Image();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-quit", global::Gtk.IconSize.Menu);
			this.btnLogout.Image = w3;
			this.hbox3.Add(this.btnLogout);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.btnLogout]));
			w4.Position = 3;
			w4.Expand = false;
			w4.Fill = false;
			this.vbox2.Add(this.hbox3);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox3]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.cbbQuestionsSets = global::Gtk.ComboBox.NewText();
			this.cbbQuestionsSets.WidthRequest = 300;
			this.cbbQuestionsSets.CanDefault = true;
			this.cbbQuestionsSets.Name = "cbbQuestionsSets";
			this.hbox1.Add(this.cbbQuestionsSets);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.cbbQuestionsSets]));
			w6.Position = 1;
			w6.Fill = false;
			w6.Padding = ((uint)(10));
			this.vbox2.Add(this.hbox1);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox1]));
			w7.Position = 2;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.btnStartNewSession = new global::Gtk.Button();
			this.btnStartNewSession.WidthRequest = 300;
			this.btnStartNewSession.CanFocus = true;
			this.btnStartNewSession.Name = "btnStartNewSession";
			this.btnStartNewSession.UseUnderline = true;
			this.btnStartNewSession.Label = global::Mono.Unix.Catalog.GetString("Start new session");
			this.hbox2.Add(this.btnStartNewSession);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.btnStartNewSession]));
			w8.Position = 1;
			w8.Fill = false;
			w8.Padding = ((uint)(10));
			this.vbox2.Add(this.hbox2);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox2]));
			w9.Position = 3;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox5 = new global::Gtk.HBox();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.btnShowRanking = new global::Gtk.Button();
			this.btnShowRanking.WidthRequest = 300;
			this.btnShowRanking.CanFocus = true;
			this.btnShowRanking.Name = "btnShowRanking";
			this.btnShowRanking.UseUnderline = true;
			this.btnShowRanking.Label = global::Mono.Unix.Catalog.GetString("Show Ranking");
			this.hbox5.Add(this.btnShowRanking);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.btnShowRanking]));
			w10.Position = 1;
			w10.Fill = false;
			w10.Padding = ((uint)(10));
			this.vbox2.Add(this.hbox5);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox5]));
			w11.Position = 4;
			w11.Expand = false;
			w11.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.btnSettings = new global::Gtk.Button();
			this.btnSettings.WidthRequest = 300;
			this.btnSettings.CanFocus = true;
			this.btnSettings.Name = "btnSettings";
			this.btnSettings.UseUnderline = true;
			this.btnSettings.Label = global::Mono.Unix.Catalog.GetString("Settings");
			global::Gtk.Image w12 = new global::Gtk.Image();
			w12.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-properties", global::Gtk.IconSize.Button);
			this.btnSettings.Image = w12;
			this.hbox4.Add(this.btnSettings);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.btnSettings]));
			w13.Position = 1;
			w13.Fill = false;
			w13.Padding = ((uint)(10));
			this.vbox2.Add(this.hbox4);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox4]));
			w14.PackType = ((global::Gtk.PackType)(1));
			w14.Position = 5;
			w14.Expand = false;
			w14.Fill = false;
			this.Add(this.vbox2);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 689;
			this.DefaultHeight = 316;
			this.cbbQuestionsSets.HasDefault = true;
			this.btnSettings.Hide();
			this.Show();
			this.btnLogout.Clicked += new global::System.EventHandler(this.OnBtnLogoutClicked);
			this.cbbQuestionsSets.Changed += new global::System.EventHandler(this.OnCbbQuestionsSetsChanged);
			this.btnStartNewSession.Clicked += new global::System.EventHandler(this.OnBtnStartNewSessionClicked);
			this.btnShowRanking.Clicked += new global::System.EventHandler(this.OnBtnShowRankingClicked);
			this.btnSettings.Clicked += new global::System.EventHandler(this.OnBtnSettingsClicked);
		}
	}
}
