using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Battlelogium.Core;

namespace Battlelogium.UI
{
    public class Battlefield3 : Battlelog
    {
        public Battlefield3(Window battlelogiumWindow)
            : base("http://battlelog.battlefield.com/bf3/", "Battlefield 3", "BF3", "bf3.exe", "70619", "http://localhost/battlelogium/battlelog.bf3.inject.js", battlelogiumWindow)
        {
        }
    }
}
