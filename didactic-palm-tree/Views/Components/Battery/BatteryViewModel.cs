using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DiagramDesigner;
using didactic_palm_tree.Abstract;

namespace didactic_palm_tree.Battery
{
    class BatteryViewModel : ComponentViewModel
    {
        public BatteryViewModel(DiagramViewModel parent, double left, double top) : base(parent, left, top)
        {

        }
    }
}
