using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AltControllerXP.Event;
using AltControllerXP.Input;
using AltControllerXP.Core;

namespace AltControllerXP.Interfaces
{
    /// <summary>
    /// Interface for controls which display inputs
    /// </summary>
    public interface IInputViewer
    {
        AltControlEventArgs GetSelectedControl();
        void SetSource(BaseSource source);
        void SetSelectedControl(AltControlEventArgs args);
        void ClearHighlighting();
        void HighlightEvent(AltControlEventArgs args, HighlightInfo highlightInfo);
    }
}
