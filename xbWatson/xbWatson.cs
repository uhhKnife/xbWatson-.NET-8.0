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

		   // Apply dark mode from registry on creation
		   bool isDarkMode = false;
		   using (var registryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\XenonSDK\\xbWatson\\Options"))
		   {
			   if (registryKey != null)
			   {
				   var darkModeValue = registryKey.GetValue("DarkMode");
				   isDarkMode = darkModeValue != null && darkModeValue.ToString() == "True";
			   }
		   }
		   SetDarkMode(isDarkMode);
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

private StreamWriter autoLogWriter;
private string autoLogPath;

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
		WriteAutoLog($"{now.ToLongDateString()}\t{now.ToLongTimeString()}\t");
	}
	LogAppendText(logText);
	WriteAutoLog(logText);
}

private void WriteAutoLog(string text)
{
	try
	{
		if (autoLogWriter == null)
		{
			InitAutoLog();
		}
		autoLogWriter.Write(text);
		autoLogWriter.Flush();
	}
	catch (Exception ex)
	{
		// Don't throw, but allow debugging
		System.Diagnostics.Debug.WriteLine($"AutoLog error: {ex}");
	}
}

private void InitAutoLog()
{
	try
	{
		string exeDir = Path.GetDirectoryName(Application.ExecutablePath);
		string logsDir = Path.Combine(exeDir, "logs");
		if (!Directory.Exists(logsDir))
			Directory.CreateDirectory(logsDir);
		string timestamp = DateTime.Now.ToString("ddMMyyHHmmss");
		string safeConsole = string.IsNullOrWhiteSpace(ConsoleName) ? "Unknown" : ConsoleName.Replace(" ", "_");
		autoLogPath = Path.Combine(logsDir, $"xbWatson_{safeConsole}_{timestamp}.log");
		autoLogWriter = new StreamWriter(autoLogPath, append: true) { AutoFlush = true };
	}
	catch (Exception ex)
	{
		System.Diagnostics.Debug.WriteLine($"InitAutoLog error: {ex}");
	}
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

		private bool confirmationShown = false;

		private void xbWatson_Closing(object sender, CancelEventArgs e)
		{
			if (isDisconnecting) return;

			if (!confirmationShown)
			{
				confirmationShown = true;
				var resourceManager = new ResourceManager("xbWatson.Strings", GetType().Assembly);
				var text = resourceManager.GetString("DisconnectConfirmation") + ConsoleName + "?";
				var result = MessageBox.Show(this, text, Name, MessageBoxButtons.OKCancel);
				if (result == DialogResult.OK)
				{
					isDisconnecting = true;
					Disconnect();
					MainWindow.RemoveFromList(this);
				}
				else
				{
					e.Cancel = true;
				}
			}
			else
			{
				e.Cancel = true;
				confirmationShown = false; // Reset for next time
			}
			// Close the auto log file if open
			if (autoLogWriter != null)
			{
				try { autoLogWriter.Close(); } catch { }
				autoLogWriter = null;
			}
		}

		private void log_MouseDown(object sender, MouseEventArgs e)
		{
			base.Activate();
		}

private bool IsDarkModeEnabled()
{
    using (var registryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\XenonSDK\\xbWatson\\Options"))
    {
        if (registryKey != null)
        {
            var darkModeValue = registryKey.GetValue("DarkMode");
            return darkModeValue != null && darkModeValue.ToString() == "True";
        }
    }
    return false;
}

private void LogAppendText(string text)
{
    if (log.InvokeRequired)
    {
        log.Invoke(new Action<string>(LogAppendText), text);
    }
    else
    {
        bool darkMode = IsDarkModeEnabled();
        string[] lines = text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string line in lines)
        {
            string normalizedLine = line.TrimEnd('\r', '\n').Trim();
            if (!string.IsNullOrEmpty(normalizedLine))
            {
                Color lineColor = log.ForeColor;
                Font lineFont = log.Font;
                if (darkMode)
                {
                    // Watson-specific log color coding
                    if (normalizedLine.StartsWith("xbWatson:")) // General Watson tag
                        lineColor = Color.LightBlue;
                    else if (normalizedLine == "*****************************************" || normalizedLine.Replace("*", "").Trim().Length == 0) // Separator line
                        lineColor = Color.Gray;
                    else if (normalizedLine.StartsWith("Configured action on")) // Action config
                        lineColor = Color.CadetBlue;
                    else if (normalizedLine.StartsWith("Dump saved as")) // Dump file
                        lineColor = Color.Teal;
                    else if (normalizedLine == "Console paused." || normalizedLine.StartsWith("Console resumed.")) // Pause/resume
                        lineColor = Color.MediumPurple;
                    else if (normalizedLine.StartsWith("Exception :")) // Exception
                        lineColor = Color.Orange;
                    else if (normalizedLine.StartsWith("Assertion failed:")) // Assertion
                        lineColor = Color.Red;
                    else if (normalizedLine.StartsWith("RIP :")) // RIP
                        lineColor = Color.OrangeRed;
                    else if (normalizedLine.StartsWith("Break:")) // Break
                        lineColor = Color.MediumVioletRed;
                    else if (normalizedLine.ToLower().Contains("error")) // Error
                        lineColor = Color.DarkRed;
                    else if (normalizedLine.ToLower().Contains("warning")) // Warning
                        lineColor = Color.Yellow;
                    else
                        lineColor = Color.FromArgb(255, 192, 203); // Default pink for dark mode
                }
                else
                {
                    lineColor = Color.Black;
                }
                int start = log.TextLength;
                log.AppendText(normalizedLine + "\n");
                log.Select(start, normalizedLine.Length + 1);
                log.SelectionColor = lineColor;
                log.SelectionFont = lineFont;
                log.SelectionStart = log.TextLength;
                log.SelectionLength = 0;
                log.SelectionColor = log.ForeColor; // Reset to default
                log.ScrollToCaret();
            }
        }
    }
}

	   public void SetDarkMode(bool enable)
	   {
		   // Save preference
		   using (var regKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\XenonSDK\\xbWatson\\Options"))
		   {
			   regKey?.SetValue("DarkMode", enable ? "True" : "False");
		   }
		   // Main window
		   this.BackColor = enable ? System.Drawing.Color.FromArgb(32, 32, 32) : System.Drawing.SystemColors.Control;
		   this.ForeColor = enable ? System.Drawing.Color.White : System.Drawing.Color.Black;

		   // Log box
		   if (log != null && !log.IsDisposed)
		   {
			   log.BackColor = enable ? System.Drawing.Color.Black : System.Drawing.SystemColors.Window;
			   log.ForeColor = enable ? System.Drawing.Color.FromArgb(255, 192, 203) : System.Drawing.Color.Black; // Pink in dark mode
			   // Update all text color in log
			   if (log.TextLength > 0)
			   {
				   log.SelectAll();
				   log.SelectionColor = log.ForeColor;
				   log.DeselectAll();
			   }
		   }

		   // Set all button text color for contrast
		   foreach (System.Windows.Forms.Control ctrl in this.Controls)
		   {
			   if (ctrl is System.Windows.Forms.Button btn)
			   {
				   btn.ForeColor = enable ? System.Drawing.Color.White : System.Drawing.SystemColors.ControlText;
			   }
		   }
		   // Set menu strip and menu item colors for contrast if present
		   foreach (System.Windows.Forms.Control ctrl in this.Controls)
		   {
			   if (ctrl is System.Windows.Forms.MenuStrip menuStrip)
			   {
				   menuStrip.BackColor = this.BackColor;
				   menuStrip.ForeColor = this.ForeColor;
				   foreach (System.Windows.Forms.ToolStripMenuItem menu in menuStrip.Items)
				   {
					   menu.BackColor = this.BackColor;
					   menu.ForeColor = this.ForeColor;
				   }
			   }
		   }
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