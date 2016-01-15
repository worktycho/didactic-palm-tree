using didactic_palm_tree.Properties;
using didactic_palm_tree.Views.Components.Abstract;
using DiagramDesigner;

namespace didactic_palm_tree.Views.Components.ViewModels
{
    class BulbViewModel : ComponentViewModel
    {
        public bool IsOn { get; set; }

        public BulbViewModel(DiagramViewModel parent, double left, double top) : base(parent, left, top)
        {
            IsOn = true;
            Model = new UIModel.Bulb();
        }

        public BulbViewModel()
        {
            Model = new UIModel.Bulb();
        }

        public override void ExecuteShowDataChangeWindowCommand(object paramter)
        {

        }
    }
}
