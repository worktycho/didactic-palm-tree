using System;
using System.ComponentModel;
using System.Windows;
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
            didactic_palm_tree.UIModel.IComponent testComponent = new TestComponent(0, 0);
            test.Add(testComponent);
        }

        [TestMethod]
        [TestCategory("UIModel.Diagram")]
        public void DiagramAddAndRetrive()
        {
            Diagram test = new Diagram("test.sql");
            didactic_palm_tree.UIModel.IComponent testComponent = new TestComponent(0, 0);
            test.Add(testComponent);
            Assert.AreEqual(test.GetComponent(new Point(0, 0)), testComponent);
        }
        [TestMethod]
        [TestCategory("UIModel.Diagram")]
        public void DiagramAdd2AndRetriveOld()
        {
            Diagram test = new Diagram("test.sql");
            didactic_palm_tree.UIModel.IComponent testComponent = new TestComponent(0, 0);
            test.Add(testComponent);

            didactic_palm_tree.UIModel.IComponent testComponent2 = new TestComponent(1, 1);
            test.Add(testComponent2);
            Assert.AreEqual(test.GetComponent(new Point(0, 0)), testComponent);
        }
        [TestMethod]
        [TestCategory("UIModel.Diagram")]
        public void DiagramAdd2AndRetriveNew()
        {
            Diagram test = new Diagram("test.sql");
            didactic_palm_tree.UIModel.IComponent testComponent = new TestComponent(0, 0);
            test.Add(testComponent);

            didactic_palm_tree.UIModel.IComponent testComponent2 = new TestComponent(1, 1);
            test.Add(testComponent2);
            Assert.AreEqual(test.GetComponent(new Point(1, 1)), testComponent2);
        }
        [TestMethod]
        [TestCategory("UIModel.Diagram")]
        public void DiagramAddSaveAndRetrive()
        {
            Diagram test = Diagram.CreateNew("test.sql");
            didactic_palm_tree.UIModel.IComponent testComponent = new TestComponent(0, 0);
            test.Add(testComponent);
            test.Save();
            Diagram test2 = Diagram.Load("test.sql");
            Assert.AreEqual(test2.GetComponent(new Point(0, 0)), testComponent);
        }
        [TestMethod]
        [TestCategory("UIModel.Diagram")]
        public void DiagramAddSave2AndRetrive()
        {
            Diagram test = Diagram.CreateNew("test.sql");
            didactic_palm_tree.UIModel.IComponent testComponent = new TestComponent(0, 0);
            test.Add(testComponent);
            test.Save();
            Diagram test2 = Diagram.CreateNew("test2.sql");
            didactic_palm_tree.UIModel.IComponent testComponent2 = new TestComponent(1, 1);
            test2.Add(testComponent2);
            test2.Save();
            Diagram test3 = Diagram.Load("test.sql");
            Assert.AreEqual(test3.GetComponent(new Point(0, 0)), testComponent);
        }
    }

    public class TestComponent : didactic_palm_tree.UIModel.IComponent
    {
        private readonly Point _point;

        public TestComponent(int x, int y)
        {_point = new Point(x, y); }

        public Point GetPosition()
        {
            return _point;
        }
    }
}
