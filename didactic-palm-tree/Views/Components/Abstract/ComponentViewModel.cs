using System;
using System.Windows.Input;
using didactic_palm_tree.Views.Util;
using DiagramDesigner;

namespace didactic_palm_tree.Views.Components.Abstract
{
    abstract class ComponentViewModel : DesignerItemViewModelBase
    {
        private IUIVisualizerService visualizerService;

        public ComponentViewModel()
        {
            Init();
        }

        public ComponentViewModel(DiagramViewModel parent, double left, double top)
        {
            this.Parent = parent;
            this.Left = left;
            this.Top = top;
            Init();
        }

        public ComponentViewModel(int id, DiagramViewModel parent, double left, double top)
        {
            this.Id = id;
            this.Parent = parent;
            this.Left = left;
            this.Top = top;
            Init();
        }

        public ICommand ShowDataChangeWindowCommand { get; private set; }

        private void Init()
        {
            visualizerService = ApplicationServicesProvider.Instance.Provider.VisualizerService;
            ShowDataChangeWindowCommand = new SimpleCommand(ExecuteShowDataChangeWindowCommand);
            this.ShowConnectors = false;
        }

        public abstract void ExecuteShowDataChangeWindowCommand(object paramter);

        protected bool OnConfirmation(ComponentData data)
        {
            return (visualizerService.ShowDialog(data) == true);
        } 
    }
}
