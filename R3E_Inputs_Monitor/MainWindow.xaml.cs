using da2mvc.core.events;
using da2mvc.core.injection;
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
    public partial class MainWindow : Window, IEventDispatcher
    {
        /*
         * TODO
         * * Right click to configure.
         * 
         * 
         */
        public event EventHandler MvcEventHandler;
        public static readonly int EVENT_OPEN_PREFERENCES = EventId.New();

        public MainWindow()
        {
            Mappings.Initialize(this);

            InitializeComponent();
            InitializeUI();
            
            Injector.ExecuteCommand<StartApplicationCommand>();

            MouseLeftButtonDown += LeftButtonHandler;
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
    }
}
