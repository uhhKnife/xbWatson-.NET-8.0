using System;
using XDevkit;

namespace xbWatson
{
	internal class ExceptionHandler(XboxConsole console, xbWatson watson) : CrashHandler(console, watson)
	{
        protected override string ActionValueName
		{
			get
			{
				return "OnException";
			}
		}

		protected override string EventName
		{
			get
			{
				return "Exception";
			}
		}

		protected override string GetDialogTitle()
		{
			return "An exception has occured";
		}

		protected override string GetDialogMessage(IXboxEventInfo information)
		{
			XboxDebugEventType code = (XboxDebugEventType)information.Info.Code;
			if ((int)code != 1)
			{
				if ((int)code == 9)
				{
					return string.Format("The instruction at address {0} referenced memory at address {1}. {2}", information.Info.Address, information.Info.Parameters[1], (information.Info.Parameters[0] != 0U) ? "The memory could not be written." : "The memory could not be read.");
				}
				if ((int)code != 12)
				{
					return string.Format("An exception {0} occured in the application at location {1}", information.Info.Code, information.Info.Address);
				}
			}
			return string.Format("A breakpoint exception {0} has been reached in the application at location {1}", information.Info.Code, information.Info.Address);
		}
	}
}