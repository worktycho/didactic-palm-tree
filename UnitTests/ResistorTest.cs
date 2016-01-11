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
    }
}
