using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Infragistics.Windows.DataPresenter;
using Prism.Commands;
using TandNTestMachine.Core.Constants;
using TandNTestMachine.Core.Mvvm;
using TandNTestMachine.Modules.Report.Model;
using TandNTestMachine.Modules.Report.Services;

namespace TandNTestMachine.Modules.Report.ViewModels
{
    public class StandardReportViewModel : ReportViewModelBase, IReportViewModel
    {
        private readonly IApplicationCommands _applicationCommands;
        private readonly IReportService _reportService;
        private List<TestProcedureReportModel> _items;

        private string _reportId;

        public StandardReportViewModel(IApplicationCommands applicationCommands,
            IReportService reportService)
        {
            _applicationCommands = applicationCommands;
            _reportService = reportService;
            StartDate = DateTime.Now.AddDays(-1);
            EndDate = DateTime.Now;
            LoadReportCommand = new DelegateCommand(OnLoadReportCommand);
        }

        public ICommand GraphSensorLogCommand { get; private set; }

        public List<TestProcedureReportModel> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }


        private void OnLoadReportCommand()
        {
            Items = _reportService.GetStandReports(StartDate, EndDate);
        }

        public void GraphSensorsLog(object sender, RoutedEventArgs e)
        {
            var dataRecord = (DataRecord) ((Button) sender).DataContext;
            if (dataRecord.DataItem is TestProcedureReportModel dataItem)
                _applicationCommands.NavigateCommand.Execute($"{ViewNames.SensorGraph}?id={dataItem.Id}");
        }
    }
}