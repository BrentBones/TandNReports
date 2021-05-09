using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TandNTestMachine.Data.Entity
{
    public class TestProcedureOperation
    {
        public Guid Id { get; set; }
        public string OpCodeName { get; set; }
        public int OpCode { get; set; }
        public bool Completed { get; set; } = false;
        public int OperationIndex { get; set; }
        public string Param1 { get; set; }
        public string Param2 { get; set; }
        public string Param3 { get; set; }
        public string Param4 { get; set; }
        public string Param5 { get; set; }
        public string Param1Name { get; set; }
        public string Param2Name { get; set; }
        public string Param3Name { get; set; }
        public string Param4Name { get; set; }
        public string Param5Name { get; set; }

        public string Data1 { get; set; }
        public string Data2 { get; set; }
        public string Data3 { get; set; }
        public string Data4 { get; set; }
        public string Data5 { get; set; }
        public string Data1Name { get; set; }
        public string Data2Name { get; set; }
        public string Data3Name { get; set; }
        public string Data4Name { get; set; }
        public string Data5Name { get; set; }
        public Guid TestProcedureId { get; set; }
        public TestProcedure TestProcedure { get; set; }

        public TestProcedureOperation()
        {
            Id = Guid.NewGuid();
        }
    }
}
