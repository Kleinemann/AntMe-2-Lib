using System.Numerics;
using AntMe_2_Lib.Definitions;

namespace AntMe_2_Lib.GameObject
{
    public class GameobjectCore
    {
        public event EventHandler<string?> ShowDebugInfoEvent;

        public Guid Guid { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }

        internal GameobjectCore()
        {
            Guid = Guid.NewGuid();
            Position = new Vector3();
            Rotation = new Vector3();
        }

        internal virtual void InitBase() {  }

        public void ShowDebugInfo()
        {
            ShowDebugInfo(null);
        }

        public void ShowDebugInfo(string? infoString)
        {
            ShowDebugInfoEvent?.Invoke(this, infoString);
        }

        public override string ToString()
        {
            return string.Format("{0} ({1}) ", this.GetType().ToString(), Guid.ToString());
        }
    }
}