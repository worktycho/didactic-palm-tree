using System;
using System.Data.Entity;
using System.Data.SQLite;
using didactic_palm_tree.UIModel;

namespace didactic_palm_tree
{
    public class CircuitContext : DbContext
    {
        public DbSet<UIModel.Component> Components { get; set; }

        public CircuitContext(SQLiteConnection connection) : base(connection, true)
        {
            
        }

        public CircuitContext() : base()
        {
            
        }
    }
}