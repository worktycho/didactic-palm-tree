using didactic_palm_tree.UIModel;
using didactic_palm_tree.Views.Components.Abstract;
using didactic_palm_tree.Views.Components.Data;
using DiagramDesigner;

namespace didactic_palm_tree.Views.Components.ViewModels
{
    class VoltmeterViewModel : ComponentViewModel
    {
        public VoltmeterViewModel(Diagram parentModel, DiagramViewModel parent, double left, double top) : base(parent, left, top)
        {
            Model = new UIModel.Voltmeter(parentModel);
        }

        public VoltmeterViewModel()
        {
            Model = null;
        }

        public override void ExecuteShowDataChangeWindowCommand(object paramter)
        {

            var data = new VoltmeterData();
            Model.Simulate();
            data.Voltage = Model.GetVoltageDrop();
            OnConfirmation(data);
        }
    }
}
