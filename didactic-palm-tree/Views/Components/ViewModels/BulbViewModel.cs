using didactic_palm_tree.Views.Components.Abstract;
using DiagramDesigner;

namespace didactic_palm_tree.Views.Components.ViewModels
{
    class BulbViewModel : ComponentViewModel
    {
        public BulbViewModel(DiagramViewModel parent, double left, double top) : base(parent, left, top)
        {
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
