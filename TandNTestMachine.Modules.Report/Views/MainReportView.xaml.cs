using System.Windows.Controls;
using TandNTestMachine.Core.Attributes;
using TandNTestMachine.Core.Constants;
using TandNTestMachine.Core.Interface;
using TandNTestMachine.Modules.Report.Views.Menus;

namespace TandNTestMachine.Modules.Report.Views
{
    /// <summary>
    ///     Interaction logic for ViewA.xaml
    /// </summary>
    [DependentView(RegionNames.RibbonRegion, typeof(HomeTab))]
    public partial class MainReportView : UserControl, ISupportDataContext
    {
        public MainReportView()
        {
            InitializeComponent();
        }
    }
}