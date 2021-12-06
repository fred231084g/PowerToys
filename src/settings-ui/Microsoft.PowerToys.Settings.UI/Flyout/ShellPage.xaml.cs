﻿// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Microsoft.PowerToys.Settings.UI.Flyout
{
    public sealed partial class ShellPage : Page
    {
        /// <summary>
        /// Declaration for the ipc callback function.
        /// </summary>
        /// <param name="msg">message.</param>
        public delegate void IPCMessageCallback(string msg);

        /// <summary>
        /// Gets or sets iPC default callback function.
        /// </summary>
        public static IPCMessageCallback DefaultSndMSGCallback { get; set; }

        public static Func<string> RunSharedEventCallback { get; set; }

        public static void SetRunSharedEventCallback(Func<string> implementation)
        {
            RunSharedEventCallback = implementation;
        }

        public static Func<string> ColorPickerSharedEventCallback { get; set; }

        public static void SetColorPickerSharedEventCallback(Func<string> implementation)
        {
            ColorPickerSharedEventCallback = implementation;
        }

        public static Action<Type> OpenMainWindowCallback { get; set; }

        public static void SetOpenMainWindowCallback(Action<Type> implementation)
        {
            OpenMainWindowCallback = implementation;
        }

        public ShellPage()
        {
            this.InitializeComponent();
            ContentFrame.Navigate(typeof(GeneralView), null, null);
        }

        public static int SendDefaultIPCMessage(string msg)
        {
            DefaultSndMSGCallback?.Invoke(msg);
            return 0;
        }
    }
}