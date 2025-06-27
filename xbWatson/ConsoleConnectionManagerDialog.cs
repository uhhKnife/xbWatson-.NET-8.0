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
			resources = new ResourceManager("xbWatson.Strings", GetType().Assembly);
			InitializeComponent();
			consoleNames = [];
			IsConsoleSelected = [];
			InitializeConsoleList();
		}

		public void InitializeConsoleList()
		{
			xbWatsonRegKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\XenonSDK\\xbWatson\\Consoles");
			if (xbWatsonRegKey is null)
			{
				Cursor = Cursors.WaitCursor;
				RestoreDefaults();
				Cursor = Cursors.Default;
				return;
			}
			var valueNames = xbWatsonRegKey.GetValueNames();
			foreach (var name in valueNames)
			{
				var regValue = xbWatsonRegKey.GetValue(name);
				consoleNames.Add(name);
				IsConsoleSelected.Add(regValue is not null && regValue.Equals("True"));
			}
			PopulateList();
		}

		private void PopulateList()
		{
			checkedListBoxMachines.Items.Clear();
			for (int i = 0; i < consoleNames.Count; i++)
			{
				try
				{
					var xboxManagerClass = new XboxManagerClass();
					var xboxConsole = xboxManagerClass.OpenConsole(consoleNames[i]);
					xboxConsole.FindConsole(2U, 50U);
					checkedListBoxMachines.Items.Add(consoleNames[i], IsConsoleSelected[i]);
					while (Marshal.ReleaseComObject(xboxConsole) > 0) { }
				}
				catch (COMException)
				{
					checkedListBoxMachines.Items.Add(consoleNames[i] + " (Not Available)", false);
					IsConsoleSelected[i] = false;
				}
			}
		}

		private void RestoreDefaults()
		{
			XenonShellExtensionRegKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\XenonSDK\\xbshlext\\Consoles");
			using var registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\XenonSDK");
			if (registryKey is null)
			{
				MessageBox.Show(Parent, resources.GetString("DefaultXenonAbsent"));
				return;
			}
			var text = registryKey.GetValue("XboxName") as string;
			if (XenonShellExtensionRegKey is null && text is null)
			{
				MessageBox.Show(Parent, resources.GetString("DefaultXenonAbsent"));
				return;
			}
			consoleNames.Clear();
			IsConsoleSelected.Clear();
			if (XenonShellExtensionRegKey is not null)
			{
				var valueNames = XenonShellExtensionRegKey.GetValueNames();
				for (int i = 1; i < valueNames.Length; i++)
				{
					bool flag = valueNames[i].Equals(text);
					consoleNames.Add(valueNames[i]);
					IsConsoleSelected.Add(flag);
				}
				XenonShellExtensionRegKey.Close();
			}
			if (consoleNames.Count == 0 && text is not null)
			{
				consoleNames.Add(text);
				IsConsoleSelected.Add(true);
			}
			PopulateList();
		}

		private void AddMachine(string name)
		{
			try
			{
				var xboxManagerClass = new XboxManagerClass();
				var xboxConsole = xboxManagerClass.OpenConsole(name);
				uint ipaddress = xboxConsole.IPAddress;
				consoleNames.Add(name);
				IsConsoleSelected.Add(true);
				PopulateList();
				while (Marshal.ReleaseComObject(xboxConsole) > 0) { }
			}
			catch (COMException)
			{
				string text = resources.GetString("ConsoleConnectionError") + name;
				MessageBox.Show(this, text);
			}
		}

		private void RemoveMachine(string name)
		{
			if (name is null) return;
			int num = consoleNames.IndexOf(name);
			if (num == -1)
			{
				string[] array = name.Split(' ');
				num = consoleNames.IndexOf(array[0]);
			}
			if (num != -1)
			{
				consoleNames.RemoveAt(num);
				IsConsoleSelected.RemoveAt(num);
				PopulateList();
			}
		}

		private void buttonDefaults_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			RestoreDefaults();
			Cursor = Cursors.Default;
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			if (textBoxConsoleName.Text.Equals(""))
			{
				MessageBox.Show(this, resources.GetString("ConsoleEntryRequest"));
				return;
			}
			if (consoleNames.Contains(textBoxConsoleName.Text))
			{
				MessageBox.Show(this, resources.GetString("ConsolePresentError"));
				return;
			}
			AddMachine(textBoxConsoleName.Text);
		}

		private void buttonRemove_Click(object sender, EventArgs e)
		{
			if (checkedListBoxMachines.SelectedItem is null)
			{
				MessageBox.Show(this, resources.GetString("ConsoleSelectRequest") ?? "Console select request");
				return;
			}
			RemoveMachine(checkedListBoxMachines.SelectedItem?.ToString());
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			if (xbWatsonRegKey is not null)
			{
				xbWatsonRegKey.Close();
				try
				{
					Registry.CurrentUser.DeleteSubKeyTree("Software\\Microsoft\\XenonSDK\\xbWatson\\Consoles");
				}
				catch (Exception)
				{
				}
			}
			xbWatsonRegKey = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\XenonSDK\\xbWatson\\Consoles");
			if (xbWatsonRegKey is null)
			{
				MessageBox.Show(this, resources.GetString("ChangesSaveError"));
				return;
			}
			for (int i = 0; i < consoleNames.Count; i++)
			{
				xbWatsonRegKey.SetValue((string)consoleNames[i], IsConsoleSelected[i]);
			}
			base.Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.xbWatsonRegKey?.Close();
			base.Close();
		}

		private void checkedListBoxMachines_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			int index = e.Index;
			var item = checkedListBoxMachines.Items[index];
			var itemString = item?.ToString();
			if (itemString is not null)
			{
				int num = consoleNames.IndexOf(itemString);
				if (num != -1)
				{
					IsConsoleSelected[num] = (e.NewValue == CheckState.Checked);
					return;
				}
			}
			e.NewValue = e.CurrentValue;
			MessageBox.Show(this, resources.GetString("ConsoleNotAvailable") ?? "Console not available");
		}

		private RegistryKey xbWatsonRegKey;
		private RegistryKey XenonShellExtensionRegKey;
		private readonly List<string> consoleNames;
		private readonly List<bool> IsConsoleSelected;
		private readonly ResourceManager resources;
	}
}