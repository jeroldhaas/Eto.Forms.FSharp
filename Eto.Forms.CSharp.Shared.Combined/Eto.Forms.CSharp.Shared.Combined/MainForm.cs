//
// MainForm.cs
//
// Author:
//       Jerold Haas <jeroldhaas@gmail.com>
//
// Copyright (c) 2015 Jerold Haas
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using Eto.Forms;
using Eto.Drawing;

namespace Eto.Forms.CSharp.Shared.Combined
{
    /// <summary>
    /// Your application's main form
    /// </summary>
    public class MainForm : Form
    {
        public MainForm ()
        {
            Title = "My Eto Form";
            ClientSize = new Size (400, 350);

            // scrollable region as the main content
            Content = new Scrollable {
                // table with three rows
                Content = new TableLayout (
                    null,
                    // row with three columns
                    new TableRow (null, new Label { Text = "Hello World!" }, null),
                    null
                )
            };

            // create a few commands that can be used for the menu and toolbar
            var clickMe = new Command {
                MenuText = "Click Me!",
                ToolBarText = "Click Me!"
            };
            clickMe.Executed += (sender, e) => MessageBox.Show (this, "I was clicked!");

            var quitCommand = new Command {
                MenuText = "Quit",
                Shortcut = Application.Instance.CommonModifier | Keys.Q
            };
            quitCommand.Executed += (sender, e) => Application.Instance.Quit ();

            var aboutCommand = new Command { MenuText = "About..." };
            aboutCommand.Executed += (sender, e) => MessageBox.Show (this, "About my app...");

            // create menu
            Menu = new MenuBar {
                Items = {
                    // File submenu
                    new ButtonMenuItem { Text = "&File", Items = { clickMe } },
                    // new ButtonMenuItem { Text = "&Edit", Items = { /* commands/items */ } },
                    // new ButtonMenuItem { Text = "&View", Items = { /* commands/items */ } },
                },
                ApplicationItems = {
                    // application (OS X) or file menu (others)
                    new ButtonMenuItem { Text = "&Preferences..." },
                },
                QuitItem = quitCommand,
                AboutItem = aboutCommand
            };

            // create toolbar            
            ToolBar = new ToolBar { Items = { clickMe } };
        }
    }
}
