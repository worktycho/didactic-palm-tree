using System.Windows;
using didactic_palm_tree.Views.Components.Abstract;
using didactic_palm_tree.Views.Components.ViewModels;
using DiagramDesigner;

namespace didactic_palm_tree.UIModel
{
    internal class Switch : Component
    {
        public override ComponentViewModel CreateViewModel(Diagram diagram, DiagramViewModel parent)
        {
            return new SwitchViewModel(parent, Left, Top) {Model = this};
        }

        public override void EnsureSimComponentExists(Diagram diagram)
        {
           
        }
    }
}