using RatchetMemoryApi.Memory.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatchetMemoryApi.Events
{
    public class WeaponUpdatedArgs : EventArgs
    {
        public int Ammo { get; set; }
        public WeaponMap WeaponId { get; set; }
        public bool IsEnabled { get; set; }
    }
}
