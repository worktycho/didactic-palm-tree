using System.Collections.Generic;

namespace didactic_palm_tree.Simulation
{
    public interface IConnection
    {
        void AddTerminal(ITerminal bottom);
        IEnumerable<IComponent> GetConnectedComponents();
    }
}