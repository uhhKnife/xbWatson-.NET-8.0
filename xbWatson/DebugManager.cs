using System;
using System.Runtime.InteropServices;
using XDevkit;
using System.Threading.Tasks;

namespace xbWatson
{
	public class DebugManager
	{
		public DebugManager(xbWatson xboxWatson, string xboxName)
		{
			this.xboxWatson = xboxWatson;
			this.fConnected = false;
			this.xManager = new XboxManagerClass();
			this.xboxConsole = this.xManager.OpenConsole(xboxName);
		}

		public void InitDM()
		{
			try
			{
				this.StdNotifyEventHandler = new XboxEvents_OnStdNotifyEventHandler(this.xboxConsole_OnStdNotify);
				this.xboxConsole.OnStdNotify += this.StdNotifyEventHandler;
				this.xDebugTarget = this.xboxConsole.DebugTarget;
				this.xDebugTarget.ConnectAsDebugger(null, (XboxDebugConnectFlags)1);
			}
			catch (Exception arg)
			{
				this.xboxConsole.OnStdNotify -= this.StdNotifyEventHandler;
				this.xboxWatson.Log("Could not connect to Xbox\n " + arg);
			}
		}

		public void UnInitDM()
		{
			try
			{
				this.xDebugTarget.DisconnectAsDebugger();
				this.xboxConsole.OnStdNotify -= this.StdNotifyEventHandler;
				int num;
				do
				{
					num = Marshal.ReleaseComObject(this.xboxConsole);
				}
				while (num > 0);
				int num2;
				do
				{
					num2 = Marshal.ReleaseComObject(this.xDebugTarget);
				}
				while (num2 > 0);
				int num3;
				do
				{
					num3 = Marshal.ReleaseComObject(this.xManager);
				}
				while (num3 > 0);
			}
			catch (Exception ex)
			{
				this.xboxWatson.Log(ex.Message);
			}
		}

		private async void xboxConsole_OnStdNotify(XboxDebugEventType eventCode, IXboxEventInfo eventInformation)
		{
			await Task.Run(() => this.HandleEvent(eventCode, eventInformation));
		}

		internal void HandleEvent(XboxDebugEventType eventCode, IXboxEventInfo eventInformation)
		{
			bool isThreadStopped = eventInformation.Info.IsThreadStopped != 0;
			bool flag = true;
			switch ((XboxDebugEventType)eventCode)
			{
			case XboxDebugEventType.ExecutionBreak:
			{
				this.xboxWatson.Log(string.Concat(new object[]
				{
					"Break: ",
					eventInformation.Info.Address,
					" ",
					eventInformation.Info.Thread.ThreadId,
					"\n"
				}));
				ExceptionHandler exceptionHandler = new ExceptionHandler(this.xboxConsole, this.xboxWatson);
				exceptionHandler.HandleEvent(eventInformation);
				goto IL_3D6;
			}
			case XboxDebugEventType.DebugString:
				this.xboxWatson.Log(eventInformation.Info.Message);
				if (isThreadStopped)
				{
					eventInformation.Info.Thread.Continue(flag);
					bool flag2;
					this.xDebugTarget.Go(out flag2);
					goto IL_3D6;
				}
				goto IL_3D6;
			case XboxDebugEventType.ExecStateChange:
				if (!this.fConnected)
				{
					this.fConnected = true;
					this.xboxWatson.Log("xbWatson: Connection to Xbox successful\n");
					goto IL_3D6;
				}
				if ((int)eventInformation.Info.ExecState == 2 || (int)eventInformation.Info.ExecState == 4)
				{
					this.xboxWatson.Log("xbWatson: Xbox is restarting\n");
					goto IL_3D6;
				}
				goto IL_3D6;
			case XboxDebugEventType.Exception:
				if ((int)eventInformation.Info.Flags == 2 && eventInformation.Info.Code != 1080890248U)
				{
					this.xboxWatson.Log(string.Concat(new object[]
					{
						"Exception : ",
						eventInformation.Info.Thread.ThreadId,
						" ",
						eventInformation.Info.Code,
						" ",
						eventInformation.Info.Address,
						" ",
						eventInformation.Info.Flags,
						"\n"
					}));
					ExceptionHandler exceptionHandler2 = new ExceptionHandler(this.xboxConsole, this.xboxWatson);
					exceptionHandler2.HandleEvent(eventInformation);
					goto IL_3D6;
				}
				goto IL_3D6;
			case XboxDebugEventType.AssertionFailed:
				this.xboxWatson.Log("Assertion failed: \r\n");
				this.xboxWatson.Log(eventInformation.Info.Message);
				if (isThreadStopped)
				{
					AssertHandler assertHandler = new AssertHandler(this.xboxConsole, this.xboxWatson);
					assertHandler.HandleEvent(eventInformation);
					goto IL_3D6;
				}
				goto IL_3D6;
			case XboxDebugEventType.DataBreak:
			{
				this.xboxWatson.Log(string.Concat(new object[]
				{
					"Databreak : ",
					eventInformation.Info.Address,
					" ",
					eventInformation.Info.Thread.ThreadId,
					" ",
					eventInformation.Info.GetType(),
					" ",
					eventInformation.Info.Address,
					"\n"
				}));
				ExceptionHandler exceptionHandler3 = new ExceptionHandler(this.xboxConsole, this.xboxWatson);
				exceptionHandler3.HandleEvent(eventInformation);
				goto IL_3D6;
			}
			case XboxDebugEventType.RIP:
				this.xboxWatson.Log("RIP : " + eventInformation.Info.Message + "\n");
				if (isThreadStopped)
				{
					RipHandler ripHandler = new RipHandler(this.xboxConsole, this.xboxWatson);
					ripHandler.HandleEvent(eventInformation);
					goto IL_3D6;
				}
				goto IL_3D6;
			}
			if (!string.IsNullOrEmpty(eventInformation.Info.Message))
			{
				this.xboxWatson.Log(eventInformation.Info.Message + "\n");
			}
			IL_3D6:
			XBOX_EVENT_INFO info = eventInformation.Info;
			int num;
			do
			{
				num = Marshal.ReleaseComObject(eventInformation);
			}
			while (num > 0);
			if (info.Module is not null)
			{
				int num2;
				do
				{
					num2 = Marshal.ReleaseComObject(info.Module);
				}
				while (num2 > 0);
			}
			if (info.Section is not null)
			{
				int num3;
				do
				{
					num3 = Marshal.ReleaseComObject(info.Section);
				}
				while (num3 > 0);
			}
			if (info.Thread is not null)
			{
				int num4;
				do
				{
					num4 = Marshal.ReleaseComObject(info.Thread);
				}
				while (num4 > 0);
			}
		}

		private xbWatson xboxWatson;

		private XboxManagerClass xManager;

		private XboxConsole xboxConsole;

		private IXboxDebugTarget xDebugTarget;

		private XboxEvents_OnStdNotifyEventHandler StdNotifyEventHandler;

		private bool fConnected;
	}
}