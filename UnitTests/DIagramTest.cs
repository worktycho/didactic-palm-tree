using System;
using System.ComponentModel;
using didactic_palm_tree.UIModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class DiagramTest
    {
        [TestMethod]
        [TestCategory("UIModel.Diagram")]
        public void DiagramExists()
        {
                Diagram test = new Diagram("test.sql");
        }

        [TestMethod]
        [TestCategory("UIModel.Diagram")]
        public void DiagramAdd()
        {
            Diagram test = new Diagram("test.sql");
            didactic_palm_tree.UIModel.IComponent testComponent = new TestComponent();
            test.Add(testComponent);
        }

        [TestMethod]
        [TestCategory("UIModel.Diagram")]
        public void DiagramAddAndRetrive()
        {
            Diagram test = new Diagram("test.sql");
            didactic_palm_tree.UIModel.IComponent testComponent = new TestComponent();
            test.Add(testComponent);
            Assert.AreEqual(test.GetComponent(0, 0), testComponent);
        }
    }

    public class TestComponent : didactic_palm_tree.UIModel.IComponent
    {
    }
}
