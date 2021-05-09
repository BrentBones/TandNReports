using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TandNTestMachine.Data.Entity
{
    public class TagAddress
    {
        public Guid Id { get; set; }
        public int TagType { get; set; }
        public string TagName { get; set; }
        public string PLCAddress { get; set; }
    }
}
