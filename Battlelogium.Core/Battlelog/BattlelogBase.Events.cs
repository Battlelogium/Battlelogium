using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battlelogium.Core.Utilities;
using System.Diagnostics;

namespace Battlelogium.Core.Battlelog
{
    public partial class BattlelogBase
    {
        public delegate void GameStartEventHandler(object sender, BFGameEventArgs args);
        public event GameStartEventHandler GameStart;
        public delegate void GameQuitEventHandler(object sender, BFGameEventArgs args);
        public event GameQuitEventHandler GameQuit;

        public bool IsGameRunning()
        {
            return ProcessTools.IsProcessRunning(this.executableName);
        }
        public void InitListenGame()
        {
            ProcessStartWaiter waiter = new ProcessStartWaiter(this.executableName);
           waiter.ProcessStart += (s, e) =>
           {
               if (this.GameStart != null)  
                this.GameStart(this, new BFGameEventArgs(e.ProcessID));
           };
            waiter.ProcessStart += (s, e) => this.WaitForGameQuitAsync(Process.GetProcessById(e.ProcessID));
            waiter.ListenAsync();
        }

        private async Task WaitForGameQuitAsync(Process gameProcess)
        {
            await Task.Run(() => gameProcess.WaitForExit());
            if (this.GameQuit != null)  
            this.GameQuit(this, new BFGameEventArgs(gameProcess.Id));
        }
    }
}
