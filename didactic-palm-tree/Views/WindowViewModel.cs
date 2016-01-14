using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Threading.Tasks;
using didactic_palm_tree.Views;
using DiagramDesigner;

namespace didactic_palm_tree.Views
{
    public class WindowViewModel : INPCBase
    {
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

        public WindowViewModel()
        {
            IsBusy = false;
            ToolBoxViewModel = new ToolBoxViewModel();
            DiagramViewModel = new DiagramViewModel();

            DiagramViewModel.CreateNewDiagramCommand.Execute(null);

            ConnectorViewModel.PathFinder = new OrthogonalPathFinder();
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
        }

        // MISCELLANEOUS



    }
}
