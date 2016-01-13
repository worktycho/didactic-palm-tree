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
            toolBoxItems.Add(new ToolBoxData("../Resources/Battery.png", typeof(BatteryViewModel)));
            toolBoxItems.Add(new ToolBoxData("../Resources/Switch_Off.png", typeof(SwitchViewModel)));
            toolBoxItems.Add(new ToolBoxData("../Resources/Bulb_Off.png", typeof(BulbViewModel)));
            toolBoxItems.Add(new ToolBoxData("../Resources/Ammeter.png", typeof(AmmeterViewModel)));
            toolBoxItems.Add(new ToolBoxData("../Resources/Voltmeter.png", typeof(VoltmeterViewModel)));
            toolBoxItems.Add(new ToolBoxData("../Resources/Resistor.png", typeof(ResistorViewModel)));
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
