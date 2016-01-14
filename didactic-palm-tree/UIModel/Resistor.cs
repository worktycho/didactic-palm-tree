using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows;

namespace didactic_palm_tree.UIModel
{
    [Table("Resistor")]
    public class Resistor : Component
    {
        public Resistor(int Resistance)
        {
            this.Resistance = Resistance;
        }

        public int Resistance
        {
            get; private set;
        }

        public override Point GetPosition()
        {
            return new Point(0, 0);
        }
    }
}
