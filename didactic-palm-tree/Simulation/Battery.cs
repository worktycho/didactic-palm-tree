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
        }

        public double GetVoltageDrop()
        {
            throw new NotImplementedException();
        }

        public ITerminal Bottom { get; set; }
    }
}
