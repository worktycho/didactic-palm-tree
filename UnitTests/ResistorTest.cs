using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using didactic_palm_tree.UIModel;

namespace UnitTests
{
    [TestClass]
    public class ResistorTest
    {
        [TestMethod]
        public void ResistorExists()
        {
            Resistor test = new Resistor(3);
        }

        [TestMethod]
        public void Resitance()
        {
            Resistor test = new Resistor(3);
            Assert.AreEqual(test.Resistance, 3);
        }
        [TestMethod]
        public void Resitance2()
        {
            Resistor test = new Resistor(1);
            Assert.AreEqual(test.Resistance, 1);
        }
    }
}
