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
        static readonly Dictionary<String, Dictionary<Point, IComponent>> StaticComponents = new Dictionary<string, Dictionary<Point, IComponent>>();
        private readonly Dictionary<Point, IComponent> _component = new Dictionary<Point, IComponent>();
        private readonly String _file;

        public Diagram(string file)
        {
            _file = file;
        }

        private Diagram(string file, Dictionary<Point, IComponent> staticComponent)
        {
            _component = staticComponent;
            _file = file;
        }

        public void Add(IComponent component)
        {
            _component.Add(component.GetPosition(), component);
        }

        public IComponent GetComponent(Point location)
        {
            if (StaticComponents.ContainsKey(_file))
            {
                if (StaticComponents[_file].ContainsKey(location))
                    return StaticComponents[_file][location];
            }
            return _component[location];
        }

        public static Diagram CreateNew(string testSql)
        {
               return new Diagram(testSql);
        }

        public void Save()
        {
            if (StaticComponents.ContainsKey(_file))
                StaticComponents[_file] = _component;
            else
            {
                StaticComponents.Add(_file, _component);
            }
        }

        public static Diagram Load(string testSql)
        {
            Diagram diagram = new Diagram("", StaticComponents[testSql]);
            return diagram;
        }
    }
}
