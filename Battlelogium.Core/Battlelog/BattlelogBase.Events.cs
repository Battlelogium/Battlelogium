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
            ProcessStartWaiter waiter = new ProcessStartWaiter(this.executableName.Replace(".exe", ""));
            waiter.ProcessStart += (s, e) => this.GameStart(this, new BFGameEventArgs(this, e.Process));
            waiter.ProcessStart += (s, e) => this.WaitForGameQuitAsync(e.Process);
            waiter.ListenAsync();
        }

        private async Task WaitForGameQuitAsync(Process gameProcess)
        {
            await Task.Run(() => gameProcess.WaitForExit());
            this.GameQuit(this, new BFGameEventArgs(this, gameProcess));
        }
    }
}
