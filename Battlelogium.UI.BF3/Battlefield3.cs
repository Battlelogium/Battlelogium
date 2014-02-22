using Battlelogium.Core;
using Battlelogium.Core.UI;

namespace Battlelogium.UI
{
    public class Battlefield3 : Battlelog
    {
        public Battlefield3(UIWindow battlelogiumWindow)
            : base("http://battlelog.battlefield.com/bf3/", "Battlefield 3", "BF3", "bf3.exe", "70619", "http://localhost/battlelogium/battlelog.bf3.inject.min.js", battlelogiumWindow)
        {
        }
    }
}
