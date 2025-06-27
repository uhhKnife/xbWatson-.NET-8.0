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
			ResourceManager resourceManager2 = new("xbWatson.Strings", base.GetType().Assembly);

			string buildType = System.Diagnostics.Debugger.IsAttached ? "Debug" : "Release";
#if DEBUG
			buildType = "Debug";
#else
			buildType = "Release";
#endif
			string monthYear = DateTime.Now.ToString("MMM yyyy");
			string commitHash = GitVersion.Commit;

			this.label1.Text =
				"Microsoft (R) xbWatson\n" +
				$"{monthYear} {buildType} - {commitHash}\n" +
				"Copyright (C) Microsoft Corp.";
			base.ShowDialog(xboxWatson);
		}

		private void OK_Click(object sender, EventArgs e)
		{
			base.Close();
		}
	}
}