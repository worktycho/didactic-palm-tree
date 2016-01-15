using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows;
using didactic_palm_tree.Views.Components.Abstract;
using didactic_palm_tree.Views.Components.ViewModels;
using DiagramDesigner;

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

        public override ComponentViewModel CreateViewModel(Diagram diagram, DiagramViewModel parent)
        {
            return new ResistorViewModel(parent, Left, Top) {Model = this};
        }

        public override void EnsureSimComponentExists(Diagram diagram)
        {
            
        }
    }
}
