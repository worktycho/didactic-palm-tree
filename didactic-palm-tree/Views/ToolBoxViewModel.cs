using System.Collections.Generic;
using didactic_palm_tree.Views.Components.ViewModels;
using DiagramDesigner.Helpers;

namespace didactic_palm_tree.Views
{
    public class ToolBoxViewModel
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
