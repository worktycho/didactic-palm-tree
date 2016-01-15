using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace didactic_palm_tree.Simulation
{
    public class Battery : IComponent
    {
        private int v;

        public Battery(int v)
        {
            this.v = v;
            this.Bottom = new Terminal(this);
            this.Top = new Terminal(this);
        }

        public double GetVoltageDrop()
        {
            return v;
        }

        public double GetCurrent()
        {
            return 0;
        }

        public ITerminal Bottom { get; set; }
        public ITerminal Top { get; set; }
        public double Voltage { get; set; } // Voltage getter setter
        public double GetResistance()
        {
            return double.PositiveInfinity;
        }

        public bool IsVoltageSource()
        {
            return true;
        }

        public void Simulate()
        {
            throw new NotImplementedException();
        }
    }
}
