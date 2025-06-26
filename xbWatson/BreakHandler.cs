using System;
using System.Windows.Forms;
using xbWatson.Forms;
using XDevkit;

namespace xbWatson
{
	internal abstract class BreakHandler
	{
		protected BreakHandler(XboxConsole console, xbWatson watson)
		{
			this.console = console;
			this.watson = watson;
		}

		protected DialogResult ShowDialog(IXboxEventInfo eventInformation, string middleButtonText)
		{
			string title = string.Format("{0} [{1}]", this.GetDialogTitle(), this.console.Name);
			string dialogMessage = this.GetDialogMessage(eventInformation);
			EventDialog eventDialog = new EventDialog(title, dialogMessage, middleButtonText);
			return eventDialog.ShowDialog(this.watson);
		}

		protected abstract string GetDialogTitle();

		protected abstract string GetDialogMessage(IXboxEventInfo information);

		public abstract void HandleEvent(IXboxEventInfo eventInformation);

		protected virtual void Reboot()
		{
			this.console.Reboot(null, null, null, (XboxRebootFlags)2);
		}

		protected XboxConsole console;

		protected xbWatson watson;
	}
}