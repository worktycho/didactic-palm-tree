using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace didactic_palm_tree.Simulation
{
    public class Resistor : IComponent
    {
        private int Resistance;

        public Resistor(int v)
        {
            this.Resistance = v;
        }

        public double GetVoltageDrop()
        {
            return 1.0/Resistance;
        }

        public ITerminal Bottom { get; set; }
    }
}
