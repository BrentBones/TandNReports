using System;

namespace TandNTestMachine.Modules.Report.Model
{
    public class IfdReportModel
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ItemName { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public int CycleNumber { get; set; }
        public int Increment { get; set; }
        public string DepthPercent1 { get; set; }
        public string PlateHeight1 { get; set; }
        public string Force1 { get; set; }
        public string DepthPercent2 { get; set; }
        public string PlateHeight2 { get; set; }
        public string Force2 { get; set; }
        public string Ifd { get; set; }
        public string IfdAverage { get; set; }
    }
}