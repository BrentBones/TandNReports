using System;

namespace TandNTestMachine.Modules.Report.Model
{
    public class TestOperationReportModel
    {
        public Guid Id { get; set; }
        public string OpCodeName { get; set; }
        public int OpCode { get; set; }
        public int OperationIndex { get; set; }
        public bool Completed { get; set; } = false;
        public string Param1 { get; set; }
        public string Param2 { get; set; }
        public string Param1Name { get; set; }
        public string Param2Name { get; set; }
        public string Data1 { get; set; }
        public string Data2 { get; set; }
        public string Data1Name { get; set; }
        public string Data2Name { get; set; }
    }
}