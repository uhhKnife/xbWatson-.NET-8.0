using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;
using XDevkit;

namespace xbWatson
{
	internal class AssertHandler : BreakHandler
	{
		public AssertHandler(XboxConsole console, xbWatson watson) : base(console, watson)
		{
		}

		protected override string GetDialogTitle()
		{
			return "Xbox Assertion Failed - " + this.console.RunningProcessInfo.ProgramName;
		}

		protected override string GetDialogMessage(IXboxEventInfo information)
		{
			return information.Info.Message;
		}

		public override void HandleEvent(IXboxEventInfo eventInformation)
		{
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\XenonSDK\\xbWatson\\Options");
			if (registryKey is not null)
			{
				string text = (string)registryKey.GetValue("OnAssert");
				registryKey.Close();
				if (text.Equals("Break"))
				{
					this.watson.Log("*****************************************\n");
					this.watson.Log("xbWatson: Configured action on Assert - Break.\nExecution stopped\n");
					this.watson.Log("*****************************************\n");
					try
					{
						IXboxStackFrame topOfStack = eventInformation.Info.Thread.TopOfStack;
						topOfStack.SetRegister64((XboxRegisters64)4, 98L);
						topOfStack.FlushRegisterChanges();
						eventInformation.Info.Thread.Continue(true);
						bool flag;
						this.console.DebugTarget.Go(out flag);
						int num;
						do
						{
							num = Marshal.ReleaseComObject(topOfStack);
						}
						while (num > 0);
					}
					catch (Exception ex)
					{
						this.watson.Log(ex.Message);
					}
					return;
				}
				if (text.Equals("Continue"))
				{
					this.watson.Log("*****************************************\n");
					this.watson.Log("xbWatson: Configured action on Assert - Continue.\nExecution continued\n");
					this.watson.Log("*****************************************\n");
					try
					{
						IXboxStackFrame topOfStack2 = eventInformation.Info.Thread.TopOfStack;
						topOfStack2.SetRegister64((XboxRegisters64)4, 105L);
						topOfStack2.FlushRegisterChanges();
						eventInformation.Info.Thread.Continue(true);
						bool flag2;
						this.console.DebugTarget.Go(out flag2);
						int num2;
						do
						{
							num2 = Marshal.ReleaseComObject(topOfStack2);
						}
						while (num2 > 0);
					}
					catch (Exception ex2)
					{
						this.watson.Log(ex2.Message);
					}
					return;
				}
				if (text.Equals("Restart"))
				{
					this.watson.Log("*****************************************\n");
					this.watson.Log("xbWatson: Configured action on Assert - Restart.\nConsole rebooting\n");
					this.watson.Log("*****************************************\n");
					try
					{
						this.Reboot();
					}
					catch (Exception ex3)
					{
						this.watson.Log(ex3.Message);
					}
					return;
				}
			}
			DialogResult dialogResult = base.ShowDialog(eventInformation, Strings.SaveCrashDumpButtonText);
			try
			{
				IXboxStackFrame topOfStack3 = eventInformation.Info.Thread.TopOfStack;
				switch (dialogResult)
				{
				case DialogResult.Cancel:
					topOfStack3.SetRegister64((XboxRegisters64)4, 98L);
					topOfStack3.FlushRegisterChanges();
					break;
				case DialogResult.Abort:
				{
					this.Reboot();
					int num3;
					do
					{
						num3 = Marshal.ReleaseComObject(topOfStack3);
					}
					while (num3 > 0);
					return;
				}
				case DialogResult.Ignore:
					topOfStack3.SetRegister64((XboxRegisters64)4, 105L);
					topOfStack3.FlushRegisterChanges();
					break;
				}
				int num4;
				do
				{
					num4 = Marshal.ReleaseComObject(topOfStack3);
				}
				while (num4 > 0);
				eventInformation.Info.Thread.Continue(true);
				bool flag3;
				this.console.DebugTarget.Go(out flag3);
			}
			catch (Exception ex4)
			{
				this.watson.Log(ex4.Message);
			}
		}
	}
}