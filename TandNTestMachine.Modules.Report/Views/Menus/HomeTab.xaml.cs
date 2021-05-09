using Infragistics.Windows.Ribbon;
using TandNTestMachine.Core.Interface;

namespace TandNTestMachine.Modules.Report.Views.Menus
{
    /// <summary>
    ///     Interaction logic for HomeTab.xaml
    /// </summary>
    public partial class HomeTab : ISupportDataContext
    {
        public HomeTab()
        {
            InitializeComponent();
            SetResourceReference(StyleProperty, typeof(RibbonTabItem));
        }
    }
}