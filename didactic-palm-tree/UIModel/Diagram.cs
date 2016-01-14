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
using System.Data.SQLite;

namespace didactic_palm_tree.UIModel
{
    public class Diagram
    {
        private CircuitContext _context;

        public Diagram(CircuitContext context)
        {
            _context = context;
        }

        public IEnumerable<Component> Components => _context.Components;

        public Component Add(Component component)
        {
            if (!_context.Components.Any(x => x.Id == component.Id))
            {
                _context.Components.Add(component);
                return component;
            }
            return _context.Components.First(x => x.Id == component.Id);
        }

        public void Remove(Component component)
        {
            _context.Components.Remove(component);
        }

        public static Diagram CreateNew(string testSql)
        {/*
            var connectionStringBuilder = new SQLiteConnectionStringBuilder { DataSource = testSql };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SQLiteConnection(connectionString);
            var context = new CircuitContext(connection);
            */
            var context = new CircuitContext();
            Diagram diagram = new Diagram(context);
            diagram._context.Database.CreateIfNotExists();
            return diagram;
        }

        public static Diagram Load(string file)
        {
            /*
            var connectionStringBuilder = new SQLiteConnectionStringBuilder { DataSource = file };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SQLiteConnection(connectionString);
            var context = new CircuitContext(connection
            */
            var context = new CircuitContext();
            Diagram diagram = new Diagram(context);
            diagram._context.Database.CreateIfNotExists();
            return diagram;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
