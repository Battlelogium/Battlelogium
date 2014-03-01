using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Battlelogium.Core.Battlelog
{
    public class BFGameEventArgs
    {
        int processID;
        public BFGameEventArgs(int processID)
        {
            this.processID = processID;
        }
    }
}
