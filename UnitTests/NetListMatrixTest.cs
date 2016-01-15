using System;
using System.Collections.Generic;
using didactic_palm_tree.Simulation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarMathLib;

namespace UnitTests
{
    [TestClass]
    public class NetListMatrixTest
    {
        [TestMethod]
        public void TestGMatrix()
        {
            var expectedMatrix = new StarMathLib.SparseMatrix(2, 2)
            {

            };
            var testConnections = new List<IConnection>();
            var testResistComponent = new Resistor(1);
            var testBatteryComponent = new Battery(1);
            var test = new NetList();
            test.Add(testResistComponent);
            test.Add(testBatteryComponent);
            test.AddConnection(testBatteryComponent.Bottom, testResistComponent.Top);
            test.AddConnection(testBatteryComponent.Top, testResistComponent.Bottom);
            Assert.AreEqual(expectedMatrix, test.CreateGMatrix(testConnections))

        }

        [TestMethod]
        public void TestBMatrix()
        {
            var expectedMatrix = new StarMathLib.SparseMatrix(1, 2)
            {

            };
            var testConnections = new List<IConnection>();
            var testVoltageSources = new List<Battery>();
            var testResistComponent = new Resistor(1);
            var testBatteryComponent = new Battery(1);
            var test = new NetList();
            test.Add(testResistComponent);
            test.Add(testBatteryComponent);
            test.AddConnection(testBatteryComponent.Bottom, testResistComponent.Top);
            test.AddConnection(testBatteryComponent.Top, testResistComponent.Bottom);
            Assert.AreEqual(expectedMatrix, test.CreateBMatrix(testVoltageSources, testConnections));
        }

        [TestMethod]
        public void TestCMatrix()
        {
            var expectedMatrix = new StarMathLib.SparseMatrix(2, 1)
            {

            };
            var testConnections = new List<IConnection>();
            var testVoltageSources = new List<Battery>();
            var testResistComponent = new Resistor(1);
            var testBatteryComponent = new Battery(1);
            var test = new NetList();
            test.Add(testResistComponent);
            test.Add(testBatteryComponent);
            test.AddConnection(testBatteryComponent.Bottom, testResistComponent.Top);
            test.AddConnection(testBatteryComponent.Top, testResistComponent.Bottom);
            Assert.AreEqual(expectedMatrix, test.CreateCMatrix(testConnections, testVoltageSources));
        }

        [TestMethod]
        public void TestDMatrix()
        {
            var expectedMatrix = new StarMathLib.SparseMatrix(1, 1)
            {

            };
            var testVoltageSources = new List<Battery>();
            var testResistComponent = new Resistor(1);
            var testBatteryComponent = new Battery(1);
            var test = new NetList();
            test.Add(testResistComponent);
            test.Add(testBatteryComponent);
            test.AddConnection(testBatteryComponent.Bottom, testResistComponent.Top);
            test.AddConnection(testBatteryComponent.Top, testResistComponent.Bottom);
            Assert.AreEqual(expectedMatrix, test.CreateDMatrix(testVoltageSources));
        }

        [TestMethod]
        public void TestAMatrix()
        {
            var expectedMatrix = new StarMathLib.SparseMatrix(3, 3)
            {

            };
            var testConnections = new List<IConnection>();
            var testVoltageSources = new List<Battery>();
            var testResistComponent = new Resistor(1);
            var testBatteryComponent = new Battery(1);
            var test = new NetList();
            test.Add(testResistComponent);
            test.Add(testBatteryComponent);
            test.AddConnection(testBatteryComponent.Bottom, testResistComponent.Top);
            test.AddConnection(testBatteryComponent.Top, testResistComponent.Bottom);
            Assert.AreEqual(expectedMatrix, test.CreateAMatrix(testConnections, testVoltageSources));
        }

        [TestMethod]
        public void TestIMatrix()
        {
            var expectedMatrix = new StarMathLib.SparseMatrix(2, 1)
            {

            };
            var testConnections = new List<IConnection>();
            var testCurrentSources = new List<Resistor>();
            var testResistComponent = new Resistor(1);
            var testBatteryComponent = new Battery(1);
            var test = new NetList();
            test.Add(testResistComponent);
            test.Add(testBatteryComponent);
            test.AddConnection(testBatteryComponent.Bottom, testResistComponent.Top);
            test.AddConnection(testBatteryComponent.Top, testResistComponent.Bottom);
            Assert.AreEqual(expectedMatrix, test.CreateIMatrix(testConnections, testCurrentSources));
        }

        [TestMethod]
        public void TestEMatrix()
        {
            var expectedMatrix = new StarMathLib.SparseMatrix(1, 1)
            {

            };
            var testVoltageSources = new List<Battery>();
            var testResistComponent = new Resistor(1);
            var testBatteryComponent = new Battery(1);
            var test = new NetList();
            test.Add(testResistComponent);
            test.Add(testBatteryComponent);
            test.AddConnection(testBatteryComponent.Bottom, testResistComponent.Top);
            test.AddConnection(testBatteryComponent.Top, testResistComponent.Bottom);
            Assert.AreEqual(expectedMatrix, test.CreateEMatrix(testVoltageSources));
        }

        [TestMethod]
        public void TestZMatrix()
        {
            var expectedMatrix = new StarMathLib.SparseMatrix(3, 1)
            {

            };
            var testConnections = new List<IConnection>();
            var testVoltageSources = new List<Battery>();
            var testResistComponent = new Resistor(1);
            var testBatteryComponent = new Battery(1);
            var test = new NetList();
            test.Add(testResistComponent);
            test.Add(testBatteryComponent);
            test.AddConnection(testBatteryComponent.Bottom, testResistComponent.Top);
            test.AddConnection(testBatteryComponent.Top, testResistComponent.Bottom);
            Assert.AreEqual(expectedMatrix, test.CreateZMatrix(testConnections, testVoltageSources));
        }

        [TestMethod]
        public void TestXMatrix()
        {
            var expectedMatrix = new StarMathLib.SparseMatrix()
            {

            };
            var testConnections = new List<IConnection>();
            var testVoltageSources = new List<Battery>();
            var testResistComponent = new Resistor(1);
            var testBatteryComponent = new Battery(1);
            var test = new NetList();
            test.Add(testResistComponent);
            test.Add(testBatteryComponent);
            test.AddConnection(testBatteryComponent.Bottom, testResistComponent.Top);
            test.AddConnection(testBatteryComponent.Top, testResistComponent.Bottom);
            Assert.AreEqual(expectedMatrix, test.CreateXMatrix(testConnections, testVoltageSources));
        }

        [TestMethod]
        public void TestVMatrix()
        {
            var expectedMatrix = new StarMathLib.SparseMatrix(3, 1)
            {

            };
            var testXMatrix = new StarMathLib.SparseMatrix()
            var testConnections = new List<IConnection>();
            var testResistComponent = new Resistor(1);
            var testBatteryComponent = new Battery(1);
            var test = new NetList();
            test.Add(testResistComponent);
            test.Add(testBatteryComponent);
            test.AddConnection(testBatteryComponent.Bottom, testResistComponent.Top);
            test.AddConnection(testBatteryComponent.Top, testResistComponent.Bottom);
            Assert.AreEqual(expectedMatrix, test.CreateVMatrix(testConnections, testXMatrix));
        }

        [TestMethod]
        public void TestJMatrix()
        {
            var expectedMatrix = new StarMathLib.SparseMatrix(3, 1)
            {

            };
            var testXMatrix = new StarMathLib.SparseMatrix()
            var testVoltageSources = new List<Battery>();
            var testResistComponent = new Resistor(1);
            var testBatteryComponent = new Battery(1);
            var test = new NetList();
            test.Add(testResistComponent);
            test.Add(testBatteryComponent);
            test.AddConnection(testBatteryComponent.Bottom, testResistComponent.Top);
            test.AddConnection(testBatteryComponent.Top, testResistComponent.Bottom);
            Assert.AreEqual(expectedMatrix, test.CreateJMatrix(testVoltageSources, testXMatrix));
        }
    }
}
