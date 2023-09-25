using AntMe_2_Lib.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AntMe_2_Lib.GameObject
{
    public abstract class AntCore: InsectCore
    {

        public AntCore() {  }


        internal override void InitBase () { Init(); }
        public virtual void Init() { }

        internal override string CasteSelectBase() { return CasteSelect(); }
        public virtual string CasteSelect() { return string.Empty; }

        internal override void WaitingBase() { Waiting(); }
        public virtual void Waiting() { }

        internal override void TickBase() { Tick();  }
        public virtual void Tick() { }
    }
}
