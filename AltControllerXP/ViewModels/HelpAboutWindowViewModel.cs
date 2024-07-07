/*
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
using System;
using System.Windows;
using System.Windows.Input;
using AltControllerXP.Core;
using AltControllerXP.Interfaces;
using AltControllerXP.Event;
using Microsoft.Xaml.Behaviors.Core;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AltControllerXP.ViewModels
{
    /// <summary>
    /// About window
    /// </summary>
    public class HelpAboutWindowViewModel : IDialogRequestClose
    {
        public string ApplicationNameText => Constants.ApplicationName;
        public string VersionText => string.Format("{0} {1}", Properties.Resources.String_Version, Constants.AppVersion);
        public string CopyrightText => string.Format("{0} 2024 {2}", Properties.Resources.String_Copyright, DateTime.Now.Year, Constants.AuthorName);
        public string TranslatorNamesText => Constants.TranslatorNames;
        public string AltControllerUri => "https://altcontroller.net";
        public HelpAboutWindowViewModel()
        {
           // Message = message;
            CloseCommand = new ActionCommand(p => CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(true)));
        }

        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequested;
       // public string Message { get; }
        public ICommand CloseCommand { get; }

        ///// <summary>
        ///// Can Close command execute
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void CloseCanExecute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = true;
        //    e.Handled = true;
        //}

        ///// <summary>
        ///// Close window
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void CloseExecuted(object sender, ExecutedRoutedEventArgs e)
        //{
        //    //Close();
        //    e.Handled = true;
        //}
    }
}
