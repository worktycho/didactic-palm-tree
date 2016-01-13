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
            this.Top = new Terminal(this);
            this.Bottom = new Terminal(this);
        }

        public double GetVoltageDrop()
        {
            return (Top.Voltage - Bottom.Voltage)/Resistance;
        }

        public ITerminal Bottom { get; set; }
        public ITerminal Top { get; set; }
    }
}
