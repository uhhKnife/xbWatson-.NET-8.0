using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Collections.Generic;

namespace xbWatson
{
	public partial class xbWatsonUI : Form
	{
		public xbWatsonUI()
		{
			resources = new ResourceManager("xbWatson.Strings", GetType().Assembly);
			ConnectedConsolesList = [];
			xbWatsonList = [];
			InitializeComponent();
			Show();
			InitializeOptions();
			CheckForConsoles();
			Show();
			if (menuConfigureConnectOnStart.Checked)
			{
				Start();
			}
		}

		private void InitializeOptions()
		{
			using var registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\XenonSDK\\xbWatson\\Options", true) ??
				Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\XenonSDK\\xbWatson\\Options");
			if (registryKey is null)
			{
				MessageBox.Show(this, resources.GetString("RegistrCreationError") ?? "Registry creation error");
				return;
			}
			if (registryKey.GetValue("OnAssert") is null)
			{
				registryKey.SetValue("OnAssert", "Prompt");
				registryKey.SetValue("OnRIP", "Prompt");
				registryKey.SetValue("OnException", "Prompt");
				registryKey.SetValue("AfterDump", "Restart");
				registryKey.SetValue("Format", "FullHeap");
				registryKey.SetValue("ConnectOnStart", "True");
				var text = Environment.GetEnvironmentVariable("XEDK") + "\\Dumps";
				registryKey.SetValue("Path", text);
				Directory.CreateDirectory(text);
				menuConfigureOnAssertPrompt.Checked = true;
				menuConfigureOnAssertBreak.Checked = false;
				menuConfigureOnAssertContinue.Checked = false;
				menuConfigureOnAssertRestart.Checked = false;
				menuConfigureOnRIPPrompt.Checked = true;
				menuConfigureOnRIPDump.Checked = false;
				menuConfigureOnRIPContinue.Checked = false;
				menuConfigureOnRIPRestart.Checked = false;
				menuConfigureOnExceptionPrompt.Checked = true;
				menuConfigureOnExceptionDump.Checked = false;
				menuConfigureOnExceptionContinue.Checked = false;
				menuConfigureOnExceptionRestart.Checked = false;
				menuConfigureAfterDumpRestart.Checked = true;
				menuConfigureAfterDumpContinue.Checked = false;
				menuConfigureDumpFormatFullHeap.Checked = true;
				menuConfigureDumpFormatMini.Checked = false;
				menuConfigureConnectOnStart.Checked = true;
			}
			else
			{
				var text2 = registryKey.GetValue("OnAssert") as string;
				if (text2 == "Break") menuConfigureOnAssertBreak.Checked = true;
				if (text2 == "Continue") menuConfigureOnAssertContinue.Checked = true;
				if (text2 == "Restart") menuConfigureOnAssertRestart.Checked = true;
				if (text2 == "Prompt") menuConfigureOnAssertPrompt.Checked = true;
				text2 = registryKey.GetValue("OnRIP") as string;
				if (text2 == "Dump") menuConfigureOnRIPDump.Checked = true;
				if (text2 == "Continue") menuConfigureOnRIPContinue.Checked = true;
				if (text2 == "Restart") menuConfigureOnRIPRestart.Checked = true;
				if (text2 == "Prompt") menuConfigureOnRIPPrompt.Checked = true;
				text2 = registryKey.GetValue("OnException") as string;
				if (text2 == "Dump") menuConfigureOnExceptionDump.Checked = true;
				if (text2 == "Continue") menuConfigureOnExceptionContinue.Checked = true;
				if (text2 == "Restart") menuConfigureOnExceptionRestart.Checked = true;
				if (text2 == "Prompt") menuConfigureOnExceptionPrompt.Checked = true;
				text2 = registryKey.GetValue("AfterDump") as string;
				if (text2 == "Continue") menuConfigureAfterDumpContinue.Checked = true;
				if (text2 == "Restart") menuConfigureAfterDumpRestart.Checked = true;
				text2 = registryKey.GetValue("Format") as string;
				if (text2 == "Mini") menuConfigureDumpFormatMini.Checked = true;
				if (text2 == "FullHeap") menuConfigureDumpFormatFullHeap.Checked = true;
				text2 = registryKey.GetValue("ConnectOnStart") as string;
				menuConfigureConnectOnStart.Checked = text2 == "True";
			}
		}

		private void CheckForConsoles()
		{
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\XenonSDK\\xbWatson\\Consoles");
			if (registryKey is null)
			{
				this.Cursor = Cursors.WaitCursor;
				var consoleConnectionManagerDialog = new ConsoleConnectionManagerDialog { Visible = false };
				this.Cursor = Cursors.Default;
				consoleConnectionManagerDialog.ShowDialog();
				return;
			}
			registryKey.Close();
		}

		private void Start()
		{
			this.Cursor = Cursors.WaitCursor;
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\XenonSDK\\xbWatson\\Consoles");
			if (registryKey is null)
			{
				this.Cursor = Cursors.Default;
				return;
			}
			string[] valueNames = registryKey.GetValueNames();
			for (int i = 0; i < valueNames.Length; i++)
			{
				if (registryKey.GetValue(valueNames[i]).Equals("True") && !this.ConnectedConsolesList.Contains(valueNames[i]))
				{
					this.StartConsole(valueNames[i]);
				}
				else if (registryKey.GetValue(valueNames[i]).Equals("False") && this.ConnectedConsolesList.Contains(valueNames[i]))
				{
					xbWatson xbWatson = this.GetxbWatsonFromName(valueNames[i]);
					if (xbWatson is not null)
					{
						this.RemoveFromList(xbWatson);
						this.StopConsole(xbWatson);
					}
				}
			}
			string[] array = [.. this.ConnectedConsolesList];
			for (int j = 0; j < array.Length; j++)
			{
				if (!ListContains(valueNames, array[j]))
				{
					xbWatson xbWatson2 = this.GetxbWatsonFromName(array[j]);
					if (xbWatson2 is not null)
					{
						this.RemoveFromList(xbWatson2);
						this.StopConsole(xbWatson2);
					}
				}
			}
			if (this.ConnectedConsolesList.Count > 0)
			{
				this.menuActionsStart.Enabled = false;
				this.menuActionsStop.Enabled = true;
			}
			else
			{
				this.menuActionsStart.Enabled = true;
				this.menuActionsStop.Enabled = false;
			}
			this.Cursor = Cursors.Default;
		}

		private void StartConsole(string name)
		{
			xbWatson xbWatson = new(this, name);
			if (xbWatson is null)
			{
				string text = this.resources.GetString("ConsoleConnectionError") + name;
				MessageBox.Show(this, text);
				return;
			}
			xbWatson.MdiParent = this;
			xbWatson.Show();
			xbWatson.Connect(name);
			this.xbWatsonList.Add(xbWatson);
			this.ConnectedConsolesList.Add(name);
		}

		private void Stop()
		{
			for (int i = 0; i < this.xbWatsonList.Count; i++)
			{
				xbWatson xb = this.xbWatsonList[i];
				this.StopConsole(xb);
			}
			this.xbWatsonList.Clear();
			this.menuActionsStop.Enabled = false;
			this.menuActionsStart.Enabled = true;
		}

		private void StopConsole(xbWatson xb)
		{
			this.ConnectedConsolesList.Remove(xb.ConsoleName);
			xb.DisableClosingEventHandler();
			xb.Disconnect();
			xb.Close();
        }

        private static bool ListContains(string[] list, string name)
		{
			foreach (var item in list)
			{
				if (item.Equals(name))
				{
					return true;
				}
			}
			return false;
		}

		private xbWatson GetxbWatsonFromName(string name)
		{
			for (int i = 0; i < this.xbWatsonList.Count; i++)
			{
				xbWatson xbWatson = this.xbWatsonList[i];
				if (xbWatson.ConsoleName.Equals(name))
				{
					return xbWatson;
				}
			}
			return null;
		}

		public void RemoveFromList(xbWatson xb)
		{
			this.ConnectedConsolesList.Remove(xb.ConsoleName);
			this.xbWatsonList.Remove(xb);
			if (this.ConnectedConsolesList.Count == 0)
			{
				this.menuActionsStart.Enabled = true;
				this.menuActionsStop.Enabled = false;
			}
		}

		public void UpdateChecks()
		{
			xbWatson xbWatson = (xbWatson)base.ActiveMdiChild;
			if (xbWatson is not null)
			{
				this.menuEditLimitBufferLength.Checked = xbWatson.IsLimitBufferLengthChecked();
				this.menuAddTimestamps.Checked = xbWatson.IsAddTimestampsChecked();
			}
		}

		[STAThread]
		private static void Main()
		{
			Application.Run(new xbWatsonUI());
		}

		private void menuActionsStart_Click(object sender, EventArgs e)
		{
			this.Start();
			if (this.ConnectedConsolesList.Count == 0)
			{
				this.Cursor = Cursors.WaitCursor;
				var consoleConnectionManagerDialog = new ConsoleConnectionManagerDialog { Visible = false };
				this.Cursor = Cursors.Default;
				DialogResult dialogResult = consoleConnectionManagerDialog.ShowDialog();
				if (dialogResult == DialogResult.OK)
				{
					this.Start();
				}
			}
		}

		private void xbWatson_Load(object sender, EventArgs e)
		{
		}

		private void xbWatsonUI_Click(object sender, EventArgs e)
		{
		}

		private void menuHelpAbout_Click(object sender, EventArgs e)
		{
			using var aboutDialog = new AboutDialog(this);
			// ShowDialog is not needed if AboutDialog shows itself in the constructor, otherwise:
			// aboutDialog.ShowDialog();
		}

		private void menuFileExit_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void menuActionsSelectConsoles_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			var consoleConnectionManagerDialog = new ConsoleConnectionManagerDialog { Visible = false };
			this.Cursor = Cursors.Default;
			DialogResult dialogResult = consoleConnectionManagerDialog.ShowDialog(this);
			if (dialogResult == DialogResult.OK)
			{
				this.Start();
			}
		}

		private void menuActionsStop_Click(object sender, EventArgs e)
		{
			this.Stop();
		}

		private void menuConfigureOnAssertPrompt_Click(object sender, EventArgs e)
		{
			if (this.menuConfigureOnAssertPrompt.Checked)
			{
				return;
			}
			this.menuConfigureOnAssertBreak.Checked = false;
			this.menuConfigureOnAssertContinue.Checked = false;
			this.menuConfigureOnAssertRestart.Checked = false;
			this.menuConfigureOnAssertPrompt.Checked = true;
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\XenonSDK\\xbWatson\\Options", true);
			if (registryKey is null)
			{
				MessageBox.Show(this, this.resources.GetString("RegistryAccessError"));
				return;
			}
			registryKey.SetValue("OnAssert", "Prompt");
			registryKey.Close();
		}

		private void menuConfigureOnAssertBreak_Click(object sender, EventArgs e)
		{
			if (this.menuConfigureOnAssertBreak.Checked)
			{
				return;
			}
			this.menuConfigureOnAssertPrompt.Checked = false;
			this.menuConfigureOnAssertContinue.Checked = false;
			this.menuConfigureOnAssertRestart.Checked = false;
			this.menuConfigureOnAssertBreak.Checked = true;
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\XenonSDK\\xbWatson\\Options", true);
			if (registryKey is null)
			{
				MessageBox.Show(this, this.resources.GetString("RegistryAccessError"));
				return;
			}
			registryKey.SetValue("OnAssert", "Break");
			registryKey.Close();
		}

		private void menuConfigureOnAssertContinue_Click(object sender, EventArgs e)
		{
			if (this.menuConfigureOnAssertContinue.Checked)
			{
				return;
			}
			this.menuConfigureOnAssertPrompt.Checked = false;
			this.menuConfigureOnAssertBreak.Checked = false;
			this.menuConfigureOnAssertRestart.Checked = false;
			this.menuConfigureOnAssertContinue.Checked = true;
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\XenonSDK\\xbWatson\\Options", true);
			if (registryKey is null)
			{
				MessageBox.Show(this, this.resources.GetString("RegistryAccessError"));
				return;
			}
			registryKey.SetValue("OnAssert", "Continue");
			registryKey.Close();
		}

		private void menuConfigureOnAssertRestart_Click(object sender, EventArgs e)
		{
			if (this.menuConfigureOnAssertRestart.Checked)
			{
				return;
			}
			this.menuConfigureOnAssertPrompt.Checked = false;
			this.menuConfigureOnAssertBreak.Checked = false;
			this.menuConfigureOnAssertContinue.Checked = false;
			this.menuConfigureOnAssertRestart.Checked = true;
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\XenonSDK\\xbWatson\\Options", true);
			if (registryKey is null)
			{
				MessageBox.Show(this, this.resources.GetString("RegistryAccessError"));
				return;
			}
			registryKey.SetValue("OnAssert", "Restart");
			registryKey.Close();
		}

		private void menuConfigureOnExceptionPrompt_Click(object sender, EventArgs e)
		{
			if (this.menuConfigureOnExceptionPrompt.Checked)
			{
				return;
			}
			this.menuConfigureOnExceptionRestart.Checked = false;
			this.menuConfigureOnExceptionDump.Checked = false;
			this.menuConfigureOnExceptionContinue.Checked = false;
			this.menuConfigureOnExceptionPrompt.Checked = true;
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\XenonSDK\\xbWatson\\Options", true);
			if (registryKey is null)
			{
				MessageBox.Show(this, this.resources.GetString("RegistryAccessError"));
				return;
			}
			registryKey.SetValue("OnException", "Prompt");
			registryKey.Close();
		}

		private void menuConfigureOnExceptionDump_Click(object sender, EventArgs e)
		{
			if (this.menuConfigureOnExceptionDump.Checked)
			{
				return;
			}
			this.menuConfigureOnExceptionRestart.Checked = false;
			this.menuConfigureOnExceptionPrompt.Checked = false;
			this.menuConfigureOnExceptionContinue.Checked = false;
			this.menuConfigureOnExceptionDump.Checked = true;
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\XenonSDK\\xbWatson\\Options", true);
			if (registryKey is null)
			{
				MessageBox.Show(this, this.resources.GetString("RegistryAccessError"));
				return;
			}
			registryKey.SetValue("OnException", "Dump");
			registryKey.Close();
		}

		private void menuConfigureOnExceptionContinue_Click(object sender, EventArgs e)
		{
			if (this.menuConfigureOnExceptionContinue.Checked)
			{
				return;
			}
			this.menuConfigureOnExceptionRestart.Checked = false;
			this.menuConfigureOnExceptionDump.Checked = false;
			this.menuConfigureOnExceptionPrompt.Checked = false;
			this.menuConfigureOnExceptionContinue.Checked = true;
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\XenonSDK\\xbWatson\\Options", true);
			if (registryKey is null)
			{
				MessageBox.Show(this, this.resources.GetString("RegistryAccessError"));
				return;
			}
			registryKey.SetValue("OnException", "Continue");
			registryKey.Close();
		}

		private void menuConfigureOnExceptionRestart_Click(object sender, EventArgs e)
		{
			if (this.menuConfigureOnExceptionRestart.Checked)
			{
				return;
			}
			this.menuConfigureOnExceptionPrompt.Checked = false;
			this.menuConfigureOnExceptionDump.Checked = false;
			this.menuConfigureOnExceptionContinue.Checked = false;
			this.menuConfigureOnExceptionRestart.Checked = true;
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\XenonSDK\\xbWatson\\Options", true);
			if (registryKey is null)
			{
				MessageBox.Show(this, this.resources.GetString("RegistryAccessError"));
				return;
			}
			registryKey.SetValue("OnException", "Restart");
			registryKey.Close();
		}

		private void menuConfigureOnRIPPrompt_Click(object sender, EventArgs e)
		{
			if (this.menuConfigureOnRIPPrompt.Checked)
			{
				return;
			}
			this.menuConfigureOnRIPRestart.Checked = false;
			this.menuConfigureOnRIPDump.Checked = false;
			this.menuConfigureOnRIPContinue.Checked = false;
			this.menuConfigureOnRIPPrompt.Checked = true;
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\XenonSDK\\xbWatson\\Options", true);
			if (registryKey is null)
			{
				MessageBox.Show(this, this.resources.GetString("RegistryAccessError"));
				return;
			}
			registryKey.SetValue("OnRIP", "Prompt");
			registryKey.Close();
		}

		private void menuConfigureOnRIPDump_Click(object sender, EventArgs e)
		{
			if (this.menuConfigureOnRIPDump.Checked)
			{
				return;
			}
			this.menuConfigureOnRIPRestart.Checked = false;
			this.menuConfigureOnRIPPrompt.Checked = false;
			this.menuConfigureOnRIPContinue.Checked = false;
			this.menuConfigureOnRIPDump.Checked = true;
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\XenonSDK\\xbWatson\\Options", true);
			if (registryKey is null)
			{
				MessageBox.Show(this, this.resources.GetString("RegistryAccessError"));
				return;
			}
			registryKey.SetValue("OnRIP", "Dump");
			registryKey.Close();
		}

		private void menuConfigureOnRIPContinue_Click(object sender, EventArgs e)
		{
			if (this.menuConfigureOnRIPContinue.Checked)
			{
				return;
			}
			this.menuConfigureOnRIPRestart.Checked = false;
			this.menuConfigureOnRIPDump.Checked = false;
			this.menuConfigureOnRIPPrompt.Checked = false;
			this.menuConfigureOnRIPContinue.Checked = true;
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\XenonSDK\\xbWatson\\Options", true);
			if (registryKey is null)
			{
				MessageBox.Show(this, this.resources.GetString("RegistryAccessError"));
				return;
			}
			registryKey.SetValue("OnRIP", "Continue");
			registryKey.Close();
		}

		private void menuConfigureOnRIPRestart_Click(object sender, EventArgs e)
		{
			if (this.menuConfigureOnRIPRestart.Checked)
			{
				return;
			}
			this.menuConfigureOnRIPPrompt.Checked = false;
			this.menuConfigureOnRIPDump.Checked = false;
			this.menuConfigureOnRIPContinue.Checked = false;
			this.menuConfigureOnRIPRestart.Checked = true;
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\XenonSDK\\xbWatson\\Options", true);
			if (registryKey is null)
			{
				MessageBox.Show(this, this.resources.GetString("RegistryAccessError"));
				return;
			}
			registryKey.SetValue("OnRIP", "Restart");
			registryKey.Close();
		}

		private void menuConfigureDumpFormatMini_Click(object sender, EventArgs e)
		{
			if (this.menuConfigureDumpFormatMini.Checked)
			{
				return;
			}
			this.menuConfigureDumpFormatFullHeap.Checked = false;
			this.menuConfigureDumpFormatMini.Checked = true;
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\XenonSDK\\xbWatson\\Options", true);
			if (registryKey is null)
			{
				MessageBox.Show(this, this.resources.GetString("RegistryAccessError"));
				return;
			}
			registryKey.SetValue("Format", "Mini");
			registryKey.Close();
		}

		private void menuConfigureDumpFormatFullHeap_Click(object sender, EventArgs e)
		{
			if (this.menuConfigureDumpFormatFullHeap.Checked)
			{
				return;
			}
			this.menuConfigureDumpFormatMini.Checked = false;
			this.menuConfigureDumpFormatFullHeap.Checked = true;
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\XenonSDK\\xbWatson\\Options", true);
			if (registryKey is null)
			{
				MessageBox.Show(this, this.resources.GetString("RegistryAccessError"));
				return;
			}
			registryKey.SetValue("Format", "FullHeap");
			registryKey.Close();
		}

		private void menuConfigureRestoreDefaults_Click(object sender, EventArgs e)
		{
			Registry.CurrentUser.DeleteSubKeyTree("Software\\Microsoft\\XenonSDK\\xbWatson\\Options");
			this.InitializeOptions();
		}

		private void menuConfigureDumpLocation_Click(object sender, EventArgs e)
		{
			new DumpLocationDialog
			{
				Visible = false
			}.ShowDialog();
		}

		private void menuConfigureAfterDumpContinue_Click(object sender, EventArgs e)
		{
			if (this.menuConfigureAfterDumpContinue.Checked)
			{
				return;
			}
			this.menuConfigureAfterDumpContinue.Checked = true;
			this.menuConfigureAfterDumpRestart.Checked = false;
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\XenonSDK\\xbWatson\\Options", true);
			if (registryKey is null)
			{
				MessageBox.Show(this, this.resources.GetString("RegistryAccessError"));
				return;
			}
			registryKey.SetValue("AfterDump", "Continue");
			registryKey.Close();
		}

		private void menuConfigureAfterDumpRestart_Click(object sender, EventArgs e)
		{
			if (this.menuConfigureAfterDumpRestart.Checked)
			{
				return;
			}
			this.menuConfigureAfterDumpContinue.Checked = false;
			this.menuConfigureAfterDumpRestart.Checked = true;
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\XenonSDK\\xbWatson\\Options", true);
			if (registryKey is null)
			{
				MessageBox.Show(this, this.resources.GetString("RegistryAccessError"));
				return;
			}
			registryKey.SetValue("AfterDump", "Restart");
			registryKey.Close();
		}

		private void menuWindowsTileVertically_Click(object sender, EventArgs e)
		{
			base.LayoutMdi(MdiLayout.TileVertical);
		}

		private void menuWindowsTileHorizontally_Click(object sender, EventArgs e)
		{
			base.LayoutMdi(MdiLayout.TileHorizontal);
		}

		private void menuItem3_Click(object sender, EventArgs e)
		{
			base.LayoutMdi(MdiLayout.Cascade);
		}

		private void menuConfigureConnectOnStart_Click(object sender, EventArgs e)
		{
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\XenonSDK\\xbWatson\\Options", true);
			if (registryKey is null)
			{
				MessageBox.Show(this, this.resources.GetString("RegistryAccessError"));
				return;
			}
			if (this.menuConfigureConnectOnStart.Checked)
			{
				registryKey.SetValue("ConnectOnStart", "False");
				this.menuConfigureConnectOnStart.Checked = false;
			}
			else
			{
				registryKey.SetValue("ConnectOnStart", "True");
				this.menuConfigureConnectOnStart.Checked = true;
			}
			registryKey.Close();
		}

		private void xbWatsonUI_Closing(object sender, CancelEventArgs e)
		{
		}

		private void menuFileSaveAs_Click(object sender, EventArgs e)
		{
			if (base.ActiveMdiChild is xbWatson xbWatson)
			{
				xbWatson.SaveLog();
			}
		}

		private void menuEditCopySelection_Click(object sender, EventArgs e)
		{
			if (base.ActiveMdiChild is xbWatson xbWatson)
			{
				xbWatson.logCopy();
			}
		}

		private void menuEditCopyContents_Click(object sender, EventArgs e)
		{
			if (base.ActiveMdiChild is xbWatson xbWatson)
			{
				xbWatson.logCopy();
			}
		}

		private void menuEditClearWindow_Click(object sender, EventArgs e)
		{
			if (base.ActiveMdiChild is xbWatson xbWatson)
			{
				xbWatson.logClear();
			}
		}

		private void menuEditSelectAll_Click(object sender, EventArgs e)
		{
			if (base.ActiveMdiChild is xbWatson xbWatson)
			{
				xbWatson.logSelectAll();
			}
		}

		private void menuEditLimitBufferLength_Click(object sender, EventArgs e)
		{
			if (base.ActiveMdiChild is xbWatson xbWatson)
			{
				xbWatson.LimitBufferLength();
			}
		}

		private void menuAddTimestamps_Click(object sender, EventArgs e)
		{
			if (base.ActiveMdiChild is xbWatson xbWatson)
			{
				xbWatson.AddTimestamps();
			}
		}

		private void menuEdit_Popup(object sender, EventArgs e)
		{
			this.UpdateChecks();
		}

		private void menuWindowsCascade_Click(object sender, EventArgs e)
		{
			base.LayoutMdi(MdiLayout.Cascade);
		}

		private readonly List<xbWatson> xbWatsonList;
		private readonly List<string> ConnectedConsolesList;
		private readonly ResourceManager resources;
	}
}