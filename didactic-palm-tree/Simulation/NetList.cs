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

        public SparseMatrix CreateBMatrix(List<IConnection> connections, List<IConnection> voltageSources)
        {
            
            var bMatrix = new StarMathLib.SparseMatrix(voltageSources.Count, connections.Count);
            for (var i = 0; i < voltageSources.Count; i++)
            {
                for (var j = 0; j < connections.Count; j++)
                {
                    var value = 0;
                    foreach (var source in voltageSources[i].GetConnectedComponents())
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

        public SparseMatrix CreateCMatrix(List<IConnection> connections, List<IConnection> voltageSources)
        {
            var cMatrix = CreateBMatrix(connections, voltageSources);
            cMatrix.Transpose();
            return cMatrix;
        }

        public SparseMatrix CreateDMatrix(List<IConnection> voltageSources)
        {
            return new SparseMatrix(voltageSources.Count, voltageSources.Count);
        }

        public SparseMatrix CreateAMatrix(List<IConnection> connections, List<IConnection> voltageSources)
        {
            
        }

        public SparseMatrix CreateIMatrix(List<IConnection> connections)
        {
            var iMatrix = new SparseMatrix(connections.Count, 1);
            return iMatrix;
        }

        public SparseMatrix CreateEMatrix(List<IConnection> voltageSources)
        {
            var eMatrix = new SparseMatrix(voltageSources.Count, 1);
            for (var i = 0; i < voltageSources.Count; i++)
            {
                eMatrix[i, 0] = voltageSources[i];
            }
            return eMatrix;
        }

        public SparseMatrix CreateZMatrix(List<IConnection> connections, List<IConnection> voltageSources)
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

        public SparseMatrix CreateXMatrix(List<IConnection> connections, List<IConnection> voltageSources)
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

        public SparseMatrix CreateJMatrix(List<IConnection> voltageSources, SparseMatrix xMatrix)
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
    }
}
