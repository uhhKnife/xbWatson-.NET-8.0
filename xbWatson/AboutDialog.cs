using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace xbWatson
{
	public partial class AboutDialog : Form
	{
		public AboutDialog(xbWatsonUI xboxWatson)
		{
			this.InitializeComponent();
			FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(base.GetType().Assembly.Location);
			ResourceManager resourceManager = new(typeof(xbWatsonUI));
			ResourceManager resourceManager2 = new("xbWatson.Strings", base.GetType().Assembly);
			this.label1.Text = resourceManager2.GetString("Version") + versionInfo.FileVersion + "\n" + versionInfo.LegalCopyright;
			base.ShowDialog(xboxWatson);
			resourceManager.ReleaseAllResources();
			resourceManager2.ReleaseAllResources();
		}

		private void OK_Click(object sender, EventArgs e)
		{
			base.Close();
		}
	}
}