using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using didactic_palm_tree.UIModel;
using didactic_palm_tree.Views.Components.Abstract;
using DiagramDesigner;

namespace didactic_palm_tree.Views
{
    public class WindowViewModel : INPCBase
    {
        private readonly Dictionary<Guid, ComponentViewModel> ComponentViewModels =
            new Dictionary<Guid, ComponentViewModel>();

        public Dictionary<ConnectorViewModel, Wire> ConnectorModels = new Dictionary<ConnectorViewModel, Wire>();
        public List<SelectableDesignerItemViewModelBase> ItemsToRemove;
        private CircuitContext _context;
        public Diagram CurrentDiagram { get; set; }

        public WindowViewModel()
        {
            IsBusy = false;
            ToolBoxViewModel = new ToolBoxViewModel();
            DiagramViewModel = new DiagramViewModel();

            _context = new CircuitContext();
            SavedDiagrams = _context.Diagrams.ToList();
            CurrentDiagram = null;

            DiagramViewModel.Items.CollectionChanged += ItemsOnCollectionChanged;

            ConnectorViewModel.PathFinder = new OrthogonalPathFinder();

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
        public List<Diagram> SavedDiagrams { get; set; }

        private void ItemsOnCollectionChanged(object sender,
            NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            HandleNewItems(notifyCollectionChangedEventArgs);
            HandleOldItems(notifyCollectionChangedEventArgs);
        }

        private void HandleOldItems(NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            if (notifyCollectionChangedEventArgs.OldItems == null) return;
            foreach (var item in notifyCollectionChangedEventArgs.OldItems)
            {
                var connector = item as ConnectorViewModel;
                if (connector == null) continue;
                if (ConnectorModels.ContainsKey(connector))
                {
                    CurrentDiagram.Remove(ConnectorModels[connector]);
                    ConnectorModels.Remove(connector);
                }
            }
        }

        private void HandleNewItems(NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            if (CurrentDiagram == null) return;
            if (notifyCollectionChangedEventArgs.NewItems == null) return;
            foreach (var item in notifyCollectionChangedEventArgs.NewItems)
            {
                if (!(item is ConnectorViewModel))
                {
                    var viewModel = (ComponentViewModel) item;
                    if (viewModel.Model == null) viewModel.Model = new Voltmeter(CurrentDiagram);
                    viewModel.Model = CurrentDiagram.Add(viewModel.Model);
                }
                else
                {
                    var connector = (ConnectorViewModel) item;
                    if (ConnectorModels.ContainsKey(connector)) continue;
                    ConnectorModels.Add(connector, new Wire()
                    {
                        Source = ((ComponentViewModel) connector.SourceConnectorInfo.DataItem).Model,
                        SourceOrientation = connector.SourceConnectorInfo.Orientation,
                        Diagram = CurrentDiagram
                    });
                    var sinkConnector = connector.SinkConnectorInfo as FullyCreatedConnectorInfo;
                    if (sinkConnector != null)
                    {
                        ConnectorModels[connector].Sink = ((ComponentViewModel) sinkConnector.DataItem).Model;
                        ConnectorModels[connector].SinkOrientation = sinkConnector.Orientation;
                    }
                    CurrentDiagram.Add(ConnectorModels[connector]);
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
            ItemsToRemove = DiagramViewModel.SelectedItems;
            var connectionsToRemove = new List<SelectableDesignerItemViewModelBase>();
            foreach (var connector in DiagramViewModel.Items.OfType<ConnectorViewModel>())
            {
                if (ItemsToDeleteHasConnector(ItemsToRemove, connector.SourceConnectorInfo))
                {
                    connectionsToRemove.Add(connector);
                }

                var sinkConnector = connector.SinkConnectorInfo as FullyCreatedConnectorInfo;
                if (sinkConnector != null && ItemsToDeleteHasConnector(ItemsToRemove, sinkConnector))
                {
                    connectionsToRemove.Add(connector);
                }
            }
            ItemsToRemove.AddRange(connectionsToRemove);
            foreach (var selectedItem in ItemsToRemove)
            {
                DiagramViewModel.RemoveItemCommand.Execute(selectedItem);
                if (selectedItem is ConnectorViewModel)
                {
                }
                else
                {
                    var componentViewModel = (ComponentViewModel) selectedItem;
                    CurrentDiagram.Remove(componentViewModel.Model);
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
            ItemsToRemove = new List<SelectableDesignerItemViewModelBase>();
            CurrentDiagram = null;
            DiagramViewModel.CreateNewDiagramCommand.Execute(null);
            var dialog = new NewDiagram();
            dialog.ShowDialog();
            var result = dialog.DialogResult;
            if (!result.HasValue || !result.Value)
            {
                return;
            }
            var name = dialog.DialogName;
            CurrentDiagram = Diagram.CreateNew(_context, name);
            SelectedDiagram = CurrentDiagram;
            SavedDiagrams = _context.Diagrams.ToList();
            this.NotifyChanged("SavedDiagrams");
            LoadDiagramItems();
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

            CurrentDiagram.Save();
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

            CurrentDiagram = this.SelectedDiagram;
            CurrentDiagram.SetContext(_context);
            LoadDiagramItems();
        }

        public Diagram SelectedDiagram { get; set; }

        private void LoadDiagramItems()
        {
            DiagramViewModel.Items.Clear();
            ComponentViewModels.Clear();
            foreach (var component in CurrentDiagram.Components)
            {
                var viewmodel = component.CreateViewModel(CurrentDiagram, DiagramViewModel);
                ComponentViewModels.Add(component.Id, viewmodel);
                DiagramViewModel.Items.Add(viewmodel);
            }
            ConnectorModels.Clear();
            foreach (var connector in CurrentDiagram.Connectors)
            {
                if (connector.Source == null)
                {
                    CurrentDiagram.Remove(connector);
                    continue;
                }
                ConnectorInfoBase sinkInfo;
                if (connector.Sink != null)
                {
                    sinkInfo = new FullyCreatedConnectorInfo(ComponentViewModels[connector.Sink.Id],
                        connector.SinkOrientation);
                }
                else
                {
                    sinkInfo = new PartCreatedConnectionInfo(new Point(0, 0));
                }
                var viewmodel =
                    new ConnectorViewModel(
                        new FullyCreatedConnectorInfo(ComponentViewModels[connector.Source.Id], connector.SourceOrientation),
                        sinkInfo);
                ConnectorModels.Add(viewmodel, connector);
                DiagramViewModel.AddConnector(viewmodel);
            }
        }

        // MISCELLANEOUS
        private bool ItemsToDeleteHasConnector(List<SelectableDesignerItemViewModelBase> itemsToRemove,
            FullyCreatedConnectorInfo connector)
        {
            return itemsToRemove.Contains(connector.DataItem);
        }
    }
}