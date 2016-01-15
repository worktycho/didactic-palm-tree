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
        private NetList _netlist;

        public Resistor(int v, NetList netlist)
        {
            this.Resistance = v;
            _netlist = netlist;
            this.Top = new Terminal(this);
            this.Bottom = new Terminal(this);
        }

        public double GetVoltageDrop()
        {
            return (Top.Voltage - Bottom.Voltage)/Resistance;
        }

        public double GetCurrent()
        {
            return 0;
        }

        public ITerminal Bottom { get; set; }
        public ITerminal Top { get; set; }
        public double GetResistance()
        {
            return Resistance;
        }

        public bool IsVoltageSource()
        {
            return false;
        }

        public void Simulate()
        {
            _netlist.Simulate();
        }
    }
}
