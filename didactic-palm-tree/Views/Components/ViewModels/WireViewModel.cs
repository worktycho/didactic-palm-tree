using didactic_palm_tree.Views.Components.Abstract;
using DiagramDesigner;

namespace didactic_palm_tree.Views.Components.ViewModels
{
    class WireViewModel : ComponentViewModel
    {
        public WireViewModel(DiagramViewModel parent, double left, double top) : base(parent, left, top)
        {
            Model = new UIModel.Wire();
        }

        public WireViewModel()
        {
            Model = new UIModel.Wire();
        }

        public override void ExecuteShowDataChangeWindowCommand(object paramter)
        {

        }
    }
}
