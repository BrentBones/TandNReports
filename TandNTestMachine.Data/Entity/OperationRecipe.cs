using System;

namespace TandNTestMachine.Data.Entity
{
    public class OperationRecipe
    {
        public Guid OperationRecipeId { get; set; }
        public Guid OperationId { get; set; }
        public Guid RecipeId { get; set; }
        public int OperationIndex { get; set; }
        public string Param1 { get; set; } = "0";
        public string Param2 { get; set; } = "0";
        public string Param3 { get; set; } = "0";
        public string Param4 { get; set; } = "0";
        public string Param5 { get; set; } = "0";
    }
}