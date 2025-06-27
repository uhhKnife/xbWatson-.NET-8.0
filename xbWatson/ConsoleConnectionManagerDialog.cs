using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;
using XDevkit;
using System.Collections.Generic;

namespace xbWatson
{
	public partial class ConsoleConnectionManagerDialog : Form
	{
		public ConsoleConnectionManagerDialog()
		{
			this.resources = new ResourceManager("xbWatson.Strings", base.GetType().Assembly);
			this.InitializeComponent();
			this.consoleNames = [];
			this.IsConsoleSelected = [];
			this.InitializeConsoleList();
		}

		public void InitializeConsoleList()
		{
			this.xbWatsonRegKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\XenonSDK\\xbWatson\\Consoles");
			if (this.xbWatsonRegKey is null)
			{
				this.Cursor = Cursors.WaitCursor;
				this.RestoreDefaults();
				this.Cursor = Cursors.Default;
				return;
			}
			string[] valueNames = this.xbWatsonRegKey.GetValueNames();
			for (int i = 0; i < valueNames.Length; i++)
			{
				this.consoleNames.Add(valueNames[i]);
				this.IsConsoleSelected.Add(this.xbWatsonRegKey.GetValue(valueNames[i]).Equals("True"));
			}
			this.PopulateList();
		}

		private void PopulateList()
		{
			this.checkedListBoxMachines.Items.Clear();
			for (int i = 0; i < this.consoleNames.Count; i++)
			{
				try
				{
					XboxManagerClass xboxManagerClass = new();
					IXboxConsole xboxConsole = xboxManagerClass.OpenConsole(this.consoleNames[i]);
					xboxConsole.FindConsole(2U, 50U);
					this.checkedListBoxMachines.Items.Add(this.consoleNames[i], this.IsConsoleSelected[i]);
					while (Marshal.ReleaseComObject(xboxConsole) != 0)
					{
					}
				}
				catch (COMException)
				{
					this.checkedListBoxMachines.Items.Add(this.consoleNames[i] + " (Not Available)", false);
					this.IsConsoleSelected[i] = false;
				}
			}
		}

		private void RestoreDefaults()
		{
			this.XenonShellExtensionRegKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\XenonSDK\\xbshlext\\Consoles");
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\XenonSDK");
			if (registryKey is null)
			{
				MessageBox.Show(base.Parent, this.resources.GetString("DefaultXenonAbsent"));
				registryKey.Close();
				return;
			}
			string text = (string)registryKey.GetValue("XboxName");
			if (this.XenonShellExtensionRegKey is null && text is null)
			{
				MessageBox.Show(base.Parent, this.resources.GetString("DefaultXenonAbsent"));
				return;
			}
			this.consoleNames.Clear();
			this.IsConsoleSelected.Clear();
			if (this.XenonShellExtensionRegKey is not null)
			{
				string[] valueNames = this.XenonShellExtensionRegKey.GetValueNames();
				for (int i = 1; i < valueNames.Length; i++)
				{
					bool flag = valueNames[i].Equals(text);
					this.consoleNames.Add(valueNames[i]);
					this.IsConsoleSelected.Add(flag);
				}
				this.XenonShellExtensionRegKey.Close();
			}
			if (this.consoleNames.Count == 0 && text is not null)
			{
				this.consoleNames.Add(text);
				this.IsConsoleSelected.Add(true);
			}
			this.PopulateList();
			registryKey.Close();
		}

		private void AddMachine(string name)
		{
			try
			{
				XboxManagerClass xboxManagerClass = new();
				IXboxConsole xboxConsole = xboxManagerClass.OpenConsole(name);
				uint ipaddress = xboxConsole.IPAddress;
				this.consoleNames.Add(name);
				this.IsConsoleSelected.Add(true);
				this.PopulateList();
				while (Marshal.ReleaseComObject(xboxConsole) != 0)
				{
				}
			}
			catch (COMException)
			{
				string text = this.resources.GetString("ConsoleConnectionError") + name;
				MessageBox.Show(this, text);
			}
		}

		private void RemoveMachine(string name)
		{
			int num = this.consoleNames.IndexOf(name);
			if (num is -1)
			{
				string text = " ";
				char[] separator = text.ToCharArray();
				string[] array = name.Split(separator);
				num = this.consoleNames.IndexOf(array[0]);
			}
			this.consoleNames.RemoveAt(num);
			this.IsConsoleSelected.RemoveAt(num);
			this.PopulateList();
		}

		private void buttonDefaults_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			this.RestoreDefaults();
			this.Cursor = Cursors.Default;
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			if (this.textBoxConsoleName.Text.Equals(""))
			{
				MessageBox.Show(this, this.resources.GetString("ConsoleEntryRequest"));
				return;
			}
			if (this.consoleNames.Contains(this.textBoxConsoleName.Text))
			{
				MessageBox.Show(this, this.resources.GetString("ConsolePresentError"));
				return;
			}
			this.AddMachine(this.textBoxConsoleName.Text);
		}

		private void buttonRemove_Click(object sender, EventArgs e)
		{
			if (this.checkedListBoxMachines.SelectedItem is null)
			{
				MessageBox.Show(this, this.resources.GetString("ConsoleSelectRequest"));
				return;
			}
			this.RemoveMachine(this.checkedListBoxMachines.SelectedItem.ToString());
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			if (this.xbWatsonRegKey is not null)
			{
				this.xbWatsonRegKey.Close();
				try
				{
					Registry.CurrentUser.DeleteSubKeyTree("Software\\Microsoft\\XenonSDK\\xbWatson\\Consoles");
				}
				catch (Exception)
				{
				}
			}
			this.xbWatsonRegKey = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\XenonSDK\\xbWatson\\Consoles");
			if (this.xbWatsonRegKey is null)
			{
				MessageBox.Show(this, this.resources.GetString("ChangesSaveError"));
				return;
			}
			for (int i = 0; i < this.consoleNames.Count; i++)
			{
				this.xbWatsonRegKey.SetValue((string)this.consoleNames[i], this.IsConsoleSelected[i]);
			}
			base.Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			if (this.xbWatsonRegKey is not null)
			{
				this.xbWatsonRegKey.Close();
			}
			base.Close();
		}

		private void checkedListBoxMachines_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			int index = e.Index;
			int num = this.consoleNames.IndexOf(this.checkedListBoxMachines.Items[index].ToString());
			if (num is not -1)
			{
				this.IsConsoleSelected[num] = (e.NewValue == CheckState.Checked);
				return;
			}
			e.NewValue = e.CurrentValue;
			MessageBox.Show(this, this.resources.GetString("ConsoleNotAvailable"));
		}

		private RegistryKey xbWatsonRegKey;
		private RegistryKey XenonShellExtensionRegKey;
		private readonly List<string> consoleNames;
		private readonly List<bool> IsConsoleSelected;
	}
}