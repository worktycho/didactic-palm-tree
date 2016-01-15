using didactic_palm_tree.Properties;
using didactic_palm_tree.Views.Components.Abstract;
using didactic_palm_tree.Views.Components.Data;
using DiagramDesigner;

namespace didactic_palm_tree.Views.Components.ViewModels
{
    class BulbViewModel : ComponentViewModel
    {
        public bool IsOn { get; set; }
        public float Voltage { get; set; }

        public BulbViewModel(DiagramViewModel parent, double left, double top) : base(parent, left, top)
        {
            IsOn = false;
            Voltage = 0;
            Model = new UIModel.Bulb();
        }

        public BulbViewModel()
        {
            Model = new UIModel.Bulb();
        }

        public override void ExecuteShowDataChangeWindowCommand(object paramter)
        {
            var data = new BulbData(Voltage);
            Model.Simulate();
            data.Voltage = Model.GetVoltageDrop();
            Voltage++;
            IsOn = (Voltage > 0);
            NotifyChanged("IsOn");
        }
    }
}
