using AntMe_2_Lib.Definitions;
using AntMe_2_Lib.GameObject;
using System.Numerics;
using System.Reflection;

namespace AntMe_2_Lib.Simulator
{
    public class AntSimulator : AntCore
    {
        public event EventHandler<string?> ShowSimDebugInfoEvent;

        public Type AntType;
        public dynamic AntObject;

        public PlayerAttribute SimPlayer
        {
            get { return Player; }
            set { Player = value; }
        }

        public CasteAttribute SimCaste
        {
            get { return Caste; }
            set { Caste = value; }
        }


        public AntSimulator(Type type)
        {
            //reading the Type
            AntObject = Activator.CreateInstance(type, true);
            AntType = type;

            ReadAttributes();

            EventInfo ei = AntType.GetEvent("ShowDebugInfoEvent");
            //PrintDebug(ei.Name);

            MethodInfo mis = this.GetType().GetMethod("AntObjectDebugEvent");
            //PrintDebug(mis.Name);
            Delegate handler = Delegate.CreateDelegate(ei.EventHandlerType, this, mis);
            ei.AddEventHandler(AntObject, handler);
        }

        private void ReadAttributes()
        {
            object[] atts = AntType.GetCustomAttributes(true);

            Dictionary<string, CasteAttribute> casteList = new Dictionary<string, CasteAttribute>();

            foreach (Attribute att in atts) 
            {
                switch(att.GetType().Name) 
                {
                    case "PlayerAttribute":
                        dynamic playerAttribute = att as dynamic;
                        SimPlayer.ColonyName = playerAttribute.ColonyName;
                        SimPlayer.FirstName = playerAttribute.FirstName;
                        SimPlayer.LastName = playerAttribute.LastName;
                        break;
                    case "CasteAttribute":
                        dynamic casteAttribute = att as dynamic;
                        CasteAttribute caste = new CasteAttribute()
                        {
                            AttackModifier = casteAttribute.AttackModifier,
                            EnergyModifier = casteAttribute.EnergyModifier,
                            LoadModifier = casteAttribute.LoadModifier,
                            Name = casteAttribute.Name,
                            RangeModifier = casteAttribute.RangeModifier,
                            RotationSpeedModifier = casteAttribute.RotationSpeedModifier,
                            SpeedModifier = casteAttribute.SpeedModifier,
                            ViewRangeModifier = casteAttribute.ViewRangeModifier
                        };

                        casteList.Add(caste.Name, caste);
                        break;
                }
            }

            string casteName = CasteSelect();
            if(casteList.ContainsKey(casteName))
                SimCaste = casteList[casteName];
            else if (casteList.Count > 0)
                    SimCaste = casteList.Values.First();   
        }

        public void AntObjectDebugEvent(object sender, string e)
        {
            ShowSimDebugInfoEvent?.Invoke(this, e);
        }

        public override string CasteSelect()
        {
            return (string)AntObject.CasteSelect();
        }

        public override void Init()
        {
            AntObject.Init();
        }

        public override void Waiting()
        {
            AntObject.Waiting();
        }

        public override void Tick()
        {
            AntObject.Tick();
        }
    }
}
