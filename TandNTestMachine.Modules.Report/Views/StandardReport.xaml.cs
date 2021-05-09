using System.Windows;
using System.Windows.Controls;
using TandNTestMachine.Core.Attributes;
using TandNTestMachine.Core.Constants;
using TandNTestMachine.Core.Interface;
using TandNTestMachine.Modules.Report.ViewModels;
using TandNTestMachine.Modules.Report.Views.Menus;

namespace TandNTestMachine.Modules.Report.Views
{
    /// <summary>
    ///     Interaction logic for StandardReport
    /// </summary>
    [DependentView(RegionNames.RibbonRegion, typeof(HomeTab))]
    public partial class StandardReport : UserControl, ISupportDataContext
    {
        public StandardReport()
        {
            InitializeComponent();
        }

        private void OnGraphSensors(object sender, RoutedEventArgs e)
        {
            if (DataContext is StandardReportViewModel dc)
                dc.GraphSensorsLog(sender, e);
        }
    }
}