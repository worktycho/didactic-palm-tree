using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows;
using didactic_palm_tree.Views.Components.Abstract;

namespace didactic_palm_tree.UIModel
{
    [Table("Resistor")]
    public class Resistor : Component
    {
        public Resistor(int resistance)
        {
            this.Resistance = resistance;
        }

        public Resistor()
        {
        }

        public int Resistance
        {
            get; private set;
        }

        public override Point GetPosition()
        {
            return new Point(0, 0);
        }

        public override ComponentViewModel CreateViewModel()
        {
            throw new NotImplementedException();
        }
    }
}
