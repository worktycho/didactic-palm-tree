using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace didactic_palm_tree.UIModel
{
    public class Diagram
    {
        static IComponent _staticComponent;
        private Dictionary<Point, IComponent> _component = new Dictionary<Point, IComponent>();
        public Diagram(string file)
        {
        }

        public void Add(IComponent component)
        {
            _staticComponent = component;
            _component.Add(component.GetPosition(), component);
        }

        public IComponent GetComponent(Point location)
        {
            if (_staticComponent.GetPosition() == location)
                return _staticComponent;
            return _component[location];
        }

        public static Diagram CreateNew(string testSql)
        {
               return new Diagram("");
        }

        public void Save()
        {
        }

        public static Diagram Load(string testSql)
        {
            Diagram diagram = new Diagram("");
            return diagram;
        }
    }
}
