using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TandNTestMachine.Data.Entity;

namespace TandNTestMachine.Data.Events
{
    public class OperationChangeEventPayload
    {
        public TestProcedure Procedure { get; set; }
        public int OperationIndex { get; set; }
    }
}
