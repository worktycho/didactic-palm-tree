using didactic_palm_tree.Views.Components.Abstract;
using DiagramDesigner;

namespace didactic_palm_tree.Views.Components.ViewModels
{
    class VoltmeterViewModel : ComponentViewModel
    {
        public VoltmeterViewModel(DiagramViewModel parent, double left, double top) : base(parent, left, top)
        {
            Model = new UIModel.Voltmeter();
        }

        public VoltmeterViewModel()
        {
            Model = new UIModel.Voltmeter();
        }

        public override void ExecuteShowDataChangeWindowCommand(object paramter)
        {

        }
    }
}
