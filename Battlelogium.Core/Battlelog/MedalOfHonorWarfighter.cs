using Battlelogium.Core;
using Battlelogium.Core.UI;
namespace Battlelogium.Core.Battlelog
{
    public class MedalOfHonorWarfighter : BattlelogBase
    {
#if DEBUG
        //static string jsUrl = "http://ron975.github.io/Battlelogium/Battlelogium.Core/Javascript/battlelog.mohw.inject.js";

        static string jsUrl = "http://localhost/battlelogium/battlelog.mohw.inject.js";
#else
        static string jsUrl = "http://ron975.github.io/Battlelogium/Battlelogium.Core/Javascript/battlelog.mohw.inject.js";
#endif
        public MedalOfHonorWarfighter()
            : base("http://battlelog.battlefield.com/mohw/", "Medal of Honor Warfighter", "MOHW", new string[1] { "mohw.exe" }, 70619, jsUrl)
        {
        }
    }
}
