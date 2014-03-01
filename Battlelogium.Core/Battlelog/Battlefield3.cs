using Battlelogium.Core;
using Battlelogium.Core.UI;
namespace Battlelogium.Core.Battlelog
{
    public class Battlefield3 : BattlelogBase
    {
#if DEBUG
        //static string jsUrl = "http://ron975.github.io/Battlelogium/Battlelogium.Core/Javascript/battlelog.bf3.inject.js";

        static string jsUrl = "http://localhost/battlelogium/battlelog.bf3.inject.js";
#else
        static string jsUrl = "http://ron975.github.io/Battlelogium/Battlelogium.Core/Javascript/battlelog.bf3.inject.js";
#endif
        public Battlefield3()
            : base("http://battlelog.battlefield.com/bf3/", "Battlefield 3", "BF3", "bf3.exe", 70619, jsUrl)
        {
        }
    }
}
