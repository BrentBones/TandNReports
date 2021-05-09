using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TandNTestMachine.Data.Entity
{
    public class Recipe
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Operation> Operations { get; private set; } = new ObservableCollection<Operation>();
    }
}
