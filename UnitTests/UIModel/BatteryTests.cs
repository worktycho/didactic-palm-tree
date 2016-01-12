using Microsoft.VisualStudio.TestTools.UnitTesting;
using didactic_palm_tree.UIModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;

namespace UnitTests.UIModel
{
    [TestClass()]
    public class BatteryTests
    {
        [TestMethod()]
        public void CreateNull()
        {
            var test = new Battery();
            var obs = Observer.Create<string>(x => Assert.AreEqual("0", x));
            test.Current.Subscribe(obs);
            var obs2 = Observer.Create<string>(x => Assert.AreEqual("0", x));
            test.Voltage.Subscribe(obs);
        }
    }
}