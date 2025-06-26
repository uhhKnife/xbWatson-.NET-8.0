using System;
using System.Windows.Forms;
using Microsoft.Win32;
using XDevkit;

namespace xbWatson
{
	internal abstract class CrashHandler : BreakHandler
	{
		protected CrashHandler(XboxConsole console, xbWatson watson) : base(console, watson)
		{
		}

		protected abstract string ActionValueName { get; }

		protected abstract string EventName { get; }

		public override void HandleEvent(IXboxEventInfo eventInformation)
		{
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\XenonSDK\\xbWatson\\Options");
			if (registryKey != null)
			{
				string text = (string)registryKey.GetValue(this.ActionValueName);
				string text2 = (string)registryKey.GetValue("AfterDump");
				registryKey.Close();
				if (text.Equals("Dump"))
				{
					this.watson.Log("*****************************************\n");
					this.watson.Log("xbWatson: Configured action on " + this.EventName + " - Dump\n");
					this.watson.DumpLog(this.console);
					if (text2.Equals("Continue"))
					{
						text = "Continue";
					}
					else
					{
						if (!text2.Equals("Restart"))
						{
							return;
						}
						text = "Restart";
					}
				}
				if (text.Equals("Continue"))
				{
					this.watson.Log("*****************************************\n");
					this.watson.Log("xbWatson: Configured action on " + this.EventName + " - Continue.\nExecution continued\n");
					this.watson.Log("*****************************************\n");
					try
					{
						this.Continue(eventInformation);
					}
					catch (Exception ex)
					{
						this.watson.Log(ex.Message);
					}
					return;
				}
				if (text.Equals("Restart"))
				{
					this.watson.Log("*****************************************\n");
					this.watson.Log("xbWatson: Configured action on " + this.EventName + " - Restart.\nConsole rebooting\n");
					this.watson.Log("*****************************************\n");
					try
					{
						this.Reboot();
					}
					catch (Exception ex2)
					{
						this.watson.Log(ex2.Message);
					}
					return;
				}
			}
			DialogResult dialogResult = base.ShowDialog(eventInformation, Strings.SaveCrashDumpButtonText);
			try
			{
				switch (dialogResult)
				{
				case DialogResult.Abort:
					this.Reboot();
					break;
				case DialogResult.Ignore:
					this.Continue(eventInformation);
					break;
				case DialogResult.No:
					this.watson.DumpLog(this.watson, this.console);
					this.HandleEvent(eventInformation);
					break;
				}
			}
			catch (Exception ex3)
			{
				this.watson.Log(ex3.Message);
			}
		}

		private void Continue(IXboxEventInfo eventInformation)
		{
			eventInformation.Info.Thread.Continue(true);
			bool flag;
			this.console.DebugTarget.Go(out flag);
		}
	}
}