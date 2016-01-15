using didactic_palm_tree.Views.Components.Abstract;
using didactic_palm_tree.Views.Components.Data;
using DiagramDesigner;

namespace didactic_palm_tree.Views.Components.ViewModels
{
    class BatteryViewModel : ComponentViewModel
    {
        private UIModel.Battery _component;

        public float Voltage { get; set; }

        public BatteryViewModel(DiagramViewModel parent, double left, double top) : base(parent, left, top)
        {
            _component = new UIModel.Battery
            {
                Left = left,
                Top = top
            };
            this.Model = _component;
        }

        public BatteryViewModel()
        {
            _component = new UIModel.Battery();
            this.Model = _component;
        }

        public override void ExecuteShowDataChangeWindowCommand(object parameter)
        {
            var data = new BatteryData(Voltage);
            if (OnConfirmation(data))
            {
                this.Voltage = data.Voltage;
            }
        }
    }
}
