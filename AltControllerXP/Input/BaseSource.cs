﻿/*
Alt Controller
--------------
Copyright 2013 Tim Brogden
http://altcontroller.net

Description
-----------
A free program for mapping computer inputs, such as pointer movements and button presses, 
to actions, such as key presses. The aim of this program is to help make third-party programs,
such as computer games, more accessible to users with physical difficulties.

License
-------
This file is part of Alt Controller. 
Alt Controller is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

Alt Controller is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with Alt Controller.  If not, see <http://www.gnu.org/licenses/>.
*/
using System.Collections.Generic;
using AltControllerXP.Config;
using AltControllerXP.Controls;
using AltControllerXP.Core;
using AltControllerXP.Event;

namespace AltControllerXP.Input
{
    /// <summary>
    /// Base class for input sources e.g. game controller, keyboard
    /// </summary>
    public abstract class BaseSource : NamedItem
    {
        private Profile _profile;
        private BaseControl[] _inputControls;

        // Properties
        public abstract ESourceType SourceType { get; }
        public Profile Profile { get { return _profile; } set { _profile = value; } }
        protected BaseControl[] InputControls { get { return _inputControls; } set { _inputControls = value; } }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="node"></param>
        public BaseSource()
            : base()
        {
            InitialiseControls();
        }

        /// <summary>
        /// Full constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public BaseSource(long id, string name)
            : base(id, name)
        {
            InitialiseControls();
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="source"></param>
        public BaseSource(BaseSource source)
            :base(source)
        {
            _profile = source._profile;
            InitialiseControls();
        }

        /// <summary>
        /// Initialise controls
        /// </summary>
        protected virtual void InitialiseControls()
        {
            _inputControls = new BaseControl[0];
        }

        /// <summary>
        /// Connect or disconnect the event handler
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="enable"></param>
        public void Connect(AltControlEventHandler handler, bool enable)
        {
            foreach (BaseControl control in _inputControls)
            {
                control.Connect(handler, enable);
            }
        }

        /// <summary>
        /// Start or stop monitoring a type of event
        /// </summary>
        /// <param name="controlID"></param>
        /// <param name="reason"></param>
        public virtual void ConfigureEventMonitoring(AltControlEventArgs args, bool enable)
        {
        }

        /// <summary>
        /// Get the types of event that this source supports for the specified control 
        /// </summary>
        /// <param name="args"></param>
        public virtual List<EEventReason> GetSupportedEventReasons(AltControlEventArgs args)
        {
            return null;
        }

        /// <summary>
        /// Update the state of the source and return whether it's connected or not
        /// </summary>
        /// <returns></returns>
        public virtual void UpdateState(IStateManager stateManager)
        {
        }

        /// <summary>
        /// Handle change of app config
        /// </summary>
        /// <param name="appConfig"></param>
        public virtual void SetAppConfig(AppConfig appConfig)
        {
            foreach (BaseControl control in _inputControls)
            {
                control.SetAppConfig(appConfig);
            }
        }

        /// <summary>
        /// Handle an external event generated by another thread
        /// </summary>
        /// <param name="args"></param>
        public virtual void ReceiveExternalEvent(AltControlEventArgs args)
        {            
            // Override in derived classes if required
        }
    }
}
