using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;
using XDevkit;

namespace xbWatson
{
	internal class AssertHandler(XboxConsole console, xbWatson watson) : BreakHandler(console, watson)
	{
        protected override string GetDialogTitle() => $"Xbox Assertion Failed - {console.RunningProcessInfo.ProgramName}";

		protected override string GetDialogMessage(IXboxEventInfo information) => information.Info.Message;

		public override void HandleEvent(IXboxEventInfo eventInformation)
		{
			using var registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\XenonSDK\\xbWatson\\Options");
			if (registryKey is not null)
			{
				var text = registryKey.GetValue("OnAssert") as string;
				if (text is not null && text.Equals("Break"))
				{
					watson.Log("*****************************************\n");
					watson.Log("xbWatson: Configured action on Assert - Break.\nExecution stopped\n");
					watson.Log("*****************************************\n");
					try
					{
						var topOfStack = eventInformation.Info.Thread.TopOfStack;
						topOfStack.SetRegister64((XboxRegisters64)4, 98L);
						topOfStack.FlushRegisterChanges();
						eventInformation.Info.Thread.Continue(true);
						console.DebugTarget.Go(out _);
						while (Marshal.ReleaseComObject(topOfStack) > 0) { }
					}
					catch (Exception ex)
					{
						watson.Log(ex.Message);
					}
					return;
				}
				if (text is not null && text.Equals("Continue"))
				{
					watson.Log("*****************************************\n");
					watson.Log("xbWatson: Configured action on Assert - Continue.\nExecution continued\n");
					watson.Log("*****************************************\n");
					try
					{
						var topOfStack2 = eventInformation.Info.Thread.TopOfStack;
						topOfStack2.SetRegister64((XboxRegisters64)4, 105L);
						topOfStack2.FlushRegisterChanges();
						eventInformation.Info.Thread.Continue(true);
						console.DebugTarget.Go(out _);
						while (Marshal.ReleaseComObject(topOfStack2) > 0) { }
					}
					catch (Exception ex2)
					{
						watson.Log(ex2.Message);
					}
					return;
				}
				if (text is not null && text.Equals("Restart"))
				{
					watson.Log("*****************************************\n");
					watson.Log("xbWatson: Configured action on Assert - Restart.\nConsole rebooting\n");
					watson.Log("*****************************************\n");
					try
					{
						this.Reboot();
					}
					catch (Exception ex3)
					{
						watson.Log(ex3.Message);
					}
					return;
				}
			}
			DialogResult dialogResult = base.ShowDialog(eventInformation, Strings.SaveCrashDumpButtonText);
			try
			{
				var topOfStack3 = eventInformation.Info.Thread.TopOfStack;
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
                this.console.DebugTarget.Go(out bool flag3);
            }
			catch (Exception ex4)
			{
				this.watson.Log(ex4.Message);
			}
		}
	}
}