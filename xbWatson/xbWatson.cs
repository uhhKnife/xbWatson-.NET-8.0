using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Windows.Forms;
using Microsoft.Win32;
using XDevkit;

namespace xbWatson
{
	public partial class xbWatson : Form
	{
		public xbWatson(xbWatsonUI parentWindow, string xboxName)
		{
			this.MainWindow = parentWindow;
			this.ConsoleName = xboxName;
			this.fLimitBufferLength = false;
			this.fTimestamp = false;
			this.InitializeComponent();
			this.ClosingEventHandler = new CancelEventHandler(this.xbWatson_Closing);
			base.Closing += this.ClosingEventHandler;
			base.Visible = true;
			this.Text = this.Text + " " + xboxName;
		}

		public string ConsoleName
		{
			get
			{
				return this.consoleName;
			}
			set
			{
				this.consoleName = value;
			}
		}

		public void DisableClosingEventHandler()
		{
			base.Closing -= this.ClosingEventHandler;
		}

		public void EnableClosingEventHandler()
		{
			base.Closing += this.ClosingEventHandler;
		}

		public bool Connect(string xboxName)
		{
			try
			{
				this.xboxDebugManager = new DebugManager(this, xboxName);
				this.xboxDebugManager.InitDM();
				return true;
			}
			catch (Exception arg)
			{
				this.Log("Could not connect to Xbox\n " + arg);
			}
			return false;
		}

		private bool isDisconnecting = false;

		public void Disconnect()
		{
			if (isDisconnecting) return;
			isDisconnecting = true;
			this.xboxDebugManager.UnInitDM();
		}

		public void Log(string logText)
		{
			if (logText == null)
			{
				return;
			}
			if (this.fLimitBufferLength)
			{
				this.LimitBufferLength();
			}
			if (this.fTimestamp)
			{
				DateTime now = DateTime.Now;
				this.LogAppendText(now.ToLongDateString() + "\t" + now.ToLongTimeString() + "\t");
			}
			this.LogAppendText(logText);
		}

		public bool IsLimitBufferLengthChecked()
		{
			return this.fLimitBufferLength;
		}

		public bool IsAddTimestampsChecked()
		{
			return this.fTimestamp;
		}

		public bool DumpLog(IWin32Window owner, IXboxConsole xboxConsole)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.DefaultExt = "dmp";
			saveFileDialog.Filter = "MiniDump (*.dmp)|*.dmp|MiniDump with heap (*.dmp)|*.dmp";
			saveFileDialog.FilterIndex = 1;
			saveFileDialog.OverwritePrompt = false;
			DialogResult dialogResult = saveFileDialog.ShowDialog(owner);
			if (dialogResult == DialogResult.OK && saveFileDialog.FileName.Length > 0)
			{
				if (saveFileDialog.FilterIndex == 1)
				{
					xboxConsole.DebugTarget.WriteDump(saveFileDialog.FileName, (XboxDumpFlags)0);
				}
				else
				{
					xboxConsole.DebugTarget.WriteDump(saveFileDialog.FileName, (XboxDumpFlags)2);
				}
				return true;
			}
			return false;
		}

		public bool DumpLog(IXboxConsole xboxConsole)
		{
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\XenonSDK\\xbWatson\\Options");
			if (registryKey == null)
			{
				this.Log("Cannot open registry for Dump location");
				return false;
			}
			string text = (string)registryKey.GetValue("Path");
			string text2 = (string)registryKey.GetValue("Format");
			Directory.CreateDirectory(text + "\\" + xboxConsole.Name);
			DateTime now = DateTime.Now;
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"\\",
				xboxConsole.Name,
				"\\Dump",
				now.Ticks,
				".dmp"
			});
			if (text2.Equals("Mini"))
			{
				xboxConsole.DebugTarget.WriteDump(text, (XboxDumpFlags)0);
			}
			else
			{
				xboxConsole.DebugTarget.WriteDump(text, (XboxDumpFlags)2);
			}
			this.Log("Dump saved as " + text + "\n");
			this.Log("*****************************************\n");
			registryKey.Close();
			return true;
		}

		public void SaveLog()
		{
			this.SaveLogFile = new SaveFileDialog();
			this.SaveLogFile.DefaultExt = "txt";
			this.SaveLogFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
			this.SaveLogFile.FilterIndex = 1;
			this.SaveLogFile.OverwritePrompt = true;
			if (this.SaveLogFile.ShowDialog(this) == DialogResult.OK && this.SaveLogFile.FileName.Length > 0)
			{
				this.log.SaveFile(this.SaveLogFile.FileName, RichTextBoxStreamType.PlainText);
			}
		}

		public void logCopy()
		{
			this.log.Copy();
		}

		public void logClear()
		{
			this.log.Clear();
		}

		public void logSelectAll()
		{
			this.log.SelectAll();
		}

		public void LimitBufferLength()
		{
			this.fLimitBufferLength = !this.fLimitBufferLength;
			this.contextMenuLimitBufferLength.Checked = this.fLimitBufferLength;
		}

		public void AddTimestamps()
		{
			this.fTimestamp = !this.fTimestamp;
			this.contextMenuAddTimestamps.Checked = this.fTimestamp;
		}

		private void contextMenuCopySelection_Click(object sender, EventArgs e)
		{
			this.log.Copy();
		}

		private void contextMenuCopyContents_Click(object sender, EventArgs e)
		{
			this.log.Copy();
		}

		private void contextMenuClearWindow_Click(object sender, EventArgs e)
		{
			this.log.Clear();
		}

		private void contextMenuSelectAll_Click(object sender, EventArgs e)
		{
			this.log.SelectAll();
		}

		private void contextMenuSaveContents_Click(object sender, EventArgs e)
		{
			this.SaveLog();
		}

		private void contextMenuLimitBufferLength_Click(object sender, EventArgs e)
		{
			this.fLimitBufferLength = !this.fLimitBufferLength;
			this.contextMenuLimitBufferLength.Checked = this.fLimitBufferLength;
		}

		private void contextMenuAddTimestamps_Click(object sender, EventArgs e)
		{
			this.fTimestamp = !this.fTimestamp;
			this.contextMenuAddTimestamps.Checked = this.fTimestamp;
		}

		private void xbWatson_Closing(object sender, CancelEventArgs e)
		{
			if (isDisconnecting) return;
			ResourceManager resourceManager = new ResourceManager("xbWatson.Strings", base.GetType().Assembly);
			string text = resourceManager.GetString("DisconnectConfirmation") + this.ConsoleName + "?";
			switch (MessageBox.Show(this, text, base.Name, MessageBoxButtons.OKCancel))
			{
			case DialogResult.OK:
				this.Disconnect();
				this.MainWindow.RemoveFromList(this);
				return;
			case DialogResult.Cancel:
				e.Cancel = true;
				return;
			default:
				return;
			}
		}

		private void log_MouseDown(object sender, MouseEventArgs e)
		{
			base.Activate();
		}

		private void LogAppendText(string text)
		{
			this.log.AppendText(text);
		}

		private SaveFileDialog SaveLogFile;

		private bool fLimitBufferLength;

		private bool fTimestamp;

		private xbWatsonUI MainWindow;

		private string consoleName;

		private CancelEventHandler ClosingEventHandler;

		private DebugManager xboxDebugManager;
	}
}