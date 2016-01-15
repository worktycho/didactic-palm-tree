using System;
using didactic_palm_tree.Simulation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class NetListCircuitTest
    {
        [TestMethod]
        public void TestSingleResistors()
        {

            var test = new NetList();
            var testResistComponent = new Resistor(1, test);
            var testBatteryComponent = new Battery(1);
            test.Add(testResistComponent);
            test.Add(testBatteryComponent);
            test.AddConnection(testBatteryComponent.Bottom, testResistComponent.Top);
            test.AddConnection(testBatteryComponent.Top, testResistComponent.Bottom);
            test.Simulate();
            Assert.AreEqual(1, testResistComponent.GetVoltageDrop());
        }
        [TestMethod]
        public void TestSingleResistors2()
        {
            var testBatteryComponent = new Battery(1);
            var test = new NetList();
            var testResistComponent = new Resistor(2, test);
            test.Add(testResistComponent);
            test.Add(testBatteryComponent);
            test.AddConnection(testBatteryComponent.Bottom, testResistComponent.Top);
            test.AddConnection(testBatteryComponent.Top, testResistComponent.Bottom);
            test.Simulate();
            Assert.AreEqual(0.5, testResistComponent.GetVoltageDrop());
        }
        [TestMethod]
        public void TestSingleResistors3()
        {
            var testBatteryComponent = new Battery(2);
            var test = new NetList();
            var testResistComponent = new Resistor(1, test);
            test.Add(testResistComponent);
            test.Add(testBatteryComponent);
            test.AddConnection(testBatteryComponent.Bottom, testResistComponent.Top);
            test.AddConnection(testBatteryComponent.Top, testResistComponent.Bottom);
            test.Simulate();
            Assert.AreEqual(2, testResistComponent.GetVoltageDrop());
        }
    }

}
