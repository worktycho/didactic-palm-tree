using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using didactic_palm_tree.Simulation;

namespace UnitTests
{
    [TestClass]
    public class NetListTest
    {
        [TestMethod]
        public void AddComponent()
        {
            var test = new NetList();
            var component = new SimTestComponent(1);
            test.Add(component);
        }
        [TestMethod]
        public void GetVoltage()
        {
            var test = new NetList();
            var component = new SimTestComponent(1);
            test.Add(component);
            test.Simulate();
            Assert.AreEqual(component.GetVoltageDrop(), 1);
        }
        [TestMethod]
        public void GetVoltage2()
        {
            var test = new NetList();
            var component = new SimTestComponent(2);
            test.Add(component);
            test.Simulate();
            Assert.AreEqual(component.GetVoltageDrop(), 2);
        }
        [TestMethod]
        public void GetVoltageTwoComponent()
        {
            var test = new NetList();
            var component = new SimTestComponent(1);
            test.Add(component);
            var component2 = new SimTestComponent(2);
            test.Add(component2);
            test.AddConnection(component.Bottom, component.Top);
            test.Simulate();
            Assert.AreEqual(NetList.GetVoltageDrop(component.Top, component2.Bottom), 3);
        }
        [TestMethod]
        public void GetVoltageTwoComponent2()
        {
            var test = new NetList();
            var component = new SimTestComponent(2);
            test.Add(component);
            var component2 = new SimTestComponent(3);
            test.Add(component2);
            test.AddConnection(component.Bottom, component2.Top);
            test.Simulate();
            Assert.AreEqual(NetList.GetVoltageDrop(component.Top, component2.Bottom), 5);
        }
        [TestMethod]
        public void GetVoltageTwoComponent3()
        {
            var test = new NetList();
            var component = new SimTestComponent(1);
            test.Add(component);
            var component2 = new SimTestComponent(3);
            test.Add(component2);
            test.AddConnection(component.Bottom, component2.Top);
            test.Simulate();
            Assert.AreEqual(NetList.GetVoltageDrop(component.Top, component2.Bottom), 4);
        }
    }

    internal class SimTestComponent : IComponent
    {
        private readonly int _voltage;
        public readonly ITerminal Top;

        public SimTestComponent(int voltage)
        {
            _voltage = voltage;
            Top = new Terminal(_voltage, this);
            Bottom = new Terminal(0, this);
        }

        public int GetVoltageDrop()
        {
            return _voltage;
        }

        public ITerminal Bottom { get; set; }
    }

    internal class Terminal : ITerminal
    {
        private SimTestComponent _component;

        public Terminal(int voltage, SimTestComponent simTestComponent)
        {
            Voltage = voltage;
            _component = simTestComponent;
        }

        public int Voltage { get; set; }
        public IConnection GetConnection()
        {
            return new Connection();
        }

        public IComponent GetComponent()
        {
            return _component;
        }
    }

    internal class Connection : IConnection
    {
        public void AddTerminal(ITerminal bottom)
        {
        }
    }
}
