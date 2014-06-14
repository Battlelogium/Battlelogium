using Battlelogium.Core;
using Battlelogium.Core.UI;
namespace Battlelogium.Core.Battlelog
{
    public class BattlefieldHardline : BattlelogBase
    {
#if DEBUG
        //static string jsUrl = "http://ron975.github.io/Battlelogium/Battlelogium.Core/Javascript/battlelog.bfh.inject.js";

        static string jsUrl = "http://localhost/battlelogium/battlelog.bfh.inject.min.js";
#else
        static string jsUrl = "http://ron975.github.io/Battlelogium/Battlelogium.Core/Javascript/battlelog.bfh.inject.min.js";
#endif
        public BattlefieldHardline()
            : base("http://battlelog.battlefield.com/bfh/", "Battlefield Hardline", "BFH", new string[1] { "bfh.exe" }, 1024944, jsUrl)
        {
        }
    }
}
