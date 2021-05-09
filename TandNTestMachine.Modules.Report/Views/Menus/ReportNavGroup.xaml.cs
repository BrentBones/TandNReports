using System;
using System.Linq;
using Infragistics.Controls.Menus;
using Infragistics.Windows.OutlookBar;
using TandNTestMachine.Core.Constants;
using TandNTestMachine.Core.Interface;
using TandNTestMachine.Modules.Report.ViewModels;

namespace TandNTestMachine.Modules.Report.Views.Menus
{
    /// <summary>
    /// Interaction logic for ReportNavGroup.xaml
    /// </summary>
    public partial class ReportNavGroup : OutlookBarGroup, IOutlookBarGroup
    {
        INavigationItem _selectedItem;
        public ReportNavGroup(ReportNavGroupViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            _dataTree.Loaded += _xamDataTree_Loaded;
            
        }
        void _xamDataTree_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            _dataTree.Loaded -= _xamDataTree_Loaded;

            var parentNode = _dataTree.Nodes[0];
            var nodeToSelect = parentNode.Nodes[0];
            nodeToSelect.IsSelected = true;
        }

        public string DefaultNavigationPath
        {
            get
            {
                var item = _dataTree.SelectionSettings.SelectedNodes[0] as XamDataTreeNode;

                if (item != null)
                    return ((INavigationItem)item.Data).NavigationPath;
                else
                {
                    return ViewNames.StandardReport;

                }
            }
        }

        private void ActiveNodeChanging(object sender, ActiveNodeChangingEventArgs e)
        {
            _selectedItem = e.NewActiveTreeNode.Data as INavigationItem;
            if (_selectedItem != null && !_selectedItem.CanNavigate)
                e.Cancel = true;
        }
    }
}
