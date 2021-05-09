using Prism.Regions;
using TandNTestMachine.Core.Constants;
using TandNTestMachine.Core.Mvvm;
using TandNTestMachine.Core.Navigation;
using TandNTestMachine.Modules.Report.Constants;

namespace TandNTestMachine.Modules.Report.ViewModels
{
    public class ReportNavGroupViewModel : NavigationGroupViewModelBase
    {
        public ReportNavGroupViewModel(IApplicationCommands applicationCommands)
            : base(applicationCommands)
        {
            GenerateMenu();
        }

        private void GenerateMenu()
        {
            var root = new NavigationItem
                {Caption = "Reports", NavigationPath = ViewNames.MainReportView, CanNavigate = false};
            root.Items.Add(new NavigationItem
                {Caption = "Standard Report", NavigationPath = ReportViewNames.StandardReport, CanNavigate = true});
            root.Items.Add(new NavigationItem
                {Caption = "IFD Report", NavigationPath = ReportViewNames.IFDReport, CanNavigate = true});
            //root.Items.Add(new NavigationItem() { Caption = "Airflow Report", NavigationPath = ReportViewNames.AirFlowReport, CanNavigate = true });
            Items.Add(root);
        }

        private string CreateNavigationPath(string folder)
        {
            var parameters = new NavigationParameters();
            parameters.Add(ReportNavigationParameters.FolderKey, folder);
            return "MessageListView" + parameters;
        }
    }
}