using System.Collections.Generic;
using System.Runtime.Remoting.Channels;

namespace didactic_palm_tree.Simulation
{
    internal class Connection : IConnection
    {
        private ITerminal bottom;
        private ITerminal top;

        public Connection(ITerminal top, ITerminal bottom)
        {
            this.top = top;
            this.bottom = bottom;
            top.Connection = this;
bottom.Connection = this;
        }

        public void AddTerminal(ITerminal bottom)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IComponent> GetConnectedComponents()
        {
            yield return this.top.GetComponent();
            yield return this.bottom.GetComponent();
        }
    }
}