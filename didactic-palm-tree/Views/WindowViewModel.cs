using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Data;
using System.Threading.Tasks;
using didactic_palm_tree.Abstract;
using didactic_palm_tree.UIModel;
using didactic_palm_tree.Views;
using DiagramDesigner;

namespace didactic_palm_tree.Views
{
    public class WindowViewModel : INPCBase
    {
        public UIModel.Diagram model;
        public ToolBoxViewModel ToolBoxViewModel { get; set; }
        public DiagramViewModel DiagramViewModel { get; set; }

        public WindowViewModel()
        {
            ToolBoxViewModel = new ToolBoxViewModel();
            DiagramViewModel = new DiagramViewModel();

            DiagramViewModel.CreateNewDiagramCommand.Execute(null);

            DiagramViewModel.Items.CollectionChanged += ItemsOnCollectionChanged;
        }

        private void ItemsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            foreach (var item in notifyCollectionChangedEventArgs.NewItems)
            {
                var ViewModel = (ComponentViewModel) item;
                model.Add(ViewModel.Model);
            }
        }
    }
}
