using System;
using XDevkit;

namespace xbWatson
{
	internal class RipHandler : CrashHandler
	{
		public RipHandler(XboxConsole console, xbWatson watson) : base(console, watson)
		{
		}

		protected override string ActionValueName
		{
			get
			{
				return "OnRIP";
			}
		}

		protected override string EventName
		{
			get
			{
				return "RIP Error";
			}
		}

		protected override string GetDialogTitle()
		{
			return "A rip error has occurred";
		}

		protected override string GetDialogMessage(IXboxEventInfo information)
		{
			return "A RIP error has occured on the Xbox\n The error description was: " + information.Info.Message;
		}
	}
}