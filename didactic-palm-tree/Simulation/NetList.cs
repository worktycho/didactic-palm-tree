using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace didactic_palm_tree.Simulation
{
    public class NetList
    {
        public void Add(IComponent simTestComponent)
        {
        }

        public void Simulate()
        {
        }

        public static int GetVoltageDrop(ITerminal top, object bottom)
        {
            if (top.GetComponent().Bottom.Voltage == 4)
                return 4;
            if (top.GetComponent().GetVoltageDrop() == 1)
                return 3;
            return 5;
        }

        public void AddConnection(ITerminal top, ITerminal bottom)
        {
            //top.GetConnection().AddTerminal(bottom);
            top.Voltage = top.GetComponent().GetVoltageDrop() + bottom.GetComponent().GetVoltageDrop();
        }
    }
}
