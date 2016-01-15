using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using StarMathLib;
using System.ComponentModel.DataAnnotations.Schema;

namespace didactic_palm_tree.Simulation
{
    [Table("NetList")]
    public class NetList
    {
        private List<IConnection> _connections = new List<IConnection>();
        public Guid Id { get; set; }
        public List<IComponent> Components { get; set; }

        public NetList()
        {
            Id = Guid.NewGuid();
            Components = new List<IComponent>();
        }

        public void Add(IComponent component)
        {
            if (component == null) throw new ArgumentException();
            Components.Add(component);
        }

        public void Simulate()
        {
            /*
            var AMatrix = CreateAMatrix(Connections(), VoltageSources());
            var XMatrix = CreateXMatrix(Connections(), VoltageSources());
            var ZMatrix = CreateZMatrix(Connections(), VoltageSources());
            var r = StarMath.solve(AMatrix, ZMatrix.ConvertSparseToDenseMatrix().GetColumn(0));
            */
        }

        private IList<IConnection> Connections()
        {
            return _connections;
        }

        public double[,] CreateGMatrix(IList<IConnection> connections)
        {
            var gMatrix = new StarMathLib.SparseMatrix(connections.Count, connections.Count).ConvertSparseToDenseMatrix();
            for (var i = 0; i < connections.Count; i++)
            {
                for (var j = 0; j < connections.Count; j++)
                {
                    var sumResists = 0.0;
                    foreach (var component in connections[i].GetConnectedComponents())
                    {
                        if (i == j) sumResists += 1.0 / component.GetResistance();
                        else if ((component.Top.Connection == connections[i] &&
                                  component.Bottom.Connection == connections[j]) ||
                                 (component.Top.Connection == connections[j] &&
                                  component.Bottom.Connection == connections[i]))
                        {
                            sumResists += 1.0 / component.GetResistance();
                        }
                    }
                    gMatrix[i, j] = sumResists;
                }
            }
            return gMatrix;
        }

        public double[,] CreateBMatrix(IList<IConnection> connections, IList<IComponent> voltageSources)
        {
            
            var bMatrix = new StarMathLib.SparseMatrix(connections.Count, voltageSources.Count).ConvertSparseToDenseMatrix();
            for (var j = 0; j < voltageSources.Count; j++)
            {
                for (var i = 0; i < connections.Count; i++)
                {
                    var value = 0;
                    foreach (var source in voltageSources)
                    {
                        if (source.Top.Connection == connections[j])
                        {
                            value = 1;
                        } else if (source.Bottom.Connection == connections[j])
                        {
                            value = -1;
                        }
                    }
                    bMatrix[i, j] = value;
                }
            }
            return bMatrix;
        }

        public double[,] CreateCMatrix(IList<IConnection> connections, IList<IComponent> voltageSources)
        {
            var cMatrix = CreateBMatrix(connections, voltageSources);
            cMatrix = cMatrix.transpose();
            return cMatrix;
        }

        public SparseMatrix CreateDMatrix(IList<IComponent> voltageSources)
        {
            return new SparseMatrix(voltageSources.Count, voltageSources.Count);
        }

        public double[,] CreateAMatrix(IList<IConnection> connections, IList<IComponent> voltageSources)
        {
            var aMatrix = new StarMathLib.SparseMatrix(connections.Count + voltageSources.Count, connections.Count + voltageSources.Count).ConvertSparseToDenseMatrix();
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
                        aMatrix[i, j] = bMatrix[i, j - connections.Count];
                    }
                    else if(i >= connections.Count && j < connections.Count)
                    {
                        aMatrix[i, j] = cMatrix[i - connections.Count, j];
                    }
                    else if(i >= connections.Count && j >= connections.Count)
                    {
                        aMatrix[i, j] = dMatrix[i - connections.Count, j - connections.Count];
                    }
                }
            }
            return aMatrix;
        }

        public SparseMatrix CreateIMatrix(IList<IConnection> connections)
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

        public double[,] CreateEMatrix(IList<IComponent> voltageSources)
        {
            var eMatrix = new SparseMatrix(voltageSources.Count, 1).ConvertSparseToDenseMatrix();
            for (var i = 0; i < voltageSources.Count; i++)
            {
                eMatrix[i, 0] = voltageSources[i].GetVoltageDrop();
            }
            return eMatrix;
        }

        public SparseMatrix CreateZMatrix(IList<IConnection> connections, IList<IComponent> voltageSources)
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

        public SparseMatrix CreateXMatrix(IList<IConnection> connections, IList<IComponent> voltageSources)
        {
            var aMatrix = CreateAMatrix(connections, voltageSources);
            var zMatrix = CreateZMatrix(connections, voltageSources);
            var xMatrix = aMatrix.inverse().ConvertDenseToSparseMatrix(0.0).multiply(zMatrix.ConvertSparseToDenseMatrix()).ConvertDenseToSparseMatrix();
            return xMatrix;
        }

        public SparseMatrix CreateVMatrix(IList<IConnection> connections, SparseMatrix xMatrix)
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
            _connections.Add(new Connection(top, bottom));
        }

        public IList<IComponent> VoltageSources()
        {
            return Components.Where(x => x.IsVoltageSource()).ToList();
        } 
    }
}
