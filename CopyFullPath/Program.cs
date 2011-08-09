// --------------------------------------------------------------------------------
// CopyFullPath by John Trimis
// This program allows you to right click on any file in explorer and copy the
// full path to the clipboard.
// --------------------------------------------------------------------------------
// Copyright (c) 2011 John Trimis 
//
// MIT license:
// Permission is hereby granted, free of charge, to any person obtaining a copy of 
// this software and associated documentation files (the "Software"), to deal in 
// the Software without restriction, including without limitation the rights to 
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of 
// the Software, and to permit persons to whom the Software is furnished to do so, 
// subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all 
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS 
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR 
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER 
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN 
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace CopyFullPath
{   //namespace CopyFullPath

    /// <summary>
    ///     An utility that copies the path of some specified file to your clipboard
    /// </summary>
    static class Program
    {   // class Program

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {   // Main
            
            string strKeyPath = @"*\Shell\Copy Full Path\Command";
            string strExePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string strCommand = "\"" + strExePath + "\" \"%1\"";

            RegistryKey key = Registry.ClassesRoot.OpenSubKey( strKeyPath );
            if ( key == null )
            {   // Key does not exist

                // The right click handler is not set in the registry, we need to add it.

                key = Registry.ClassesRoot.CreateSubKey( strKeyPath );
                key.SetValue( "", strCommand );   // "" is the default value

            }   // Key does not exist

            string[] args = Environment.GetCommandLineArgs();
            if ( args.Length > 1 )
            {   // At least one argument passed in

                Clipboard.SetText( args[1] );

            }   // At least one argument passed in

        }   // Main

    }   // class Program

}   // namespace CopyFullPath