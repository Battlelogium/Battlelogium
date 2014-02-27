using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows;

namespace Battlelogium.ExecUtils
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (args == null)
            {
                return;
            }
            switch (args[0])
            {
                case "clearcache":
                    var cachepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cache");
                    int id = int.Parse(args[1]);
                    try
                    {
                        Process.GetProcessById(id).WaitForExit();
                    }
                    catch (Exception) { }
                    try
                    {
                        Directory.Delete(cachepath, true);
                    }
                    catch (Exception) { }
                    break;
            }
            return;
        }
    }
}
