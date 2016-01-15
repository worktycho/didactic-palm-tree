using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using StarMathLib;

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
                                  component.Bottom.GetConnection() == connections[j]) ||
                                 (component.Top.GetConnection() == connections[j] &&
                                  component.Bottom.GetConnection() == connections[i]))
                        {
                            sumResists += 1.0 / component.GetResistance();
                        }
                    }
                    gMatrix[i, j] = sumResists;
                }
            }
        }

        public SparseMatrix CreateGMatrix(List<IConnection> connections)
        {
            var gMatrix = new StarMathLib.SparseMatrix(connections.Count, connections.Count);
            for (var i = 0; i < connections.Count; i++)
            {
                for (var j = 0; j < connections.Count; j++)
                {
                    var sumResists = 0.0;
                    foreach (var component in connections[i].GetConnectedComponents())
                    {
                        if (i == j) sumResists += 1.0 / component.GetResistance();
                        else if ((component.Top.GetConnection() == connections[i] &&
                                  component.Bottom.GetConnection() == connections[j]) ||
                                 (component.Top.GetConnection() == connections[j] &&
                                  component.Bottom.GetConnection() == connections[i]))
                        {
                            sumResists += 1.0 / component.GetResistance();
                        }
                    }
                    gMatrix[i, j] = sumResists;
                }
            }
            return gMatrix;
        }

        public SparseMatrix CreateBMatrix(List<IConnection> connections, List<Battery> voltageSources)
        {
            
            var bMatrix = new StarMathLib.SparseMatrix(voltageSources.Count, connections.Count);
            for (var i = 0; i < voltageSources.Count; i++)
            {
                for (var j = 0; j < connections.Count; j++)
                {
                    var value = 0;
                    foreach (var source in voltageSources)
                    {
                        if (source.Top.GetConnection() == connections[j])
                        {
                            value = 1;
                        } else if (source.Bottom.GetConnection() == connections[j])
                        {
                            value = -1;
                        }
                    }
                    bMatrix[i, j] = value;
                }
            }
            return bMatrix;
        }

        public SparseMatrix CreateCMatrix(List<IConnection> connections, List<Battery> voltageSources)
        {
            var cMatrix = CreateBMatrix(connections, voltageSources);
            cMatrix.Transpose();
            return cMatrix;
        }

        public SparseMatrix CreateDMatrix(List<Battery> voltageSources)
        {
            return new SparseMatrix(voltageSources.Count, voltageSources.Count);
        }

        public SparseMatrix CreateAMatrix(List<IConnection> connections, List<Battery> voltageSources)
        {
            var aMatrix = new StarMathLib.SparseMatrix(connections.Count + voltageSources.Count, connections.Count + voltageSources.Count);
            var gMatrix = CreateGMatrix(connections);
            var bMatrix = CreateBMatrix(connections, voltageSources);
            var cMatrix = CreateCMatrix(connections, voltageSources);
            var dMatrix = CreateDMatrix(voltageSources);

            for (var i = 0; i < connections.Count + voltageSources.Count; i++)
            {
                for (var j = 0; j < connections.Count + voltageSources.Count; j++)
                {
                    if(i < connections.Count && j < connections.Count)
                    {
                        aMatrix[i, j] = gMatrix[i, j];
                    }
                    else if(i < connections.Count && j >= connections.Count)
                    {
                        aMatrix[i, j] = bMatrix[i, j - connections.Count + 1];
                    }
                    else if(i >= connections.Count && j < connections.Count)
                    {
                        aMatrix[i, j] = cMatrix[i - connections.Count + 1, j];
                    }
                    else if(i >= connections.Count && j >= connections.Count)
                    {
                        aMatrix[i, j] = dMatrix[i - connections.Count + 1, j - connections.Count + 1];
                    }
                }
            }
            return aMatrix;
        }

        public SparseMatrix CreateIMatrix(List<IConnection> connections)
        {
            var iMatrix = new SparseMatrix(connections.Count, 1);
            /*for (var i = 0; i < connections.Count; i++)
            {
                var sum = 0.0;
                for (var j = 0; j < currentSources.Count; j++)
                {
                    var current = 0.0;
                    foreach (var component in connections[i].GetConnectedComponents())
                    {
                        if (component.Bottom.GetConnection() == currentSources[j])
                        {
                            // Current source add
                            current = 0.0;
                        }
                    }
                    sum += current;
                }
                iMatrix[i, 0] = sum;
            }*/
            return iMatrix;
        }

        public SparseMatrix CreateEMatrix(List<Battery> voltageSources)
        {
            var eMatrix = new SparseMatrix(voltageSources.Count, 1);
            for (var i = 0; i < voltageSources.Count; i++)
            {
                eMatrix[i, 0] = voltageSources[i].Voltage;
            }
            return eMatrix;
        }

        public SparseMatrix CreateZMatrix(List<IConnection> connections, List<Battery> voltageSources)
        {
            var iMatrix = CreateIMatrix(connections);
            var eMatrix = CreateEMatrix(voltageSources);
            var zMatrix = new SparseMatrix(connections.Count + voltageSources.Count, 1);
            var k = 0;
            for (var i = 0; i < connections.Count; i++)
            {
                zMatrix[k++, 0] = iMatrix[i, 0];
            }
            for (var j = 0; j < voltageSources.Count; j++)
            {
                zMatrix[k++, 0] = eMatrix[j, 0];
            }
            return zMatrix;
        }

        public SparseMatrix CreateXMatrix(List<IConnection> connections, List<Battery> voltageSources)
        {
            var aMatrix = CreateAMatrix(connections, voltageSources);
            var zMatrix = CreateZMatrix(connections, voltageSources);
            var xMatrix = aMatrix.ConvertSparseToDenseMatrix().inverse().ConvertDenseToSparseMatrix(0.0).multiply(zMatrix.ConvertSparseToDenseMatrix()).ConvertDenseToSparseMatrix();
            return xMatrix;
        }

        public SparseMatrix CreateVMatrix(List<IConnection> connections, SparseMatrix xMatrix)
        {
            var vMatrix = xMatrix;
            for (var i = 0; i < xMatrix.NumRows - connections.Count; i++)
            {
                vMatrix.RemoveRow(xMatrix.NumRows - i - 1);
            }
            return vMatrix;
        }

        public SparseMatrix CreateJMatrix(List<Battery> voltageSources, SparseMatrix xMatrix)
        {
            var jMatrix = xMatrix;
            for (var i = 0; i < xMatrix.NumRows - voltageSources.Count; i++)
            {
                jMatrix.RemoveRow(i);
            }
            return jMatrix;
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

        public IEnumerable<IComponent> VoltageSources()
        {
            var connections = new List<IComponent>();
            return connections.Where(x => x.IsVoltageSource());
        } 
    }
}
