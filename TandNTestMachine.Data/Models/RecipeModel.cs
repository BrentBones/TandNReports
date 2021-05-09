using System;

namespace TandNTestMachine.Data.Models
{
    public class RecipeModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        //public ICollection<OperationModel> Operations { get; private set; } = new ObservableCollection<OperationModel>();
    }
}