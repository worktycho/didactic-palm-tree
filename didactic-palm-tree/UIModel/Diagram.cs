using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SQLite;
using didactic_palm_tree.Simulation;
using DiagramDesigner;

namespace didactic_palm_tree.UIModel
{
    public class Diagram
    {
        [NotMapped]
        private CircuitContext _context;

        [Key]
        public Guid Id { get; set; }

        public Diagram(CircuitContext context, string name) : this()
        {
            _context = context;
            Name = name;
        }

        public Diagram()
        {
            Id = Guid.NewGuid();
            NetList = new NetList();
        }

        [NotMapped]
        public IEnumerable<Component> Components => _context.Components.Where(x => x.Diagram.Id == this.Id);
        [NotMapped]
        public IEnumerable<Wire> Connectors => _context.Connectors.Where(x => x.Diagram.Id == this.Id);

        public string Name
        {
            get; set; }

        public NetList NetList { get; private set; }

        public Component Add(Component component)
        {
            component.Diagram = this;
            if (!_context.Components.Any(x => x.Id == component.Id))
            {
                _context.Components.Add(component);
                return component;
            }
            NetList.Add(component.SimComponent);
            return _context.Components.First(x => x.Id == component.Id);
        }

        public void Remove(Component component)
        {
            _context.Components.Remove(component);
        }

        public static Diagram CreateNew(CircuitContext context, string name)
        {/*
            var connectionStringBuilder = new SQLiteConnectionStringBuilder { DataSource = testSql };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SQLiteConnection(connectionString);
            var context = new CircuitContext(connection);
            */
            Diagram diagram = new Diagram(context, name);
            diagram._context.Database.CreateIfNotExists();
            diagram._context.Diagrams.Add(diagram);
            diagram._context.SaveChanges();
            return diagram;
        }

        public static Diagram Load(string name)
        {
            /*
            var connectionStringBuilder = new SQLiteConnectionStringBuilder { DataSource = file };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SQLiteConnection(connectionString);
            var context = new CircuitContext(connection
            */
            var context = new CircuitContext();
            Diagram diagram = new Diagram(context, name);
            diagram._context.Database.CreateIfNotExists();
            return diagram;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Add(Wire connector)
        {

            if (!_context.Connectors.Any(x => x.Id == connector.Id))
            {
                _context.Connectors.Add(connector);
            }
            if (connector.Sink == null) return;
            connector.CreateTerminals();
            NetList.AddConnection(connector.SourceTerminal, connector.SinkTerminal);
        }

        internal void Remove(Wire connector)
        {
            _context.Connectors.Remove(connector);
        }

        public void SetContext(CircuitContext context)
        {
            _context = context;
        }
    }
}
