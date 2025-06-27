using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using Microsoft.Win32;

namespace xbWatson
{
	public partial class DumpLocationDialog : Form
	{
		public DumpLocationDialog()
		{
			this.resources = new ResourceManager("xbWatson.Strings", base.GetType().Assembly);
			this.InitializeComponent();
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\XenonSDK\\xbWatson\\Options");
			if (registryKey is null)
			{
				MessageBox.Show(this, this.resources.GetString("RegistryAccessError"));
				return;
			}
			this.textBoxPath.Text = (string)registryKey.GetValue("Path");
			registryKey.Close();
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			if (this.textBoxPath.Text.Equals(""))
			{
				MessageBox.Show(this, this.resources.GetString("PathEntryRequest"));
				return;
			}
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\XenonSDK\\xbWatson\\Options", true);
			if (registryKey is null)
			{
				MessageBox.Show(this, this.resources.GetString("RegistryAccessError"));
				return;
			}
			registryKey.SetValue("Path", this.textBoxPath.Text);
			registryKey.Close();
			base.Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void buttonPath_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			folderBrowserDialog.ShowNewFolderButton = true;
			DialogResult dialogResult = folderBrowserDialog.ShowDialog(this);
			if (dialogResult == DialogResult.OK)
			{
				this.textBoxPath.Text = folderBrowserDialog.SelectedPath;
			}
		}
	}
}