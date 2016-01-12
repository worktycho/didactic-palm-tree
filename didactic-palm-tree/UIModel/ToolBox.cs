using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using DiagramDesigner.Helpers;
using DiagramDesigner;

namespace didactic_palm_tree.UIModel
{
    public class ToolBox
    {
        private List<ToolBoxData> toolBoxItems = new List<ToolBoxData>();

        public ToolBox()
        {
            toolBoxItems.Add(new ToolBoxData("../Images/Setting.png", typeof(SettingsDesignerItemViewModel)));
            toolBoxItems.Add(new ToolBoxData("../Images/Persist.png", typeof(PersistDesignerItemViewModel)));
        }

        public List<ToolBoxData> ToolBoxItems
        {
            get { return toolBoxItems; }
        }
    }
}
