using System;
using System.Collections.Generic;
using TandNTestMachine.Modules.Report.Model;

namespace TandNTestMachine.Modules.Report.Services
{
    public interface IReportService
    {
        List<TestProcedureReportModel> GetStandReports(DateTime startDate, DateTime endDate);
        List<IfdReportModel> GetIfdReports(DateTime starDate, DateTime endDate);
    }
}