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
            var connections = new List<IConnection>();
            var gMatrix = new StarMathLib.SparseMatrix(connections.Count, connections.Count);
            // Assuming one battery
            var bMatrix = new StarMathLib.SparseMatrix(1, connections.Count);
            for (var i = 0; i < connections.Count; i++)
            {
                for (var j = 0; j < connections.Count; j++)
                {
                    var sumResists = 0.0;
                    foreach (var component in connections[i].GetConnectedComponents())
                    {
                        if (i == j) sumResists += 1.0/component.GetResistance();
                        else if ((component.Top.GetConnection() == connections[i] &&
                                  component.Top.GetConnection() == connections[j]) ||
                                 (component.Top.GetConnection() == connections[j] &&
                                  component.Top.GetConnection() == connections[i]))
                        {
                            sumResists += 1.0 / component.GetResistance();
                        }
                    }
                    gMatrix[i, j] = sumResists;
                }
            }
        }

        public static double GetVoltageDrop(ITerminal top, object bottom)
        {
            return top.GetComponent().Bottom.Voltage;
        }

        public void AddConnection(ITerminal top, ITerminal bottom)
        {
            //top.Voltage = top.GetComponent().GetVoltageDrop() + bottom.GetComponent().GetVoltageDrop();
            //bottom.Voltage = top.Voltage;
        }
    }
}
