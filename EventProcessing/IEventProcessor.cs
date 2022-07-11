using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationService.EventProcessing
{
    public interface IEventProcessor
    {
        void ProcessEvent(string message);
    }
}