using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TandNTestMachine.Data.Entity
{
    public class TestProcedureSensorLog
    {
        public Guid Id { get; set; }
        public Single PlateForce { get; set; }
        public Single PlateHeight { get; set; }
        public Single VacuumPressure { get; set; }
        public Single VacuumFlow { get; set; }
        public Int32 ElapsedTime{ get; set; }
        public Guid TestProcedureId { get; set; }

        public TestProcedure TestProcedure { get; set; }
    }
}
