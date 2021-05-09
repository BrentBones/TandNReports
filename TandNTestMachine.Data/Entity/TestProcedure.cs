using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TandNTestMachine.Data.Entity;

namespace TandNTestMachine.Data.Entity
{
    public class TestProcedure
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ItemName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public bool RunToCompletion { get; set; }

        public List<TestProcedureOperation> TestProcedureOperations { get; set; } = new List<TestProcedureOperation>();
        public List<TestProcedureSensorLog> TestProcedureSensorLogs { get; set; } = new List<TestProcedureSensorLog>();

        public TestProcedure()
        {
            Id = Guid.NewGuid();
        }

    }
}
