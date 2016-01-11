using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace didactic_palm_tree.UIModel
{
    public class Diagram
    {
        private IComponent Component;
        public Diagram(string file)
        {
        }

        public void Add(IComponent component)
        {
            this.Component = component;
        }

        public IComponent GetComponent(int x, int y)
        {
            return Component;
        }
    }
}
