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
			MainWindow = parentWindow;
			ConsoleName = xboxName;
			fLimitBufferLength = false;
			fTimestamp = false;
			InitializeComponent();
			ClosingEventHandler = xbWatson_Closing;
			Closing += ClosingEventHandler;
			Visible = true;
			Text += $" {xboxName}";
		}

		public string ConsoleName
		{
			get
			{
				return consoleName;
			}
			set
			{
				consoleName = value;
			}
		}

		public void DisableClosingEventHandler()
		{
			Closing -= ClosingEventHandler;
		}

		public void EnableClosingEventHandler()
		{
			Closing += ClosingEventHandler;
		}

		public bool Connect(string xboxName)
		{
			try
			{
				xboxDebugManager = new DebugManager(this, xboxName);
				xboxDebugManager.InitDM();
				return true;
			}
			catch (Exception arg)
			{
				Log($"Could not connect to Xbox\n {arg}");
			}
			return false;
		}

		public void Disconnect()
		{
			if (isDisconnecting) return;
			isDisconnecting = true;
			xboxDebugManager?.UnInitDM();
		}

		public void Log(string logText)
		{
			if (logText is null)
				return;
			if (fLimitBufferLength)
				LimitBufferLength();
			if (fTimestamp)
			{
				var now = DateTime.Now;
				LogAppendText($"{now.ToLongDateString()}\t{now.ToLongTimeString()}\t");
			}
			LogAppendText(logText);
		}

		public bool IsLimitBufferLengthChecked()
		{
			return fLimitBufferLength;
		}

		public bool IsAddTimestampsChecked()
		{
			return fTimestamp;
		}

		public static bool DumpLog(IWin32Window owner, IXboxConsole xboxConsole)
		{
            SaveFileDialog saveFileDialog = new()
            {
                DefaultExt = "dmp",
                Filter = "MiniDump (*.dmp)|*.dmp|MiniDump with heap (*.dmp)|*.dmp",
                FilterIndex = 1,
                OverwritePrompt = false
            };
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
			using var registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\XenonSDK\\xbWatson\\Options");
			if (registryKey is null)
			{
				Log("Cannot open registry for Dump location");
				return false;
			}
			var path = registryKey.GetValue("Path") as string;
			var format = registryKey.GetValue("Format") as string;
			Directory.CreateDirectory($"{path}\\{xboxConsole.Name}");
			var now = DateTime.Now;
			var dumpPath = $"{path}\\{xboxConsole.Name}\\Dump{now.Ticks}.dmp";
			if (format == "Mini")
				xboxConsole.DebugTarget.WriteDump(dumpPath, (XboxDumpFlags)0);
			else
				xboxConsole.DebugTarget.WriteDump(dumpPath, (XboxDumpFlags)2);
			Log($"Dump saved as {dumpPath}\n");
			Log("*****************************************\n");
			return true;
		}

		public void SaveLog()
		{
            SaveLogFile = new SaveFileDialog
            {
                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 1,
                OverwritePrompt = true
            };
            if (SaveLogFile.ShowDialog(this) == DialogResult.OK && SaveLogFile.FileName.Length > 0)
			{
				log.SaveFile(SaveLogFile.FileName, RichTextBoxStreamType.PlainText);
			}
		}

		public void logCopy()
		{
			log.Copy();
		}

		public void logClear()
		{
			log.Clear();
		}

		public void logSelectAll()
		{
			log.SelectAll();
		}

		public void LimitBufferLength()
		{
			fLimitBufferLength = !fLimitBufferLength;
			contextMenuLimitBufferLength.Checked = fLimitBufferLength;
		}

		public void AddTimestamps()
		{
			fTimestamp = !fTimestamp;
			contextMenuAddTimestamps.Checked = fTimestamp;
		}

		private void contextMenuCopySelection_Click(object sender, EventArgs e)
		{
			log.Copy();
		}

		private void contextMenuCopyContents_Click(object sender, EventArgs e)
		{
			log.Copy();
		}

		private void contextMenuClearWindow_Click(object sender, EventArgs e)
		{
			log.Clear();
		}

		private void contextMenuSelectAll_Click(object sender, EventArgs e)
		{
			log.SelectAll();
		}

		private void contextMenuSaveContents_Click(object sender, EventArgs e)
		{
			SaveLog();
		}

		private void contextMenuLimitBufferLength_Click(object sender, EventArgs e)
		{
			fLimitBufferLength = !fLimitBufferLength;
			contextMenuLimitBufferLength.Checked = fLimitBufferLength;
		}

		private void contextMenuAddTimestamps_Click(object sender, EventArgs e)
		{
			fTimestamp = !fTimestamp;
			contextMenuAddTimestamps.Checked = fTimestamp;
		}

		private void xbWatson_Closing(object sender, CancelEventArgs e)
		{
			if (isDisconnecting) return;
			var resourceManager = new ResourceManager("xbWatson.Strings", GetType().Assembly);
			var text = resourceManager.GetString("DisconnectConfirmation") + ConsoleName + "?";
			switch (MessageBox.Show(this, text, Name, MessageBoxButtons.OKCancel))
			{
				case DialogResult.OK:
					Disconnect();
					MainWindow.RemoveFromList(this);
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
			log.AppendText(text);
		}

		private SaveFileDialog SaveLogFile;
		private bool fLimitBufferLength;
		private bool fTimestamp;
		private readonly xbWatsonUI MainWindow;
		private string consoleName;
		private readonly CancelEventHandler ClosingEventHandler;
		private DebugManager xboxDebugManager;
		private bool isDisconnecting = false;
	}
}