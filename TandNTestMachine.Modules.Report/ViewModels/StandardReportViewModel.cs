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
    public class StandardReportViewModel : ViewModelBase, IReportViewModel
    {
        private readonly IApplicationCommands _applicationCommands;
        private DateTime _endDate;
        private List<TestProcedureReportModel> _items;

        private string _reportId;
        private readonly IReportService _reportService;
        private DateTime _startDate;

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

        public ICommand LoadReportCommand { get; }

        public DateTime StartDate
        {
            get => _startDate;
            set => SetProperty(ref _startDate, value);
        }

        public DateTime EndDate
        {
            get => _endDate;
            set => SetProperty(ref _endDate, value);
        }

        private void OnLoadReportCommand()
        {
            Items = _reportService.GetStandReports(_startDate, _endDate);
        }

        public void GraphSensorsLog(object sender, RoutedEventArgs e)
        {
            var dataRecord = (DataRecord) ((Button) sender).DataContext;
            if (dataRecord.DataItem is TestProcedureReportModel dataItem)
                _applicationCommands.NavigateCommand.Execute($"{ViewNames.SensorGraph}?id={dataItem.Id}");
        }
    }
}