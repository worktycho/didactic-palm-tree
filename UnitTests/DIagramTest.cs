using System;
using System.ComponentModel;
using System.Net;
using System.Windows;
using didactic_palm_tree;
using didactic_palm_tree.UIModel;
using didactic_palm_tree.Views.Components.Abstract;
using DiagramDesigner;
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
            var context = new CircuitContext();
                Diagram test = Diagram.CreateNew(context, "test");
        }

        [TestMethod]
        [TestCategory("UIModel.Diagram")]
        public void DiagramAdd()
        {

            var context = new CircuitContext();
            Diagram test = Diagram.CreateNew(context, "test.sql");
            didactic_palm_tree.UIModel.Component testComponent = new TestComponent(0, 0);
            test.Add(testComponent);
        }
    }

    public class TestComponent : didactic_palm_tree.UIModel.Component
    {
        private readonly Point _point;

        public TestComponent(int x, int y)
        {_point = new Point(x, y); }

        public override ComponentViewModel CreateViewModel(Diagram diagram, DiagramViewModel parent)
        {
            throw new NotImplementedException();
        }
    }
}
