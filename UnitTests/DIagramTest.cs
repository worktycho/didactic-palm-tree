using System;
using System.ComponentModel;
using System.Windows;
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
                Diagram test = Diagram.CreateNew("test.sql");
        }

        [TestMethod]
        [TestCategory("UIModel.Diagram")]
        public void DiagramAdd()
        {
            Diagram test = Diagram.CreateNew("test.sql");
            didactic_palm_tree.UIModel.Component testComponent = new TestComponent(0, 0);
            test.Add(testComponent);
        }
    }

    public class TestComponent : didactic_palm_tree.UIModel.Component
    {
        private readonly Point _point;

        public TestComponent(int x, int y)
        {_point = new Point(x, y); }

        public override ComponentViewModel CreateViewModel(DiagramViewModel parent)
        {
            throw new NotImplementedException();
        }
    }
}
