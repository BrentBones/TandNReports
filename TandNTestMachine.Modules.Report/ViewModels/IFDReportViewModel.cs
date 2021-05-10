using System.Collections.Generic;
using Prism.Commands;
using TandNTestMachine.Core.Mvvm;
using TandNTestMachine.Modules.Report.Model;
using TandNTestMachine.Modules.Report.Services;

namespace TandNTestMachine.Modules.Report.ViewModels
{
    public class IFDReportViewModel : ReportViewModelBase
    {
        private readonly IApplicationCommands _applicationCommands;
        private readonly IReportService _reportService;
        private List<IfdReportModel> _items;

        public IFDReportViewModel(IApplicationCommands applicationCommands,
            IReportService reportService)
        {
            _applicationCommands = applicationCommands;
            _reportService = reportService;

            LoadReportCommand = new DelegateCommand(OnLoadReportCommand);
        }

        public List<IfdReportModel> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }


        private void OnLoadReportCommand()
        {
            Items = _reportService.GetIfdReports(StartDate, EndDate);
        }
    }
}