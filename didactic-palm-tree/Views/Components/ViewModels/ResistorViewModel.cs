using didactic_palm_tree.Views.Components.Abstract;
using DiagramDesigner;

namespace didactic_palm_tree.Views.Components.ViewModels
{
    class ResistorViewModel : ComponentViewModel
    {
        public ResistorViewModel(DiagramViewModel parent, double left, double top) : base(parent, left, top)
        {
            Model = new UIModel.Resistor(1);
        }

        public ResistorViewModel()
        {
            Model = new UIModel.Resistor(1);
        }

        public override void ExecuteShowDataChangeWindowCommand(object paramter)
        {

        }
    }
}
