using System;
using System.Windows.Input;

namespace TandNTestMachine.Modules.Report.ViewModels
{
    public interface IReportViewModel
    {
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }

        public ICommand LoadReportCommand { get; }
    }
}
