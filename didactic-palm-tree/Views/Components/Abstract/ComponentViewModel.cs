using System.ComponentModel;
using System.Windows.Input;
using didactic_palm_tree.Views.Util;
using DiagramDesigner;
using Component = didactic_palm_tree.UIModel.Component;

namespace didactic_palm_tree.Views.Components.Abstract
{
    public abstract class ComponentViewModel : DesignerItemViewModelBase
    {
        private Component _model;
        private IUIVisualizerService visualizerService;

        public ComponentViewModel()
        {
            Init();
        }

        public ComponentViewModel(DiagramViewModel parent, double left, double top)
        {
            Parent = parent;
            Left = left;
            Top = top;
            Init();
        }

        public ComponentViewModel(int id, DiagramViewModel parent, double left, double top)
        {
            Id = id;
            Parent = parent;
            Left = left;
            Top = top;
            Init();
        }

        public Component Model
        {
            get { return _model; }
            set
            {
                _model = value;
                if (_model != null)
                    PropertyChanged += _model.OnPropertyChanged;
            }
        }

        public ICommand ShowDataChangeWindowCommand { get; private set; }

        private void Init()
        {
            visualizerService = ApplicationServicesProvider.Instance.Provider.VisualizerService;
            ShowDataChangeWindowCommand = new SimpleCommand(ExecuteShowDataChangeWindowCommand);
            ShowConnectors = false;
        }

        public abstract void ExecuteShowDataChangeWindowCommand(object paramter);

        protected bool OnConfirmation(ComponentData data)
        {
            return visualizerService.ShowDialog(data) == true;
        }
    }
}