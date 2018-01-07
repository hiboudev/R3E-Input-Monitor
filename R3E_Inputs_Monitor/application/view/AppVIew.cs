using da2mvc.framework.application.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R3E_Inputs_Monitor.application.view
{
    public class AppView : AbstractAppView
    {
        protected override void InitializeMappings()
        {
            Mappings.Initialize();
        }
    }
}
