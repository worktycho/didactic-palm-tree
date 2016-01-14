using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using didactic_palm_tree.UIModel;
using didactic_palm_tree.Views.Components.Abstract;
using DiagramDesigner;

namespace didactic_palm_tree.Views
{
    public class WindowViewModel : INPCBase
    {
        public Diagram model;

        public WindowViewModel()
        {
            IsBusy = false;
            ToolBoxViewModel = new ToolBoxViewModel();
            DiagramViewModel = new DiagramViewModel();

            DiagramViewModel.CreateNewDiagramCommand.Execute(null);

            DiagramViewModel.Items.CollectionChanged += ItemsOnCollectionChanged;

            ConnectorViewModel.PathFinder = new OrthogonalPathFinder();

            ExecuteLoadDiagramCommand(null);

            DeleteSelectedItemsCommand = new SimpleCommand(ExecuteDeleteSelectedItemsCommand);
            CreateNewDiagramCommand = new SimpleCommand(ExecuteCreateNewDiagramCommand);
            SaveDiagramCommand = new SimpleCommand(ExecuteSaveDiagramCommand);
            LoadDiagramCommand = new SimpleCommand(ExecuteLoadDiagramCommand);
        }

        // VIEWMODELS
        public ToolBoxViewModel ToolBoxViewModel { get; set; }
        public DiagramViewModel DiagramViewModel { get; set; }

        // COMMANDS
        public SimpleCommand DeleteSelectedItemsCommand { get; private set; }
        public SimpleCommand CreateNewDiagramCommand { get; private set; }
        public SimpleCommand SaveDiagramCommand { get; private set; }
        public SimpleCommand LoadDiagramCommand { get; private set; }

        // UTILITIES
        public bool IsBusy { get; set; }
        public int? CurrentDiagramId { get; set; }
        public List<int> SavedDiagrams { get; set; }
        public List<SelectableDesignerItemViewModelBase> itemsToRemove; 

        private void ItemsOnCollectionChanged(object sender,
            NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            if (notifyCollectionChangedEventArgs.NewItems != null)
            {
                foreach (var item in notifyCollectionChangedEventArgs.NewItems)
                {
                    if (item is ConnectorViewModel)
                    {
                        //TODO
                    }
                    else
                    {
                        var viewModel = (ComponentViewModel)item;
                        viewModel.Model = model.Add(viewModel.Model);
                    }
                }
            }
        }

        // COMMAND FUNCTIONS
        private void ExecuteDeleteSelectedItemsCommand(object parameter)
        {
            /*
            1. Get components needing removal
            2. Get connectors for each component needing removal
            3. Combine the two sets
            4. Use DiagramViewModel.RemoveitemCommand.Execute(items) to remove them         
            */
            itemsToRemove = DiagramViewModel.SelectedItems;
            List<SelectableDesignerItemViewModelBase> connectionsToRemove = new List<SelectableDesignerItemViewModelBase>();
            foreach (var connector in DiagramViewModel.Items.OfType<ConnectorViewModel>())
            {
                if (ItemsToDeleteHasConnector(itemsToRemove, connector.SourceConnectorInfo))
                {
                    connectionsToRemove.Add(connector);
                }

                if (ItemsToDeleteHasConnector(itemsToRemove, (FullyCreatedConnectorInfo)connector.SinkConnectorInfo))
                {
                    connectionsToRemove.Add(connector);
                }
            }
            itemsToRemove.AddRange(connectionsToRemove);
            foreach (var selectedItem in itemsToRemove)
            {
                DiagramViewModel.RemoveItemCommand.Execute(selectedItem);
                if (selectedItem is ConnectorViewModel)
                {

                }
                else
                {
                    ComponentViewModel componentViewModel = (ComponentViewModel) selectedItem;
                    model.Remove(componentViewModel.Model);
                }
            }
        }

        private void ExecuteCreateNewDiagramCommand(object parameter)
        {
            /*
            1. Create empty set of components to remove
            2. Create empty diagram ID
            3. Use DiagramViewModel.CreateNewDiagram.Execute(null) to create it
            */
            

        }

        private void ExecuteSaveDiagramCommand(object parameter)
        {
            /*
            1. Check whether diagram actually has components to remove
            2. Set to BUSY
            3. Start a new task:
             3a. Save diagram ID
             3b. Clear components for removal from database
             3c. For each type of ComponentViewModel, save it
             3d. Save all connections
            4. Set to NOT BUSY
            */

            model.Save();
        }

        private void ExecuteLoadDiagramCommand(object parameter)
        {
            /*
            1. Set to BUSY
            2. Check whether diagram ID actually available
            3. Start a new task:
             3a. Load the diagram ID back
             3b. For each piece of data, check against possible ViewModels to load
             3c. Load the connections
            4. Set to NOT BUSY
            */

            DiagramViewModel.Items.Clear();
            model = Diagram.Load("test.sql");
            foreach (var component in model.Components)
            {
                var viewmodel = component.CreateViewModel(DiagramViewModel);
                DiagramViewModel.Items.Add(viewmodel);
            }
        }

        // MISCELLANEOUS
        private bool ItemsToDeleteHasConnector(List<SelectableDesignerItemViewModelBase> itemsToRemove, FullyCreatedConnectorInfo connector)
        {
            return itemsToRemove.Contains(connector.DataItem);
        }
    }
}