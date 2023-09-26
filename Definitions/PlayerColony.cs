using AntMe_2_Lib.Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AntMe_2_Lib.Definitions
{
    public class PlayerColony
    {
        public Guid Guid = Guid.NewGuid();
        public Vector3 StartPosition { get; set; }
        public PlayerAttribute Player;
        public Type AntType;
        public Dictionary<Guid, AntSimulator> Ants = new Dictionary<Guid, AntSimulator>();


        public void DoTicks()
        {
            foreach (AntSimulator sim in Ants.Values)
            {
                sim.Tick();
            }
        }
    }
}
