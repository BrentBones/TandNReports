using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using TandNTestMachine.Core.Constants;
using TandNTestMachine.Modules.Report.Services;
using TandNTestMachine.Modules.Report.ViewModels;
using TandNTestMachine.Modules.Report.Views;
using TandNTestMachine.Modules.Report.Views.Menus;

namespace TandNTestMachine.Modules.Report
{
    public class ReportModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ReportModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.OutlookBarRegion, typeof(ReportNavGroup));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register<ReportNavGroup, ReportNavGroupViewModel>();
            containerRegistry.RegisterForNavigation<MainReportView, MainReportViewModel>();
            containerRegistry.RegisterForNavigation<StandardReport, StandardReportViewModel>();
            containerRegistry.RegisterForNavigation<IFDReport, IFDReportViewModel>();
            containerRegistry.RegisterForNavigation<SensorGraph, SensorGraphViewModel>();
            containerRegistry.RegisterSingleton<IReportService, ReportService>();
        }
    }
}