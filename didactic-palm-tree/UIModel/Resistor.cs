using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace didactic_palm_tree.UIModel
{
    [Table("Resistor")]
    public class Resistor
    {
        public Resistor(int Resistance)
        {
            this.Resistance = Resistance;
        }

        public int Resistance
        {
            get; private set;
        }
    }
}
