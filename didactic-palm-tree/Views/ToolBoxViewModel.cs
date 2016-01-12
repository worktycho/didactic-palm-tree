using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiagramDesigner.Helpers;
using didactic_palm_tree.Battery;

namespace didactic_palm_tree.Views
{
    class ToolBoxViewModel
    {
        private List<ToolBoxData> toolBoxItems = new List<ToolBoxData>();

        public ToolBoxViewModel()
        {
            //toolBoxItems.Add(new ToolBoxData("../Images/Setting.png", typeof()));
            toolBoxItems.Add(new ToolBoxData("../Resources/Battery.png", typeof(BatteryViewModel)));
        }

        public List<ToolBoxData> ToolBoxItems
        {
            get
            {
                return toolBoxItems;
            }
        }
    }
}
