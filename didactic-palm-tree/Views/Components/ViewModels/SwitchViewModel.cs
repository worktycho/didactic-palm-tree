using didactic_palm_tree.Views.Components.Abstract;
using DiagramDesigner;

namespace didactic_palm_tree.Views.Components.ViewModels
{
    class SwitchViewModel : ComponentViewModel
    {
        public SwitchViewModel(DiagramViewModel parent, double left, double top) : base(parent, left, top)
        {
            Model = new UIModel.Switch();
        }

        public SwitchViewModel()
        {
            Model = new UIModel.Switch();
        }

        public override void ExecuteShowDataChangeWindowCommand(object paramter)
        {

        }
    }
}
