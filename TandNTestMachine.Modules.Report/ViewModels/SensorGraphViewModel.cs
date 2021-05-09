using System;
using System.Collections.Generic;
using System.Windows.Input;
using Prism.Regions;
using TandNTestMachine.Core.Mvvm;
using TandNTestMachine.Data.Entity;
using TandNTestMachine.Data.Interfaces;

namespace TandNTestMachine.Modules.Report.ViewModels
{
    public class SensorGraphViewModel : ViewModelBase, IReportViewModel
    {
        private readonly IDataProvider _data;
        private Guid _id;
        private List<TestProcedureSensorLog> _items;

        public SensorGraphViewModel(IDataProvider dataProvider)
        {
            _data = dataProvider;
        }

        public string LegendString { get; } = "Legend";

        public List<TestProcedureSensorLog> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICommand LoadReportCommand { get; }

        #region INavigationAware

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            _id = Guid.Parse(navigationContext.Parameters.GetValue<string>("id"));
            if (_id == null)
                ClearGraph();
            else
                LoadGraph(_id);
        }

        private void LoadGraph(Guid id)
        {
            Items = _data.GetTestSensorLogs(_id);
        }

        private void ClearGraph()
        {
            Items = new List<TestProcedureSensorLog>();
        }

        #endregion
    }
}