using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using didactic_palm_tree.UIModel;
using DiagramDesigner;

namespace didactic_palm_tree.Abstract
{
    abstract class ComponentViewModel : DesignerItemViewModelBase
    {
        //private IUIVisualizerService visualizerService;

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

        public ComponentViewModel(int id, DiagramViewModel parent, double left, double top, string setting)
        {
            this.Id = id;
            this.Parent = parent;
            this.Left = left;
            this.Top = top;
            this.Setting = setting;
            Init();
        }

        public String Setting { get; set; }
        public UIModel.Component Model { get; set; }

        //public ICommand ShowDataChangeWindowCommand { get; private set; }
        private void Init()
        {
            //visualizerService = ApplicationServicesProvider.Instance.Provider.VisualizerService;
            //ShowDataChangeWindowCommand = new SimpleCommand(ExecuteShowDataChangeWindowCommand);
            this.ShowConnectors = false;
        }

        protected bool OnConfirmation(ComponentData data)
        {
            return true;
            //return (visualizerService.ShowDialog(data) == true);
        } 
    }
}
