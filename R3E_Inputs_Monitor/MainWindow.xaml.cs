﻿using da2mvc.core.events;
using da2mvc.core.injection;
using da2mvc.core.view;
using R3E_Inputs_Monitor.application.command;
using R3E_Inputs_Monitor.display;
using R3E_Inputs_Monitor.r3e;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace R3E_Inputs_Monitor
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IEventDispatcher, IView
    {
        /*
         * TODO
         * * Right click to configure.
         * 
         * 
         */
        public event EventHandler MvcEventHandler;
        public event EventHandler Disposed;

        public static readonly int EVENT_OPEN_PREFERENCES = EventId.New();

        public MainWindow()
        {
            Mappings.Initialize(this);

            InitializeComponent();
            InitializeUI();
            
            Injector.ExecuteCommand<StartApplicationCommand>();

            MouseLeftButtonDown += LeftButtonHandler;

            // Don't draw the grip if window is not focused.
            Activated += ActivatedHandler;
            Deactivated += DeactivatedHandler;
        }

        private void ActivatedHandler(object sender, EventArgs e)
        {
            ResizeMode = ResizeMode.CanResizeWithGrip;
        }

        private void DeactivatedHandler(object sender, EventArgs e)
        {
            ResizeMode = ResizeMode.CanResize;
        }

        private void LeftButtonHandler(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        public void DispatchEvent(BaseEventArgs args)
        {
            MvcEventHandler?.Invoke(this, args);
        }

        private void InitializeUI()
        {
            KeyDown += KeyDownHandler;
        }

        private void KeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C && !e.IsRepeat && Keyboard.Modifiers == 0)
            {
                DispatchEvent(new BaseEventArgs(EVENT_OPEN_PREFERENCES));
            }
            else if (e.Key == Key.Escape)
                Application.Current.Shutdown();
        }

        public void Dispose()
        {
            Disposed?.Invoke(this, EventArgs.Empty);
        }
    }
}
