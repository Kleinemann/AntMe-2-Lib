using AntMe_2_Lib.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AntMe_2_Lib.Simulator
{
    public static class ColonyManager
    {
        public static Dictionary<Guid, PlayerColony> Colonys = new Dictionary<Guid, PlayerColony>();

        public static void LoadingUserAntsByDll()
        {
            Colonys.Clear();

            foreach (string path in GameSettings.AntImportPath)
            {
                if (!File.Exists(path))
                    continue;

                Assembly assembly = Assembly.LoadFrom(path);

                if (assembly != null)
                {
                    Type[] types = assembly.GetTypes();

                    foreach (Type type in types)
                    {
                        if (type.ToString().Contains("AntMe_2_Ants"))
                        {
                            if (type.GetMethod("Waiting") == null
                                || type.GetMethod("Init") == null)
                                continue;

                            //AntSimulatorList.Add(CreateAntSimulatorWidthDebugInfo(type));
                            PlayerColony colony = new PlayerColony();
                            colony.Player = new PlayerAttribute() { ColonyName = "BLUB", FirstName = "JAHDJK" };
                            colony.AntType = type;
                            colony.Ants = new Dictionary<Guid, AntSimulator>();

                            Colonys.Add(colony.Guid, colony);
                        }
                    }
                }
            }
        }

        public static AntSimulator AntBorn(PlayerColony colony, object eventTargetObject)
        {
            if (colony.Ants.Count >= GameSettings.MaxAnts)
                return null;

            AntSimulator sim = new AntSimulator(colony);
            colony.Ants.Add(sim.Guid, sim);

            return sim;
        }
    }
}
