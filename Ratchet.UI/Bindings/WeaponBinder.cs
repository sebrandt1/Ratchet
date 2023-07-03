using RatchetMemoryApi.Memory;
using RatchetMemoryApi.Memory.Addresses;
using RatchetMemoryApi.Memory.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.UI.Bindings
{
    [DataContract]
    internal class WeaponBinder
    {
        [DataMember]
        public string SlotName 
        {
            get => Weapon.GetType().Name; 
        }

        [DataMember]
        public bool Enabled 
        { 
            get => Weapon.IsEnabled(); 
            set => Weapon.SetEnabled(value); 
        }

        [DataMember]
        public int Ammo 
        { 
            get => Weapon.GetAmmo(); 
            set => Weapon.SetAmmo(value); 
        }

        [DataMember]
        public WeaponMap GunID 
        { 
            get => Weapon.GetWeaponInMySlot(); 
            set => Weapon.SetWeapon(value); 
        }

        public WeaponBase Weapon { get; set; }

    }
}
