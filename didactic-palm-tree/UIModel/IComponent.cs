using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using didactic_palm_tree.Views.Components.Abstract;
using DiagramDesigner;
using System.ComponentModel;
using System.Xml.Serialization;
using didactic_palm_tree.Simulation;
using IComponent = didactic_palm_tree.Simulation.IComponent;

namespace didactic_palm_tree.UIModel
{
    [Table("Component")]
    public abstract class Component
    {
        [Key]
        public Guid Id { get; set; }
        public double Left { get; set; }
        public double Top { get; set; }
        public Diagram Diagram { get; set; }

        public IComponent SimComponent { get; protected set; }

        public Component()
        {
            Id = Guid.NewGuid();
        }

        public abstract ComponentViewModel CreateViewModel(Diagram diagram, DiagramViewModel parent);

        public void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var viewmodel = (ComponentViewModel) sender;
            Left = viewmodel.Left;
            Top = viewmodel.Top;
        }

        public void Simulate()
        {
            this.SimComponent.Simulate();
        }

        public float GetVoltageDrop()
        {
            return (float)this.SimComponent.GetVoltageDrop();
        }

<<<<<<< HEAD
        public float GetCurrent()
        {
            throw new NotImplementedException();
        }
=======
        public abstract void EnsureSimComponentExists(Diagram diagram);
>>>>>>> 970e6871741061df988839b8778d008c14ddcdeb
    }
}
