using System;
using System.Windows.Input;
using TandNTestMachine.Core.Mvvm;
using TandNTestMachine.Modules.Report.ViewModels;

namespace TandNTestMachine.Modules.Report.Model
{
    public class ReportViewModelBase : ViewModelBase, IReportViewModel
    {
        private DateTime _endDate;

        private DateTime _startDate;

        public ReportViewModelBase()
        {
            EndDate = DateTime.Now.AddDays(1);
            StartDate = DateTime.Now.AddDays(-30);
        }

        public ICommand LoadReportCommand { get; set; }

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
    }
}