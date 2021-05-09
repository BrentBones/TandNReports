using System;
using System.Collections.Generic;

namespace TandNTestMachine.Data.Models
{
    public class RecipeWithOperationsModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<OperationModel> Operations { get; set; } = new List<OperationModel>();
    }
}