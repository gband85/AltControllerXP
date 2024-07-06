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
using AltControllerXP.Core;
using AltControllerXP.Event;

namespace AltControllerXP.Actions
{
    /// <summary>
    /// Action for releasing a keyboard key if it's pressed, and vice versa
    /// </summary>
    public class ToggleKeyAction : BaseKeyAction
    {
        /// <summary>
        /// Return what type of action this is
        /// </summary>
        public override EActionType ActionType
        {
            get { return EActionType.ToggleKey; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        public ToggleKeyAction()
            : base()
        {
        }

        /// <summary>
        /// Return the name of the action
        /// </summary>
        /// <returns></returns>
        public override string Name
        {
            get
            {
                return string.Format(Properties.Resources.String_Toggle_key_X, base.KeyName);
            }
        }

        /// <summary>
        /// Perform the action
        /// </summary>
        public override void StartAction(IStateManager parent, AltControlEventArgs cargs)
        {
            // Toggle key
            parent.KeyStateManager.ToggleKeyState(VirtualKey);
        }
    }
}
