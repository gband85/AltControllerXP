using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows;
using AltControllerXP.Config;
using AltControllerXP.Sys;
using AltControllerXP.Event;

namespace AltControllerXP.Core
{
    /// <summary>
    /// Interface for state manager
    /// </summary>
    public interface IStateManager
    {
        Profile CurrentProfile { get; }
        KeyPressManager KeyStateManager { get; }
        MouseManager MouseStateManager { get; }
        Rect CurrentWindowRect { get; }
        Rect OverlayWindowRect { get; }
        double DPI_X { get; }
        double DPI_Y { get; }
        bool IsDiagnosticsEnabled { get; }
        int SeqNumber { get; }
        void ReportEvent(EventReport report);
        void Reset();
        void SetMode(long modeID);
        void SetApp(string appName);
        void SetPage(long pageID);
        void SetCurrentWindowRect(RECT rectangle);
    }
}
