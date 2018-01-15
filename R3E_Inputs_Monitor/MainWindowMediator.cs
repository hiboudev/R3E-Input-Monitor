using da2mvc.core.view;
using R3E_Inputs_Monitor.preferences.command;
using R3E_Inputs_Monitor.preferences.events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R3E_Inputs_Monitor
{
    class MainWindowMediator : BaseMediator<MainWindow>
    {
        public MainWindowMediator()
        {
            HandleEvent<UpdatePreferencesCommand, PreferencesModelEventArgs>(UpdatePreferencesCommand.EVENT_PREFERENCES_UPDATED, OnPreferencesChanged);
            HandleEvent<LoadPreferencesCommand, PreferencesModelEventArgs>(LoadPreferencesCommand.EVENT_PREFERENCES_LOADED, OnPreferencesChanged);
        }

        private void OnPreferencesChanged(PreferencesModelEventArgs args)
        {
            View.Topmost = args.Preferences.AlwaysOnTop;
        }
    }
}
