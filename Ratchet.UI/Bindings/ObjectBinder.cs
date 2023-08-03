using RatchetMemoryApi;
using RatchetMemoryApi.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.UI.Bindings
{
    internal class ObjectBinder
    {
        public Destructible Destructible { get; set; }
        private bool v = false;
        public string Address => Destructible.MyAddress.ToString("X");
        public ushort ModelId
        {
            get
            {
                return Destructible.GetModelId();
            }
            set
            {
                Destructible.SetModelId(value);
            }
        }

        public byte Opacity
        {
            get
            {
                return Destructible.GetOpacity();
            }
            set
            {
                Destructible.SetOpacity(value);
            }
        }

        public bool TeleportToMe 
        { 
            get
            {
                return v;
            }
            set
            {
                Teleport();
                v = value;
            }
        }

        private void Teleport()
        {
            var pos = new Position();
            var x = pos.X;
            var y = pos.Y;
            var z = pos.Z;
            Destructible.MoveTo(x,y,z);
            Destructible.SetVisible(true);
        }
    }
}
