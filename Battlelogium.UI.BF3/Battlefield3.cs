using Battlelogium.Core;
using Battlelogium.Core.UI;

namespace Battlelogium.UI
{
    public class Battlefield3 : Battlelog
    {
#if DEBUG
        static string jsUrl = "http://localhost/battlelogium/battlelog.bf4.inject.js";
#else
        static string jsUrl = "http://ron975.github.io/Battlelogium/Battlelogium.Core/Javascript/battlelog.bf4.inject.js";
#endif
        public Battlefield3(UIWindow battlelogiumWindow)
            : base("http://battlelog.battlefield.com/bf3/", "Battlefield 3", "BF3", "bf3.exe", "70619", jsUrl, battlelogiumWindow)
        {
        }
    }
}
