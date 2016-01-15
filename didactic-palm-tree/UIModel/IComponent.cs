using System;
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

        public Component()
        {
            Id = Guid.NewGuid();
        }

        public abstract ComponentViewModel CreateViewModel(DiagramViewModel parent);

        public void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var viewmodel = (ComponentViewModel) sender;
            Left = viewmodel.Left;
            Top = viewmodel.Top;
        }
    }
}
