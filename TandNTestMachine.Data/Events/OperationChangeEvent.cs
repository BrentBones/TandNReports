using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TandNTestMachine.Data.Events
{
    public class OperationChangeEvent : PubSubEvent<OperationChangeEventPayload>
    {
    }
}
