using System;
using TandNTestMachine.Core.Mvvm;

namespace TandNTestMachine.Modules.Report.ViewModels
{
    public class MainReportViewModel : ViewModelBase
    {
        private string _message;

        public MainReportViewModel()
        {
            Message = "Report View from your Prism Module";
        }

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }
        
    }
}