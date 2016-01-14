using System.Windows;
using didactic_palm_tree.Views.Components.Abstract;
using didactic_palm_tree.Views.Components.ViewModels;

namespace didactic_palm_tree.UIModel
{
    internal class Switch : Component
    {
        public override Point GetPosition()
        {
            throw new System.NotImplementedException();
        }

        public override ComponentViewModel CreateViewModel()
        {
            return new SwitchViewModel();
        }
    }
}