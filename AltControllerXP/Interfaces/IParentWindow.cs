using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows;

namespace AltControllerXP.Interfaces
{
    /// <summary>
    /// Interface for parent window
    /// </summary>
    public interface IParentWindow
    {
        Profile GetCurrentProfile();
        AppConfig GetAppConfig();
        void ApplyNewProfile(Profile profile);
        void ChildWindowClosing(Window window);
        void AttachEventReportHandler(EventReportHandler handler);
        void DetachEventReportHandler(EventReportHandler handler);
        void SubmitEvent(AltControlEventArgs args);
        void ConfigureDiagnostics(bool enable);
    }
}
