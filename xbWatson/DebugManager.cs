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
            fConnected = false;
            xManager = new XboxManagerClass();
            xboxConsole = (XboxConsole)xManager.OpenConsole(xboxName);
            xDebugTarget = xboxConsole.DebugTarget;
            StdNotifyEventHandler = null;
        }

        public void InitDM()
        {
            try
            {
                StdNotifyEventHandler = xboxConsole_OnStdNotify;
                xboxConsole.OnStdNotify += StdNotifyEventHandler;
                xDebugTarget.ConnectAsDebugger(null, (XboxDebugConnectFlags)1);
            }
            catch (Exception arg)
            {
                xboxConsole.OnStdNotify -= StdNotifyEventHandler;
                xboxWatson.Log($"Could not connect to Xbox\n {arg}");
            }
        }

        public void UnInitDM()
        {
            try
            {
                xDebugTarget?.DisconnectAsDebugger();
                xboxConsole.OnStdNotify -= StdNotifyEventHandler;
                while (Marshal.ReleaseComObject(xboxConsole) > 0) { }
                while (Marshal.ReleaseComObject(xDebugTarget) > 0) { }
                while (Marshal.ReleaseComObject(xManager) > 0) { }
            }
            catch (Exception ex)
            {
                xboxWatson.Log(ex.Message);
            }
        }

        private async void xboxConsole_OnStdNotify(XboxDebugEventType eventCode, IXboxEventInfo eventInformation)
        {
            await Task.Run(() => HandleEvent(eventCode, eventInformation));
        }

        internal void HandleEvent(XboxDebugEventType eventCode, IXboxEventInfo eventInformation)
        {
            bool isThreadStopped = eventInformation.Info.IsThreadStopped != 0;
            bool flag = true;
            switch (eventCode)
            {
                case XboxDebugEventType.ExecutionBreak:
                    xboxWatson.Log($"Break: {eventInformation.Info.Address} {eventInformation.Info.Thread.ThreadId}\n");
                    var exceptionHandler = new ExceptionHandler(xboxConsole, xboxWatson);
                    exceptionHandler.HandleEvent(eventInformation);
                    break;
                case XboxDebugEventType.DebugString:
                    xboxWatson.Log(eventInformation.Info.Message);
                    if (isThreadStopped)
                    {
                        eventInformation.Info.Thread.Continue(flag);
                        xDebugTarget.Go(out _);
                    }
                    break;
                case XboxDebugEventType.ExecStateChange:
                    if (!fConnected)
                    {
                        fConnected = true;
                        xboxWatson.Log("xbWatson: Connection to Xbox successful\n");
                    }
                    else if ((int)eventInformation.Info.ExecState == 2 || (int)eventInformation.Info.ExecState == 4)
                    {
                        xboxWatson.Log("xbWatson: Xbox is restarting\n");
                    }
                    break;
                case XboxDebugEventType.Exception:
                    // RIP event: XDK uses Exception with Info.Code == 0x406D1388 (1080890248U)
                    if (eventInformation.Info.Code == 1080890248U)
                    {
                        xboxWatson.Log("RIP event: \r\n");
                        xboxWatson.Log(eventInformation.Info.Message);
                        if (isThreadStopped)
                        {
                            var ripHandler = new RipHandler(xboxConsole, xboxWatson);
                            ripHandler.HandleEvent(eventInformation);
                        }
                    }
                    else if ((int)eventInformation.Info.Flags == 2)
                    {
                        xboxWatson.Log($"Exception : {eventInformation.Info.Thread.ThreadId} {eventInformation.Info.Code} {eventInformation.Info.Address} {eventInformation.Info.Flags}\n");
                        var exceptionHandler2 = new ExceptionHandler(xboxConsole, xboxWatson);
                        exceptionHandler2.HandleEvent(eventInformation);
                    }
                    break;
                case XboxDebugEventType.AssertionFailed:
                    xboxWatson.Log("Assertion failed: \r\n");
                    xboxWatson.Log(eventInformation.Info.Message);
                    if (isThreadStopped)
                    {
                        var assertHandler = new AssertHandler(xboxConsole, xboxWatson);
                        assertHandler.HandleEvent(eventInformation);
                    }
                    break;
            }
        }

        // Revert dynamic changes and fix event handler assignment
        private XboxManagerClass xManager;
        private xbWatson xboxWatson;
        private XboxConsole xboxConsole;
        private IXboxDebugTarget xDebugTarget;
        private XboxEvents_OnStdNotifyEventHandler StdNotifyEventHandler;
        private bool fConnected;
    }
}