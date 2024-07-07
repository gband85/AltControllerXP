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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Reflection;
using AltControllerXP.Core;
using UserControl = System.Windows.Controls.UserControl;

namespace AltControllerXP.UserControls
{
    /// <summary>
    /// Colour picker control
    /// </summary>
    public partial class ColourPickerControl : UserControl
    {
        // Fields
        private List<ColourItem> _colourItems;

        // Properties
        public string SelectedColour
        {
            get { return (string)GetValue(SelectedColourProperty); }
            set { SetValue(SelectedColourProperty, value); }
        }
        private static readonly DependencyProperty SelectedColourProperty =
            DependencyProperty.Register(
            "SelectedColour",
            typeof(string),
            typeof(ColourPickerControl),
            new FrameworkPropertyMetadata(SelectedColourPropertyChanged)
        );
        public List<ColourItem> ColourItems { get { return _colourItems; } }

        // Routed events
        public static readonly RoutedEvent SelectedColourChangedEvent = EventManager.RegisterRoutedEvent(
            "SelectedColourChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ColourPickerControl));
        public event RoutedEventHandler SelectedColourChanged
        {
            add { AddHandler(SelectedColourChangedEvent, value); }
            remove { RemoveHandler(SelectedColourChangedEvent, value); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ColourPickerControl()
        {
            PopulateColourList();

            InitializeComponent();

            ColoursCombo.DataContext = this;
        }

        /// <summary>
        /// Design mode changed
        /// </summary>
        private static void SelectedColourPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            ColourPickerControl control = source as ColourPickerControl;
            if (control.IsLoaded)
            {
                control.RaiseEvent(new RoutedEventArgs(SelectedColourChangedEvent));
            }
        }

        /// <summary>
        /// Control loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Make sure a colour is selected
            if (SelectedColour == null && _colourItems.Count != 0)
            {
                SelectedColour = _colourItems[0].Name;
            }
        }

        /// <summary>
        /// Populate the list of colours
        /// </summary>
        private void PopulateColourList()
        {
            // Get standard colours
            _colourItems = new List<ColourItem>();
            foreach (PropertyInfo colourInfo in typeof(Colors).GetProperties())
            {
                if (colourInfo.Name != "Transparent")
                {
                    Color colour = (Color)ColorConverter.ConvertFromString(colourInfo.Name);
                    System.Drawing.Color sdc = System.Drawing.Color.FromArgb(colour.R, colour.G, colour.B);
                    int hue = (int)sdc.GetHue();    // 0 - 360
                    int brightness = (int)(255 * sdc.GetBrightness());
                    int id = (hue << 8) + brightness;
                    string textColour = brightness < 128 ? "WhiteSmoke" : "Black";
                    _colourItems.Add(new ColourItem(id, colourInfo.Name, textColour));
                }
            }

            // Sort by ID
            _colourItems.Sort((x, y) => x.ID.CompareTo(y.ID));            
        }
    }

    /// <summary>
    /// Data for item in colours combo box
    /// </summary>
    public class ColourItem : NamedItem
    {
        public string TextColour { get; set; }

        public ColourItem(long id, string name, string textColour)
            :base(id, name)
        {
            TextColour = textColour;
        }
    }
}
