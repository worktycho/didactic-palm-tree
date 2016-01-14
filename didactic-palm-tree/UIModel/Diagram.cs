using System;
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

        public void Add(Component component)
        {
            _context.Components.Add(component);
        }

        public void Remove(Component component)
        {
            _context.Components.Remove(component);
        }

        public Component GetComponent(Point location)
        {
            
            return _context.Components.FirstOrDefault(comp => comp.GetPosition() == location);
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
