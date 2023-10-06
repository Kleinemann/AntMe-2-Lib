using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace AntMe_2_Lib.Simulator
{
    public static class GameSettings
    {
        public static ulong GameSeed = 0;

        public static List<string> AntImportPath = new List<string>()
        {
            @"G:\Workspace\AntMe!2_Ants\bin\Debug\net6.0\AntMe!2_Ants.dll",
            @"C:\Workbench\AntMe!2-Ants\bin\Debug\net6.0\AntMe!2_Ants.dll"
        };

        public static int Rounds = 1000;
        public static float RoundSpeed = 3f;

        public static int MaxAnts = 100;
    }
}
