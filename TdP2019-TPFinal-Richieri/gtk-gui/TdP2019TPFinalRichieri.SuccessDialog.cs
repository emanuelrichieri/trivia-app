
// This file has been generated by the GUI designer. Do not modify.
namespace TdP2019TPFinalRichieri
{
	public partial class SuccessDialog
	{
		private global::Gtk.VBox dialog1_VBox1;

		private global::Gtk.VBox vbox7;

		private global::Gtk.HBox hbox5;

		private global::Gtk.Image imgInfo;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gtk.TextView txtMessage;

		private global::Gtk.Button btnClose;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget TdP2019TPFinalRichieri.SuccessDialog
			this.WidthRequest = 400;
			this.HeightRequest = 130;
			this.Name = "TdP2019TPFinalRichieri.SuccessDialog";
			this.Title = global::Mono.Unix.Catalog.GetString("Success");
			this.Icon = global::Stetic.IconLoader.LoadIcon(this, "gtk-ok", global::Gtk.IconSize.Menu);
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.Modal = true;
			this.Resizable = false;
			// Internal child TdP2019TPFinalRichieri.SuccessDialog.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.WidthRequest = 400;
			w1.HeightRequest = 100;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.dialog1_VBox1 = new global::Gtk.VBox();
			this.dialog1_VBox1.WidthRequest = 400;
			this.dialog1_VBox1.HeightRequest = 100;
			this.dialog1_VBox1.Name = "dialog1_VBox1";
			this.dialog1_VBox1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox1.Gtk.Box+BoxChild
			this.vbox7 = new global::Gtk.VBox();
			this.vbox7.WidthRequest = 400;
			this.vbox7.HeightRequest = 100;
			this.vbox7.Name = "vbox7";
			this.vbox7.Spacing = 6;
			// Container child vbox7.Gtk.Box+BoxChild
			this.hbox5 = new global::Gtk.HBox();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.imgInfo = new global::Gtk.Image();
			this.imgInfo.Name = "imgInfo";
			this.imgInfo.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-ok", global::Gtk.IconSize.Menu);
			this.hbox5.Add(this.imgInfo);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.imgInfo]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.txtMessage = new global::Gtk.TextView();
			this.txtMessage.WidthRequest = 400;
			this.txtMessage.HeightRequest = 80;
			this.txtMessage.CanFocus = true;
			this.txtMessage.Name = "txtMessage";
			this.txtMessage.Editable = false;
			this.txtMessage.CursorVisible = false;
			this.txtMessage.Justification = ((global::Gtk.Justification)(3));
			this.txtMessage.WrapMode = ((global::Gtk.WrapMode)(2));
			this.GtkScrolledWindow.Add(this.txtMessage);
			this.hbox5.Add(this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.GtkScrolledWindow]));
			w4.Position = 1;
			this.vbox7.Add(this.hbox5);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox7[this.hbox5]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			this.dialog1_VBox1.Add(this.vbox7);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.dialog1_VBox1[this.vbox7]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			w1.Add(this.dialog1_VBox1);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(w1[this.dialog1_VBox1]));
			w7.Position = 0;
			w7.Expand = false;
			w7.Fill = false;
			// Internal child TdP2019TPFinalRichieri.SuccessDialog.ActionArea
			global::Gtk.HButtonBox w8 = this.ActionArea;
			w8.Name = "__gtksharp_77_Stetic_TopLevelDialog_ActionArea";
			// Container child __gtksharp_77_Stetic_TopLevelDialog_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.btnClose = new global::Gtk.Button();
			this.btnClose.CanFocus = true;
			this.btnClose.Name = "btnClose";
			this.btnClose.UseStock = true;
			this.btnClose.UseUnderline = true;
			this.btnClose.Label = "gtk-close";
			this.AddActionWidget(this.btnClose, -7);
			global::Gtk.ButtonBox.ButtonBoxChild w9 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w8[this.btnClose]));
			w9.Expand = false;
			w9.Fill = false;
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 404;
			this.DefaultHeight = 300;
			this.Show();
			this.btnClose.Clicked += new global::System.EventHandler(this.OnClickBtnClose);
		}
	}
}
