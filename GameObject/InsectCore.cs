using AntMe_2_Lib.Definitions;

namespace AntMe_2_Lib.GameObject
{
    public class InsectCore : GameobjectCore
    {
        #region Attributes
        internal CasteAttribute Caste = new CasteAttribute();
        internal PlayerAttribute Player = new PlayerAttribute();

        int attackDefault = 5;
        public int Attack
        {
            get { return attackDefault + Caste.AttackModifier; }
        }

        int energyDefault = 100;
        public int Energy
        { 
            get { return energyDefault + (Caste.EnergyModifier * 2); }
        }

        int loadDefault = 10;
        public int Load
        {
            get { return loadDefault + Caste.LoadModifier; }
        }

        int rangeDefautl = 200;
        public int Range
        {
            get { return rangeDefautl + (Caste.RangeModifier * 50); }
        }

        int rotationSpeedDefault = 25;
        public int RotationSpeed
        {
            get { return rotationSpeedDefault + (Caste.RotationSpeedModifier * 5); }
        }

        int speedDefault = 1000;
        public int Speed
        {
            get { return speedDefault + (Caste.SpeedModifier * 500);  }
        }

        int viewRangeDefault = 5;
        public int ViewRange
        {
            get { return viewRangeDefault + (Caste.ViewRangeModifier); }
        }
        #endregion

        public enum InsectStateEnum { WAITING, ROTATE, MOVING, FIGHTING, DEATH };
        public InsectStateEnum State = InsectStateEnum.WAITING;

        internal object Target = null;
        internal GameobjectCore Carrying = null;
        internal InsectCore FightTarget = null;
        internal float RotateAngle = 0;

        internal override void InitBase()
        {
            base.InitBase();
        }

        internal virtual string CasteSelectBase() { return string.Empty; }

        internal virtual void WaitingBase() { }

        internal virtual void TickBase() { }

        public void MoveForward()
        {
            State = InsectStateEnum.MOVING;
        }

        public override string ToString()
        {
            return string.Format("{0}/{1} ({2}) ", Player.ColonyName, Caste.Name, Guid.ToString());
        }
    }
}
