using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace didactic_palm_tree.UIModel
{
    [Table("Component")]
    public abstract class Component
    {
        [Key]
        public Guid Id { get; set; }

        public abstract Point GetPosition();

        public Component()
        {
            Id = Guid.NewGuid();
        }
    }
}
