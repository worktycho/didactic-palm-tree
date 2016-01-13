using didactic_palm_tree.Views.Components.Abstract;
using didactic_palm_tree.Views.Components.Data;
using DiagramDesigner;

namespace didactic_palm_tree.Views.Components.ViewModels
{
    class BatteryViewModel : ComponentViewModel
    {
        public string Setting { get; set; }

        public BatteryViewModel(DiagramViewModel parent, double left, double top) : base(parent, left, top)
        {

        }

        public BatteryViewModel()
        {
            
        }

        public override void ExecuteShowDataChangeWindowCommand(object parameter)
        {
            var data = new BatteryData(Setting);
            if (OnConfirmation(data))
            {
                this.Setting = data.Setting;
            }
        }
    }
}
