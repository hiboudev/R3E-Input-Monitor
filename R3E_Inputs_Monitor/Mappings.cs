using da2mvc.core.injection;
using R3E_Inputs_Monitor.display;
using R3E_Inputs_Monitor.preferences.command;
using R3E_Inputs_Monitor.preferences.model;
using R3E_Inputs_Monitor.preferences.view;
using R3E_Inputs_Monitor.r3e;
using R3E_Inputs_Monitor.r3e.socket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R3E_Inputs_Monitor
{
    class Mappings
    {
        private static bool initialized;

        public static void Initialize(MainWindow mainWindow = null)
        {
            if (initialized) return;
            initialized = true;

            if (mainWindow != null)
                Injector.MapInstance(mainWindow);

            Injector.MapType<R3eApiSocket>(true);
            Injector.MapType<PreferencesModel>(true);
            Injector.MapType<PreferencesView>();
            Injector.MapView<DisplayView, DisplayMediator>(true);
            Injector.MapCommand<MainWindow, OpenPreferencesCommand>(MainWindow.EVENT_OPEN_PREFERENCES);
            Injector.MapCommand<PreferencesView, UpdatePreferencesCommand>(PreferencesView.EVENT_PREFERENCES_CHANGED);
        }
    }
}
