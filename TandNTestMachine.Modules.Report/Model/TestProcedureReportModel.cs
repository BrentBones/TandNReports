using System;
using System.Collections.Generic;

namespace TandNTestMachine.Modules.Report.Model
{
    public class TestProcedureReportModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ItemName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public bool RunToCompletion { get; set; }

        public List<TestOperationReportModel> TestProcedureOperations { get; set; }
    }
}