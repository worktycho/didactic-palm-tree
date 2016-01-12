﻿using System;
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
            var testResistComponent = new Resistor(1);
            var testBatteryComponent = new Battery(1);
            var test = new NetList();
            test.Add(testResistComponent);
            test.Add(testBatteryComponent);
            test.Simulate();
            Assert.AreEqual(1, testResistComponent.GetVoltageDrop());
        }
        [TestMethod]
        public void TestSingleResistors2()
        {
            var testResistComponent = new Resistor(2);
            var testBatteryComponent = new Battery(1);
            var test = new NetList();
            test.Add(testResistComponent);
            test.Add(testBatteryComponent);
            test.Simulate();
            Assert.AreEqual(0.5, testResistComponent.GetVoltageDrop());
        }
    }

}
