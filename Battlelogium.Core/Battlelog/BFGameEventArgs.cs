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
        BattlelogBase battlelog;
        Process process;
        public BFGameEventArgs(BattlelogBase battlelog, Process process)
        {
            this.battlelog = battlelog;
            this.process = process;

        }
    }
}
