namespace AntMe_2_Lib.Definitions
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class CasteAttribute : Attribute
    {
        public int AttackModifier = 0;

        public int EnergyModifier = 0;

        public int LoadModifier = 0;

        public string Name = "Basic";

        public int RangeModifier = 0;

        public int RotationSpeedModifier = 0;

        public int SpeedModifier = 0;

        public int ViewRangeModifier = 0;       

        public static bool CheckRules(CasteAttribute caste)
        {
            int v = caste.AttackModifier + caste.EnergyModifier + caste.LoadModifier + caste.RangeModifier + caste.RotationSpeedModifier + caste.SpeedModifier + caste.ViewRangeModifier;
            return v <= 0;
        }
    }
}
