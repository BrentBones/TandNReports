using System.Windows.Controls;
using TandNTestMachine.Core.Attributes;
using TandNTestMachine.Core.Constants;
using TandNTestMachine.Core.Interface;
using TandNTestMachine.Modules.Report.Views.Menus;

namespace TandNTestMachine.Modules.Report.Views
{
    /// <summary>
    ///     Interaction logic for IFDReport
    /// </summary>
    [DependentView(RegionNames.RibbonRegion, typeof(HomeTab))]
    public partial class IFDReport : UserControl, ISupportDataContext
    {
        public IFDReport()
        {
            InitializeComponent();
        }
    }
}