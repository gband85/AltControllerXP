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
using System.Windows;

namespace AltControllerXP.Views
{
    /// <summary>
    /// Window that shows a notes for the current profile
    /// </summary>
    public partial class ProfileNotesWindow : Window
    {
        // Members
        private string _profileNotes = "";

        // Properties
        public string ProfileNotes { get { return _profileNotes; } set { _profileNotes = value; UpdateDisplay(); } }

        /// <summary>
        /// Constructor
        /// </summary>
        public ProfileNotesWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Window loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateDisplay();
        }

        /// <summary>
        /// Display the profile notes text
        /// </summary>
        private void UpdateDisplay()
        {
            if (this.IsLoaded)
            {
                ProfileNotesText.Text = _profileNotes; 
            }
        }

        /// <summary>
        /// OK button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            _profileNotes = this.ProfileNotesText.Text;
            this.DialogResult = true;
            this.Close();
        }

        /// <summary>
        /// Cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
