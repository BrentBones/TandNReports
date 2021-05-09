using System;

namespace TandNTestMachine.Data.Models
{
    public class OperationModel
    {
        public Guid Id { get; set; }
        public Guid OperationRecipeId { get; set; }
        public int OperationIndex { get; set; }
        public string OpCodeName { get; set; }
        public int OpCode { get; set; }
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
        public string Data1Name { get; set; }
        public string Data2Name { get; set; }
        public string Data3Name { get; set; }
        public string Data4Name { get; set; }
        public string Data5Name { get; set; }
    }
}