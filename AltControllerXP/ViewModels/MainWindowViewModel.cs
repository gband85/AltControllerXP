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
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using System.Threading;
using AltControllerXP.Config;
using AltControllerXP.Core;
using AltControllerXP.Views;
using Microsoft.Xaml.Behaviors.Core;
//using AltControllerXP.Event;
//using AltControllerXP.Input;
//using AltControllerXP.Sys;
using Microsoft.Win32;
using AltControllerXP.Interfaces;
//using System.Diagnostics;
using CommunityToolkit.Mvvm;

namespace AltControllerXP.ViewModels
{
    
    
    /// <summary>
    /// Main application window
    /// </summary>
    public partial class MainWindowViewModel : ViewModelBase
    {
        // Configuration
        private Profile _profile;
            
        ///// <summary>
        ///// Constructor
        ///// </summary>
        private readonly IDialogService dialogService;
        public MainWindowViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            HelpAboutCommand = new ActionCommand(p => HelpAbout());
            HelpUserGuideCommand = new ActionCommand(p => HelpUserGuide());
            ViewProfileNotesCommand = new ActionCommand(p => ViewProfileNotes());
            
        }
        public ICommand HelpAboutCommand { get; }
        public ICommand HelpUserGuideCommand { get; }
        public ICommand ViewProfileNotesCommand { get; }

        private void HelpUserGuide()
        {
            //ClearMessages();

            try
            {
                var utils = new Utils();
                utils.OpenUrl(Constants.UserGuideURL);
            }
            catch (Exception)
            {
            }
          //  e.Handled = true;
        }
        
        private void HelpAbout()
        {
            var viewModel = new HelpAboutWindowViewModel();
           // var view = new HelpAboutWindow { DataContext = viewModel };

            bool? result = dialogService.ShowDialog(viewModel);

            if (result.HasValue)
            {
                if (result.Value)
                {

                }
            }
        }

        private void ViewProfileNotes()
        {
           // var viewModel = new ProfileNotesWindowViewModel();
            
            //bool? result = dialogService.ShowDialog(viewModel);

            // if (result.HasValue)
            // {
            //     if (result.Value)
            //     {
            //        // _profileNotes = this.ProfileNotesText;
            //      viewModel.ProfileNotes = viewModel.ProfileNotesText;
            //     }
            // }
        }
    }
}
