using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace xbWatson.Forms
{
	public partial class EventDialog : Form
	{
		public EventDialog(string title, string message, string middleButtonText)
		{
			this.InitializeComponent();
			this.Text = title;
			this.messageLabel.Text = message;
			this.middleButton.Text = middleButtonText;
		}

		private void button_Click(object sender, EventArgs e)
		{
			base.DialogResult = ((Button)sender).DialogResult;
		}
	}
}