using didactic_palm_tree.Views.Components.Abstract;
using DiagramDesigner;

namespace didactic_palm_tree.Views.Components.ViewModels
{
    public class AmmeterViewModel : ComponentViewModel
    {
        public AmmeterViewModel(DiagramViewModel parent, double left, double top) : base(parent, left, top)
        {
           Model = new UIModel.Ammeter();
        }

        public AmmeterViewModel()
        {
            Model = new UIModel.Ammeter();
        }

        public override void ExecuteShowDataChangeWindowCommand(object paramter)
        {
            
        }
    }
}
