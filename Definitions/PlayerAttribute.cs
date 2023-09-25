namespace AntMe_2_Lib.Definitions
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class PlayerAttribute : Attribute
    {
        /// <summary>
        /// First name of the player
        /// </summary>
        public string FirstName = string.Empty;

        /// <summary>
        /// Name of the colony
        /// </summary>
        public string ColonyName = string.Empty;

        /// <summary>
        /// Last name of the player
        /// </summary>
        public string LastName = string.Empty;
    }
}
